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
                MarketPlace = MarketPlace.UnitedArabEmirates,
                IsActiveLimitRate = true

            }) ;

            //ReportsSample reportsSample = new ReportsSample(amazonConnection);

            //reportsSample.GetReportGET_FBA_REIMBURSEMENTS_DATA();
            //reportsSample.GetReportGET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATEs();
            //reportsSample.CreateReport_GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE();

            //FeedsSample feedsSample = new FeedsSample(amazonConnection);
            ////feedsSample.SubmitFeedInventory();


            amazonConnection.ProductFee.GetMyFeesEstimateForSKU("SKU1 + SKU2-FBA",
                            new AmazonSpApiSDK.Models.ProductFees.FeesEstimateRequest()
                            {
                                Identifier = "00001",
                                IsAmazonFulfilled = true,
                                MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                                PriceToEstimateFees = new AmazonSpApiSDK.Models.ProductFees.PriceToEstimateFees(new AmazonSpApiSDK.Models.ProductFees.MoneyType("AED", 200))
                            });

            //var order2s = amazonConnection.VendorDirectFulfillmentOrders.GetOrder("UNrSh9H8R");


            //var orderData=amazonConnection.Orders.GetOrder(new ParameterGetOrder()
            //{
            //    OrderId = "404-6678802-8633900"
            //});



            while (true)
            {
                var ddata = amazonConnection.CatalogItem.GetCatalogItem("B0096IS4GE");
                if(ddata.AttributeSets!=null && ddata.AttributeSets.Count > 0)
                {
                    var itm = ddata.AttributeSets[0];
                    Console.WriteLine("Brand > " + itm.Brand);
                    Console.WriteLine("ProductGroup > " + itm.ProductGroup);
                }
                
            }


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
