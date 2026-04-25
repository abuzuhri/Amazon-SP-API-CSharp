using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The time period used to group data in the response. Only valid for the PERFORMANCE time period type.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AggregationFrequency
    {
        WEEK,
        MONTH,
        QUARTER,
        YEAR
    }
}
