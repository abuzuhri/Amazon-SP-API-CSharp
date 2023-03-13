using System.Collections.Generic;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    public class FeaturedOfferExpectedPriceResponseBody
    {
        /// <summary>
        /// Metadata that identifies the target offer for which the featured offer expected price result data was computed.
        /// </summary>
        [JsonProperty("offerIdentifier")]
        public OfferIdentifier OfferIdentifier { get; set; }

        /// <summary>
        /// The featured offer expected price results for the requested target offer.
        /// </summary>
        [JsonProperty("featuredOfferExpectedPriceResults")]
        public List<FeaturedOfferExpectedPriceResult> FeaturedOfferExpectedPriceResultList { get; set; }

        /// <summary>
        /// The errors that occurred if the operation was not successful (HTTP status code non-200).
        /// </summary>
        [JsonProperty("errors")]
        public ErrorList ErrorList { get; set; }
    }
}