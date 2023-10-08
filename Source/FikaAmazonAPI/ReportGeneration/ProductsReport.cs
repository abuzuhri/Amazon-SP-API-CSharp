using FikaAmazonAPI.ReportGeneration.ReportDataTable;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.ReportGeneration
{
    public class ProductsReport
    {
        public List<ProductsRow> Data { get; set; } = new List<ProductsRow>();
        public ProductsReport(string path, Encoding encoding = default)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var table = Table.ConvertFromCSV(path, encoding: encoding);

            List<ProductsRow> values = new List<ProductsRow>();
            foreach (var row in table.Rows)
            {
                values.Add(ProductsRow.FromRow(row));
            }
            Data = values;
        }


    }
    public class ProductsRow
    {
        /// <summary>
        /// The title of the item listed. This will be populated with Amazon catalogue data.
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// This is used for backwards compatibility only.
        /// </summary>
        public string ItemDescription { get; set; }
        /// <summary>
        /// An identifier created by Amazon when you create a listing. Consists of 4 digits, a capital letter and 6 more digits.
        /// </summary>
        public string ListingId { get; set; }
        /// <summary>
        /// Stock Keeping Units (SKUs) are unique blocks of letters and/or numbers that identify your products.
        /// SKUs are assigned by you as the seller.
        /// </summary>
        public string SellerSku { get; set; }
        /// <summary>
        /// The price you are asking for the product.
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// The quantity of the product available for purchase.
        /// </summary>
        public int? Quantity { get; set; }
        /// <summary>
        /// The date the listing was created.
        /// </summary>
        public string OpenDate { get; set; }
        public string ImageUrl { get; set; }
        /// <summary>
        /// This will always be y.
        /// </summary>
        public bool ItemIsMarketplace { get; set; }
        /// <summary>
        /// A numeric entry that indicates if the product-id is an ASIN, ISBN, UPC or EAN code/number. When uploading files in Standard Book format, this field value will default to 2 (ISBN) unless otherwise specified.
        /// 1 = ASIN, 2 = ISBN, 3 = UPC, 4 = EAN
        /// </summary>
        public int? ProductIdType { get; set; }
        /// <summary>
        /// This is used for backwards compatibility only.
        /// </summary>
        public string ZshopShippingFee { get; set; }
        /// <summary>
        /// Your description of the listing
        /// </summary>
        /// <example>
        /// Read once, no scratches, normal condition
        /// </example>
        public string ItemNote { get; set; }
        /// <summary>
        /// This is your condition code for the listing.
        /// 1 = Used; Like New, 2 = Used; Very Good, 3 = Used; Good, 4 = Used; Acceptable, 5 = Collectible; Like New,
        /// 6 = Collectible; Very Good, 7 = Collectible; Good, 8 = Collectible; Acceptable, 11 = New
        /// </summary>
        public int? ItemCondition { get; set; }
        /// <summary>
        /// This is used for backwards compatibility only.
        /// </summary>
        public string ZshopCategory1 { get; set; }
        /// <summary>
        /// This is used for backwards compatibility only.
        /// </summary>
        public string ZshopBrowsePath { get; set; }
        /// <summary>
        /// This is used for backwards compatibility only.
        /// </summary>
        public string ZshopStorefrontFeature { get; set; }
        /// <summary>
        /// This is not used. The field is populated with the product-id.
        /// </summary>
        public string ASIN1 { get; set; }
        /// <summary>
        /// This is used for backwards compatibility only.
        /// </summary>
        public string ASIN2 { get; set; }
        /// <summary>
        /// This is used for backwards compatibility only.
        /// </summary>
        public string ASIN3 { get; set; }
        /// <summary>
        /// y = listings that are available to customers outside the UK.
        /// n = listings that are available only to customers in the UK.
        /// </summary>
        public string WillShipInternationally { get; set; }
        /// <summary>
        /// This will always be n
        /// </summary>
        public string ExpeditedShipping { get; set; }
        /// <summary>
        /// This is used for backwards compatibility only.
        /// </summary>
        public string ZshopBoldface { get; set; }
        /// <summary>
        /// ASIN, ISBN, UPC or EAN for the item
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// This is used for backwards compatibility only.
        /// </summary>
        public string BidForFeaturedPlacement { get; set; }
        /// <summary>
        /// This field will be empty in the report; it enables you to use an open listings report to update online inventory.
        /// </summary>
        public string AddDelete { get; set; }
        /// <summary>
        /// This is the quantity of the item that is pending purchase at the time of the report.
        /// </summary>
        public int? PendingQuantity { get; set; }
        /// <summary>
        /// This will indicate for FBA sellers if the listing is set for seller fulfilment or fulfilment by Amazon.
        /// </summary>
        public string FulfillmentChannel { get; set; }
        public string OptionalPaymentTypeExclusion { get; set; }
        public string Status { get; set; }
        public string refNumber { get; set; }
        public string MerchantShippingGroup { get; set; }

        public static ProductsRow FromRow(TableRow rowData)
        {
            var row = new ProductsRow();
            row.ItemName = rowData.GetString("item-name");
            row.ItemDescription = rowData.GetString("item-description");
            row.ListingId = rowData.GetString("listing-id");
            row.SellerSku = rowData.GetString("seller-sku");
            row.Price = DataConverter.GetDecimal(rowData.GetString("price"));
            row.Quantity = rowData.GetInt32Nullable("quantity");
            row.OpenDate = rowData.GetString("open-date");
            row.ImageUrl = rowData.GetString("image-url");
            row.ItemIsMarketplace = rowData.GetString("item-is-marketplace") == "y";
            row.ProductIdType = rowData.GetInt32Nullable("product-id-type");
            row.ZshopShippingFee = rowData.GetString("zshop-shipping-fee");
            row.ItemNote = rowData.GetString("item-note");
            row.ItemCondition = rowData.GetInt32Nullable("zshop-category1");
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
            row.PendingQuantity = rowData.GetInt32Nullable("pending-quantity");
            row.FulfillmentChannel = rowData.GetString("fulfillment-channel") ?? rowData.GetString("fulfilment-channel");
            row.OptionalPaymentTypeExclusion = rowData.GetString("optional-payment-type-exclusion");
            row.Status = rowData.GetString("status");
            row.MerchantShippingGroup = rowData.GetString("merchant-shipping-group");

            return row;
        }
    }
}
