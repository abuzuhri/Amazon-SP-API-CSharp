using FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101;
using FikaAmazonAPI.Parameter.Order.V20260101;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class OrderServiceV20260101 : RequestService
    {
        public OrderServiceV20260101(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {

        }

        #region SearchOrders

        public List<Order> SearchOrders(ParameterSearchOrders parameterSearchOrders) =>
            Task.Run(() => SearchOrdersAsync(parameterSearchOrders)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Order>> SearchOrdersAsync(ParameterSearchOrders parameterSearchOrders, CancellationToken cancellationToken = default)
        {
            if (parameterSearchOrders.MarketplaceIds == null || parameterSearchOrders.MarketplaceIds.Count == 0)
            {
                parameterSearchOrders.MarketplaceIds = new List<string>
                {
                    AmazonCredential.MarketPlace.ID
                };
            }

            var parameter = parameterSearchOrders.getParameters();
            await CreateAuthorizedRequestAsync(OrdersApiUrls.SearchOrdersV20260101, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Order> list = new List<Order>();

            var response = await ExecuteRequestAsync<SearchOrdersResponse>(RateLimitType.OrderV20260101_SearchOrders, cancellationToken);
            list.AddRange(response.Orders);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterSearchOrders.MaxNumberOfPages.HasValue || totalPages < parameterSearchOrders.MaxNumberOfPages.Value))
                {
                    parameterSearchOrders.PaginationToken = nextToken;
                    var getNextPage = await SearchOrdersByNextTokenAsync(parameterSearchOrders, cancellationToken);
                    list.AddRange(getNextPage.Orders);
                    nextToken = getNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<SearchOrdersResponse> SearchOrdersByNextTokenAsync(ParameterSearchOrders parameterSearchOrders, CancellationToken cancellationToken = default)
        {
            var parameter = parameterSearchOrders.getParameters();

            await CreateAuthorizedRequestAsync(OrdersApiUrls.SearchOrdersV20260101, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<SearchOrdersResponse>(RateLimitType.OrderV20260101_SearchOrders, cancellationToken);
        }

        #endregion

        #region GetOrder
        public Order GetOrder(ParameterGetOrder parameter) =>
            Task.Run(() => GetOrderAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Order> GetOrderAsync(ParameterGetOrder parameterGetOrder, CancellationToken cancellationToken = default)
        {
            var parameter = parameterGetOrder.getParameters();
            await CreateAuthorizedRequestAsync(OrdersApiUrls.GetOrderV20260101(parameterGetOrder.OrderId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetOrderResponse>(RateLimitType.OrderV20260101_GetOrder, cancellationToken);

            if (response != null && response.Order != null)
                return response.Order;
            else return null;
        }

        #endregion
    }
}
