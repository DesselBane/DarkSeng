using System.IO.Compression; //needs reference to System.IO.Compression.FileSystem

namespace DarkSeng.Compression
{
    public class Zip
    {
        /// <summary>
        /// Compresses the file with the Zip algorithm
        /// </summary>
        /// <param name="sourcePath">Path to the file which will be compressed</param>
        /// <param name="destinationPath">Path to the directory where the compressed file will be copied to</param>
        public static void Compress(string sourcePath, string destinationPath)
        {
            try
            {
                ZipFile.CreateFromDirectory(sourcePath, destinationPath);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Decompresses the file with the Zip algorithm
        /// </summary>
        /// <param name="sourcePath">Path to the file which will be decompressed</param>
        /// <param name="destinationPath">Path to the directory where the decompressed file will be copied to</param>
        public static void Decompress(string sourcePath, string destinationPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(sourcePath, destinationPath);
            }
            catch
            {
            }
        }
    }
}
