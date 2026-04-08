using FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101;
using FikaAmazonAPI.Search;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.Order.V20260101
{
    [CamelCase]
    public class ParameterSearchOrders : ParameterBased
    {
        public ParameterSearchOrders()
        {
        }

        /// <summary>
        /// The response includes orders created at or after this time. The date must be in ISO 8601 format.
        /// Note: You must provide exactly one of createdAfter and lastUpdatedAfter in your request.If createdAfter is provided, neither lastUpdatedAfter nor lastUpdatedBefore may be provided.
        /// </summary>
        public DateTime? CreatedAfter { get; set; }

        /// <summary>
        /// A date used for selecting orders created before (or at) a specified time. Only orders placed before the specified time are returned. The date must be in ISO 8601 format.	
        /// </summary>
        public DateTime? CreatedBefore { get; set; }

        /// <summary>
        /// The response includes orders updated at or after this time. An update is defined as any change made by Amazon or by the seller, including an update to the order status. The date must be in ISO 8601 format.
        /// Note: You must provide exactly one of createdAfter and lastUpdatedAfter.If lastUpdatedAfter is provided, neither createdAfter nor createdBefore may be provided.
        /// </summary>
        public DateTime? LastUpdatedAfter { get; set; }

        /// <summary>
        /// The response includes orders updated at or before this time.An update is defined as any change made by Amazon or by the seller, including an update to the order status.The date must be in ISO 8601 format.
        /// Note: If you include lastUpdatedAfter in the request, lastUpdatedBefore is optional, and if provided must be equal to or after the lastUpdatedAfter date and at least two minutes before the time of the request.If lastUpdatedBefore is provided, neither createdAfter nor createdBefore may be provided.
        /// </summary>
        public DateTime? LastUpdatedBefore { get; set; }


        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        /// <summary>
        /// A list of FulfillmentStatus values you can use to filter the results.
        /// </summary>
        public ICollection<FulfillmentStatusEnum> FulfillmentStatuses { get; set; }

        /// <summary>
        /// A list of MarketplaceId values. Used to select orders that were placed in the specified marketplaces. Max count : 50
        /// </summary>
        public ICollection<string> MarketplaceIds { get; set; }

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        /// <summary>
        /// The response includes orders that are fulfilled by the parties that you include in this list.
        /// </summary>
        public ICollection<FulfilledByEnum> FulfilledBy { get; set; }

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        /// <summary>
        /// A list of datasets to include in the response.
        /// </summary>
        public ICollection<IncludedDataEnum> IncludedData { get; set; }

        /// <summary>
        /// The maximum number of orders that can be returned per page. The value must be between 1 and 100. Default: 100.
        /// </summary>
        public int? MaxResultsPerPage { get; set; } = 100;

        /// <summary>
        /// Pagination occurs when a request produces a response that exceeds the maxResultsPerPage. This means that the response is divided into individual pages. To retrieve the next page, you must pass the nextToken value as the paginationToken query parameter in the next request. You will not receive a nextToken value on the last page.
        /// </summary>
        public string PaginationToken { get; set; }

        /// <summary>
        /// Maximum number of pages to return
        /// </summary>
        public int? MaxNumberOfPages { get; set; }

    }
}
