namespace ServerApp
{
    internal class Program
    {
        private static void Main()
        {
            using (var server = new Server())
            {
                server.StartServer(200, "127.0.0.1");
                server.ListenClients();
            }
        }
    }
}