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

                Utilities.ClientStates mode;
                Utilities.RecieveBytes(out mode, _clientStream);

                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (mode)
                {
                    case Utilities.ClientStates.ConnectionToServer:
                        ConnectionToServer();
                        break;

                    case Utilities.ClientStates.SelectTable:
                        SelectTable();
                        break;

                    case Utilities.ClientStates.Edit:
                        break;

                    case Utilities.ClientStates.DisconectFromServer:
                        break;
                }

                _clientStream.Close();
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