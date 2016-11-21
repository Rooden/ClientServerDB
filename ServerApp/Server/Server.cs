using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
    internal partial class Server : IDisposable
    {
        private TcpListener _server;
        private TcpClient _client;
        private NetworkStream _clientStream;
        private SqlConnection _connection;

        public void StartServer(int port, string ip)
        {
            var ipAddress = IPAddress.Parse(ip);

            _server = new TcpListener(ipAddress, port);
            _server.Start();

            Console.WriteLine("Server start successful!");

            _connection = new SqlConnection(
                @"Server = localhost;
                    User Id = RDadmin;
                    Password = 1324;
                    Network Library = DBMSSOCN;
                    Initial Catalog = KICT"
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
                Console.WriteLine($"Client was found! IP - {_client.Client.RemoteEndPoint}"); // RemoteEndPoint OR LocalEndPoint
                _clientStream = _client.GetStream();

                TakingRequests();

                _clientStream.Close();
                _client.Close();
            }
        }

        private void TakingRequests()
        {
            while (true)
            {
                Utilities.ClientStates currentMode;
                Utilities.RecieveBytes(out currentMode, _clientStream);

                switch (currentMode)
                {
                    case Utilities.ClientStates.ConnectionToServer:
                        ConnectionToServer();
                        break;

                    case Utilities.ClientStates.SelectTable:
                        SelectTable();
                        break;

                    case Utilities.ClientStates.Query:
                        ExecuteQuery();
                        break;

                    case Utilities.ClientStates.Edit:
                        EditData();
                        break;

                    case Utilities.ClientStates.DisconectFromServer:
                        return;

                    default:
                        Console.WriteLine("What is this invalid state?");
                        break;
                }
            }
        }

        public void Dispose()
        {
            _connection.Close();
            _server.Stop();
        }
    }
}