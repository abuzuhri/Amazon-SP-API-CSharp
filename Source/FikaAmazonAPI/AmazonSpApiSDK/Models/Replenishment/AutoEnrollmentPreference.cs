using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Auto-enrollment preference: OPTED_IN or OPTED_OUT.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AutoEnrollmentPreference
    {
        OPTED_IN,
        OPTED_OUT
    }
}
