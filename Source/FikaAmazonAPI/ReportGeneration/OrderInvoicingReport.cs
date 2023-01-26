using FikaAmazonAPI.ReportGeneration.ReportDataTable;
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

            var table = Table.ConvertFromCSV(path);

            List<OrderInvoicingReportRow> values = new List<OrderInvoicingReportRow>();
            foreach (var row in table.Rows)
            {
                values.Add(OrderInvoicingReportRow.FromRow(row, refNumber));
            }
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
        public string refNumber { get; set; }

        public OrderInvoicingReportRow()
        {

        }

        public static OrderInvoicingReportRow FromRow(TableRow rowData, string refNumber)
        {
            var row = new OrderInvoicingReportRow();
            row.AmazonOrderId = rowData.GetString("order-id");
            row.OrderItemId = rowData.GetString("order-item-id");
            row.PurchaseDate = DataConverter.GetDate(rowData.GetString("purchase-date"), DataConverter.DateTimeFormat.DATETIME_K_FORMAT);
            row.PaymentDate = DataConverter.GetDate(rowData.GetString("payments-date"), DataConverter.DateTimeFormat.DATETIME_K_FORMAT);
            row.BuyerEmail = rowData.GetString("buyer-email");
            row.BuyerName = rowData.GetString("buyer-name");
            row.PaymentMethodeDetails = rowData.GetString("payment-method-details");
            row.BuyerPhoneNumber = rowData.GetString("buyer-phone-number");
            row.SKU = rowData.GetString("sku");
            row.ProductName = rowData.GetString("product-name");
            row.Quantity = rowData.GetDecimal("quantity-purchased");
            row.Currency = rowData.GetString("currency");
            row.ItemPrice = rowData.GetDecimal("item-price");
            row.ItemTax = rowData.GetDecimal("item-tax");
            row.ShippingPrice = rowData.GetDecimal("shipping-price");
            row.ShippingTax = rowData.GetDecimal("shipping-tax");
            row.ShipServiceLevel = rowData.GetString("ship-service-level");
            row.RecipientName = rowData.GetString("recipient-name");
            row.ShipAddress1 = rowData.GetString("ship-address-1");
            row.ShipAddress2 = rowData.GetString("ship-address-2");
            row.ShipAddress3 = rowData.GetString("ship-address-3");
            row.ShipCity = rowData.GetString("ship-city");
            row.ShipState = rowData.GetString("ship-state");
            row.ShipPostalCode = rowData.GetString("ship-postal-code");
            row.ShipCountry = rowData.GetString("ship-country");
            row.ShipPhoneNumber = rowData.GetString("ship-phone-number");
            row.BillAddress1 = rowData.GetString("bill-address-1");
            row.BillAddress2 = rowData.GetString("bill-address-2");
            row.BillAddress3 = rowData.GetString("bill-address-3");
            row.BillCity = rowData.GetString("bill-city");
            row.BillState = rowData.GetString("bill-state");
            row.BillPostalCode = rowData.GetString("bill-postal-code");
            row.BillCountry = rowData.GetString("bill-country");
            row.DeliveryIndustructions = rowData.GetString("delivery-Instructions");
            row.SalesChannel = rowData.GetString("sales-channel");
            row.BuyerCompany = rowData.GetString("buyer-company-name");
            row.BuyerTaxRegistationId = rowData.GetString("buyer-tax-registration-id");
            row.BuyerTaxRegistationCountry = rowData.GetString("buyer-tax-registration-country");
            row.refNumber = refNumber;

            return row;
        }
    }
}
