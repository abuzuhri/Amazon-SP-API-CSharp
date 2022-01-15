using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.ReportGeneration
{
    public class OrdersReport
    {
        public List<OrdersRow> Data { get; set; }
        public OrdersReport(string path, string refNumber)
        {
            var values = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => OrdersRow.FromCsv(v, refNumber))
                                           .ToList();
            Data = values;
        }


    }
    public class OrdersRow
    {
        public string AmazonOrderId { get; set; }
        public string MerchantOrderId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string OrderStatus { get; set; }
        public string FulfillmentChannel { get; set; }
        public string SalesChannel { get; set; }
        public string OrderChannel { get; set; }
        public string ShipServiceLevel { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public string ASIN { get; set; }
        public string ItemStatus { get; set; }
        public int? Quantity { get; set; }
        public string Currency { get; set; }
        public decimal? ItemPrice { get; set; }
        public decimal? ItemTax { get; set; }
        public decimal? ShippingPrice { get; set; }
        public decimal? ShippingTax { get; set; }
        public decimal? GiftWrapPrice { get; set; }
        public decimal? GiftWrapTax { get; set; }
        public decimal? ItemPromotionDiscount { get; set; }
        public decimal? ShipPromotionDiscount { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public string PromotionIds { get; set; }
        public string refNumber { get; set; }

        public static OrdersRow FromCsv(string csvLine, string refNumber)
        {
            string[] values = csvLine.Split('\t');
            var row = new OrdersRow();
            row.AmazonOrderId = values[0];
            row.MerchantOrderId = values[1];
            row.PurchaseDate = DataConverter.GetDate(values[2], DataConverter.DateTimeFormate.DATETIME_K_FORMAT);
            row.LastUpdatedDate = DataConverter.GetDate(values[3], DataConverter.DateTimeFormate.DATETIME_K_FORMAT);
            row.OrderStatus = values[4];
            row.FulfillmentChannel = values[5];
            row.SalesChannel = values[6];
            row.OrderChannel = values[7];
            row.ShipServiceLevel = values[8];
            row.ProductName = values[9];
            row.SKU = values[10];
            row.ASIN = values[11];
            row.ItemStatus = values[12];
            row.Quantity = DataConverter.GetInt(values[13]);
            row.Currency = values[14];
            row.ItemPrice = DataConverter.GetInt(values[15]);
            row.ItemTax = DataConverter.GetInt(values[16]);
            row.ShippingPrice = DataConverter.GetInt(values[17]);
            row.ShippingTax = DataConverter.GetInt(values[18]);
            row.GiftWrapPrice = DataConverter.GetInt(values[19]);
            row.GiftWrapTax = DataConverter.GetInt(values[20]);
            row.ItemPromotionDiscount = DataConverter.GetInt(values[21]);
            row.ShipPromotionDiscount = DataConverter.GetInt(values[22]);
            row.ShipCity = values[23];
            row.ShipState = values[24];
            row.ShipPostalCode = values[25];
            row.ShipCountry = values[26];
            row.PromotionIds = values[27];

            row.refNumber = refNumber;


            return row;
        }
    }
}
