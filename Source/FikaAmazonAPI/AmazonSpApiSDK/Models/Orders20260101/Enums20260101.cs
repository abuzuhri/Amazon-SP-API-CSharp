using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

/// <summary>
/// Code Generated then Edited from:
/// https://github.com/amzn/selling-partner-api-models/blob/main/models/orders-api-model/orders_2026-01-01.json
/// </summary>

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101
{
    /// <summary>
    /// Values for the includedData query parameter in the Orders API v2026-01-01.
    /// Controls which data is returned in the response.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IncludedData20260101
    {
        [EnumMember(Value = "BUYER")]
        BUYER,

        [EnumMember(Value = "RECIPIENT")]
        RECIPIENT,

        [EnumMember(Value = "FULFILLMENT")]
        FULFILLMENT,

        [EnumMember(Value = "PROCEEDS")]
        PROCEEDS,

        [EnumMember(Value = "EXPENSE")]
        EXPENSE,

        [EnumMember(Value = "PROMOTION")]
        PROMOTION,

        [EnumMember(Value = "CANCELLATION")]
        CANCELLATION,

        [EnumMember(Value = "PACKAGES")]
        PACKAGES
    }

    /// <summary>
    /// Fulfillment status values in v2026-01-01 (replaces OrderStatuses from v0).
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FulfillmentStatus20260101
    {
        [EnumMember(Value = "UNSHIPPED")]
        UNSHIPPED,

        [EnumMember(Value = "PARTIALLY_SHIPPED")]
        PARTIALLY_SHIPPED,

        [EnumMember(Value = "SHIPPED")]
        SHIPPED,

        [EnumMember(Value = "CANCELLED")]
        CANCELLED,

        [EnumMember(Value = "PENDING")]
        PENDING,

        [EnumMember(Value = "UNFULFILLABLE")]
        UNFULFILLABLE,

        [EnumMember(Value = "PENDING_AVAILABILITY")]
        PENDING_AVAILABILITY,

        [EnumMember(Value = "INVOICE_UNCONFIRMED")]
        INVOICE_UNCONFIRMED
    }

    /// <summary>
    /// FulfilledBy values in v2026-01-01 (replaces FulfillmentChannels from v0).
    /// MFN -> MERCHANT, AFN -> AMAZON.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FulfilledBy20260101
    {
        [EnumMember(Value = "MERCHANT")]
        MERCHANT,

        [EnumMember(Value = "AMAZON")]
        AMAZON
    }
}
