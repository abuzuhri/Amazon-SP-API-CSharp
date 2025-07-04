using FikaAmazonAPI.ReportGeneration.ReportDataTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FikaAmazonAPI.ReportGeneration
{
    internal static class ReportParser
    {
        internal static List<T> ParseTableRows<T>(Stream stream, Func<TableRow, string, T> map, string refNumber, Encoding encoding = null)
        {
            if (stream == null || stream.Length == 0)
                return new List<T>();

            stream.Position = 0;
            var table = Table.ConvertFromCSV(stream, encoding: encoding);
            var values = new List<T>();
            if (table != null)
            {
                foreach (var row in table.Rows)
                    values.Add(map(row, refNumber));
            }
            return values;
        }

        internal static List<T> ParseTableRows<T>(Stream stream, Func<TableRow, T> map, Encoding encoding = null)
        {
            if (stream == null || stream.Length == 0)
                return new List<T>();

            stream.Position = 0;
            var table = Table.ConvertFromCSV(stream, encoding: encoding);
            var values = new List<T>();
            if (table != null)
            {
                foreach (var row in table.Rows)
                    values.Add(map(row));
            }
            return values;
        }

        internal static List<T> ParseCsvLines<T>(Stream stream, Func<string, string, T> map, string refNumber, Encoding encoding = null)
        {
            if (stream == null || stream.Length == 0)
                return new List<T>();

            stream.Position = 0;
            using var reader = new StreamReader(stream, encoding ?? Encoding.UTF8,
                detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen: true);
            var lines = new List<string>();
            while (!reader.EndOfStream)
                lines.Add(reader.ReadLine());

            return lines.Skip(1)
                        .Select(l => map(l, refNumber))
                        .ToList();
        }
    }
}
