using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerApp
{
    internal partial class Server
    {
        private TcpListener _server;
        private TcpClient _client;
        private static SqlConnection _connection;

        public void StartServer(int port, string ip = "127.0.0.1")
        {
            var ipAddress = IPAddress.Parse(ip);

            _server = new TcpListener(ipAddress, port);
            _server.Start();

            Console.WriteLine("Server start successful!");

            _connection = new SqlConnection(
                @"Server = localhost; User Id = test; Password = 1324; Network Library = DBMSSOCN; Initial Catalog = Test"
            );

            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Debug Mode\n" + ex.Message + "\n");
            }
        }

        public void ListenClients()
        {
            int i = 1;
            while (true)
            {
                Console.WriteLine("Looking for clients.");
                _client = _server.AcceptTcpClient();
                Console.WriteLine("Client was found!");
                var clientStream = _client.GetStream();

                DataSet dataSet;
                if (i++ != 1)
                {
                    var binaryFormatter = new BinaryFormatter();
                    var tableName = binaryFormatter.Deserialize(clientStream) as string;
                    dataSet = GetDataFromTable(tableName);
                }
                else
                {
                    dataSet = GetDataFromTable();
                }

                if (dataSet == null)
                    continue;

                Console.WriteLine("Sending bytes.");
                var resultBytes = Utilities.GetBytesFrom(dataSet);
                clientStream.Write(resultBytes, 0, resultBytes.Length);
                Console.WriteLine("Finish.");

                var list = GetAllTablesName();

                if (list == null)
                    continue;

                Console.WriteLine("Sending bytes.");
                resultBytes = Utilities.GetBytesFrom(list);
                clientStream.Write(resultBytes, 0, resultBytes.Length);
                Console.WriteLine("Finish.");
                clientStream.Close();
                clientStream.Dispose();
                _client.Close();
            }
        }

        ~Server()
        {
            Server._connection.Close();
            _server.Stop();
        }
    }
}