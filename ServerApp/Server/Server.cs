using ServerApp.Utilities;
using System;
using System.Data.SqlClient;
using System.Linq;
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
        }

        public void ListenClients()
        {
            while (true)
            {
                Console.WriteLine("Looking for clients.");
                _client = _server.AcceptTcpClient();
                Console.WriteLine($"Client was found! IP - {_client.Client.RemoteEndPoint}"); // RemoteEndPoint OR LocalEndPoint
                _clientStream = _client.GetStream();

                string dbInfo;
                TransferUtilities.RecieveBytes(out dbInfo, _clientStream);

                var connectionToDbInfo = dbInfo.Split('/');
                // [0] = login, [1] = password, [3] = db name
                _connection = new SqlConnection(
                    $@"Server = localhost;
                    User Id = {connectionToDbInfo[0]};
                    Password = {connectionToDbInfo[1]};
                    Network Library = DBMSSOCN;
                    Initial Catalog = {connectionToDbInfo[2]}"
                );

                try
                {
                    _connection.Open();
                    Console.WriteLine("Connected to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Debug Mode\n" + ex.Message + "\n");
                }

                TakingRequests();

                _clientStream.Close();
                _client.Close();
            }
        }

        private void TakingRequests()
        {
            while (true)
            {
                TransferUtilities.ClientStates currentMode;
                TransferUtilities.RecieveBytes(out currentMode, _clientStream);

                switch (currentMode)
                {
                    case TransferUtilities.ClientStates.ConnectionToServer:
                        ConnectionToServer();
                        break;

                    case TransferUtilities.ClientStates.SelectTable:
                        SelectTable();
                        break;

                    case TransferUtilities.ClientStates.Query:
                        ExecuteQuery();
                        break;

                    case TransferUtilities.ClientStates.Edit:
                        EditData();
                        break;

                    case TransferUtilities.ClientStates.DisconectFromServer:
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