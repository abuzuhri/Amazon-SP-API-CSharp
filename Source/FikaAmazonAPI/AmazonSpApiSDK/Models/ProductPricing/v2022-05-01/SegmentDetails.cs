using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing.v2022_05_01
{
    /// <summary>
    /// The details about the segment. The FeaturedOfferExpectedPrice API uses only the
    /// sampleLocation portion as input.
    /// </summary>
    public class SegmentDetails
    {
        /// <summary>
        /// The glance view weighted percentage for this segment, as a percentage of total
        /// glance views across all segments for the ASIN.
        /// </summary>
        [JsonProperty("glanceViewWeightPercentage")]
        public decimal? GlanceViewWeightPercentage { get; set; }

        /// <summary>
        /// The representative location that features the offer for the segment.
        /// </summary>
        [JsonProperty("sampleLocation")]
        public SampleLocation SampleLocation { get; set; }
    }
}
