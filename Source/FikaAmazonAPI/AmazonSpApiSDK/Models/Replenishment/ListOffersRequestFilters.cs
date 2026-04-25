using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Filters for listOffers. marketplaceId and programTypes are required; all other fields are optional.
    /// Note: deliveriesConditions filter and inventory/price sorting were added in the April 2026 release.
    /// </summary>
    public class ListOffersRequestFilters
    {
        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }

        /// <summary>SKU filter (sellers only). 1–20 entries.</summary>
        [JsonProperty("skus")]
        public List<string> Skus { get; set; }

        /// <summary>ASIN filter. 1–20 entries.</summary>
        [JsonProperty("asins")]
        public List<string> Asins { get; set; }

        [JsonProperty("eligibilities")]
        public List<EligibilityStatus> Eligibilities { get; set; }

        [JsonProperty("preferences")]
        public Preference Preferences { get; set; }

        [JsonProperty("promotions")]
        public Promotion Promotions { get; set; }

        [JsonProperty("programTypes")]
        public List<ProgramType> ProgramTypes { get; set; }

        /// <summary>
        /// Delivery condition types to filter by — paused, at-risk, or healthy. Added April 2026.
        /// </summary>
        [JsonProperty("deliveriesConditions")]
        public List<DeliveryConditionType> DeliveriesConditions { get; set; }
    }
}
