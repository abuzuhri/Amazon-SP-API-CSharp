using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Set of program properties for an offer.</summary>
    public class OfferProgramConfiguration
    {
        [JsonProperty("preferences")]
        public OfferProgramConfigurationPreferences Preferences { get; set; }

        [JsonProperty("promotions")]
        public OfferProgramConfigurationPromotions Promotions { get; set; }

        /// <summary>Determines whether the offer was automatically or manually enrolled. Sellers only.</summary>
        [JsonProperty("enrollmentMethod")]
        public EnrollmentMethod? EnrollmentMethod { get; set; }
    }
}
