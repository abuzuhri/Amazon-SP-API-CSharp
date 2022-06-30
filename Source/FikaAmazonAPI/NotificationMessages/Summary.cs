using System.Collections.Generic;
using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class Summary
    {
        /// <summary>
        /// Required. A list that contains the total number of offers for the item for the given conditions and fulfillment channels.
        /// </summary>
        [JsonProperty("NumberOfOffers")]
        public List<OfferCountElement> NumberOfOffers { get; set; }

        /// <summary>
        /// Required. A list that contains the lowest prices of the item for the given conditions and fulfillment channels.
        /// </summary>
        [JsonProperty("LowestPrices")]
        public List<LowestPrice> LowestPrices { get; set; }

        /// <summary>
        /// Optional. A list that contains the Buy Box price of the item for the given conditions.
        /// </summary>
        [JsonProperty("BuyBoxPrices")]
        public List<BuyBoxPrice> BuyBoxPrices { get; set; }

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
        /// Obsolete. Leaved only for proper deserialization, use BuyBoxEligibleOffers instead.
        /// </summary>
        [JsonProperty("NumberOfBuyBoxEligibleOffers")]
        [System.Obsolete("NumberOfBuyBoxEligibleOffers is obsolete, use BuyBoxEligibleOffers", false)]
        public List<OfferCountElement> NumberOfBuyBoxEligibleOffers
        {
            get { return BuyBoxEligibleOffers; }
            set { BuyBoxEligibleOffers = value; }
        }

        /// <summary>
        /// Required. A list that contains the total number of offers that are eligible for the Buy Box for the given conditions and fulfillment channels.
        /// </summary>
        [JsonProperty("BuyBoxEligibleOffers")]
        public List<OfferCountElement> BuyBoxEligibleOffers { get; set; }

        /// <summary>
        /// Optional. This price is based on competitive prices from other retailers (excluding other Amazon sellers). Your offer may be ineligible for the Buy Box if your price + shipping is greater than this competitive price.
        /// </summary>
        [JsonProperty("CompetitivePriceThreshold")]
        public MoneyType CompetitivePriceThreshold { get; set; }
    }
}
