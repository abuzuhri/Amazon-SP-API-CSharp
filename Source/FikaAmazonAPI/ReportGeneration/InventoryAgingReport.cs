using FikaAmazonAPI.ReportGeneration.ReportDataTable;
using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.ReportGeneration
{
    public class InventoryAgingReport
    {
        public List<InventoryAgingRow> Data { get; set; } = new List<InventoryAgingRow>();
        public InventoryAgingReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var table = Table.ConvertFromCSV(path);

            List<InventoryAgingRow> values = new List<InventoryAgingRow>();
            foreach (var row in table.Rows)
            {
                values.Add(InventoryAgingRow.FromRow(row, refNumber));
            }
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

        public static InventoryAgingRow FromRow(TableRow rowData, string refNumber)
        {
            var row = new InventoryAgingRow();
            row.SnapshotDate = DataConverter.GetDate(rowData.GetString("snapshot-date"), DataConverter.DateTimeFormat.DATE_AGING_FORMAT);
            row.SKU = rowData.GetString("sku");
            row.FNSKU = rowData.GetString("fnsku");
            row.ASIN = rowData.GetString("asin");
            row.ProductName = rowData.GetString("product-name");
            row.Condition = rowData.GetString("condition");
            row.AvaliableQuantitySellable = DataConverter.GetInt(rowData.GetString("avaliable-quantity(sellable)"));
            row.QtyWithRemovalsInProgress = DataConverter.GetInt(rowData.GetString("qty-with-removals-in-progress"));
            row.InvAge0To90Days = DataConverter.GetInt(rowData.GetString("inv-age-0-to-90-days"));
            row.InvAge91To180Days = DataConverter.GetInt(rowData.GetString("inv-age-91-to-180-days"));
            row.InvAge181To270Days = DataConverter.GetInt(rowData.GetString("inv-age-181-to-270-days"));
            row.InvAge271To365Days = DataConverter.GetInt(rowData.GetString("inv-age-271-to-365-days"));
            row.InvAge365PlusDays = DataConverter.GetInt(rowData.GetString("inv-age-365-plus-days"));
            row.Currency = rowData.GetString("currency");
            row.QtyToBeChargedLtsf12Mo = DataConverter.GetInt(rowData.GetString("qty-to-be-charged-ltsf-12-mo"));
            row.ProjectedLtsf12Mo = DataConverter.GetInt(rowData.GetString("projected-ltsf-12-mo"));
            row.UnitsShippedLast7Days = DataConverter.GetInt(rowData.GetString("units-shipped-last-7-days"));
            row.UnitsShippedLast30Days = DataConverter.GetInt(rowData.GetString("units-shipped-last-30-days"));
            row.UnitsShippedLast60Days = DataConverter.GetInt(rowData.GetString("units-shipped-last-60-days"));
            row.UnitsShippedLast90Days = DataConverter.GetInt(rowData.GetString("units-shipped-last-90-days"));
            row.Alert = rowData.GetString("alert");
            row.YourPrice = DataConverter.GetDecimal(rowData.GetString("your-price"));
            row.SalesPrice = DataConverter.GetDecimal(rowData.GetString("sales_price"));
            row.LowestPriceNew = DataConverter.GetDecimal(rowData.GetString("lowest_price_new"));
            row.LowestPriceUsed = DataConverter.GetDecimal(rowData.GetString("lowest_price_used"));
            row.RecommendedAction = rowData.GetString("Recommended action");
            row.refNumber = refNumber;

            return row;
        }
    }
}
