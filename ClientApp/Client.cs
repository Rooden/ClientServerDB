using ServerApp;
using System.Net.Sockets;

namespace ClientApp
{
    internal partial class Client
    {
        private NetworkStream _serverStream;
        private TcpClient _server;

        public void ConnectToServer(int port, string ip = "127.0.0.1")
        {
            _server = new TcpClient(ip, port);
            _serverStream = _server.GetStream();
        }

        public void DisconnectFromServer()
        {
            Utilities.SendBytes(Utilities.ClientStates.DisconectFromServer, _serverStream);
        }

        ~Client()
        {
            DisconnectFromServer();
            _serverStream.Close();
            _server.Close();
        }
    }
}