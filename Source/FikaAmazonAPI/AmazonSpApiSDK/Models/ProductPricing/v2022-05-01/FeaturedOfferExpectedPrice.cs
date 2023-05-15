using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    public class FeaturedOfferExpectedPrice
    {
        /// <summary>
        /// A computed listing price at or below which a seller can expect to become the featured offer (before applicable promotions).
        /// </summary>
        [JsonProperty("listingPrice")]
        public MoneyType ListingPrice { get; set; }

        /// <summary>
        /// The number of Amazon Points offered with the purchase of an item, and their monetary value.
        /// </summary>
        [JsonProperty("points")]
        public Points Points { get; set; }
    }
}