using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class SellerFeedbackRating
    {
        /// <summary>
        /// Optional. The percentage of positive feedback for the seller in the past 365 days.
        /// </summary>
        [JsonProperty("SellerPositiveFeedbackRating")]
        public double? SellerPositiveFeedbackRating { get; set; }

        /// <summary>
        /// Required. The count of feedback received about the seller.
        /// </summary>
        [JsonProperty("FeedbackCount")]
        public long FeedbackCount { get; set; }
    }
}
