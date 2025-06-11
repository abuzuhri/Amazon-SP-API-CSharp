using System;
using System.IO;
using System.Linq;
using System.Text;

namespace FikaAmazonAPI.Utils
{
    public class EncodingDetector
    {
        private static readonly Encoding[] CommonEncodings = {
            Encoding.UTF8, Encoding.Unicode, Encoding.BigEndianUnicode,
            Encoding.UTF32, Encoding.ASCII, Encoding.GetEncoding("ISO-8859-1")
        };

        public static Encoding DetectEncoding(string filePath, int sampleSize = 4096)
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            return DetectEncoding(buffer, sampleSize);
        }

        public static Encoding DetectEncoding(byte[] buffer, int sampleSize = 4096)
        {
            if (buffer == null || buffer.Length == 0)
                throw new ArgumentException("Buffer is empty");

            // Schritt 1: Prüfe auf BOM
            Encoding bomEncoding = CheckBOM(buffer);
            if (bomEncoding != null)
                return bomEncoding;

            // Schritt 2: Prüfe auf UTF-8
            if (IsUTF8(buffer))
                return Encoding.UTF8;

            // Schritt 3: Prüfe auf bekannte Encodings durch Heuristik
            return HeuristicDetection(buffer);
        }

        private static Encoding CheckBOM(byte[] buffer)
        {
            if (buffer.Length >= 3 && buffer[0] == 0xEF && buffer[1] == 0xBB && buffer[2] == 0xBF)
                return Encoding.UTF8; // UTF-8 mit BOM

            if (buffer.Length >= 2 && buffer[0] == 0xFF && buffer[1] == 0xFE)
                return Encoding.Unicode; // UTF-16 LE

            if (buffer.Length >= 2 && buffer[0] == 0xFE && buffer[1] == 0xFF)
                return Encoding.BigEndianUnicode; // UTF-16 BE

            if (buffer.Length >= 4 && buffer[0] == 0x00 && buffer[1] == 0x00 && buffer[2] == 0xFE && buffer[3] == 0xFF)
                return Encoding.UTF32; // UTF-32 BE

            if (buffer.Length >= 4 && buffer[0] == 0xFF && buffer[1] == 0xFE && buffer[2] == 0x00 && buffer[3] == 0x00)
                return Encoding.UTF32; // UTF-32 LE

            return null;
        }

        private static bool IsUTF8(byte[] buffer)
        {
            int i = 0;
            while (i < buffer.Length)
            {
                if (buffer[i] <= 0x7F)
                {
                    i++;
                    continue;
                }

                if (buffer[i] >= 0xC2 && buffer[i] <= 0xDF)
                {
                    if (i + 1 < buffer.Length && (buffer[i + 1] & 0xC0) == 0x80)
                    {
                        i += 2;
                        continue;
                    }
                }
                else if (buffer[i] >= 0xE0 && buffer[i] <= 0xEF)
                {
                    if (i + 2 < buffer.Length && (buffer[i + 1] & 0xC0) == 0x80 && (buffer[i + 2] & 0xC0) == 0x80)
                    {
                        i += 3;
                        continue;
                    }
                }
                else if (buffer[i] >= 0xF0 && buffer[i] <= 0xF4)
                {
                    if (i + 3 < buffer.Length && (buffer[i + 1] & 0xC0) == 0x80 && (buffer[i + 2] & 0xC0) == 0x80 && (buffer[i + 3] & 0xC0) == 0x80)
                    {
                        i += 4;
                        continue;
                    }
                }

                return false;
            }
            return true;
        }

        private static Encoding HeuristicDetection(byte[] buffer)
        {
            int asciiCount = buffer.Count(b => b <= 127);
            int extendedCount = buffer.Length - asciiCount;

            if (extendedCount == 0)
                return Encoding.ASCII; // ASCII-Dateien enthalten keine Sonderzeichen

            return Encoding.GetEncoding("ISO-8859-1"); // Latin-1 als Fallback für ANSI
        }
    }
}
