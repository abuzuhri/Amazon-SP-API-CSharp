using Newtonsoft.Json;
using System;
using System.Collections.Generic;

/// <summary>
/// Code Generated then Edited from:
/// https://github.com/amzn/selling-partner-api-models/blob/main/models/orders-api-model/orders_2026-01-01.json
/// </summary>

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101
{
    /// <summary>
    /// Represents an order in the Orders API v2026-01-01.
    /// </summary>
    public class Order20260101
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("orderAliases")]
        public IList<OrderAlias> OrderAliases { get; set; }

        [JsonProperty("salesChannel")]
        public SalesChannel SalesChannel { get; set; }

        [JsonProperty("createdTime")]
        public DateTime? CreatedTime { get; set; }

        [JsonProperty("lastUpdatedTime")]
        public DateTime? LastUpdatedTime { get; set; }

        [JsonProperty("programs")]
        public IList<string> Programs { get; set; }

        [JsonProperty("associatedOrders")]
        public IList<AssociatedOrder> AssociatedOrders { get; set; }

        [JsonProperty("fulfillment")]
        public OrderFulfillment Fulfillment { get; set; }

        [JsonProperty("buyer")]
        public Buyer Buyer { get; set; }

        [JsonProperty("recipient")]
        public Recipient Recipient { get; set; }

        [JsonProperty("proceeds")]
        public OrderProceeds Proceeds { get; set; }

        [JsonProperty("packages")]
        public IList<Package> Packages { get; set; }

        [JsonProperty("orderItems")]
        public IList<OrderItem20260101> OrderItems { get; set; }
    }

    public class OrderAlias
    {
        [JsonProperty("aliasType")]
        public string AliasType { get; set; }

        [JsonProperty("aliasId")]
        public string AliasId { get; set; }
    }

    public class SalesChannel
    {
        [JsonProperty("marketplaceId")]
        public string MarketplaceId { get; set; }

        [JsonProperty("marketplaceName")]
        public string MarketplaceName { get; set; }
    }

    public class AssociatedOrder
    {
        [JsonProperty("associationType")]
        public string AssociationType { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }
    }
}
