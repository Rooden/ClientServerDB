using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

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
        }

        public void ListenClients()
        {
            while (true)
            {
                Console.WriteLine("Looking for clients.");
                using (_client = _server.AcceptTcpClient())
                {
                    Console.WriteLine("Client was found!");
                    var clientStream = _client.GetStream();
                    var dataSet = GetDataFromDatabase();

                    if (dataSet == null)
                        continue;

                    Console.WriteLine("Sending bytes.");
                    var resultBytes = GetBytesFrom(dataSet);
                    clientStream.Write(resultBytes, 0, resultBytes.Length);
                    Console.WriteLine("Finish.");

                    var list = GetAllTablesName();

                    if (list == null)
                        continue;

                    Console.WriteLine("Sending bytes.");
                    resultBytes = GetBytesFrom(list);
                    clientStream.Write(resultBytes, 0, resultBytes.Length);
                    Console.WriteLine("Finish.");
                }
            }
        }

        ~Server()
        {
            _connection.Close();
            _server.Stop();
        }
    }
}