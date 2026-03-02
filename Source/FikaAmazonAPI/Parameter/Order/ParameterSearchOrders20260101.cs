using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

/// <summary>
/// Code Generated then Edited from:
/// https://github.com/amzn/selling-partner-api-models/blob/main/models/orders-api-model/orders_2026-01-01.json
/// </summary>

namespace FikaAmazonAPI.Parameter.Order
{
    /// <summary>
    /// Parameters for the searchOrders endpoint (Orders API v2026-01-01).
    /// Replaces ParameterOrderList from v0.
    /// 
    /// Key differences from v0 ParameterOrderList:
    /// - NextToken -> paginationToken (expires 24 hours)
    /// - OrderStatuses -> fulfillmentStatuses (upper snake case values) (Still SCREAMING_SNAKE_CASE for me)
    /// - FulfillmentChannels -> fulfilledBy (MERCHANT/AMAZON instead of MFN/AFN)
    /// - PaymentMethods, BuyerEmail, EasyShipShipmentStatuses removed
    /// - includedData parameter for flexible data retrieval
    /// - No RDT required for PII access (role-based instead)
    /// </summary>
    [CamelCase]
    public class ParameterSearchOrders20260101 : ParameterBased
    {
        /// <summary>
        /// A list of marketplace identifiers. Max count: 50.
        /// </summary>
        public ICollection<string> MarketplaceIds { get; set; }

        /// <summary>
        /// A date used for selecting orders that were last updated after (or at) a specified time.
        /// The date must be in ISO 8601 format.
        /// </summary>
        public DateTime? LastUpdatedAfter { get; set; }

        /// <summary>
        /// A date used for selecting orders that were last updated before (or at) a specified time.
        /// The date must be in ISO 8601 format.
        /// </summary>
        public DateTime? LastUpdatedBefore { get; set; }

        /// <summary>
        /// A date used for selecting orders created after (or at) a specified time.
        /// The date must be in ISO 8601 format.
        /// </summary>
        public DateTime? CreatedAfter { get; set; }

        /// <summary>
        /// A date used for selecting orders created before (or at) a specified time.
        /// The date must be in ISO 8601 format.
        /// </summary>
        public DateTime? CreatedBefore { get; set; }

        /// <summary>
        /// Maximum number of results per page.
        /// </summary>
        public int? MaxResultsPerPage { get; set; } = 100;

        /// <summary>
        /// Pagination token from a previous response. Expires after 24 hours.
        /// Replaces NextToken from v0.
        /// </summary>
        public string PaginationToken { get; set; }

        /// <summary>
        /// A list of fulfillment status values used to filter the results.
        /// Replaces OrderStatuses from v0.
        /// Values: UNSHIPPED, PARTIALLY_SHIPPED, SHIPPED, CANCELLED, PENDING, 
        /// UNFULFILLABLE, PENDING_AVAILABILITY, INVOICE_UNCONFIRMED.
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public ICollection<FulfillmentStatus20260101> FulfillmentStatuses { get; set; }

        /// <summary>
        /// A list that indicates how an order was fulfilled.
        /// Replaces FulfillmentChannels from v0.
        /// Values: MERCHANT (was MFN), AMAZON (was AFN).
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public ICollection<FulfilledBy20260101> FulfilledBy { get; set; }

        /// <summary>
        /// A list of AmazonOrderId values. Max count: 50.
        /// </summary>
        public ICollection<string> AmazonOrderIds { get; set; }

        /// <summary>
        /// Specifies which data to include in the response.
        /// Values: BUYER, RECIPIENT, FULFILLMENT, PROCEEDS, EXPENSE, PROMOTION, CANCELLATION, PACKAGES.
        /// The less data requested, the better the performance.
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public ICollection<IncludedData20260101> IncludedData { get; set; }

        /// <summary>
        /// Maximum number of pages to retrieve (client-side pagination control, not sent to API).
        /// </summary>
        [IgnoreToAddParameter]
        public int? MaxNumberOfPages { get; set; }
    }
}
