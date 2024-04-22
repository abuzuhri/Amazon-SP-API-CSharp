using FikaAmazonAPI.ReportGeneration.ReportDataTable;
using System.Collections.Generic;

namespace FikaAmazonAPI.ReportGeneration
{
    public class UnsuppressedInventoryDataReport
    {
        public List<UnsuppressedInventoryDataRow> Data { get; set; } = new List<UnsuppressedInventoryDataRow>();

        public UnsuppressedInventoryDataReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var table = Table.ConvertFromCSV(path);

            List<UnsuppressedInventoryDataRow> values = new List<UnsuppressedInventoryDataRow>();
            foreach (var row in table.Rows)
            {
                values.Add(UnsuppressedInventoryDataRow.FromRow(row, refNumber));
            }
            Data = values;
        }
    }

    public class UnsuppressedInventoryDataRow
    {
        public string SellerSku { get; set; }
        public string FNSKU { get; set; }
        public string ASIN { get; set; }
        public string ProductName { get; set; }
        public string Condition { get; set; }
        public decimal? YourPrice { get; set; }
        public string MfnListingExists { get; set; }
        public int? MfnFulfillableQuantity { get; set; }
        public string AfnListingExists { get; set; }
        public int? AfnWarehouseQuantity { get; set; }
        public int? AfnFulfillableQuantity { get; set; }
        public int? AfnUnsellableQuantity { get; set; }
        public int? AfnReservedQuantity { get; set; }
        public int? AfnTotalQuantity { get; set; }
        public decimal? PerUnitVolume { get; set; }
        public int? AfnInboundWorkingQuantity { get; set; }
        public int? AfnInboundShippedQuantity { get; set; }
        public int? AfnInboundReceivingQuantity { get; set; }
        public int? AfnResearchingQuantity { get; set; }
        public int? AfnReservedFutureSupply { get; set; }
        public int? AfnFutureSupplyBuyable { get; set; }
        public string refNumber { get; set; }
        public static UnsuppressedInventoryDataRow FromRow(TableRow rowData, string refNumber)
        {
            var row = new UnsuppressedInventoryDataRow();
            row.SellerSku = rowData.GetString("sku");
            row.FNSKU = rowData.GetString("fnsku");
            row.ASIN = rowData.GetString("asin");
            row.ProductName = rowData.GetString("product-name");
            row.Condition = rowData.GetString("condition");
            row.YourPrice = rowData.GetDecimal("your-price");
            row.MfnListingExists = rowData.GetString("mfn-listing-exists");
            row.MfnFulfillableQuantity = rowData.GetInt32("mfn-fulfillable-quantity");
            row.AfnListingExists = rowData.GetString("afn-listing-exists");
            row.AfnWarehouseQuantity = rowData.GetInt32("afn-warehouse-quantity");
            row.AfnFulfillableQuantity = rowData.GetInt32("afn-fulfillable-quantity");
            row.AfnUnsellableQuantity = rowData.GetInt32("afn-unsellable-quantity");
            row.AfnReservedQuantity = rowData.GetInt32("afn-reserved-quantity");
            row.AfnTotalQuantity = rowData.GetInt32("afn-total-quantity");
            row.PerUnitVolume = rowData.GetDecimal("per-unit-volume");
            row.AfnInboundWorkingQuantity = rowData.GetInt32("afn-inbound-working-quantity");
            row.AfnInboundShippedQuantity = rowData.GetInt32("afn-inbound-shipped-quantity");
            row.AfnInboundReceivingQuantity = rowData.GetInt32("afn-inbound-receiving-quantity");
            row.AfnResearchingQuantity = rowData.GetInt32("afn-researching-quantity");
            row.AfnReservedFutureSupply = rowData.GetInt32("afn-reserved-future-supply");
            row.AfnFutureSupplyBuyable = rowData.GetInt32("afn-future-supply-buyable");
            row.refNumber = refNumber;

            return row;
        }
    }
}
