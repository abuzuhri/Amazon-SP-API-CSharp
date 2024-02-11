using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.ReportGeneration
{
    public class SettlementOrderReport
    {
        public List<SettlementOrderRow> Data { get; set; }=new List<SettlementOrderRow>();
        public SettlementOrderReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;
            var values = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => SettlementOrderRow.FromCsv(v, refNumber))
                                           .ToList();
            Data = values;
        }


    }
    public class SettlementOrderRow
    {
        public string SettlementId { get; set; }
        public DateTime? SettlementStartDate { get; set; }
        public DateTime? SettlementEndDate { get; set; }
        public DateTime? DepositDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Currency { get; set; }
        public string TransactionType { get; set; }
        public string OrderId { get; set; }
        public string MerchantOrderId { get; set; }
        public string AdjustmentId { get; set; }
        public string ShipmentId { get; set; }
        public string MarketplaceName { get; set; }
        public string AmountType { get; set; }
        public string AmountDescription { get; set; }
        public decimal? Amount { get; set; }
        public string FulfillmentId { get; set; }
        public DateTime? PostedDate { get; set; }
        public DateTime? PostedDateTime { get; set; }
        public string OrderItemCode { get; set; }
        public string MerchantOrderItemId { get; set; }
        public string MerchantAdjustmentItemId { get; set; }
        public string SKU { get; set; }
        public int? QuantityPurchased { get; set; }
        public string PromotionId { get; set; }
        public string refNumber { get; set; }

        public static SettlementOrderRow FromCsv(string csvLine, string refNumber)
        {
            string[] values = csvLine.Split('\t');
            var row = new SettlementOrderRow();
            row.SettlementId = values[0];
            row.SettlementStartDate = DataConverter.GetDate(values[1], DataConverter.DateTimeFormat.DATETIME_FORMAT_UTC_DOT);
            row.SettlementEndDate = DataConverter.GetDate(values[2], DataConverter.DateTimeFormat.DATETIME_FORMAT_UTC_DOT);
            row.DepositDate = DataConverter.GetDate(values[3], DataConverter.DateTimeFormat.DATETIME_FORMAT_UTC_DOT);
            row.TotalAmount = DataConverter.GetDecimal(values[4]);
            row.Currency = values[5];
            row.TransactionType = values[6];
            row.OrderId = values[7];
            row.MerchantOrderId = values[8];
            row.AdjustmentId = values[9];
            row.ShipmentId = values[10];
            row.MarketplaceName = values[11];
            row.AmountType = values[12];
            row.AmountDescription = values[13];
            row.Amount = DataConverter.GetDecimal(values[14]);
            row.FulfillmentId = values[15];
            row.PostedDate = DataConverter.GetDate(values[16], DataConverter.DateTimeFormat.DATE_FORMAT_DOT);
            row.PostedDateTime = DataConverter.GetDate(values[17], DataConverter.DateTimeFormat.DATETIME_FORMAT_UTC_DOT);
            row.OrderItemCode = values[18];
            row.MerchantOrderItemId = values[19];
            row.MerchantAdjustmentItemId = values[20];
            row.SKU = values[21];
            row.QuantityPurchased = DataConverter.GetInt(values[22]);
            row.PromotionId = values[23];

            row.refNumber = refNumber;


            return row;
        }
    }
}
