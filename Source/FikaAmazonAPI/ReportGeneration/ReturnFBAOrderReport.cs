using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ReturnFBAOrderReport
    {
        public List<ReturnFBAOrderRow> Data { get; set; }=new List<ReturnFBAOrderRow>();
        public ReturnFBAOrderReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;
            List<ReturnFBAOrderRow> values = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => ReturnFBAOrderRow.FromCsv(v, refNumber))
                                           .ToList();
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


        public static ReturnFBAOrderRow FromCsv(string csvLine, string refNumber)
        {
            string[] values = csvLine.Split('\t');
            var row = new ReturnFBAOrderRow();
            row.ReturnDate = DataConverter.GetDate(values[0], DataConverter.DateTimeFormate.DATETIME_K_FORMAT);
            row.OrderId = values[1];
            row.SKU = values[2];
            row.ASIN = values[3];
            row.FNSKU = values[4];
            row.ProductName = values[5];
            row.Quantity = Convert.ToInt32(values[6]);
            row.FulfillmentCenterId = values[7];
            row.DetailedDisposition = values[8];
            row.Reason = values[9];
            row.Status = values[10];
            row.LicensePlateNumber = values[11];
            row.CustomerComments = values[12];
            row.refNumber = refNumber;

            return row;
        }
    }
}
