using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FikaAmazonAPI.AmazonSpApiSDK.Api.Sellers;
using FikaAmazonAPI.AmazonSpApiSDK.Clients;
using FikaAmazonAPI;
using FikaAmazonAPI.ConstructFeed;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Parameter.Notification;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Parameter.Report;
using FikaAmazonAPI.Utils;
using static FikaAmazonAPI.ConstructFeed.BaseXML;
using static FikaAmazonAPI.Utils.Constants;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.AmazonSpApiSDK.Services;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.RestrictedResource;

namespace FikaAmazonAPI.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {


            AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
                SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
                RoleArn = Environment.GetEnvironmentVariable("RoleArn"),
                ClientId = Environment.GetEnvironmentVariable("ClientId"),
                ClientSecret = Environment.GetEnvironmentVariable("ClientSecret"),
                RefreshToken = Environment.GetEnvironmentVariable("RefreshToken"),
                MarketPlace = MarketPlace.UnitedArabEmirates

            });




            var restrictedResource = new RestrictedResource();
            restrictedResource.method = Method.GET.ToString();
            restrictedResource.path = ApiUrls.OrdersApiUrls.Orders;
            restrictedResource.dataElements = new List<string> { "buyerInfo", "shippingAddress" };


            var createRDT = new CreateRestrictedDataTokenRequest()
            {
                restrictedResources = new List<RestrictedResource> { restrictedResource }
            };




            ParameterOrderList serachOrderList = new ParameterOrderList();
            serachOrderList.CreatedAfter = DateTime.UtcNow.AddHours(-24);
            serachOrderList.OrderStatuses = new List<OrderStatuses>();
            serachOrderList.OrderStatuses.Add(OrderStatuses.Unshipped);
            serachOrderList.MarketplaceIds = new List<string> { MarketPlace.UnitedArabEmirates.ID };
            serachOrderList.RestrictedDataTokenRequest = createRDT;
            serachOrderList.IsNeedRestrictedDataToken = false;

            var orders = amazonConnection.Orders.GetOrders(serachOrderList);
            var order = amazonConnection.Orders.GetOrder(new ParameterGetOrder() { 
                OrderId= "405-5895000-9009106",
                
            });
            var orderss = amazonConnection.Orders.GetOrders(serachOrderList);


            Console.ReadLine();
            
        }



    }
}
