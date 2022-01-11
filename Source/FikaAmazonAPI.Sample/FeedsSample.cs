using FikaAmazonAPI.ConstructFeed;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FikaAmazonAPI.ConstructFeed.BaseXML;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Sample
{
    public class FeedsSample
    {
        AmazonConnection amazonConnection;
        public FeedsSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }


        public void GetFeeds()
        {

            var data = amazonConnection.Feed.GetFeeds(new Parameter.Feed.ParameterGetFeed()
            {
                processingStatuses = ProcessingStatuses.DONE,
                pageSize = 100,
                feedTypes = new List<FeedType> { FeedType.POST_PRODUCT_PRICING_DATA },
                createdSince = DateTime.UtcNow.AddDays(-6),
                createdUntil = DateTime.UtcNow.AddDays(-1),
                marketplaceIds = new List<string> { MarketPlace.UnitedArabEmirates.ID }
            });
        }


        public void CreateFeedDocument()
        {

            var data = amazonConnection.Feed.CreateFeedDocument(ContentType.XML);
        }



        public void GetFeedDocument()
        {

            var data2 = amazonConnection.Feed.GetFeedDocument("amzn1.tortuga.3.92d8fd38-6ccf-49be-979f-6dc27375ea3e.T2DF7HINJ0NRA2");
        }

        public void GetFeed()
        {

            var data2 = amazonConnection.Feed.GetFeed("194146018872");
        }

        public void CancelFeed()
        {

            var data2 = amazonConnection.Feed.CancelFeed("194146018872");
        }

        public void SubmitFeedInventory()
        {
            ConstructFeedService createDocument = new ConstructFeedService("A3J37AJU4O9RHK", "1.02");
            var list = new List<InventoryMessage>();
            list.Add(new InventoryMessage()
            {
                SKU = "8201031206122...",
                Quantity = 2,
                FulfillmentLatency = "11",
            });
            createDocument.AddInventoryMessage(list);
            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_INVENTORY_AVAILABILITY_DATA);

        }

        /// <summary>
        /// UnderTest
        /// </summary>
        //public void SubmitFeedMaxOrderQuantity()
        //{
        //    ConstructFeedService createDocument = new ConstructFeedService("A3J37AJU4O9RHK", "1.02");
            
        //    var list = new List<ProductMessage>();
        //    list.Add(new ProductMessage()
        //    {
        //        SKU = "8201031206122...",
        //        StandardProductID = new ConstructFeed.Messages.StandardProductID()
        //        {
        //            Type = "ASIN",
        //            Value= "B08CDYB2DC"
        //        },
        //        DescriptionData = new DescriptionData()
        //        {
        //            MaxOrderQuantity=2,
        //            Title= "REBUNE RE-2061-1Hot Air Styler Hair Styler 1000 Watts 3 In 1"
        //        }
        //    });
        //    createDocument.AddProductMessage(list,OperationType.Update);
        //    var xml = createDocument.GetXML();

        //    var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_PRODUCT_DATA);

        //}
        public void SubmitFeedPRICING()
        {

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

            var feedOutput = amazonConnection.Feed.GetFeed(feedID);

            var outPut = amazonConnection.Feed.GetFeedDocument(feedOutput.ResultFeedDocumentId);

            var reportOutput = outPut.Url;


            var processingReport = amazonConnection.Feed.GetFeedDocumentProcessingReport(reportOutput);
        }
    }
}
