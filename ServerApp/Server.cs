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
        private static NetworkStream _clientStream;
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
            while (true)
            {
                Console.WriteLine("Looking for clients.");
                _client = _server.AcceptTcpClient();
                Console.WriteLine("Client was found!");
                _clientStream = _client.GetStream();

                string mode;
                Utilities.RecieveBytes(out mode, _clientStream);

                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (mode)
                {
                    case "ConnectionToServer":
                        ConnectionToServer();
                        break;

                    case "SelectTable":
                        SelectTable();
                        break;

                    case "Edit":
                        break;
                }

                _clientStream.Close();
                _clientStream.Dispose();
                _client.Close();
            }
        }

        ~Server()
        {
            _connection.Close();
            _server.Stop();
        }
    }
}