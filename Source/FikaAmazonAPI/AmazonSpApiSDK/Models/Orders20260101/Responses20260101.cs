using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Code Generated then Edited from:
/// https://github.com/amzn/selling-partner-api-models/blob/main/models/orders-api-model/orders_2026-01-01.json
/// </summary>

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101
{
    /// <summary>
    /// Response wrapper for searchOrders.
    /// </summary>
    public class SearchOrdersResponse
    {
        [JsonProperty("orders")]
        public IList<Order20260101> Orders { get; set; }

        [JsonProperty("paginationToken")]
        public string PaginationToken { get; set; }
    }

    /// <summary>
    /// Response wrapper for getOrder.
    /// </summary>
    public class GetOrderResponse20260101
    {
        [JsonProperty("order")]
        public Order20260101 Order { get; set; }
    }

    /// <summary>
    /// Error response model.
    /// </summary>
    public class OrdersError20260101
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }
    }

    /// <summary>
    /// Envelope for error responses from the Orders API v2026-01-01.
    /// </summary>
    public class ErrorList20260101
    {
        [JsonProperty("errors")]
        public IList<OrdersError20260101> Errors { get; set; }
    }
}
