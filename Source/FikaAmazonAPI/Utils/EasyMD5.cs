using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FikaAmazonAPI.Utils
{
    public class EasyMD5
    {
        public static string GetMD5HashFromFile(string filepath)
        {
            if (filepath == null)
                throw new ArgumentNullException("filepath");
            if (File.Exists(filepath) == false)
                throw new InvalidOperationException("file '" + filepath + "' doesn't exist");

            FileStream file = new FileStream(filepath, FileMode.Open);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(file);
            file.Close();

            return GetMD5HashFromBytes(bytes);
        }

        private static string GetMD5HashFromBytes(byte[] bytes)
        {

            using var md5 = MD5.Create();
            var hash = md5.ComputeHash(bytes);
            var hashString = new StringBuilder();
            foreach (var t in hash)
            {
                hashString.Append(t.ToString("x2", CultureInfo.InvariantCulture));
            }

            return hashString.ToString();
        }
    }
}
