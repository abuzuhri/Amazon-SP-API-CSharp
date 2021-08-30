using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class Summary
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("BuyBoxPrices")]
        public List<BuyBoxPriceElement> BuyBoxPrices { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("CompetitivePriceThreshold")]
        public MoneyType CompetitivePriceThreshold { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("ListPrice")]
        public MoneyType ListPrice { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("LowestPrices")]
        public List<LowestPriceElement> LowestPrices { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("MinimumAdvertisedPrice")]
        public MoneyType MinimumAdvertisedPrice { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("NumberOfBuyBoxEligibleOffers")]
        public List<NumberOfBuyBoxEligibleOfferElement> NumberOfBuyBoxEligibleOffers { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("NumberOfOffers")]
        public List<NumberOfOfferElement> NumberOfOffers { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("SalesRankings")]
        public List<SalesRankingElement> SalesRankings { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("SuggestedLowerPricePlusShipping")]
        public MoneyType SuggestedLowerPricePlusShipping { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("TotalBuyBoxEligibleOffers")]
        public long TotalBuyBoxEligibleOffers { get; set; }

        public List<BuyBoxEligibleOfferElement> BuyBoxEligibleOffers { get; set; }
    }
}
