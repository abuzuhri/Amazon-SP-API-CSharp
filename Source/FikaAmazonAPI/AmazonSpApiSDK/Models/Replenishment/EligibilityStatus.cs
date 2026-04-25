using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>The current eligibility status of an offer.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EligibilityStatus
    {
        ELIGIBLE,
        INELIGIBLE,
        SUSPENDED,
        REPLENISHMENT_ONLY_ORDERING
    }
}
