using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Preferences applied to an offer.</summary>
    public class OfferProgramConfigurationPreferences
    {
        [JsonProperty("autoEnrollment")]
        public AutoEnrollmentPreference? AutoEnrollment { get; set; }
    }
}
