using System;
using System.IO.Compression;
using System.IO;

namespace DarkSeng.Compression
{
    public class GZip
    {
        /// <summary>
        /// Compresses the file with the GZip algorithm
        /// </summary>
        /// <param name="sourcePath">Path to the file which will be compressed</param>
        /// <param name="destinationPath">Path to the directory where the compressed file will be copied to</param>
        public static void Compress(string sourcePath, string destinationPath)
        {
            try
            {
                FileInfo fileToCompress = new FileInfo(sourcePath);

                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) &
                        FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(destinationPath + "\\" + fileToCompress.Name + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                                CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);

                            }
                        }

                        FileInfo info = new FileInfo(destinationPath + "\\" + fileToCompress.Name + ".gz");
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Decompresses the file with the GZip algorithm
        /// </summary>
        /// <param name="sourcePath">Path to the file which will be decompressed</param>
        /// <param name="destinationPath">Path to the directory where the decompressed file will be copied to</param>
        public static void Decompress(string sourcePath, string destinationPath)
        {
            try
            {
                FileInfo fileToDecompress = new FileInfo(sourcePath);

                using (FileStream originalFileStream = fileToDecompress.OpenRead())
                {
                    string currentFileName = fileToDecompress.FullName;

                    using (FileStream decompressedFileStream = File.Create(destinationPath + "\\" + Path.GetFileNameWithoutExtension(currentFileName)))
                    {
                        using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(decompressedFileStream);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
