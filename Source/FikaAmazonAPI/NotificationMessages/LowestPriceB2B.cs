using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    public class LowestPriceB2B : PriceBaseB2B
    {
        /// <summary>
        /// Required. Indicates whether the item is fulfilled by Amazon or by the seller.
        /// </summary>
        /// <remarks>
        /// See values from FulfillmentChannelType class.
        /// </remarks>
        [JsonProperty("FulfillmentChannel")]
        public string FulfillmentChannel { get; set; }
    }
}
