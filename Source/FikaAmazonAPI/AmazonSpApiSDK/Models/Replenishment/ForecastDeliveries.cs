using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Projected subscriber demand for an offer over different time horizons.</summary>
    public class ForecastDeliveries
    {
        [JsonProperty("next15DaysDeliveries")]
        public long? Next15DaysDeliveries { get; set; }

        [JsonProperty("next30DaysDeliveries")]
        public long? Next30DaysDeliveries { get; set; }

        [JsonProperty("next60DaysDeliveries")]
        public long? Next60DaysDeliveries { get; set; }

        [JsonProperty("next90DaysDeliveries")]
        public long? Next90DaysDeliveries { get; set; }
    }
}
