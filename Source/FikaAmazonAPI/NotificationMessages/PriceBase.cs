using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    public abstract class PriceBase
    {
        /// <summary>
        /// Required. ListingPrice + Shipping - Points. 
        /// </summary>
        [JsonProperty("LandedPrice")]
        public MoneyType LandedPrice { get; set; }

        /// <summary>
        /// Required. The price of the item.
        /// </summary>
        [JsonProperty("ListingPrice")]
        public MoneyType ListingPrice { get; set; }

        /// <summary>
        /// Required. The shipping cost. 
        /// </summary>
        [JsonProperty("Shipping")]
        public MoneyType Shipping { get; set; }

        /// <summary>
        /// Required. Indicates the condition of the item. For example: New, Used, Collectible, Refurbished, or Club. 
        /// </summary>
        [JsonProperty("Condition")]
        public string Condition { get; set; }
    }
}
