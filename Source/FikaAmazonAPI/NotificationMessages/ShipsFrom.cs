using Newtonsoft.Json;


namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class ShipsFrom
    {
        /// <summary>
        /// Optional. The state from where the item is shipped.
        /// </summary>
        [JsonProperty("State")]
        public string State { get; set; }

        /// <summary>
        /// Optional. The country from where the item is shipped.
        /// </summary>
        [JsonProperty("Country")]
        public string Country { get; set; }
    }
}
