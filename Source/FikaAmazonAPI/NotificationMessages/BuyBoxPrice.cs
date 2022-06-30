using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class BuyBoxPrice
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
        /// Optional. The number of Amazon Points offered with the purchase of an item. 
        /// </summary>
        /// <remarks>
        /// Note: The Points object is only returned in Japan (JP).
        /// </remarks>
        [JsonProperty("Points", NullValueHandling = NullValueHandling.Ignore)]
        public Points Points { get; set; }

        /// <summary>
        /// Required. Indicates the condition of the item. For example: New, Used, Collectible, Refurbished, or Club. 
        /// </summary>
        [JsonProperty("Condition")]
        public string Condition { get; set; }
    }
}
