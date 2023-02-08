using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    public class Price
    {
        /// <summary>
        /// The listing price of the item excluding any promotions.
        /// </summary>
        [JsonProperty("listingPrice")]
        public MoneyType ListingPrice { get; set; }
        
        /// <summary>
        /// The listing price of the item excluding any promotions.
        /// </summary>
        [JsonProperty("shippingPrice")]
        public MoneyType ShippingPrice { get; set; }
        
        /// <summary>
        /// The listing price of the item excluding any promotions.
        /// </summary>
        [JsonProperty("points")]
        public MoneyType Points { get; set; }
    }
}