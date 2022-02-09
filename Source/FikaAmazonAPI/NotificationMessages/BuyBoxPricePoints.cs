using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class BuyBoxPricePoints
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("PointsNumber")]
        public long PointsNumber { get; set; }
    }
}
