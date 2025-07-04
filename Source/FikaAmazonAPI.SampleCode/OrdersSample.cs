﻿using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.AmazonSpApiSDK.Services;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Parameter.Order;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    public class OrdersSample
    {
        AmazonConnection amazonConnection;
        public OrdersSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }


        public void GetOrdersOnePageWithNextPageToken()
        {
            // ONLY USE THIS SAMPLE IF YOU NEED TO GET ONE PAGE EACH TIME other wise remove parameter 'MaxNumberOfPages' and libaray will fetch all orders to you
            ParameterOrderList searchOrderList = new ParameterOrderList();
            searchOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);
            searchOrderList.MaxNumberOfPages = 1;
            searchOrderList.OrderStatuses = new List<OrderStatuses>();
            searchOrderList.OrderStatuses.Add(OrderStatuses.Shipped);

            searchOrderList.AmazonOrderIds = new List<string>();

            var orders = amazonConnection.Orders.GetOrders(searchOrderList);
            var nextPageToken = orders.NextToken;
            while (!string.IsNullOrEmpty(nextPageToken))
            {
                var moreOrders = amazonConnection.Orders.GetGetOrdersByNextToken(nextPageToken, searchOrderList);
                nextPageToken = moreOrders.NextToken;
            }

        }
        public void GetOrders()
        {
            ParameterOrderList searchOrderList = new ParameterOrderList();
            searchOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);

            searchOrderList.OrderStatuses = new List<OrderStatuses>();
            searchOrderList.OrderStatuses.Add(OrderStatuses.Shipped);

            searchOrderList.AmazonOrderIds = new List<string>();
            searchOrderList.AmazonOrderIds.Add("403-1710607-6240347");
            searchOrderList.AmazonOrderIds.Add("403-5583945-7236361");
            searchOrderList.AmazonOrderIds.Add("403-3320829-4528316");
            searchOrderList.AmazonOrderIds.Add("406-2574982-2047546");

            var orders = amazonConnection.Orders.GetOrders(searchOrderList);
        }

        /// <summary>
        /// You must have valid PII developer to be able to call this method
        /// </summary>
        public void GetOrdersPIISimple()
        {
            ParameterOrderList searchOrderList = new ParameterOrderList();
            searchOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);

            searchOrderList.OrderStatuses = new List<OrderStatuses>();
            searchOrderList.OrderStatuses.Add(OrderStatuses.Unshipped);

            //You must have valid PII developer to be able to call this
            searchOrderList.IsNeedRestrictedDataToken = true;

            var orders = amazonConnection.Orders.GetOrders(searchOrderList);
        }
        public void GetOrdersPIIAdvance()
        {
            ParameterOrderList searchOrderList = new ParameterOrderList();
            searchOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);

            searchOrderList.OrderStatuses = new List<OrderStatuses>();
            searchOrderList.OrderStatuses.Add(OrderStatuses.Unshipped);

            //You must have valid PII developer to be able to call this 
            var restrictedResource = new RestrictedResource();
            restrictedResource.method = Method.GET.ToString();
            restrictedResource.path = ApiUrls.OrdersApiUrls.Orders;
            restrictedResource.dataElements = new List<string> { "buyerInfo", "shippingAddress" };


            var createRDT = new CreateRestrictedDataTokenRequest()
            {
                restrictedResources = new List<RestrictedResource> { restrictedResource }
            };
            searchOrderList.RestrictedDataTokenRequest = createRDT;
            searchOrderList.IsNeedRestrictedDataToken = true;

            var orders = amazonConnection.Orders.GetOrders(searchOrderList);
        }

        public void GetOrderBuyerInfo()
        {
            var BuyerInfo = amazonConnection.Orders.GetOrderBuyerInfo("402-0467973-4229120");
        }


        public void GetOrderAddress()
        {
            // This method has been changed and is a breaking change
            // If you would like the default behavior please reference the 
            // ShippingAddress variable
            var Address = amazonConnection.Orders.GetOrderAddress("402-0467973-4229120");
            var BuyerCompanyName = Address.BuyerCompanyName;
            var ShippingAddress = Address.ShippingAddress;
            var DeliveryPreferences = Address.DeliveryPreferences;
        }


        public void GetOrderItems()
        {
            var Items = amazonConnection.Orders.GetOrderItems("402-0467973-4229120");
        }

        /// <summary>
        /// You must have valid PII developer to be able to call this method
        /// </summary>
        public void GetOrderItemsPIISimple()
        {
            ParameterBasedPII parameterBasedPII = new ParameterBasedPII();
            parameterBasedPII.IsNeedRestrictedDataToken = true;

            var order = amazonConnection.Orders.GetOrderItems("405-0426616-1636335", parameterBasedPII);
        }

        /// <summary>
        /// You must have valid PII developer to be able to call this method
        /// </summary>
        public void GetOrderItemsPII()
        {
            var restrictedResource = new RestrictedResource();
            restrictedResource.method = Method.GET.ToString();
            restrictedResource.path = ApiUrls.OrdersApiUrls.OrderItems("405-0426616-1636335");
            //restrictedResource.dataElements = new List<string> { "buyerInfo", "shippingAddress" };


            var createRDT = new CreateRestrictedDataTokenRequest()
            {
                restrictedResources = new List<RestrictedResource> { restrictedResource }
            };

            ParameterBasedPII parameterBasedPII = new ParameterBasedPII();
            parameterBasedPII.IsNeedRestrictedDataToken = true;
            parameterBasedPII.RestrictedDataTokenRequest = createRDT;

            var order = amazonConnection.Orders.GetOrderItems("405-0426616-1636335", parameterBasedPII);
        }

        public OrderList GetOrderListFulfillmentChannels()
        {
            var parameterOrderList = new ParameterOrderList
            {
                CreatedAfter = DateTime.UtcNow.AddDays(-24),
                //FulfillmentChannels = new List<FulfillmentChannels> { FulfillmentChannels.AFN },
                OrderStatuses = new List<OrderStatuses> { OrderStatuses.Shipped }
            };

            var orders = amazonConnection.Orders.GetOrders(parameterOrderList);

            return orders;
        }

        public void GetOrderItemsBuyerInfo()
        {
            var ItemsBuyerInfo = amazonConnection.Orders.GetOrderItemsBuyerInfo("402-0467973-4229120");
        }
    }
}
