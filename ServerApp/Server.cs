using System;
using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
    internal partial class Server
    {
        private TcpListener _server;
        private TcpClient _client;

        public void StartServer(int port, string ip = "127.0.0.1")
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
                using (_client = _server.AcceptTcpClient())
                {
                    Console.WriteLine("Client was found!");
                    var clientStream = _client.GetStream();
                    var dataSet = GetDataFromDatabase();

                    if (dataSet == null)
                        continue;

                    Console.WriteLine("Sending bytes.");
                    var resultBytes = GetBytesFromDataSet(dataSet);
                    clientStream.Write(resultBytes, 0, resultBytes.Length);
                    Console.WriteLine("Finish.");
                }
            }
        }

        ~Server()
        {
            _server.Stop();
        }
    }
}