using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace DarkSeng.Serialization
{
    /// <summary>
    /// Serializes and deserializes an object in binary format.
    /// </summary>
    public class BinarySerializer
    {
        private static BinaryFormatter _formatter = new BinaryFormatter();

        /// <summary>
        /// Serializes the object to the given path.
        /// </summary>
        /// <typeparam name=T>Type</typeparam>
        /// <param name=obj>The object which will be serialized.</param>
        /// <param name=path>The file path to which the object is to be serialized.</param>
        public static void Serialize<T>(T obj, string path)
        {
            try
            {
                if (obj.GetType().IsSerializable)
                {
                    using (Stream stream = System.IO.File.Open(path, FileMode.Create))
                    {
                        _formatter.Serialize(stream, obj);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Deserializes the file from the given path to an object.
        /// </summary>
        /// <typeparam name=T>Type</typeparam>
        /// <param name=path>The path to the file which is to be deserialized</param>
        /// <returns></returns>
        public static T Deserialize<T>(string path)
        {
            try
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    return (T)_formatter.Deserialize(stream);
                }
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Serializes the object to the given path in a compressed format.
        /// </summary>
        /// <typeparam name=T>Type</typeparam>
        /// <param name=obj>The object which will be serialized.</param>
        /// <param name=path>The file path to which the object is to be serialized.</param>
        public static void SerializeCompressed<T>(T obj, string path)
        {
            try
            {
                if (obj.GetType().IsSerializable)
                {
                    using (Stream stream = System.IO.File.Open(path, FileMode.Create))
                    using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Compress))
                    {
                        _formatter.Serialize(deflateStream, obj);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Deserializes the compressed file from the given path to an object.
        /// </summary>
        /// <typeparam name=T>Type</typeparam>
        /// <param name=path>The path to the file which is to be deserialized</param>
        /// <returns></returns>
        public static T DeserializeCompressed<T>(string path)
        {
            try
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress))
                {
                    return (T)_formatter.Deserialize(deflateStream);
                }
            }
            catch
            {
                return default(T);
            }
        }
    }
}