using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// A product offer with segment information indicating where it's featured.
    /// In the spec this composes Offer via allOf; we model it as a subclass for the
    /// usual base-fields-then-segments layout.
    /// </summary>
    public class SegmentedFeaturedOffer : Offer
    {
        /// <summary>The list of segment information in which the offer is featured.</summary>
        [JsonProperty("featuredOfferSegments")]
        public List<FeaturedOfferSegment> FeaturedOfferSegments { get; set; }
    }
}
