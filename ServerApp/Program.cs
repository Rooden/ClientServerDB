namespace ServerApp
{
    internal class Program
    {
        private static void Main()
        {
            var server = new Server();
            server.StartServer(200);
            server.ListenClients();
        }
    }
}