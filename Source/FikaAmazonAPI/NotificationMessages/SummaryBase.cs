using System.Collections.Generic;
using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public abstract class SummaryBase
    {
        /// <summary>
        /// Required. A list that contains the total number of offers for the item for the given conditions and fulfillment channels.
        /// </summary>
        [JsonProperty("NumberOfOffers")]
        public List<OfferCountElement> NumberOfOffers { get; set; }

        /// <summary>
        /// Required. A list that contains the total number of offers that are eligible for the Buy Box for the given conditions and fulfillment channels.
        /// </summary>
        public abstract List<OfferCountElement> BuyBoxEligibleOffers { get; set; }
    }
}
