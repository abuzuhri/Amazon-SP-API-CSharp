using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ReimbursementsOrderReport
    {
        public List<ReimbursementsOrderRow> Data { get; set; }=new List<ReimbursementsOrderRow>();
        public ReimbursementsOrderReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;
            List<ReimbursementsOrderRow> values = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => ReimbursementsOrderRow.FromCsv(v, refNumber))
                                           .ToList();
            Data = values;
        }


    }
    public class ReimbursementsOrderRow
    {
        public DateTime? ApprovalDate { get; set; }
        public string ReimbursementId { get; set; }
        public string CaseId { get; set; }
        public string AmazonOrderId { get; set; }
        public string Reason { get; set; }
        public string SKU { get; set; }
        public string FNSKU { get; set; }
        public string ASIN { get; set; }
        public string ProductName { get; set; }
        public string Condition { get; set; }
        public string CurrencyUnit { get; set; }
        public decimal? AmountPerUnit { get; set; }
        public decimal? AmountTotal { get; set; }
        public int? QuantityReimbursedCash { get; set; }
        public int? QuantityReimbursedInventory { get; set; }
        public int? QuantityReimbursedTotal { get; set; }
        public string OriginalReimbursementId { get; set; }
        public string OriginalReimbursementType { get; set; }
        public string refNumber { get; set; }


        public static ReimbursementsOrderRow FromCsv(string csvLine, string refNumber)
        {
            string[] values = csvLine.Split('\t');
            var row = new ReimbursementsOrderRow();
            row.ApprovalDate = DataConverter.GetDate(values[0], DataConverter.DateTimeFormat.DATETIME_K_FORMAT);
            row.ReimbursementId = values[1];
            row.CaseId = values[2];
            row.AmazonOrderId = values[3];
            row.Reason = values[4];
            row.SKU = values[5];
            row.FNSKU = values[6];
            row.ASIN = values[7];
            row.ProductName = values[8];
            row.Condition = values[9];
            row.CurrencyUnit = values[10];
            row.AmountPerUnit = DataConverter.GetDecimal(values[11]);
            row.AmountTotal = DataConverter.GetDecimal(values[12]);
            row.QuantityReimbursedCash = DataConverter.GetInt(values[13]);
            row.QuantityReimbursedInventory = DataConverter.GetInt(values[14]);
            row.QuantityReimbursedTotal = DataConverter.GetInt(values[15]);
            row.OriginalReimbursementId = values[16];
            row.OriginalReimbursementType = values[17];
            row.refNumber = refNumber;

            return row;
        }


    }
}
