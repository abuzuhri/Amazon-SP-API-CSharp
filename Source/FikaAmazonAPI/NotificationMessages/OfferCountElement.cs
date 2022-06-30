using Newtonsoft.Json;


namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class OfferCountElement
    {
        /// <summary>
        /// Required. Indicates the condition of the item. For example: New, Used, Collectible, Refurbished, or Club.
        /// </summary>
        [JsonProperty("Condition")]
        public string Condition { get; set; }

        /// <summary>
        /// Required. Indicates whether the item is fulfilled by Amazon or by the seller.
        /// </summary>
        /// <remarks>
        /// See values from FulfillmentChannelType class.
        /// </remarks>
        [JsonProperty("FulfillmentChannel")]
        public string FulfillmentChannel { get; set; }

        /// <summary>
        /// The total number of offers for the specified condition and fulfillment channel.
        /// </summary>
        [JsonProperty("OfferCount")]
        public long OfferCount { get; set; }
    }
}
