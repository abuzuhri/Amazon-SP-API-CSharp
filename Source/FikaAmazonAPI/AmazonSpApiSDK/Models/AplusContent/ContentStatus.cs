using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentStatus
    {
        APPROVED,
        DRAFT,
        REJECTED,
        SUBMITTED
    }
}
