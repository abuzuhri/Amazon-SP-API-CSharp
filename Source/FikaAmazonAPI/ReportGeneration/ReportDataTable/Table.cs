using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FikaAmazonAPI.ReportGeneration.ReportDataTable
{
    public class Table
    {
        internal const string ERROR_NO_CELLS_TO_ADD = "No cells to add";
        internal const string ERROR_NO_HEADER_TO_ADD = "No headers to add";
        internal const string ERROR_COLUMN_NAME_NOT_FOUND = "Could not find a column named '{0}' in the table.";
        internal const string ERROR_CELLS_NOT_MATCHING_HEADERS = "The number of cells ({0}) you are trying to add doesn't match the number of columns ({1})";

        private readonly string[] header;
        private readonly TableRows rows = new TableRows();

        public ICollection<string> Header
        {
            get { return header; }
        }

        public TableRows Rows
        {
            get { return rows; }
        }

        public int RowCount
        {
            get { return rows.Count; }
        }

        public Table(params string[] header)
        {

            if (header == null || header.Length == 0)
            {
                throw new ArgumentException(ERROR_NO_HEADER_TO_ADD, "header");
            }
            for (int colIndex = 0; colIndex < header.Length; colIndex++)
                header[colIndex] = header[colIndex] ?? string.Empty;

            for (int colIndex = 0; colIndex < header.Length; colIndex++)
                header[colIndex] = TheValue(header[colIndex]);

            this.header = header;
        }

        public static Table ConvertFromCSV(string path, char separator = '\t')
        {
            var lines = File.ReadAllLines(path);

            var table = new Table(lines.First().Split(separator));


            lines.Skip(1).ToList().ForEach(a => ConvertFromCSVAddRow(table, a, separator));
            return table;
        }
        private static void ConvertFromCSVAddRow(Table table, string line, char separator)
        {
            table.AddRow(line.Split(separator));
        }
        public bool ContainsColumn(string column)
        {
            return GetHeaderIndex(column, false) >= 0;
        }

        internal int GetHeaderIndex(string column, bool throwIfNotFound = true)
        {
            int index = Array.IndexOf(header, column);
            if (!throwIfNotFound)
                return index;
            if (index < 0)
            {
                var mess = string.Format(
                            ERROR_COLUMN_NAME_NOT_FOUND + "\nThe table looks like this:\n{1}",
                            column,
                            this);
                throw new IndexOutOfRangeException(mess);
            }
            return index;
        }

        public void AddRow(IDictionary<string, string> values)
        {
            string[] cells = new string[header.Length];
            foreach (var value in values)
            {
                int headerIndex = GetHeaderIndex(value.Key);
                cells[headerIndex] = value.Value;
            }

            AddRow(cells);
        }

        public void AddRow(params string[] cells)
        {
            if (cells == null)
                throw new Exception(ERROR_NO_CELLS_TO_ADD);

            if (cells.Length != header.Length)
            {
                var mess =
                    string.Format(
                        ERROR_CELLS_NOT_MATCHING_HEADERS + ".\nThe table looks like this\n{2}",
                        cells.Length,
                        header.Length,
                        this);
                throw new ArgumentException(mess);
            }
            var row = new TableRow(this, cells);
            rows.Add(row);
        }

        public void RenameColumn(string oldColumn, string newColumn)
        {
            int colIndex = GetHeaderIndex(oldColumn);
            header[colIndex] = newColumn;
        }

        public override string ToString()
        {
            return ToString(false, true);
        }

        public string ToString(bool headersOnly = false, bool withNewline = true)
        {
            int[] columnWidths = new int[header.Length];
            for (int colIndex = 0; colIndex < header.Length; colIndex++)
                columnWidths[colIndex] = header[colIndex].Length;

            if (!headersOnly)
            {
                foreach (TableRow row in rows)
                {
                    for (int colIndex = 0; colIndex < header.Length; colIndex++)
                        columnWidths[colIndex] = Math.Max(columnWidths[colIndex], row[colIndex].Length);
                }
            }

            StringBuilder builder = new StringBuilder();
            AddTableRow(builder, header, columnWidths);

            if (!headersOnly)
            {
                foreach (TableRow row in rows)
                    AddTableRow(builder, row.Select(pair => pair.Value), columnWidths);
            }

            if (!withNewline)
            {
                var newlineLength = Environment.NewLine.Length;
                builder.Remove(builder.Length - newlineLength, newlineLength);
            }

            return builder.ToString();
        }

        private void AddTableRow(StringBuilder builder, IEnumerable<string> cells, int[] widths)
        {
            const string margin = " ";
            const string separator = "|";
            int colIndex = 0;

            builder.Append(separator);
            foreach (string cell in cells)
            {
                builder.Append(margin);

                builder.Append(cell);
                builder.Append(' ', widths[colIndex] - cell.Length);

                builder.Append(margin);
                builder.Append(separator);

                colIndex++;
            }

            builder.AppendLine();
        }

        private static string TheValue(string txt)
        {
            return Regex.Replace(txt, "^\"|\"$", "");
        }
    }
}
