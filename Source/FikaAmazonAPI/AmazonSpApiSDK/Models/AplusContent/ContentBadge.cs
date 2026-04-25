using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentBadge
    {
        BULK,
        GENERATED,
        LAUNCHPAD,
        PREMIUM,
        STANDARD
    }
}
