using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerApp.Utilities
{
    public class TransferUtilities
    {
        private static readonly BinaryFormatter BinaryFormatter = new BinaryFormatter();

        public enum ClientStates
        {
            ConnectionToServer,
            SelectTable,
            Query,
            Edit,
            DisconectFromServer
        }

        public static byte[] GetBytesFrom<T>(T data)
        {
            var memoryStream = new MemoryStream();

            BinaryFormatter.Serialize(memoryStream, data);
            var resultBytes = memoryStream.ToArray();

            memoryStream.Close();
            memoryStream.Dispose();

            return resultBytes;
        }

        public static void SendBytes<T>(T data, NetworkStream stream)
        {
            var resultBytes = GetBytesFrom(data);
            stream.Write(resultBytes, 0, resultBytes.Length);
        }

        public static void RecieveBytes<T>(out T resultData, NetworkStream stream)
        {
            resultData = (T)BinaryFormatter.Deserialize(stream);
        }
    }
}