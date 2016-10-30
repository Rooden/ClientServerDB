using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerApp
{
    internal partial class Server
    {
        private static DataSet GetDataFromDatabase()
        {
            var dataSet = new DataSet();

            try
            {
                _connection.Open();
                var command = new SqlDataAdapter("select * from TestTable", _connection);

                command.FillSchema(dataSet, SchemaType.Source, "TestTable");
                command.Fill(dataSet, "TestTable");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataSet;
        }

        private static byte[] GetBytesFrom(object data)
        {
            var memoryStream = new MemoryStream();
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(memoryStream, data);
            var resultBytes = memoryStream.ToArray();

            memoryStream.Close();
            memoryStream.Dispose();

            return resultBytes;
        }

        private static List<string> GetAllTablesName()
        {
            var result = new List<string>();
            var command = new SqlCommand(@"SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_TYPE LIKE '%TABLE%'", _connection);
            using (var reader = command.ExecuteReader())
            {
                if (!reader.HasRows)
                    return result;

                while (reader.Read())
                {
                    var item = reader.GetString(reader.GetOrdinal("TABLE_NAME"));
                    result.Add(item);
                }
            }

            return result;
        }
    }
}