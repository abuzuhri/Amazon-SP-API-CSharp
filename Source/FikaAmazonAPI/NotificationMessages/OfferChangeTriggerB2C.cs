using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    public class OfferChangeTriggerB2C : OfferChangeTriggerBase
    {
        /// <summary>
        /// Required. The type of offer that changed and triggered this notification.
        /// </summary>
        /// <remarks>
        /// OfferChangeType values:
        /// External - The CompetitivePriceThreshold in the Summary object has changed, triggered by a new offer from a non-Amazon seller.
        /// Internal - The price of an offer on Amazon's retail website has changed.
        /// Featured Offer - The BuyBox winner or BuyBox price has changed.
        /// </remarks>
        [JsonProperty("OfferChangeType")]
        public string OfferChangeType { get; set; }
    }
}
