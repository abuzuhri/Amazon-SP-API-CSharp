using FikaAmazonAPI.ReportGeneration.ReportDataTable;
using System.Collections.Generic;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ProductsReport
    {
        public List<ProductsRow> Data { get; set; } = new List<ProductsRow>();
        public ProductsReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var table = Table.ConvertFromCSV(path);

            List<ProductsRow> values = new List<ProductsRow>();
            foreach (var row in table.Rows)
            {
                values.Add(ProductsRow.FromRow(row, refNumber));
            }
            Data = values;
        }


    }
    public class ProductsRow
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ListingId { get; set; }
        public string SellerSku { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string OpenDate { get; set; }
        public string ImageUrl { get; set; }
        public bool ItemIsMarketplace { get; set; }
        public int? ProductIdType { get; set; }
        public string ZshopShippingFee { get; set; }
        public string ItemNote { get; set; }
        public int? ItemCondition { get; set; }
        public string ZshopCategory1 { get; set; }
        public string ZshopBrowsePath { get; set; }
        public string ZshopStorefrontFeature { get; set; }
        public string ASIN1 { get; set; }
        public string ASIN2 { get; set; }
        public string ASIN3 { get; set; }
        public string WillShipInternationally { get; set; }
        public string ExpeditedShipping { get; set; }
        public string ZshopBoldface { get; set; }
        public string ProductId { get; set; }
        public string BidForFeaturedPlacement { get; set; }
        public string AddDelete { get; set; }
        public int? PendingQuantity { get; set; }
        public string FulfillmentChannel { get; set; }
        public string OptionalPaymentTypeExclusion { get; set; }
        public string Status { get; set; }
        public string refNumber { get; set; }

        public static ProductsRow FromRow(TableRow rowData, string refNumber)
        {
            var row = new ProductsRow();
            row.ItemName = rowData.GetString("item-name");
            row.ItemDescription = rowData.GetString("item-description");
            row.ListingId = rowData.GetString("listing-id");
            row.SellerSku = rowData.GetString("seller-sku");
            row.Price = DataConverter.GetDecimal(rowData.GetString("price"));
            row.Quantity = rowData.GetInt32("quantity");
            row.OpenDate = rowData.GetString("open-date");
            row.ImageUrl = rowData.GetString("image-url");
            row.ItemIsMarketplace = rowData.GetString("item-is-marketplace") == "y";
            row.ProductIdType = rowData.GetInt32("product-id-type");
            row.ZshopShippingFee = rowData.GetString("zshop-shipping-fee");
            row.ItemNote = rowData.GetString("item-note");
            row.ItemCondition = rowData.GetInt32("zshop-category1");
            row.ZshopCategory1 = rowData.GetString("zshop-category1");
            row.ZshopBrowsePath = rowData.GetString("zshop-browse-path");
            row.ZshopStorefrontFeature = rowData.GetString("zshop-storefront-feature");
            row.ASIN1 = rowData.GetString("asin1");
            row.ASIN2 = rowData.GetString("asin2");
            row.ASIN3 = rowData.GetString("asin3");
            row.WillShipInternationally = rowData.GetString("will-ship-internationally");
            row.ExpeditedShipping = rowData.GetString("expedited-shipping");
            row.ZshopBoldface = rowData.GetString("zshop-boldface");
            row.ProductId = rowData.GetString("product-id");
            row.BidForFeaturedPlacement = rowData.GetString("bid-for-featured-placement");
            row.AddDelete = rowData.GetString("add-delete");
            row.PendingQuantity = rowData.GetInt32("pending-quantity");
            row.FulfillmentChannel = rowData.GetString("fulfillment-channel");
            row.OptionalPaymentTypeExclusion = rowData.GetString("optional-payment-type-exclusion");
            row.Status = rowData.GetString("status");

            return row;
        }
        public static ProductsRow FromCsv(string csvLine, string refNumber)
        {
            string[] values = csvLine.Split('\t');
            var row = new ProductsRow();
            row.ItemName = values[0];
            row.ItemDescription = values[1];
            row.ListingId = values[2];
            row.SellerSku = values[3];
            row.Price = DataConverter.GetDecimal(values[4]);
            row.Quantity = DataConverter.GetInt(values[5]);
            row.OpenDate = values[6];
            row.ImageUrl = values[7];
            row.ItemIsMarketplace = values[8] == "y";
            row.ProductIdType = DataConverter.GetInt(values[9]);
            row.ZshopShippingFee = values[10];
            row.ItemNote = values[11];
            row.ItemCondition = DataConverter.GetInt(values[12]);
            row.ZshopCategory1 = values[13];
            row.ZshopBrowsePath = values[14];
            row.ZshopStorefrontFeature = values[15];
            row.ASIN1 = values[16];
            row.ASIN2 = values[17];
            row.ASIN3 = values[18];
            row.WillShipInternationally = values[19];
            row.ExpeditedShipping = values[20];
            row.ZshopBoldface = values[21];
            row.ProductId = values[22];
            row.BidForFeaturedPlacement = values[23];
            row.AddDelete = values[24];
            row.PendingQuantity = DataConverter.GetInt(values[25]);
            row.FulfillmentChannel = values[26];
            row.OptionalPaymentTypeExclusion = values[27];
            row.Status = values[28];

            row.refNumber = refNumber;


            return row;
        }
    }
}
