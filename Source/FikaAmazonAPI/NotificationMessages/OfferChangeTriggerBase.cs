using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public abstract class OfferChangeTriggerBase
    {
        /// <summary>
        /// Required. The marketplace identifier of the item that had an offer change.
        /// </summary>
        [JsonProperty("MarketplaceId")]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// Required. The ASIN for the item that had an offer change.
        /// </summary>
        [JsonProperty("ASIN")]
        public string Asin { get; set; }

        /// <summary>
        /// Required. The condition of the item that had an offer change. For example, if a used offer changes, the array of offers in the Offers object will be only used items. The Summary object provides a summary for the other conditions that can be used for repricing.
        /// </summary>
        [JsonProperty("ItemCondition")]
        public string ItemCondition { get; set; }

        /// <summary>
        /// Required. The update time for the offer that caused this notification, in ISO 8601 format.
        /// </summary>
        [JsonProperty("TimeOfOfferChange")]
        public string TimeOfOfferChange { get; set; }
    }
}
