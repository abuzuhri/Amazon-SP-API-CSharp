using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>Amazon Prime details.</summary>
    public class PrimeDetails
    {
        [JsonProperty("eligibility")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PrimeEligibility Eligibility { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PrimeEligibility
    {
        NATIONAL,
        REGIONAL,
        NONE
    }
}
