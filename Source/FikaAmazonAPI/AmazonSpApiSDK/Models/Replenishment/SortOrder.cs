using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortOrder
    {
        ASC,
        DESC
    }
}
