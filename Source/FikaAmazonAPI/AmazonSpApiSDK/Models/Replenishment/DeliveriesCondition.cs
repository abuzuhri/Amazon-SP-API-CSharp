using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Delivery condition and the quantity of upcoming deliveries associated with that condition for an offer.
    /// </summary>
    public class DeliveriesCondition
    {
        [JsonProperty("condition")]
        public DeliveryConditionType? Condition { get; set; }

        /// <summary>The number of upcoming deliveries in the next 30 days associated with this condition.</summary>
        [JsonProperty("next30DaysDeliveries")]
        public long? Next30DaysDeliveries { get; set; }
    }
}
