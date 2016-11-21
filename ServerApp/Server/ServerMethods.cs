using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ServerApp
{
    internal partial class Server
    {
        private DataSet GetDataFromTable(string tableName = "PERSON")
        {
            var dataSet = new DataSet();

            try
            {
                var adapter = new SqlDataAdapter($@"select * from {tableName}", _connection);

                adapter.FillSchema(dataSet, SchemaType.Source, tableName);
                adapter.Fill(dataSet, tableName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Debug Mode\n" + ex.Message + "\n");
            }

            return dataSet;
        }

        private List<string> GetAllTableNames()
        {
            var result = new List<string>();
            var query = @"SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_TYPE LIKE '%TABLE%'";
            using (var command = new SqlCommand(query, _connection))
            {
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
            }

            return result;
        }

        private void ConnectionToServer()
        {
            var dataSet = GetDataFromTable();
            if (dataSet == null)
                return;

            Console.WriteLine("Sending dataSet bytes.");
            Utilities.SendBytes(dataSet, _clientStream);
            Console.WriteLine("Finish.");

            var list = GetAllTableNames();
            if (list == null)
                return;

            Console.WriteLine("Sending list bytes.");
            Utilities.SendBytes(list, _clientStream);
            Console.WriteLine("Finish.");
        }

        private void SelectTable()
        {
            string tableName;
            Utilities.RecieveBytes(out tableName, _clientStream);

            var dataSet = GetDataFromTable(tableName);
            if (dataSet == null)
                return;

            Console.WriteLine("Sending dataSet bytes.");
            Utilities.SendBytes(dataSet, _clientStream);
            Console.WriteLine("Finish.");
        }

        private void ExecuteQuery()
        {
            var dataSet = new DataSet();

            string query;
            Utilities.RecieveBytes(out query, _clientStream);

            try
            {
                var adapter = new SqlDataAdapter(query, _connection);

                Console.WriteLine("Execute Query.");
                adapter.FillSchema(dataSet, SchemaType.Source);
                adapter.Fill(dataSet);
                Console.WriteLine("Executed successfuly!");
                Utilities.SendBytes(dataSet, _clientStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Debug Mode\n" + ex.Message + "\n");
            }
        }

        private void EditData()
        {
            Dictionary<string, string> editTable;
            Utilities.RecieveBytes(out editTable, _clientStream);

            var updateQuery = $@"UPDATE {editTable["tableName"]}
                    SET {editTable["columnName"]} = N'{editTable["newValue"]}'
                    WHERE {editTable["tableName"]}_ID = {editTable["ID"]}";
            try
            {
                Console.WriteLine($"Editing table {editTable["tableName"]}.");
                using (var command = new SqlCommand(updateQuery, _connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Update successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Debug Mode\n" + ex.Message + "\n");
            }
        }
    }
}