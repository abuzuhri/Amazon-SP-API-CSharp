using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    public class SummaryB2B : SummaryBase
    {
        /// <summary>
        /// Required. A list that contains the total number of offers that are eligible for the Buy Box for the given conditions and fulfillment channels.
        /// </summary>
        [JsonProperty("BuyBoxEligibleOffers")]
        public override List<OfferCountElement> BuyBoxEligibleOffers { get; set; }
    }
}
