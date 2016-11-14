using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ServerApp
{
    internal partial class Server
    {
        private static SqlDataAdapter _adapter;

        private static DataSet GetDataFromTable(string tableName = "PERSON")
        {
            var dataSet = new DataSet();

            try
            {
                _adapter = new SqlDataAdapter($@"select * from {tableName}", _connection);

                _adapter.FillSchema(dataSet, SchemaType.Source, tableName);
                _adapter.Fill(dataSet, tableName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Debug Mode\n" + ex.Message);
            }

            return dataSet;
        }

        private static List<string> GetAllTableNames()
        {
            var result = new List<string>();
            var command =
                new SqlCommand(@"SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_TYPE LIKE '%TABLE%'",
                    _connection);
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

        private static void ConnectionToServer()
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

        private static void SelectTable()
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

        private static void ExecuteQuery()
        {
            var dataSet = new DataSet();

            string query;
            Utilities.RecieveBytes(out query, _clientStream);

            try
            {
                var adapter = new SqlDataAdapter(query, _connection);

                adapter.FillSchema(dataSet, SchemaType.Source);
                adapter.Fill(dataSet);
                Utilities.SendBytes(dataSet, _clientStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Debug Mode\n" + ex.Message);
            }
        }

        private static void EditData()
        {
            //Utilities.EditTable editTable;
            Dictionary<string, string> editTable2;
            Utilities.RecieveBytes(out editTable2, _clientStream);

            var tname = editTable2["tableName"];
            var cname = editTable2["columnName"];
            var nvalue = editTable2["newValue"];
            var id = editTable2["ID"];
            var updateQuery = $@"UPDATE {tname} SET {cname} = N'{nvalue}' WHERE {tname}_ID = {id}";
            try
            {
                Console.WriteLine("Start edit.");
                using (var command = new SqlCommand(updateQuery, _connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Update successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! " + ex.Message);
            }
            /*var updateQuery =
                $@"UPDATE {editTable.tableName} SET {editTable.columnName} = N'{editTable.newValue}' WHERE {editTable
                    .tableName}_ID = {editTable.ID}";

            try
            {
                Console.WriteLine("Start edit.");
                var command = new SqlCommand(updateQuery, _connection);
                Console.WriteLine("Update successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! " + ex.Message);
            }*/
        }
    }
}