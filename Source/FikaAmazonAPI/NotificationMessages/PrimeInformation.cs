using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class PrimeInformation
    {
        /// <summary>
        /// Required. Indicates whether the offer is an Amazon Prime offer throughout the entire marketplace where it is listed.
        /// </summary>
        [JsonProperty("IsOfferNationalPrime")]
        public bool IsOfferNationalPrime { get; set; }

        /// <summary>
        /// Required. Indicates whether the offer is an Amazon Prime offer.
        /// </summary>
        [JsonProperty("IsOfferPrime")]
        public bool IsOfferPrime { get; set; }
    }
}
