using Newtonsoft.Json;
using System;

/// <summary>
/// Code Generated then Edited from:
/// https://github.com/amzn/selling-partner-api-models/blob/main/models/orders-api-model/orders_2026-01-01.json
/// </summary>

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101
{
    /// <summary>
    /// Shipping package information. New in v2026-01-01.
    /// Requires includedData=PACKAGES.
    /// </summary>
    public class Package
    {
        [JsonProperty("packageReferenceId")]
        public string PackageReferenceId { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty("shippingService")]
        public string ShippingService { get; set; }

        [JsonProperty("packageStatus")]
        public PackageStatus PackageStatus { get; set; }

        [JsonProperty("createdTime")]
        public DateTime? CreatedTime { get; set; }

        [JsonProperty("shipTime")]
        public DateTime? ShipTime { get; set; }

        [JsonProperty("shipFromAddress")]
        public DeliveryAddress ShipFromAddress { get; set; }
    }

    public class PackageStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("detailedStatus")]
        public string DetailedStatus { get; set; }
    }
}
