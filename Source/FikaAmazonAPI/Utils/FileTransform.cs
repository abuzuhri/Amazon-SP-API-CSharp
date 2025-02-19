using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Ude;

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

        public static void ConvertFileToUtf8(string filePath)
        {
            string content = File.ReadAllText(filePath, DetectFileEncoding(filePath));
            File.WriteAllText(filePath, content, GetEncodingFromCulture(Thread.CurrentThread.CurrentCulture));
        }
        static Encoding DetectFileEncoding(string filePath)
        {
            using (FileStream fs = File.OpenRead(filePath))
            {
                CharsetDetector detector = new CharsetDetector();
                detector.Feed(fs);
                detector.DataEnd();

                return detector.Charset != null ? Encoding.GetEncoding(detector.Charset) : Encoding.UTF8;
            }
        }

        static Encoding GetEncodingFromCulture(CultureInfo culture)
        {
            string cultureName = culture.Name.ToLower();

            return cultureName switch
            {
                "en-us" => Encoding.GetEncoding("Windows-1252"), // Westeuropa (ANSI)
                "de-de" => Encoding.GetEncoding("Windows-1252"), // Westeuropa (ANSI)
                "fr-fr" => Encoding.GetEncoding("Windows-1252"), // Westeuropa (ANSI)
                "ja-jp" => Encoding.GetEncoding("shift_jis"), // Japanisch
                "zh-cn" => Encoding.GetEncoding("gb2312"), // Vereinfachtes Chinesisch
                "ru-ru" => Encoding.GetEncoding("Windows-1251"), // Kyrillisch
                "ko-kr" => Encoding.GetEncoding("ks_c_5601-1987"), // Koreanisch
                "ar-sa" => Encoding.GetEncoding("Windows-1256"), // Arabisch
                _ => Encoding.UTF8 // Standard als Fallback
            };
        }
    }
}
