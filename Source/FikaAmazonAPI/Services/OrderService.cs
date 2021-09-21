using FikaAmazonAPI.AmazonSpApiSDK.Api.Orders;
using FikaAmazonAPI.AmazonSpApiSDK.Clients;
using FikaAmazonAPI.AmazonSpApiSDK.Models;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class OrderService : RequestService
    {
        public OrderService(AmazonCredential amazonCredential) : base(amazonCredential)
        {
            
        }

        #region GetOrders

        public List<CreateReportResult> GetOrders(ParameterOrderList serachOrderList)
        {
            var orderList = new List<CreateReportResult>();

            var queryParameters = serachOrderList.getParameters();


            CreateAuthorizedRequest(OrdersApiUrls.Orders, RestSharp.Method.GET, queryParameters,parameter: serachOrderList);
            var response = ExecuteRequest<GetOrdersResponse>();
            var nextToken = response.Payload.NextToken;
            orderList = response.Payload.Orders;
            while (!string.IsNullOrEmpty(nextToken))
            {
                var orderPayload = GetByNextToken(nextToken);
                orderList.AddRange(orderPayload.Orders);
                nextToken = orderPayload.NextToken;
            }
            return orderList;
        }

        private OrdersList GetByNextToken(string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            CreateAuthorizedRequest(OrdersApiUrls.Orders, RestSharp.Method.GET, queryParameters);
            var response = ExecuteRequest<GetOrdersResponse>();
            return response.Payload;
        }

        #endregion

        public CreateReportResult GetOrder(string orderId, List<KeyValuePair<string, string>> queryParameters = null)
        {
            CreateAuthorizedRequest(OrdersApiUrls.Order(orderId), RestSharp.Method.GET);
            var response = ExecuteRequest<GetOrderResponse>();
           return response.Payload;
        }


        public OrderItemList GetOrderItems(string orderId)
        {
            var orderItemList = new OrderItemList();
            CreateAuthorizedRequest(OrdersApiUrls.OrderItems(orderId), RestSharp.Method.GET);
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
