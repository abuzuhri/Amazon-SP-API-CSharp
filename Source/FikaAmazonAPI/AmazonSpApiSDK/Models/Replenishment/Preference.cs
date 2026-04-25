using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Offer preferences to include in the listOffers result filter criteria.</summary>
    public class Preference
    {
        [JsonProperty("autoEnrollment")]
        public List<AutoEnrollmentPreference> AutoEnrollment { get; set; }
    }
}
