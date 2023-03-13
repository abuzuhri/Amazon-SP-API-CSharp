using FikaAmazonAPI.ReportGeneration.ReportDataTable;
using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ReturnFBAOrderReport
    {
        public List<ReturnFBAOrderRow> Data { get; set; } = new List<ReturnFBAOrderRow>();
        public ReturnFBAOrderReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var table = Table.ConvertFromCSV(path);

            List<ReturnFBAOrderRow> values = new List<ReturnFBAOrderRow>();
            foreach (var row in table.Rows)
            {
                values.Add(ReturnFBAOrderRow.FromRow(row, refNumber));
            }
            Data = values;
        }
    }
    public class ReturnFBAOrderRow
    {
        public DateTime? ReturnDate { get; set; }
        public string OrderId { get; set; }
        public string SKU { get; set; }
        public string ASIN { get; set; }
        public string FNSKU { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string FulfillmentCenterId { get; set; }
        public string DetailedDisposition { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string LicensePlateNumber { get; set; }
        public string CustomerComments { get; set; }
        public string refNumber { get; set; }


        public static ReturnFBAOrderRow FromRow(TableRow rowData, string refNumber)
        {
            var row = new ReturnFBAOrderRow();
            row.ReturnDate = DataConverter.GetDate(rowData.GetString("return-date"), DataConverter.DateTimeFormat.DATETIME_K_FORMAT);
            row.OrderId = rowData.GetString("order-id");
            row.SKU = rowData.GetString("sku");
            row.ASIN = rowData.GetString("asin");
            row.FNSKU = rowData.GetString("fnsku");
            row.ProductName = rowData.GetString("product-name");
            row.Quantity = rowData.GetInt32("quantity");
            row.FulfillmentCenterId = rowData.GetString("fulfillment-center-id");
            row.DetailedDisposition = rowData.GetString("detailed-disposition");
            row.Reason = rowData.GetString("reason");
            row.Status = rowData.GetString("status");
            row.LicensePlateNumber = rowData.GetString("license-plate-number");
            row.CustomerComments = rowData.GetString("customer-comments");
            row.refNumber = refNumber;

            return row;
        }
    }
}
