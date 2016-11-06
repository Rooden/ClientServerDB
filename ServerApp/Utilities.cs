using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerApp
{
    public class Utilities
    {
        public static byte[] GetBytesFrom(object data)
        {
            var memoryStream = new MemoryStream();
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(memoryStream, data);
            var resultBytes = memoryStream.ToArray();

            memoryStream.Close();
            memoryStream.Dispose();

            return resultBytes;
        }
    }
}