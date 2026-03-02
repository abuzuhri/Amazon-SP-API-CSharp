using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101;
using FikaAmazonAPI.AmazonSpApiSDK.Services;
using FikaAmazonAPI.Parameter.Order;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    /// <summary>
    /// Order service for the Orders API v2026-01-01.
    /// 
    /// Migration summary from v0:
    /// ─────────────────────────────────────────────────────────────────────────
    ///  v0 Operation              │ v2026-01-01 Operation
    /// ─────────────────────────────────────────────────────────────────────────
    ///  GetOrders                 │ SearchOrders
    ///  GetOrder                  │ GetOrder (with includedData)
    ///  GetOrderItems             │ GetOrder (items always included)
    ///  GetOrderBuyerInfo         │ GetOrder with includedData=BUYER
    ///  GetOrderAddress           │ GetOrder with includedData=RECIPIENT
    ///  GetOrderItemsBuyerInfo    │ GetOrder with includedData=BUYER
    /// ─────────────────────────────────────────────────────────────────────────
    /// 
    /// Key changes:
    /// - No Restricted Data Tokens (RDT) required for PII access.
    /// - Use includedData parameter for flexible data retrieval.
    /// - Pagination tokens expire after 24 hours.
    /// - FulfillmentChannels MFN/AFN replaced with MERCHANT/AMAZON.
    /// - OrderStatuses replaced with FulfillmentStatuses (upper snake case) (I personaly knows it as :SCREAMING_SNAKE_CASE).
    /// - New features: Package tracking, programs array, structured proceeds.
    /// 
    /// Infos from:
    /// https://developer-docs.amazon.com/sp-api/docs/orders-api-migration-guide
    /// https://developer-docs.amazon.com/sp-api/reference/searchorders
    /// https://developer-docs.amazon.com/sp-api/reference/getorder-3
    /// + Some inspiration from the code of the Python Respository:
    /// https://github.com/saleweaver/python-amazon-sp-api/tree/master
    /// </summary>
    public class OrderService20260101 : RequestService
    {
        public OrderService20260101(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory)
            : base(amazonCredential, loggerFactory)
        {

        }

        #region SearchOrders

        /// <summary>
        /// Synchronous wrapper for SearchOrdersAsync.
        /// Replaces GetOrders from v0.
        /// </summary>
        public IList<Order20260101> SearchOrders(ParameterSearchOrders20260101 parameter) =>
            Task.Run(() => SearchOrdersAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();

        /// <summary>
        /// Returns orders that are created or updated during the specified time period.
        /// Automatically handles pagination (respects MaxNumberOfPages if set).
        /// 
        /// Replaces GetOrdersAsync from v0.
        /// Also replaces the need for separate GetOrderBuyerInfo/GetOrderAddress calls
        /// when includedData contains BUYER/RECIPIENT.
        /// </summary>
        public async Task<IList<Order20260101>> SearchOrdersAsync(ParameterSearchOrders20260101 parameter, CancellationToken cancellationToken = default)
        {
            var allOrders = new List<Order20260101>();

            if (parameter.MarketplaceIds == null || parameter.MarketplaceIds.Count == 0)
            {
                parameter.MarketplaceIds = new List<string> { AmazonCredential.MarketPlace.ID };
            }

            var queryParameters = parameter.getParameters();

            await CreateAuthorizedRequestAsync(
                OrdersApiUrls20260101.SearchOrders,
                RestSharp.Method.Get,
                queryParameters,
                cancellationToken: cancellationToken);


            var response = await ExecuteRequestAsync<SearchOrdersResponse>(Utils.RateLimitType.Order20260101_SearchOrders, cancellationToken);

            if (response?.Orders != null)
            {
                allOrders.AddRange(response.Orders);
            }

            var paginationToken = response?.PaginationToken;
            int pageCount = 1;

            if (parameter.MaxNumberOfPages.HasValue && parameter.MaxNumberOfPages.Value == 1)
            {
                // Caller only wants one page; return results as-is
                return allOrders;
            }

            while (!string.IsNullOrEmpty(paginationToken))
            {
                cancellationToken.ThrowIfCancellationRequested();

                var nextPageResponse = await SearchOrdersByPaginationTokenAsync(paginationToken, parameter, cancellationToken);

                if (nextPageResponse?.Orders != null)
                {
                    allOrders.AddRange(nextPageResponse.Orders);
                }

                paginationToken = nextPageResponse?.PaginationToken;

                if (parameter.MaxNumberOfPages.HasValue)
                {
                    pageCount++;
                    if (pageCount >= parameter.MaxNumberOfPages.Value)
                        break;
                }
            }

            return allOrders;
        }

        /// <summary>
        /// Synchronous wrapper for SearchOrdersPageAsync.
        /// Returns a single page of results (no auto-pagination).
        /// </summary>
        public SearchOrdersResponse SearchOrdersPage(ParameterSearchOrders20260101 parameter) =>
            Task.Run(() => SearchOrdersPageAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();

        /// <summary>
        /// Returns a single page of searchOrders results without automatic pagination.
        /// Replaces GetOrdersListAsync from v0.
        /// </summary>
        public async Task<SearchOrdersResponse> SearchOrdersPageAsync(ParameterSearchOrders20260101 parameter, CancellationToken cancellationToken = default)
        {
            if (parameter.MarketplaceIds == null || parameter.MarketplaceIds.Count == 0)
            {
                parameter.MarketplaceIds = new List<string> { AmazonCredential.MarketPlace.ID };
            }

            var queryParameters = parameter.getParameters();

            await CreateAuthorizedRequestAsync(
                OrdersApiUrls20260101.SearchOrders,
                RestSharp.Method.Get,
                queryParameters,
                cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<SearchOrdersResponse>(Utils.RateLimitType.Order20260101_SearchOrders, cancellationToken);
        }

        /// <summary>
        /// Fetches the next page of results using a pagination token.
        /// Note: Pagination tokens expire after 24 hours in v2026-01-01.
        /// </summary>
        private async Task<SearchOrdersResponse> SearchOrdersByPaginationTokenAsync(string paginationToken, ParameterSearchOrders20260101 originalParameter, CancellationToken cancellationToken = default)
        {
            var queryParameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("paginationToken", paginationToken),
                new KeyValuePair<string, string>("marketplaceIds", string.Join(",", originalParameter.MarketplaceIds))
            };

            await CreateAuthorizedRequestAsync(
                OrdersApiUrls20260101.SearchOrders,
                RestSharp.Method.Get,
                queryParameters,
                cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<SearchOrdersResponse>(Utils.RateLimitType.Order20260101_SearchOrders, cancellationToken);
        }

        #endregion

        #region GetOrder

        /// <summary>
        /// Synchronous wrapper for GetOrderAsync.
        /// </summary>
        public Order20260101 GetOrder(ParameterGetOrder20260101 parameter) =>
            Task.Run(() => GetOrderAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();

        /// <summary>
        /// Returns detailed order information for the specified order ID.
        /// 
        /// Replaces the following v0 operations (consolidated into one call):
        /// - GetOrder
        /// - GetOrderItems (items are always included)
        /// - GetOrderBuyerInfo (use includedData=BUYER)
        /// - GetOrderAddress (use includedData=RECIPIENT)
        /// - GetOrderItemsBuyerInfo (use includedData=BUYER)
        /// 
        /// No RDT required for PII access. Use appropriate application roles instead.
        /// </summary>
        public async Task<Order20260101> GetOrderAsync(ParameterGetOrder20260101 parameter, CancellationToken cancellationToken = default)
        {
            var queryParameters = parameter.getParameters();

            await CreateAuthorizedRequestAsync(
                OrdersApiUrls20260101.GetOrder(parameter.OrderId),
                RestSharp.Method.Get,
                queryParameters,
                cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<GetOrderResponse20260101>(Utils.RateLimitType.Order20260101_GetOrder, cancellationToken);

            return response?.Order;
        }

        /// <summary>
        /// Convenience method: GetOrder with all available data included.
        /// Equivalent to calling getOrder with includedData=BUYER,RECIPIENT,FULFILLMENT,PROCEEDS,EXPENSE,PROMOTION,CANCELLATION,PACKAGES
        /// </summary>
        public async Task<Order20260101> GetOrderFullAsync(string orderId, CancellationToken cancellationToken = default)
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = orderId,
                IncludedData = new List<AmazonSpApiSDK.Models.Orders20260101.IncludedData20260101>
                {
                    AmazonSpApiSDK.Models.Orders20260101.IncludedData20260101.BUYER,
                    AmazonSpApiSDK.Models.Orders20260101.IncludedData20260101.RECIPIENT,
                    AmazonSpApiSDK.Models.Orders20260101.IncludedData20260101.FULFILLMENT,
                    AmazonSpApiSDK.Models.Orders20260101.IncludedData20260101.PROCEEDS,
                    AmazonSpApiSDK.Models.Orders20260101.IncludedData20260101.EXPENSE,
                    AmazonSpApiSDK.Models.Orders20260101.IncludedData20260101.PROMOTION,
                    AmazonSpApiSDK.Models.Orders20260101.IncludedData20260101.CANCELLATION,
                    AmazonSpApiSDK.Models.Orders20260101.IncludedData20260101.PACKAGES
                }
            };

            return await GetOrderAsync(parameter, cancellationToken);
        }

        #endregion
    }
}
