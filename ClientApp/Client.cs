using ServerApp;
using System.Net.Sockets;

namespace ClientApp
{
    internal partial class Client
    {
        private NetworkStream _serverStream;
        private TcpClient _server;
        private bool _activeConnection;

        public void ConnectToServer(int port, string ip = "127.0.0.1")
        {
            _server = new TcpClient(ip, port);
            _serverStream = _server.GetStream();
            _activeConnection = true;
        }

        public void DisconnectFromServer()
        {
            if (!_activeConnection)
                return;

            _activeConnection = false;

            Utilities.SendBytes(Utilities.ClientStates.DisconectFromServer, _serverStream);
            _serverStream.Close();
            _server.Close();
        }
    }
}