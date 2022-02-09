using System.Collections.Generic;
using Newtonsoft.Json;


namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class AnyOfferChangedNotification
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("OfferChangeTrigger")]
        public OfferChangeTrigger OfferChangeTrigger { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("Offers")]
        public List<OfferElement> Offers { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("SellerId")]
        public string SellerId { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("Summary")]
        public Summary Summary { get; set; }
    }

}