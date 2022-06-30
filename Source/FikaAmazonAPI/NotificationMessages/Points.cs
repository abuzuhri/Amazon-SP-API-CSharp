using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class Points
    {
        /// <summary>
        /// Required. The number of Amazon Points offered with the purchase of an item.
        /// </summary>
        [JsonProperty("PointsNumber")]
        public long PointsNumber { get; set; }
    }
}
