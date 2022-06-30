using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class OfferB2C : OfferBase
    {
        /// <summary>
        /// Optional. The number of Amazon Points offered with the purchase of an item.
        /// </summary>
        /// <remarks>
        /// Note: The Points object is only returned in Japan (JP).
        /// </remarks>
        [JsonProperty("Points")]
        public Points Points { get; set; }

        /// <summary>
        /// Optional. Indicates whether expedited shipping is available.
        /// </summary>
        [JsonProperty("IsExpeditedShippingAvailable")]
        public bool? IsExpeditedShippingAvailable { get; set; }

        /// <summary>
        /// Optional. Indicates whether the item ships domestically.
        /// </summary>
        [JsonProperty("ShipsDomestically")]
        public bool? ShipsDomestically { get; set; }
    }
}
