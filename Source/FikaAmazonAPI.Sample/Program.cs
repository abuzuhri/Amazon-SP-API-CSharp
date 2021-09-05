using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AmazonSpApiSDK.Api.Sellers;
using AmazonSpApiSDK.Clients;
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


            var feeddata=amazonConnection.Feed.GetFeed("195102018875");

            ConstructFeedService createDocument = new ConstructFeedService("A3J37AJU4O9RHK", "1.02");

            var list = new List<PriceMessage>();
            list.Add(new PriceMessage()
            {
                SKU = "8201031206122...",
                StandardPrice = new StandardPrice()
                {
                    currency = BaseCurrencyCode.AED.ToString(),
                    Value = (201.0522M).ToString("0.00")
                }
            });
            createDocument.AddPriceMessage(list);

            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_PRODUCT_PRICING_DATA);

            var feedOutput=amazonConnection.Feed.GetFeed(feedID);
            
            var outPut=amazonConnection.Feed.GetFeedDocument(feedOutput.ResultFeedDocumentId);

            var reportOutpit = outPut.Url;


            Console.ReadLine();
            
        }



    }
}
