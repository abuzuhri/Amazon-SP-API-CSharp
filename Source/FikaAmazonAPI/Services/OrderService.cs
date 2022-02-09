using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Services
{
    public class OrderService : RequestService
    {
        public OrderService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        #region GetOrders

        public OrderList GetOrders(ParameterOrderList searchOrderList)
        {
            var orderList = new OrderList();

            if (searchOrderList.MarketplaceIds == null || searchOrderList.MarketplaceIds.Count == 0)
            {
                searchOrderList.MarketplaceIds=new List<string>();
                searchOrderList.MarketplaceIds.Add(AmazonCredential.MarketPlace.ID);
            }
            var queryParameters = searchOrderList.getParameters();

            CreateAuthorizedRequest(OrdersApiUrls.Orders, RestSharp.Method.GET, queryParameters,parameter: searchOrderList);
            var response = ExecuteRequest<GetOrdersResponse>();
            var nextToken = response.Payload.NextToken;
            orderList = response.Payload.Orders;
            while (!string.IsNullOrEmpty(nextToken))
            {
                var orderPayload = GetByNextToken(nextToken, searchOrderList.MarketplaceIds);
                orderList.AddRange(orderPayload.Orders);
                nextToken = orderPayload.NextToken;
            }
            return orderList;
        }

        private OrdersList GetByNextToken(string nextToken, IList<string> marketplaceIds)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceIds", string.Join(",", marketplaceIds)));

            CreateAuthorizedRequest(OrdersApiUrls.Orders, RestSharp.Method.GET, queryParameters);
            var response = ExecuteRequest<GetOrdersResponse>();
            return response.Payload;
        }

        #endregion

        public Order GetOrder(ParameterGetOrder parameter)
        {
            CreateAuthorizedRequest(OrdersApiUrls.Order(parameter.OrderId), RestSharp.Method.GET,parameter: parameter);
            var response = ExecuteRequest<GetOrderResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            else return null;
        }


        public OrderItemList GetOrderItems(string orderId,IParameterBasedPII ParameterBasedPII=null)
        {
            var orderItemList = new OrderItemList();
            CreateAuthorizedRequest(OrdersApiUrls.OrderItems(orderId), RestSharp.Method.GET,parameter: ParameterBasedPII);
            var response = ExecuteRequest<GetOrderItemsResponse>();
            var nextToken = response.Payload.NextToken;
            orderItemList.AddRange(response.Payload.OrderItems);
            while (!string.IsNullOrEmpty(nextToken))
            {
                var orderItemPayload = GetOrderItemsNextToken(orderId,nextToken);
                orderItemList.AddRange(orderItemPayload.OrderItems);
                nextToken = orderItemPayload.NextToken;
            }
            return orderItemList;
        }
        public OrderItemsList GetOrderItemsNextToken(string orderId,string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            CreateAuthorizedRequest(OrdersApiUrls.OrderItems(orderId), RestSharp.Method.GET, queryParameters);
            var response = ExecuteRequest<GetOrderItemsResponse>();
            return response.Payload;
        }

        public OrderBuyerInfo GetOrderBuyerInfo(string orderId, List<KeyValuePair<string, string>> queryParameters = null)
        {
            CreateAuthorizedRequest(OrdersApiUrls.OrderBuyerInfo(orderId), RestSharp.Method.GET, queryParameters);
            var response = ExecuteRequest<GetOrderBuyerInfoResponse>();
            return response.Payload;
        }
        
        public OrderItemsBuyerInfoList GetOrderItemsBuyerInfo(string orderId)
        {
            CreateAuthorizedRequest(OrdersApiUrls.OrderItemsBuyerInfo(orderId), RestSharp.Method.GET);
            var response = ExecuteRequest<GetOrderItemsBuyerInfoResponse>();
            return response.Payload;
        }

        public Address GetOrderAddress(string orderId)
        {
            CreateAuthorizedRequest(OrdersApiUrls.OrderShipmentInfo(orderId), RestSharp.Method.GET);
            var response = ExecuteRequest<GetOrderAddressResponse>();
            return response.Payload.ShippingAddress;
        }
    }
}
