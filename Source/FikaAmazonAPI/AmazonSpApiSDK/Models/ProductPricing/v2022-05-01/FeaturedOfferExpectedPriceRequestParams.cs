using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    public class FeaturedOfferExpectedPriceRequestParams
    {
        /// <summary>
        /// A marketplace identifier. Specifies the marketplace for which data is returned.
        /// </summary>
        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// The seller SKU of the item.
        /// </summary>
        [JsonProperty("sku")]
        public string SellerSku { get; set; }
    }
}