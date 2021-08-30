using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class OfferPoints
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("PointsNumber")]
        public long PointsNumber { get; set; }
    }
}
