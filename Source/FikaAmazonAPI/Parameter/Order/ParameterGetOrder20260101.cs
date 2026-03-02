using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101;
using FikaAmazonAPI.Search;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

/// <summary>
/// Code Generated then Edited from:
/// https://github.com/amzn/selling-partner-api-models/blob/main/models/orders-api-model/orders_2026-01-01.json
/// </summary>

namespace FikaAmazonAPI.Parameter.Order
{
    /// <summary>
    /// Parameters for the getOrder endpoint (Orders API v2026-01-01).
    /// Replaces ParameterGetOrder from v0.
    /// 
    /// Key differences from v0:
    /// - No RDT required: PII access is role-based.
    /// - includedData parameter replaces separate GetOrderBuyerInfo/GetOrderAddress/GetOrderItems calls.
    /// - Order items are always included in the response.
    /// 
    /// </summary>
    [CamelCase]
    public class ParameterGetOrder20260101 : ParameterBased
    {
        /// <summary>
        /// The Amazon order identifier (path parameter).
        /// </summary>
        [PathParameter]
        public string OrderId { get; set; }

        /// <summary>
        /// Specifies which additional data to include in the response.
        /// Values: BUYER, RECIPIENT, FULFILLMENT, PROCEEDS, EXPENSE, PROMOTION, CANCELLATION, PACKAGES.
        /// Order items are always included regardless of this parameter.
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public ICollection<IncludedData20260101> IncludedData { get; set; }
    }
}
