using System;
using System.IO;
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

        public static string GetMD5HashFromBytes(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException("bytes");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
