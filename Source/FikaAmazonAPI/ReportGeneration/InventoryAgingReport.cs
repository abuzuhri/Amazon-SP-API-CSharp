using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.ReportGeneration
{
    public class InventoryAgingReport
    {
        public List<InventoryAgingRow> Data { get; set; }=new List<InventoryAgingRow>();
        public InventoryAgingReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;
            var values = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => InventoryAgingRow.FromCsv(v, refNumber))
                                           .ToList();
            Data = values;
        }


    }
    public class InventoryAgingRow
    {
        public DateTime? SnapshotDate { get; set; }
        public string SKU { get; set; }
        public string FNSKU { get; set; }
        public string ASIN { get; set; }
        public string ProductName { get; set; }
        public string Condition { get; set; }
        public int? AvaliableQuantitySellable { get; set; }
        public int? QtyWithRemovalsInProgress { get; set; }
        public int? InvAge0To90Days { get; set; }
        public int? InvAge91To180Days { get; set; }
        public int? InvAge181To270Days { get; set; }
        public int? InvAge271To365Days { get; set; }
        public int? InvAge365PlusDays { get; set; }
        public string Currency { get; set; }
        public int? QtyToBeChargedLtsf12Mo { get; set; }
        public decimal? ProjectedLtsf12Mo { get; set; }
        public int? UnitsShippedLast7Days { get; set; }
        public int? UnitsShippedLast30Days { get; set; }
        public int? UnitsShippedLast60Days { get; set; }
        public int? UnitsShippedLast90Days { get; set; }
        public string Alert { get; set; }
        public decimal? YourPrice { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? LowestPriceNew { get; set; }
        public decimal? LowestPriceUsed { get; set; }
        public string RecommendedAction { get; set; }
        public string refNumber { get; set; }

        public static InventoryAgingRow FromCsv(string csvLine, string refNumber)
        {
            string[] values = csvLine.Split('\t');
            var row = new InventoryAgingRow();
            row.SnapshotDate = DataConverter.GetDate(values[0], DataConverter.DateTimeFormate.DATE_AGING_FORMAT);
            row.SKU = values[1];
            row.FNSKU = values[2];
            row.ASIN = values[3];
            row.ProductName = values[4];
            row.Condition = values[5];
            row.AvaliableQuantitySellable = DataConverter.GetInt(values[6]);
            row.QtyWithRemovalsInProgress = DataConverter.GetInt(values[7]);
            row.InvAge0To90Days = DataConverter.GetInt(values[8]);
            row.InvAge91To180Days = DataConverter.GetInt(values[9]);
            row.InvAge181To270Days = DataConverter.GetInt(values[10]);
            row.InvAge271To365Days = DataConverter.GetInt(values[11]);
            row.InvAge365PlusDays = DataConverter.GetInt(values[12]);
            row.Currency = values[13];
            row.QtyToBeChargedLtsf12Mo = DataConverter.GetInt(values[14]);
            row.ProjectedLtsf12Mo = DataConverter.GetInt(values[15]);
            row.UnitsShippedLast7Days = DataConverter.GetInt(values[16]);
            row.UnitsShippedLast30Days = DataConverter.GetInt(values[17]);
            row.UnitsShippedLast60Days = DataConverter.GetInt(values[18]);
            row.UnitsShippedLast90Days = DataConverter.GetInt(values[19]);
            row.Alert = values[20];
            row.YourPrice = DataConverter.GetDecimal(values[21]);
            row.SalesPrice = DataConverter.GetDecimal(values[22]);
            row.LowestPriceNew = DataConverter.GetDecimal(values[23]);
            row.LowestPriceUsed = DataConverter.GetDecimal(values[24]);
            row.RecommendedAction = values[25];

            row.refNumber = refNumber;


            return row;
        }
    }
}
