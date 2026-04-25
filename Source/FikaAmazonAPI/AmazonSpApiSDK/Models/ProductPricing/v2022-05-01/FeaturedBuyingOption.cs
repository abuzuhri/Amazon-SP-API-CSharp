using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// Describes a featured buying option, which includes a list of segmented featured offers
    /// for a particular item condition.
    /// </summary>
    public class FeaturedBuyingOption
    {
        /// <summary>
        /// The buying option type for the featured offer (e.g., New, B2B, Fresh, Subscribe and Save).
        /// Currently only `New` is documented; modeled as string for forward compatibility.
        /// </summary>
        [JsonProperty("buyingOptionType")]
        public string BuyingOptionType { get; set; }

        [JsonProperty("segmentedFeaturedOffers")]
        public List<SegmentedFeaturedOffer> SegmentedFeaturedOffers { get; set; }
    }
}
