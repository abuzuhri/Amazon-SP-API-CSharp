using System;
using System.IO;

namespace FikaAmazonAPI.Utils
{
    public static class PathValidator
    {
        public static void EnsureSafePath(string path, string paramName = "path")
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path cannot be null or empty.", paramName);

            if (path.IndexOf('\0') >= 0)
                throw new ArgumentException("Path contains null characters.", paramName);

            var segments = path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            foreach (var segment in segments)
            {
                if (segment == "..")
                    throw new ArgumentException("Path contains directory traversal sequences.", paramName);
            }

            var fullPath = Path.GetFullPath(path);
            var canonicalSegments = fullPath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            foreach (var segment in canonicalSegments)
            {
                if (segment == "..")
                    throw new ArgumentException("Path resolves to a directory traversal.", paramName);
            }
        }
    }
}
