using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class OrderService : RequestService
    {
        public OrderService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        #region GetOrders

        public OrderList GetOrders(ParameterOrderList searchOrderList) =>
            GetOrdersAsync(searchOrderList).GetAwaiter().GetResult();
        public async Task<OrderList> GetOrdersAsync(ParameterOrderList searchOrderList)
        {
            var orderList = new OrderList();

            if (searchOrderList.MarketplaceIds == null || searchOrderList.MarketplaceIds.Count == 0)
            {
                searchOrderList.MarketplaceIds = new List<string>();
                searchOrderList.MarketplaceIds.Add(AmazonCredential.MarketPlace.ID);
            }
            var queryParameters = searchOrderList.getParameters();

            await CreateAuthorizedRequestAsync(OrdersApiUrls.Orders, RestSharp.Method.GET, queryParameters, parameter: searchOrderList);
            var response = await ExecuteRequestAsync<GetOrdersResponse>(Utils.RateLimitType.Order_GetOrders);
            var nextToken = response.Payload.NextToken;
            orderList = response.Payload.Orders;
            while (!string.IsNullOrEmpty(nextToken))
            {
                var orderPayload = GetGetOrdersByNextToken(nextToken, searchOrderList.MarketplaceIds);
                orderList.AddRange(orderPayload.Orders);
                nextToken = orderPayload.NextToken;
            }
            return orderList;
        }

        public OrdersList GetGetOrdersByNextToken(string nextToken, IList<string> marketplaceIds) =>
            GetGetOrdersByNextTokenAsync(nextToken, marketplaceIds).GetAwaiter().GetResult();
        public async Task<OrdersList> GetGetOrdersByNextTokenAsync(string nextToken, IList<string> marketplaceIds)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceIds", string.Join(",", marketplaceIds)));

            await CreateAuthorizedRequestAsync(OrdersApiUrls.Orders, RestSharp.Method.GET, queryParameters);
            var response = await ExecuteRequestAsync<GetOrdersResponse>(Utils.RateLimitType.Order_GetOrders);
            return response.Payload;
        }

        #endregion

        public Order GetOrder(ParameterGetOrder parameter) =>
            GetOrderAsync(parameter).GetAwaiter().GetResult();
        public async Task<Order> GetOrderAsync(ParameterGetOrder parameter)
        {
            await CreateAuthorizedRequestAsync(OrdersApiUrls.Order(parameter.OrderId), RestSharp.Method.GET, parameter: parameter);
            var response = await ExecuteRequestAsync<GetOrderResponse>(Utils.RateLimitType.Order_GetOrder);
            if (response != null && response.Payload != null)
                return response.Payload;
            else return null;
        }


        public OrderItemList GetOrderItems(string orderId, IParameterBasedPII parameterBasedPII = null) =>
            GetOrderItemsAsync(orderId, parameterBasedPII).GetAwaiter().GetResult();
        public async Task<OrderItemList> GetOrderItemsAsync(string orderId, IParameterBasedPII ParameterBasedPII = null)
        {
            var orderItemList = new OrderItemList();
            await CreateAuthorizedRequestAsync(OrdersApiUrls.OrderItems(orderId), RestSharp.Method.GET, parameter: ParameterBasedPII);
            var response = await ExecuteRequestAsync<GetOrderItemsResponse>(Utils.RateLimitType.Order_GetOrderItems);
            var nextToken = response.Payload.NextToken;
            orderItemList.AddRange(response.Payload.OrderItems);
            while (!string.IsNullOrEmpty(nextToken))
            {
                var orderItemPayload = GetOrderItemsNextToken(orderId, nextToken);
                orderItemList.AddRange(orderItemPayload.OrderItems);
                nextToken = orderItemPayload.NextToken;
            }
            return orderItemList;
        }

        public OrderItemsList GetOrderItemsNextToken(string orderId, string nextToken) =>
            GetOrderItemsNextTokenAsync(orderId, nextToken).GetAwaiter().GetResult();
        public async Task<OrderItemsList> GetOrderItemsNextTokenAsync(string orderId, string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            await CreateAuthorizedRequestAsync(OrdersApiUrls.OrderItems(orderId), RestSharp.Method.GET, queryParameters);
            var response = await ExecuteRequestAsync<GetOrderItemsResponse>(Utils.RateLimitType.Order_GetOrderItems);
            return response.Payload;
        }

        public OrderBuyerInfo GetOrderBuyerInfo(string orderId, List<KeyValuePair<string, string>> queryParameters = null) =>
            GetOrderBuyerInfoAsync(orderId, queryParameters).GetAwaiter().GetResult();
        public async Task<OrderBuyerInfo> GetOrderBuyerInfoAsync(string orderId, List<KeyValuePair<string, string>> queryParameters = null)
        {
            await CreateAuthorizedRequestAsync(OrdersApiUrls.OrderBuyerInfo(orderId), RestSharp.Method.GET, queryParameters);
            var response = await ExecuteRequestAsync<GetOrderBuyerInfoResponse>(Utils.RateLimitType.Order_GetOrderBuyerInfo);
            return response.Payload;
        }

        public OrderItemsBuyerInfoList GetOrderItemsBuyerInfo(string orderId) =>
            GetOrderItemsBuyerInfoAsync(orderId).GetAwaiter().GetResult();
        public async Task<OrderItemsBuyerInfoList> GetOrderItemsBuyerInfoAsync(string orderId)
        {
            await CreateAuthorizedRequestAsync(OrdersApiUrls.OrderItemsBuyerInfo(orderId), RestSharp.Method.GET);
            var response = await ExecuteRequestAsync<GetOrderItemsBuyerInfoResponse>(Utils.RateLimitType.Order_GetOrderItemsBuyerInfo);
            return response.Payload;
        }

        public Address GetOrderAddress(string orderId) =>
            GetOrderAddressAsync(orderId).GetAwaiter().GetResult();
        public async Task<Address> GetOrderAddressAsync(string orderId)
        {
            await CreateAuthorizedRequestAsync(OrdersApiUrls.OrderShipmentInfo(orderId), RestSharp.Method.GET);
            var response = await ExecuteRequestAsync<GetOrderAddressResponse>(Utils.RateLimitType.Order_GetOrderAddress);
            return response.Payload.ShippingAddress;
        }
    }
}
