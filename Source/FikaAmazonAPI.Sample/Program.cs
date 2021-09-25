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

            var data4 = amazonConnection.ProductPricing.GetItemOffers(new Parameter.ProductPricing.ParameterGetItemOffers()
            {
                ItemCondition = ItemCondition.New,
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Asin = "B00LZ0VSMI"
            });

            var data3 = amazonConnection.ProductPricing.GetCompetitivePricing(new Parameter.ProductPricing.ParameterGetCompetitivePricing()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Asins = new string[] { "B00LZ0VSMI" },

            });

            var data2 = amazonConnection.ProductPricing.GetPricing(new Parameter.ProductPricing.ParameterGetPricing()
            {
                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                Asins = new string[] { "B00LZ0VSMI" }
            });

            var data= amazonConnection.ProductPricing.GetListingOffers(new Parameter.ProductPricing.ParameterGetListingOffers()
            {
                ItemCondition=ItemCondition.New,
                MarketplaceId=MarketPlace.UnitedArabEmirates.ID,
                SellerSKU= "3282770207736."
            });

            //B00LZ0VSMI

            FulFillmentInboundSample fulFillmentInboundSample = new FulFillmentInboundSample(amazonConnection);
            //fulFillmentInboundSample.GetInboundGuidance();
            fulFillmentInboundSample.GetPrepInstructions();

            //OrdersSample ordersSample = new OrdersSample(amazonConnection);
            //ordersSample.GetOrders();


            Console.ReadLine();
            
        }



    }
}
