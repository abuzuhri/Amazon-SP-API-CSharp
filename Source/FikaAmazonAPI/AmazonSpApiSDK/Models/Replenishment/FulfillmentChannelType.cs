using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The fulfillment channel type of an offer. Only valid for sellers, not vendors.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FulfillmentChannelType
    {
        AMAZON,
        MERCHANT
    }
}
