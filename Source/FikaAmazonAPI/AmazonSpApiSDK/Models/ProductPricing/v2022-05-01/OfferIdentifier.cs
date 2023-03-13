using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    public class OfferIdentifier
    {
        /// <summary>
        /// A marketplace identifier. Specifies the marketplace for which data is returned.
        /// </summary>
        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }
        
        /// <summary>
        /// The seller identifier for the offer.
        /// </summary>
        [JsonProperty("sellerId")]
        public string SellerId { get; set; }

        /// <summary>
        /// The seller stock keeping unit (SKU) of the item. This will only be present for the target offer, which belongs to the requesting seller.
        /// </summary>
        [JsonProperty("sku")]
        public string SellerSku { get; set; }
        
        /// <summary>
        /// The Amazon identifier for the item.
        /// </summary>
        [JsonProperty("asin")]
        public string Asin { get; set; }
        
        /// <summary>
        /// The fulfillment type for the offer.
        /// </summary>
        [JsonProperty("fulfillmentType")]
        public FulfillmentType FulfillmentType { get; set; }
    }
}