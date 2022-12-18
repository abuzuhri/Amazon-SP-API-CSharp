using FikaAmazonAPI.ReportGeneration.ReportDataTable;
using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.ReportGeneration
{
    public class LedgerDetailReport
    {
        public List<LedgerDetailReportRow> Data { get; set; } = new List<LedgerDetailReportRow>();
        public LedgerDetailReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var table = Table.ConvertFromCSV(path);

            List<LedgerDetailReportRow> values = new List<LedgerDetailReportRow>();
            foreach (var row in table.Rows)
            {
                values.Add(LedgerDetailReportRow.FromRow(row, refNumber));
            }
            Data = values;
        }
    }
    public class LedgerDetailReportRow
    {
        public DateTime? Date { get; set; }
        public string FNSKU { get; set; }
        public string ASIN { get; set; }
        public string MSKU { get; set; }
        public string Title { get; set; }
        public string EventType { get; set; }
        public string ReferenceID { get; set; }
        public int Quantity { get; set; }
        public string FulfillmentCenter { get; set; }
        public string Disposition { get; set; }
        public string Reason { get; set; }
        public string Country { get; set; }
        public int? ReconciledQuantity { get; set; }
        public int? UnreconciledQuantity { get; set; }
        public string refNumber { get; set; }


        public static LedgerDetailReportRow FromRow(TableRow rowData, string refNumber)
        {
            var row = new LedgerDetailReportRow();
            row.Date = DataConverter.GetDate(rowData.GetString("Date"), DataConverter.DateTimeFormat.DATE_LEDGER_FORMAT);
            row.FNSKU = rowData.GetString("FNSKU");
            row.ASIN = rowData.GetString("ASIN");
            row.MSKU = rowData.GetString("MSKU");
            row.Title = rowData.GetString("Title");
            row.EventType = rowData.GetString("Event Type");
            row.ReferenceID = rowData.GetString("Reference ID");
            row.Quantity = rowData.GetInt32("Quantity");
            row.FulfillmentCenter = rowData.GetString("Fulfillment Center");
            row.Disposition = rowData.GetString("Disposition");
            row.Reason = rowData.GetString("Reason");
            row.Country = rowData.GetString("Country");
            row.ReconciledQuantity = rowData.GetInt32Nullable("Reconciled Quantity");
            row.UnreconciledQuantity = rowData.GetInt32Nullable("Unreconciled Quantity");
            row.refNumber = refNumber;

            return row;
        }
    }
}
