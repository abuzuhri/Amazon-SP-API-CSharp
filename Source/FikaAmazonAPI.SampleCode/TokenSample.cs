using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.AmazonSpApiSDK.Services;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    public class TokenSample
    {
        AmazonConnection amazonConnection;
        public TokenSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }


        public void OrderPII()
        {
            var restrictedResource = new RestrictedResource();
            restrictedResource.method = Method.GET.ToString();
            restrictedResource.path = ApiUrls.OrdersApiUrls.OrderItems("404-7777403-8594716");
            //restrictedResource.dataElements = new List<string> { "buyerInfo", "shippingAddress" };


            var createRDT = new CreateRestrictedDataTokenRequest()
            {
                restrictedResources = new List<RestrictedResource> { restrictedResource }
            };

            ParameterBasedPII parameterBasedPII = new ParameterBasedPII();
            parameterBasedPII.IsNeedRestrictedDataToken = true;
            parameterBasedPII.RestrictedDataTokenRequest = createRDT;

           var order= amazonConnection.Orders.GetOrderItems("404-7777403-8594716", parameterBasedPII);
        }

        public void OrdersPII()
        {
            var restrictedResource = new RestrictedResource();
            restrictedResource.method = Method.GET.ToString();
            restrictedResource.path = ApiUrls.OrdersApiUrls.OrderItems("404-7777403-8594716");
            //restrictedResource.dataElements = new List<string> { "buyerInfo", "shippingAddress" };


            var createRDT = new CreateRestrictedDataTokenRequest()
            {
                restrictedResources = new List<RestrictedResource> { restrictedResource }
            };


            ParameterOrderList searchOrderList = new ParameterOrderList();
            searchOrderList.CreatedAfter = DateTime.UtcNow.AddHours(-24);
            searchOrderList.OrderStatuses = new List<OrderStatuses>();
            searchOrderList.OrderStatuses.Add(OrderStatuses.Unshipped);
            searchOrderList.MarketplaceIds = new List<string> { MarketPlace.UnitedArabEmirates.ID };
            searchOrderList.RestrictedDataTokenRequest = createRDT;
            searchOrderList.IsNeedRestrictedDataToken = true;

            var orders = amazonConnection.Orders.GetOrders(searchOrderList);


        }
    }
}
