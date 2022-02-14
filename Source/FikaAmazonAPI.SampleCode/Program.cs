using FikaAmazonAPI.ConstructFeed;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Parameter.Finance;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.ReportGeneration;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Configuration;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .Build();

            AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = config.GetSection("FikaAmazonAPI:AccessKey").Value,
                SecretKey = config.GetSection("FikaAmazonAPI:SecretKey").Value,
                RoleArn = config.GetSection("FikaAmazonAPI:RoleArn").Value,
                ClientId = config.GetSection("FikaAmazonAPI:ClientId").Value,
                ClientSecret = config.GetSection("FikaAmazonAPI:ClientSecret").Value,
                RefreshToken = config.GetSection("FikaAmazonAPI:RefreshToken").Value,
                MarketPlace = MarketPlace.GetMarketPlaceByID(config.GetSection("FikaAmazonAPI:MarketPlaceID").Value),
                IsActiveLimitRate = true
            });

            var dataaa = amazonConnection.FbaInventory.GetInventorySummaries(new Parameter.FbaInventory.ParameterGetInventorySummaries
            {
                granularityType = AmazonSpApiSDK.Models.FbaInventory.Granularity.GranularityTypeEnum.Marketplace,
                granularityId = config.GetSection("FikaAmazonAPI:MarketPlaceID").Value
            }); ;

            ReportManager reportManager = new ReportManager(amazonConnection);
            var products = reportManager.GetProducts(); //GET_MERCHANT_LISTINGS_ALL_DATA
            var inventoryAging = reportManager.GetInventoryAging(); //GET_FBA_INVENTORY_AGED_DATA
            var ordersByDate = reportManager.GetOrdersByOrderDate(90); //GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL
            var ordersByLastUpdate = reportManager.GetOrdersByLastUpdate(90); //GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL
            var settlementOrder = reportManager.GetSettlementOrder(90); //GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2
            var returnMFNOrder = reportManager.GetReturnMFNOrder(90); //GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE
            var returnFBAOrder = reportManager.GetReturnFBAOrder(90); //GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA
            var reimbursementsOrder = reportManager.GetReimbursementsOrder(180); //GET_FBA_REIMBURSEMENTS_DATA
            var feedbacks = reportManager.GetFeedbackFromDays(180); //GET_SELLER_FEEDBACK_DATA

            while (true)
            {
                var data = amazonConnection.ProductPricing.GetItemOffers(new FikaAmazonAPI.Parameter.ProductPricing.ParameterGetItemOffers()
                {
                    ItemCondition = ItemCondition.New,
                    MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
                    Asin = "B0010WW4XS"
                });
            }



            OrdersSample ordersSample = new OrdersSample(amazonConnection);

            ordersSample.GetOrderListFulfillmentChannels();



            ParameterOrderList serachOrderList = new ParameterOrderList();
            serachOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);

            serachOrderList.OrderStatuses = new List<OrderStatuses>();
            serachOrderList.OrderStatuses.Add(OrderStatuses.Shipped);


            var orders = amazonConnection.Orders.GetOrders(serachOrderList);

            var list3 = amazonConnection.Financial.ListFinancialEvents(new ParameterListFinancialEvents()
            {
                PostedAfter = DateTime.UtcNow.AddDays(-15)
            });


            var item = amazonConnection.CatalogItem.GetCatalogItem("B00CZC5F0G");



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
