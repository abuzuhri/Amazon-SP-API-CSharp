using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class ShippingTime
    {
        /// <summary>
        /// Optional. The maximum time, in hours, that the item will likely be shipped after the order has been placed.
        /// </summary>
        [JsonProperty("MinimumHours")]
        public short? MinimumHours { get; set; }

        /// <summary>
        /// Optional. The minimum time, in hours, that the item will likely be shipped after the order has been placed.
        /// </summary>
        [JsonProperty("MaximumHours")]
        public short? MaximumHours { get; set; }

        /// <summary>
        /// Optional. The date when the item will be available for shipping. Only displayed for items that are not currently available for shipping.
        /// </summary>
        [JsonProperty("AvailableDate")]
        public string AvailableDate { get; set; }

        /// <summary>
        /// Optional. Indicates whether the item is available for shipping now, or on a known or an unknown date in the future. If known, the availableDate attribute indicates the date that the item will be available for shipping.
        /// </summary>
        [JsonProperty("AvailabilityType")]
        public string AvailabilityType { get; set; }
    }
}
