using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Test
{
    [TestClass]
    public class Orders
    {
        AmazonConnection amazonConnection;
        public Orders()
        {
            amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
                SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
                RoleArn = Environment.GetEnvironmentVariable("RoleArn"),
                ClientId = Environment.GetEnvironmentVariable("ClientId"),
                ClientSecret = Environment.GetEnvironmentVariable("ClientSecret"),
                RefreshToken = Environment.GetEnvironmentVariable("RefreshToken"),
                MarketPlace = MarketPlace.UnitedArabEmirates

            });

        }

        [TestMethod]
        public void GetOrders()
        {
            ParameterOrderList serachOrderList = new ParameterOrderList();
            serachOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);

            serachOrderList.OrderStatuses = new List<OrderStatuses>();
            serachOrderList.OrderStatuses.Add(OrderStatuses.Canceled);

            serachOrderList.AmazonOrderIds = new List<string>();
            serachOrderList.AmazonOrderIds.Add("403-1710607-6240347");
            serachOrderList.AmazonOrderIds.Add("403-5583945-7236361");
            serachOrderList.AmazonOrderIds.Add("403-3320829-4528316");
            serachOrderList.AmazonOrderIds.Add("406-2574982-2047546");

            var orders = amazonConnection.Orders.GetOrders(serachOrderList);
        }


        [TestMethod]
        public void GetOrderBuyerInfo()
        {
            var BuyerInfo = amazonConnection.Orders.GetOrderBuyerInfo("402-0467973-4229120");
        }

        [TestMethod]
        public void GetOrderAddress()
        {
            var Address = amazonConnection.Orders.GetOrderAddress("402-0467973-4229120");
        }

        [TestMethod]
        public void GetOrderItems()
        {
            var Items = amazonConnection.Orders.GetOrderItems("402-0467973-4229120");
        }

        [TestMethod]
        public void GetOrderItemsBuyerInfo()
        {
            var ItemsBuyerInfo = amazonConnection.Orders.GetOrderItemsBuyerInfo("402-0467973-4229120");
        }
    }
}
