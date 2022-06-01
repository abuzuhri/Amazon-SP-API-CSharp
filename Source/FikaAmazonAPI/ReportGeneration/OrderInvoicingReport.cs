using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.ReportGeneration
{
    public class OrderInvoicingReport
    {
        public List<OrderInvoicingReportRow> Data { get; set; } = new List<OrderInvoicingReportRow>();
        public OrderInvoicingReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;
            var values = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => OrderInvoicingReportRow.FromCsv(v, refNumber))
                                           .ToList();
            Data = values;
        }
    }


    public class OrderInvoicingReportRow
    {
        public string AmazonOrderId { get; set; }
        public string OrderItemId { get; set; }
        public DateTime? PurchaseDate{ get; set; }
        public DateTime? PaymentDate { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerName { get; set; }
        public string PaymentMethodeDetails { get; set; }
        public string BuyerPhoneNumber { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public decimal? Quantity { get; set; }
        public string Currency { get; set; }
        public decimal? ItemPrice { get; set; }
        public decimal? ItemTax { get; set; }
        public decimal? ShippingPrice { get; set; }
        public decimal? ShippingTax { get; set; }
        public string ShipServiceLevel { get; set; }
        public string RecipientName { get; set; }
        public string ShipAddress1 { get; set; }
        public string ShipAddress2 { get; set; }
        public string ShipAddress3 { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPhoneNumber { get; set; }
        public string BillAddress1 { get; set; }
        public string BillAddress2 { get; set; }
        public string BillAddress3 { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillPostalCode { get; set; }
        public string BillCountry { get; set; }
        public string DeliveryIndustructions { get; set; }
        public string SalesChannel { get; set; }
        public string BuyerCompany { get; set; }
        public string BuyerTaxRegistationId { get; set; }
        public string BuyerTaxRegistationCountry { get; set; }

        public OrderInvoicingReportRow()
        {

        }

        public static OrderInvoicingReportRow FromCsv(string csvLine, string refNumber)
        {
            string[] values = csvLine.Split('\t');
            var row = new OrderInvoicingReportRow();
            row.AmazonOrderId = values[0];
            row.OrderItemId = values[1];
            row.PurchaseDate = DataConverter.GetDate(values[2], DataConverter.DateTimeFormate.DATETIME_K_FORMAT);
            row.PaymentDate = DataConverter.GetDate(values[3], DataConverter.DateTimeFormate.DATETIME_K_FORMAT);
            row.BuyerEmail = values[4];
            row.BuyerName = values[5];
            row.PaymentMethodeDetails = values[6];
            row.BuyerPhoneNumber = values[7];
            row.SKU = values[8];
            row.ProductName = values[9];
            row.Quantity = DataConverter.GetInt(values[10]);
            row.Currency = values[11];
            row.ItemPrice = DataConverter.GetDecimal(values[12]);
            row.ItemTax = DataConverter.GetDecimal(values[13]);
            row.ShippingPrice = DataConverter.GetDecimal(values[14]);
            row.ShippingTax = DataConverter.GetDecimal(values[15]);
            row.ShipServiceLevel = values[16];
            row.RecipientName = values[17];
            row.ShipAddress1 = values[18];
            row.ShipAddress2 = values[19];
            row.ShipAddress3 = values[20];
            row.ShipCity = values[21];
            row.ShipState = values[22];
            row.ShipPostalCode = values[23];
            row.ShipCountry = values[24];
            row.ShipPhoneNumber = values[25];
            row.BillAddress1 = values[26];
            row.BillAddress2 = values[27];
            row.BillAddress3 = values[28];
            row.BillCity = values[29];
            row.BillState = values[30];
            row.BillPostalCode = values[31];
            row.BillCountry = values[32];
            row.DeliveryIndustructions = values[36];
            row.SalesChannel = values[37];
            row.BuyerCompany = values[50];
            row.BuyerTaxRegistationId = values[53];
            row.BuyerTaxRegistationCountry = values[54];
            return row;
        }
    }



    

}
