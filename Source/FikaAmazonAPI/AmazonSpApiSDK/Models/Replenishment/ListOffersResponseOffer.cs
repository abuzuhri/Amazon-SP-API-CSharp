using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>Details about an offer returned by listOffers.</summary>
    public class ListOffersResponseOffer
    {
        /// <summary>SKU. Sellers only.</summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("asin")]
        public string Asin { get; set; }

        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }

        [JsonProperty("eligibility")]
        public EligibilityStatus? Eligibility { get; set; }

        [JsonProperty("offerProgramConfiguration")]
        public OfferProgramConfiguration OfferProgramConfiguration { get; set; }

        [JsonProperty("programType")]
        public ProgramType? ProgramType { get; set; }

        [JsonProperty("vendorCodes")]
        public List<string> VendorCodes { get; set; }

        /// <summary>Listed price amount for the item.</summary>
        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("priceCurrencyCode")]
        public string PriceCurrencyCode { get; set; }

        [JsonProperty("inventory")]
        public long? Inventory { get; set; }

        /// <summary>Stock risk level — risk of going out of stock.</summary>
        [JsonProperty("stockRisk")]
        public string StockRisk { get; set; }

        /// <summary>Per-condition delivery health for the next 30 days.</summary>
        [JsonProperty("deliveriesConditions")]
        public List<DeliveriesCondition> DeliveriesConditions { get; set; }

        [JsonProperty("subscriptions")]
        public long? Subscriptions { get; set; }

        [JsonProperty("fulfillmentNetworkIDType")]
        public string FulfillmentNetworkIDType { get; set; }

        [JsonProperty("forecastDeliveries")]
        public ForecastDeliveries ForecastDeliveries { get; set; }
    }
}
