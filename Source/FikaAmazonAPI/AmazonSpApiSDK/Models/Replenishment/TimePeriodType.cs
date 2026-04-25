using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Determines whether the metrics requested are backward-looking (PERFORMANCE) or forward-looking (FORECAST).
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimePeriodType
    {
        PERFORMANCE,
        FORECAST
    }
}
