using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    public class SummaryB2B : SummaryBase
    {
        /// <summary>
        /// Required. A list that contains the lowest prices of the item for the given conditions, fulfillment channels, quantity tiers, and discount types.
        /// </summary>
        /// <remarks>
        /// The seven pre-defined quantity tiers for discount type “Quantity Discounts” are 2, 3, 5, 10, 20, 30 and 50.
        /// </remarks>
        [JsonProperty("LowestPrices")]
        public List<LowestPriceB2B> LowestPrices { get; set; }

        /// <summary>
        /// Optional. A list that contains the Buy Box price of the item for the given conditions, quantity tiers, and discount types.
        /// </summary>
        /// <remarks>
        /// Up to the first 50 quantity tiers are shown.
        /// </remarks>
        [JsonProperty("BuyBoxPrices")]
        public List<BuyBoxPriceB2B> BuyBoxPrices { get; set; }

        /// <summary>
        /// Required. A list that contains the total number of offers that are eligible for the Buy Box for the given conditions and fulfillment channels.
        /// </summary>
        [JsonProperty("BuyBoxEligibleOffers")]
        public override List<OfferCountElement> BuyBoxEligibleOffers { get; set; }
    }
}
