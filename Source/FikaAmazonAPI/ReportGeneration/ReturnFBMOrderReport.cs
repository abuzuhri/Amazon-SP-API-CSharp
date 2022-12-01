using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ReturnFBMOrderReport
    {
        public List<ReturnFBMOrderRow> Data { get; set; }=new List<ReturnFBMOrderRow>();
        public ReturnFBMOrderReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;
            List<ReturnFBMOrderRow> values = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => ReturnFBMOrderRow.FromCsv(v, refNumber))
                                           .ToList();
            Data = values;
        }


    }
    public class ReturnFBMOrderRow
    {
        public string OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ReturnRequestDate { get; set; }
        public string ReturnRequestStatus { get; set; }
        public string AmazonRMAID { get; set; }
        public string MerchantRMAID { get; set; }
        public string LabelType { get; set; }
        public string LabelCost { get; set; }
        public string CurrencyCode { get; set; }
        public string ReturnCarrier { get; set; }
        public string TrackingID { get; set; }
        public string LabelToBePaidBy { get; set; }
        public bool AToZClaim { get; set; }
        public bool IsPrime { get; set; }
        public string ASIN { get; set; }
        public string MerchantSKU { get; set; }
        public string ItemName { get; set; }
        public int? ReturnQuantity { get; set; }
        public string ReturnReason { get; set; }

        public bool InPolicy { get; set; }
        public string ReturnType { get; set; }
        public string Resolution { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? ReturnDeliveryDate { get; set; }
        public decimal? OrderAmount { get; set; }
        public int? OrderQuantity { get; set; }
        public string SafeTActionReason { get; set; }
        public string SafeTClaimId { get; set; }
        public string SafeTClaimState { get; set; }
        public string SafeTClaimCreationTime { get; set; }
        public string SafeTClaimReimbursementAmount { get; set; }
        public decimal? RefundedAmount { get; set; }
        public string Category { get; set; }
        public string refNumber { get; set; }

        public static ReturnFBMOrderRow FromCsv(string csvLine, string refNumber)
        {
            string[] values = csvLine.Split('\t');
            ReturnFBMOrderRow row = new ReturnFBMOrderRow();
            row.OrderID = values[0];
            row.OrderDate = DataConverter.GetDate(values[1], DataConverter.DateTimeFormat.DATE_MMM_FORMAT);
            row.ReturnRequestDate = DataConverter.GetDate(values[2], DataConverter.DateTimeFormat.DATE_MMM_FORMAT);
            row.ReturnRequestStatus = values[3];
            row.AmazonRMAID = values[4];
            row.MerchantRMAID = values[5];
            row.LabelType = values[6];
            row.LabelCost = values[7];
            row.CurrencyCode = values[8];
            row.ReturnCarrier = values[9];
            row.TrackingID = values[10];
            row.LabelToBePaidBy = values[11];
            row.AToZClaim = values[12] == "Y";
            row.IsPrime = values[13] == "Y";
            row.ASIN = values[14];
            row.MerchantSKU = values[15];
            row.ItemName = values[16];
            row.ReturnQuantity = DataConverter.GetInt(values[17]);
            row.ReturnReason = values[18];
            row.InPolicy = values[19] == "Y";
            row.ReturnType = values[20];
            row.Resolution = values[21];
            row.InvoiceNumber = values[22];
            row.ReturnDeliveryDate = DataConverter.GetDate(values[23], DataConverter.DateTimeFormat.DATE_MMM_FORMAT);
            row.OrderAmount = DataConverter.GetDecimal(values[24]);
            row.OrderQuantity = DataConverter.GetInt(values[25]);
            row.SafeTActionReason = values[26];
            row.SafeTClaimId = values[27];
            row.SafeTClaimState = values[28];
            row.SafeTClaimCreationTime = values[29];
            row.SafeTClaimReimbursementAmount = values[30];
            row.RefundedAmount = DataConverter.GetDecimal(values[31]);
            row.Category = values[32];

            row.refNumber = refNumber;



            return row;
        }

    }
}
