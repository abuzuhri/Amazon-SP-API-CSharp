using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// Describes the segment in which an offer is featured.
    /// </summary>
    public class FeaturedOfferSegment
    {
        /// <summary>The customer membership type that makes up this segment.</summary>
        [JsonProperty("customerMembership")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomerMembership CustomerMembership { get; set; }

        /// <summary>Details about the segment.</summary>
        [JsonProperty("segmentDetails")]
        public SegmentDetails SegmentDetails { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CustomerMembership
    {
        PRIME,
        NON_PRIME,
        DEFAULT
    }
}
