using FikaAmazonAPI.AmazonSpApiSDK.Models.Finances;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json.Linq;
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
            row.SettlementId = values.GetElementAtIndexOrDefault(0);
            row.SettlementStartDate = DataConverter.GetDate(values.GetElementAtIndexOrDefault(1), DataConverter.DateTimeFormat.DATETIME_FORMAT_UTC_DOT);
            row.SettlementEndDate = DataConverter.GetDate(values.GetElementAtIndexOrDefault(2), DataConverter.DateTimeFormat.DATETIME_FORMAT_UTC_DOT);
            row.DepositDate = DataConverter.GetDate(values.GetElementAtIndexOrDefault(3), DataConverter.DateTimeFormat.DATETIME_FORMAT_UTC_DOT);
            row.TotalAmount = DataConverter.GetDecimal(values.GetElementAtIndexOrDefault(4));
            row.Currency = values.GetElementAtIndexOrDefault(5);
            row.TransactionType = values.GetElementAtIndexOrDefault(6);
            row.OrderId = values.GetElementAtIndexOrDefault(7);
            row.MerchantOrderId = values.GetElementAtIndexOrDefault(8);
            row.AdjustmentId = values.GetElementAtIndexOrDefault(9);
            row.ShipmentId = values.GetElementAtIndexOrDefault(10);
            row.MarketplaceName = values.GetElementAtIndexOrDefault(11);
            row.AmountType = values.GetElementAtIndexOrDefault(12);
            row.AmountDescription = values.GetElementAtIndexOrDefault(13);
            row.Amount = DataConverter.GetDecimal(values.GetElementAtIndexOrDefault(14));
            row.FulfillmentId = values.GetElementAtIndexOrDefault(15);
            row.PostedDate = DataConverter.GetDate(values.GetElementAtIndexOrDefault(16), DataConverter.DateTimeFormat.DATE_FORMAT_DOT);
            row.PostedDateTime = DataConverter.GetDate(values.GetElementAtIndexOrDefault(17), DataConverter.DateTimeFormat.DATETIME_FORMAT_UTC_DOT);
            row.OrderItemCode = values.GetElementAtIndexOrDefault(18);
            row.MerchantOrderItemId = values.GetElementAtIndexOrDefault(19);
            row.MerchantAdjustmentItemId = values.GetElementAtIndexOrDefault(20);
            row.SKU = values.GetElementAtIndexOrDefault(21);
            row.QuantityPurchased = DataConverter.GetInt(values[22]);
            row.PromotionId = values.GetElementAtIndexOrDefault(23);

            row.refNumber = refNumber;

            return row;
        }
    }
}
