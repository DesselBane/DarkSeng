using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DarkSeng.Files
{
    public static class Extensions
    {
        /// <summary>
        /// Returns all file paths from a given directory with given file extensions
        /// </summary>
        /// <param name="dir">Directory to search in</param>
        /// <param name="extensions">File extensions e.g. ".txt"</param>
        /// <returns></returns>
        public static IEnumerable<string> GetFilePathsByExtensions(this DirectoryInfo dir, params string[] extensions)
        {
            foreach (var file in dir.GetFiles())
                if (extensions.Contains(file.Extension))
                    yield return file.FullName;
        }

        /// <summary>
        /// Returns all file paths from a given directory with given file extensions. Searches also recursivly in sub directories.
        /// </summary>
        /// <param name="dir">Directory to search in</param>
        /// <param name="extensions">File extensions e.g. ".txt"</param>
        /// <returns></returns>
        public static IEnumerable<string> GetAllFilePathsByExtensions(this DirectoryInfo dir, params string[] extensions)
        {
            foreach (var file in dir.GetFiles())
                if (extensions.Contains(file.Extension))
                    yield return file.FullName;

            foreach (var directory in dir.GetDirectories())
                foreach (var path in directory.GetAllFilePathsByExtensions(extensions))
                    yield return path;
        }
    }
}
