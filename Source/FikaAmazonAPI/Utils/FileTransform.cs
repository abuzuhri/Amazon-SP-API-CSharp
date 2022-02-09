using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;

namespace FikaAmazonAPI.Utils
{
    public class FileTransform
    {
        public static string DecryptString(byte[] key, byte[] iv, byte[] cipherText)
        {
            byte[] buffer = cipherText;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }

        }



        public static string Decompress(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            using (FileStream originalFileStream = fileInfo.OpenRead())
            {
                string currentFileName = fileInfo.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileInfo.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine($"Decompressed: {fileInfo.Name}");
                    }
                    return decompressedFileStream.Name;
                }
            }
        }


    }
}
