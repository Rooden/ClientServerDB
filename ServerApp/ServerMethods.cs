using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerApp
{
    internal partial class Server
    {
        private static DataSet GetDataFromDatabase()
        {
            var connection = new SqlConnection(
                @"Server = localhost; User Id = test; Password = 1324; Network Library = DBMSSOCN; Initial Catalog = Test"
            );
            var dataSet = new DataSet();

            try
            {
                connection.Open();
                var command = new SqlDataAdapter("select * from TestTable", connection);

                command.FillSchema(dataSet, SchemaType.Source, "TestTable");
                command.Fill(dataSet, "TestTable");

                /*
                var tblAuthors = dataSet.Tables["TestTable"];

                foreach (DataRow drCurrent in tblAuthors.Rows)
                {
                    Console.WriteLine($"{drCurrent["TT"]} {drCurrent["Name"]}");
                }
                Console.ReadLine();
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dataSet;
        }

        private static byte[] GetBytesFromDataSet(DataSet dataSet)
        {
            var memoryStream = new MemoryStream();
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(memoryStream, dataSet);
            var resultBytes = memoryStream.ToArray();

            memoryStream.Close();
            memoryStream.Dispose();

            return resultBytes;
        }
    }
}