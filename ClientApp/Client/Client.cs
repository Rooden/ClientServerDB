using ServerApp.Utilities;
using System.Net.Sockets;

namespace ClientApp
{
    public partial class Client
    {
        private NetworkStream _serverStream;
        private TcpClient _server;
        private bool _activeConnection;

        public void ConnectToServer(int port, string ip)
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

            TransferUtilities.SendBytes(TransferUtilities.ClientStates.DisconectFromServer, _serverStream);
            _serverStream.Close();
            _server.Close();
        }
    }
}