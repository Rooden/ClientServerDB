using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ServerApp
{
    internal partial class Server
    {
        private static DataSet GetDataFromTable(string tableName = "TestTable")
        {
            var dataSet = new DataSet();

            try
            {
                var command = new SqlDataAdapter($@"select * from {tableName}", _connection);

                command.FillSchema(dataSet, SchemaType.Source, tableName);
                command.Fill(dataSet, tableName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Debug Mode\n" + ex.Message);
            }

            return dataSet;
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