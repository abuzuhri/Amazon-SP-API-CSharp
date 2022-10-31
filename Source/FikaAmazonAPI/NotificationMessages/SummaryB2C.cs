using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    public class SummaryB2C : SummaryBase
    {
        /// <summary>
        /// Required. A list that contains the lowest prices of the item for the given conditions and fulfillment channels.
        /// </summary>
        [JsonProperty("LowestPrices")]
        public List<LowestPriceB2C> LowestPrices { get; set; }

        /// <summary>
        /// Optional. A list that contains the Buy Box price of the item for the given conditions.
        /// </summary>
        [JsonProperty("BuyBoxPrices")]
        public List<BuyBoxPriceB2C> BuyBoxPrices { get; set; }

        /// <summary>
        /// Optional. The list price of the item as suggested by the manufacturer.
        /// </summary>
        [JsonProperty("ListPrice")]
        public MoneyType ListPrice { get; set; }

        /// <summary>
        /// Optional. The suggested lower price of the item, including shipping (minus Amazon Points). The suggested lower price is based on a range of factors, including historical selling prices, recent Buy Box-eligible prices, and input from customers for your products.
        /// </summary>
        [JsonProperty("SuggestedLowerPricePlusShipping")]
        public MoneyType SuggestedLowerPricePlusShipping { get; set; }

        /// <summary>
        /// Optional. A list that contains the sales rank of the item in the given product categories.
        /// </summary>
        [JsonProperty("SalesRankings")]
        public List<SalesRank> SalesRankings { get; set; }

        /// <summary>
        /// Required. A list that contains the total number of offers that are eligible for the Buy Box for the given conditions and fulfillment channels.
        /// </summary>
        [JsonProperty("NumberOfBuyBoxEligibleOffers")]
        public override List<OfferCountElement> BuyBoxEligibleOffers { get; set; }

        /// <summary>
        /// Optional. This price is based on competitive prices from other retailers (excluding other Amazon sellers). Your offer may be ineligible for the Buy Box if your price + shipping is greater than this competitive price.
        /// </summary>
        [JsonProperty("CompetitivePriceThreshold")]
        public MoneyType CompetitivePriceThreshold { get; set; }
    }
}
