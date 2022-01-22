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
using FikaAmazonAPI.AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.AmazonSpApiSDK.Models.MerchantFulfillment;
using FikaAmazonAPI.Parameter.Finance;
using FikaAmazonAPI.ReportGeneration;

namespace FikaAmazonAPI.SampleCode
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Environment.SetEnvironmentVariable("AccessKey", "AKIATPXBLIMNZTJ4RNQG");
            Environment.SetEnvironmentVariable("SecretKey", "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");
            Environment.SetEnvironmentVariable("RoleArn", "arn:aws:iam::239917024027:role/IcanloSpApiRole");
            Environment.SetEnvironmentVariable("ClientId", "amzn1.application-oa2-client.60e302fbf260411fb308ad0c635a1c30");
            Environment.SetEnvironmentVariable("ClientSecret", "7dab6ccaa0d51dab00a796e5bc3b08e411368413b7b80dfbe228eb47ad289db5");
            Environment.SetEnvironmentVariable("RefreshToken", "Atzr|IwEBIB_EWhQekUsF08ZtXWccm5chfM8K7t6Cw_U6G5YtEvJ2ZQmCV_r8jcr_4htXf64mBG1pXxDShTydP3vyRyTdAaXctrj5Kf1LWBVJdlOh05TPWgGbqag-GU1_IAqp0dQ4hG6jrTc30B1n7pzIX2boXyFejZprrldZWbgXmC5yEHue9_-_Qdv7CBQmeWDYeOALvx2s2ZmJqNw_q6IvIUttSeE5cbgNJ3nqxtfzlnJxAu928NQnBN_8t3RJ6r1gRDE6bDgpDOOL_uxB3fN9KAmKPfoa3eRDAPjiivuM81TgIvwYFtcUiuGWnqYhlYKs6gxpxfk");


            AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
                SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
                RoleArn = Environment.GetEnvironmentVariable("RoleArn"),
                ClientId = Environment.GetEnvironmentVariable("ClientId"),
                ClientSecret = Environment.GetEnvironmentVariable("ClientSecret"),
                RefreshToken = Environment.GetEnvironmentVariable("RefreshToken"),
                MarketPlace = MarketPlace.UnitedArabEmirates, //MarketPlace.GetMarketPlaceByID("A2VIGQ35RCS4UG")
                IsActiveLimitRate = true
            });


            var list3=amazonConnection.Financial.ListFinancialEvents(new ParameterListFinancialEvents()
            {
                PostedAfter=DateTime.UtcNow.AddDays(-15)
            });

            string text = System.IO.File.ReadAllText(@"C:\Users\tareq\Downloads\Beispiel_Upload.txt");

            var feedresultTXT = amazonConnection.Feed.SubmitFeed(text
                                                    , FeedType.POST_FLAT_FILE_INVLOADER_DATA
                                                    , new List<string>() { MarketPlace.UnitedArabEmirates.ID }
                                                    , null
                                                    , ContentType.TXT);


            string pathURL = string.Empty;
            while (pathURL == string.Empty)
            {
                Thread.Sleep(1000 * 30);
                var feedOutput = amazonConnection.Feed.GetFeed(feedresultTXT);
                if (feedOutput.ProcessingStatus == AmazonSpApiSDK.Models.Feeds.Feed.ProcessingStatusEnum.DONE)
                {
                    var outPut = amazonConnection.Feed.GetFeedDocument(feedOutput.ResultFeedDocumentId);

                    pathURL = outPut.Url;
                }
            }


            ReportManager reportManager = new ReportManager(amazonConnection);
            var products=reportManager.GetProducts(); //GET_MERCHANT_LISTINGS_ALL_DATA
            var inventoryAging = reportManager.GetInventoryAging(); //GET_FBA_INVENTORY_AGED_DATA
            var ordersByDate = reportManager.GetOrdersByOrderDate(90); //GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL
            var ordersByLastUpdate = reportManager.GetOrdersByLastUpdate(90); //GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL
            var settlementOrder = reportManager.GetSettlementOrder(90); //GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2
            var returnMFNOrder = reportManager.GetReturnMFNOrder(90); //GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE
            var returnFBAOrder = reportManager.GetReturnFBAOrder(90); //GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA
            var reimbursementsOrder = reportManager.GetReimbursementsOrder(180); //GET_FBA_REIMBURSEMENTS_DATA
            var feedbacks = reportManager.GetFeedbackFromDays(180); //GET_SELLER_FEEDBACK_DATA


            var options = new AmazonSpApiSDK.Models.Feeds.FeedOptions();
            options.Add("DocumentType", "Invoice");
            options.Add("InvoiceNumber", "FV-EUR/1/2/3");
            options.Add("OrderId", "???-???????-?????");
            options.Add("TotalAmount", "39.37");
            options.Add("TotalVATAmount", "6.29");






            //234729019012

            var feedresultPDF = amazonConnection.Feed.SubmitFeed(@"C:\Users\tareq\Downloads\224129324d8e2096ec0a70f223572eda36.pdf"
                                                    , FeedType.UPLOAD_VAT_INVOICE
                                                    , new List<string>() { MarketPlace.UnitedArabEmirates.ID }
                                                    , options
                                                    , ContentType.PDF);




            ConstructFeedService createDocument = new ConstructFeedService("A3J37AJU4O9RHK", "1.02");
            var list = new List<InventoryMessage>();
            list.Add(new InventoryMessage()
            {
                SKU = "82010312061.22...",
                Quantity = 2,
                FulfillmentLatency = "11",
            });
            createDocument.AddInventoryMessage(list);
            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_INVENTORY_AVAILABILITY_DATA);

            Thread.Sleep(1000 * 30);

            //var feedOutput = amazonConnection.Feed.GetFeed(feedID);

            //var outPut = amazonConnection.Feed.GetFeedDocument(feedOutput.ResultFeedDocumentId);
            //Thread.Sleep(1000 * 30);
            //var reportOutpit = outPut.Url;

            //var processingReport = amazonConnection.Feed.GetFeedDocumentProcessingReport(reportOutpit);


            Console.ReadLine();
            
        }



    }
}
