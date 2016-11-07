using System.Net.Sockets;

namespace ClientApp
{
    internal partial class Client : Form1
    {
        private NetworkStream _serverStream;
        private TcpClient _server;

        public void ConnectToServer(int port, string ip = "127.0.0.1")
        {
            _server = new TcpClient(ip, port);
            _serverStream = _server.GetStream();
        }

        ~Client()
        {
            _serverStream.Close();
            _server.Close();
        }
    }
}