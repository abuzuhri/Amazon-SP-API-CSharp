using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentType
    {
        /// <summary>A+ Content published through Seller Central.</summary>
        EBC,
        /// <summary>A+ Content published through Vendor Central.</summary>
        EMC
    }
}
