using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101;
using FikaAmazonAPI.RestSharp;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

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
    public class ParameterSearchOrders : ParameterBased
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
        [IgnoreToAddParameter]
        public ICollection<FulfillmentStatus20260101> FulfillmentStatuses { get; set; }

        /// <summary>
        /// A list that indicates how an order was fulfilled.
        /// Replaces FulfillmentChannels from v0.
        /// Values: MERCHANT (was MFN), AMAZON (was AFN).
        /// </summary>
        [IgnoreToAddParameter]
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
        [IgnoreToAddParameter]
        public ICollection<IncludedData20260101> IncludedData { get; set; }

        /// <summary>
        /// Maximum number of pages to retrieve (client-side pagination control, not sent to API).
        /// </summary>
        [IgnoreToAddParameter]
        public int? MaxNumberOfPages { get; set; }


        //?createdAfter=2025-01-01T00%3A00%3A00Z&
        //createdBefore=2025-01-01T00%3A00%3A00Z&
        //lastUpdatedAfter=2025-01-01T00%3A00%3A00Z&
        //lastUpdatedBefore=2025-01-01T00%3A00%3A00Z&
        //fulfillmentStatuses=PENDING,UNSHIPPED&
        //marketplaceIds=ATVPDKIKX0DER,ATV2222222222&
        //fulfilledBy=MERCHANT,AMAZON&
        //includedData=BUYER,RECIPIENT' \

        //fulfillmentStatuses=PENDING,UNSHIPPED&
        //marketplaceIds=ATVPDKIKX0DER,ATV2222222222&
        //fulfilledBy=MERCHANT,AMAZON&
        //includedData=BUYER,RECIPIENT' \

        public List<KeyValuePair<string,string>> getParameters()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            //DataTimes
            if(LastUpdatedAfter.HasValue)
            {
                string timeURL = ParameterSearchOrders.FormatDate(LastUpdatedAfter.GetValueOrDefault());
                parameters.Add(new KeyValuePair<string,string>("lastUpdatedAfter", timeURL));
            }

            if(LastUpdatedBefore.HasValue)
            {
                string timeURL = ParameterSearchOrders.FormatDate(LastUpdatedBefore.GetValueOrDefault());
                parameters.Add(new KeyValuePair<string, string>("lastUpdatedBefore", timeURL));
            }

            if (CreatedAfter.HasValue)
            {
                string timeURL = ParameterSearchOrders.FormatDate(CreatedAfter.GetValueOrDefault());
                parameters.Add(new KeyValuePair<string, string>("createdAfter", timeURL));
            }

            if (CreatedBefore.HasValue)
            {
                string timeURL = ParameterSearchOrders.FormatDate(CreatedBefore.GetValueOrDefault());
                parameters.Add(new KeyValuePair<string, string>("createdBefore", timeURL));
            }

            // Basic Types
            if(MaxResultsPerPage != null)
            {
                parameters.Add(new KeyValuePair<string, string>("maxResultsPerPage", MaxResultsPerPage.Value.ToString()));
            }

            if(! /* NOT */ string.IsNullOrEmpty(PaginationToken))
            {
                parameters.Add(new KeyValuePair<string, string>("paginationToken",PaginationToken));
            }

            // Enums
            if (FulfillmentStatuses != null && FulfillmentStatuses.Count > 0)
            {
                parameters.Add(new KeyValuePair<string, string>("fulfillmentStatuses", JoinEnums(FulfillmentStatuses)));
            }

            if (IncludedData != null && IncludedData.Count > 0)
            {
                parameters.Add(new KeyValuePair<string, string>("includedData", JoinEnums(IncludedData)));
            }

            if (FulfilledBy != null && FulfilledBy.Count > 0)
            {
                parameters.Add(new KeyValuePair<string, string>("fulfilledBy", JoinEnums(FulfilledBy)));
            }

            // List/Collections
            if (MarketplaceIds != null && MarketplaceIds.Count > 0)
            {
                parameters.Add(new KeyValuePair<string, string>("marketplaceIds", string.Join(",", MarketplaceIds)));
            }

            return parameters;

        }

        // Helpers

        private static string FormatDate(DateTime dt)
        {
            return dt.ToUniversalTime().ToString(Constants.DateISO8601Format);
        }

        private static string JoinEnums<T>(ICollection<T> values) where T : Enum
        {
            return string.Join(",", values.Select(GetEnumMemberValue));
        }

        private static string GetEnumMemberValue<T>(T enumValue) where T : Enum
        {
            var member = typeof(T).GetMember(enumValue.ToString()).FirstOrDefault();
            var attr = member?.GetCustomAttribute<EnumMemberAttribute>();
            return attr?.Value ?? enumValue.ToString();
        }
    }
}