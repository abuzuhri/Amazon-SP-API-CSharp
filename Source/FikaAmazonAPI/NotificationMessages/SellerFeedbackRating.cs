using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class SellerFeedbackRating
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("FeedbackCount")]
        public long FeedbackCount { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("SellerPositiveFeedbackRating")]
        public long SellerPositiveFeedbackRating { get; set; }
    }
}
