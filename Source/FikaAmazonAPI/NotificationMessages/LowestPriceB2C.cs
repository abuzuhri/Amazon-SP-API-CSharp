using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class LowestPriceB2C : PriceBaseB2C
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
