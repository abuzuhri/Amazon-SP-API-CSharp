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

            Environment.SetEnvironmentVariable("AccessKey", "AKIATPXBLIMN56RIIXTY");
            Environment.SetEnvironmentVariable("SecretKey", "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");
            Environment.SetEnvironmentVariable("RoleArn", "arn:aws:iam::239917024027:role/IcanloSpApiRole");
            Environment.SetEnvironmentVariable("ClientId", "amzn1.application-oa2-client.60e302fbf260411fb308ad0c635a1c30");
            Environment.SetEnvironmentVariable("ClientSecret", "7dab6ccaa0d51dab00a796e5bc3b08e411368413b7b80dfbe228eb47ad289db5");
            Environment.SetEnvironmentVariable("RefreshToken", "Atzr|IwEBIMWv5q0KZilh8WdxtHSjSAOYU0L_vW67jN_RGufCAbxhxaHdET73JS8kD0NrYvjB5eDAeNpYmYTk9AQY2U3WgFpjxKZh6M5odzrl0LSOWiysyjO_mLxdzh4RZ78USCQz7qw-WUKZqXcByayz39HKa5IK-46naVjFgoX1rMvzRAviX_9ZwOEtGXHdCR8cm1Db_-9EbCqZlMqvZ_fDA0hFfQ-Ii7U1mJVk0J8AgktPA9ePRusTD7VzYy149ToBqYtpPbyMgWx51yWUQx9C1DKqBw6jJjub9kIk7WqdF890CpIoWJHMWuVNu_6cM7GW6-raApY");


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
