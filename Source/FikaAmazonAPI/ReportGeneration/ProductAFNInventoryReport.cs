using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ProductAFNInventoryReport
    {
        public List<ProductAFNInventoryRow> Data { get; set; } = new List<ProductAFNInventoryRow>();
        public ProductAFNInventoryReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;
            var values = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => ProductAFNInventoryRow.FromCsv(v, refNumber))
                                           .ToList();
            Data = values;
        }
    }

    public class ProductAFNInventoryRow
    {
        public string SellerSku { get; set; }
        public string FulfillmentChannelSku { get; set; }
        public string ASIN { get; set; }
        public string ConditionType { get; set; }
        public string WarehouseConditionCode { get; set; }
        public int? QuantityAvailable { get; set; }


        public static ProductAFNInventoryRow FromCsv(string csvLine, string refNumber)
        {
            string[] values = csvLine.Split('\t');
            var row = new ProductAFNInventoryRow();
            row.SellerSku = values[0];
            row.FulfillmentChannelSku = values[1];
            row.ASIN = values[2];
            row.ConditionType = values[3];
            row.WarehouseConditionCode = values[4];
            row.QuantityAvailable = DataConverter.GetInt(values[5]);
            return row;
        }
    }
}
