using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public abstract class PriceBaseB2C : PriceBase
    {
        /// <summary>
        /// Optional. The number of Amazon Points offered with the purchase of an item. 
        /// </summary>
        /// <remarks>
        /// Note: The Points object is only returned in Japan (JP).
        /// </remarks>
        [JsonProperty("Points", NullValueHandling = NullValueHandling.Ignore)]
        public Points Points { get; set; }
    }
}
