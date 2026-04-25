using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The lowest priced offers for the specified item condition and offer type.
    /// </summary>
    public class LowestPricedOffer
    {
        [JsonProperty("lowestPricedOffersInput")]
        public LowestPricedOffersInput LowestPricedOffersInput { get; set; }

        [JsonProperty("offers")]
        public List<Offer> Offers { get; set; }
    }
}
