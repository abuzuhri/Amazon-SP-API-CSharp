using FikaAmazonAPI.ConstructFeed;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Utils;
using static FikaAmazonAPI.ConstructFeed.BaseXML;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
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

        public void FeebPostOrderFullfillment()
        {
            ConstructFeedService createDocument = new ConstructFeedService("{sellerId}", "1.02");

            var list = new List<OrderFulfillmentMessage>();

            list.Add(new OrderFulfillmentMessage()
            {
                AmazonOrderID = "{orderId}",
                FulfillmentDate = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK"),
                FulfillmentData = new FulfillmentData()
                {
                    CarrierName = "Correos Express",
                    ShippingMethod = "ePaq",
                    ShipperTrackingNumber = "{trackingNumber}"
                }
            });
            createDocument.AddOrderFulfillmentMessage(list);

            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_ORDER_FULFILLMENT_DATA);


            var feedOutput = amazonConnection.Feed.GetFeed(feedID);
            var outPut = amazonConnection.Feed.GetFeedDocument(feedOutput.ResultFeedDocumentId);
            var processingReport = amazonConnection.Feed.GetFeedDocumentProcessingReport(outPut.Url);
        }

        public void SubmitFeedOrderAcknowledgement()
        {
            ConstructFeedService createDocument = new ConstructFeedService("{sellerId}", "1.02");
            var list = new List<OrderAcknowledgementMessage>();
            list.Add(new OrderAcknowledgementMessage()
            {
                AmazonOrderID = "AMZ1234567890123",
                MerchantOrderID = "12345678",
                StatusCode = OrderAcknowledgementStatusCode.Success,
                Item = new List<OrderAcknowledgementItem>() {
                   new OrderAcknowledgementItem() {
                       AmazonOrderItemCode = "52986411826454",
                       MerchantOrderItemID = "1"
                       }
                }
            });
            createDocument.AddOrderAcknowledgementMessage(list);
            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_ORDER_ACKNOWLEDGEMENT_DATA);
        }

        public void SubmitFeedOrderAdjustment()
        {
            ConstructFeedService createDocument = new ConstructFeedService("{sellerId}", "1.02");
            var list = new List<OrderAdjustmentMessage>();
            list.Add(new OrderAdjustmentMessage()
            {
                AmazonOrderID = "AMZ1234567890123",
                ActionType = AdjustmentActionType.Refund,
                AdjustedItem = new List<AdjustedItem>() {
                   new AdjustedItem() {
                       AmazonOrderItemCode = "52986411826454",
                       AdjustmentReason = AdjustmentReason.CustomerCancel,
                       DirectPaymentAdjustments = new List<DirectPaymentAdjustments>()
                           {
                               new DirectPaymentAdjustments()
                               {
                                   Component = new List<DirectPaymentAdjustmentsComponent>()
                                   {
                                       new DirectPaymentAdjustmentsComponent() {
                                            DirectPaymentType = "Credit Card Refund",
                                            Amount = new CurrencyAmount() {
                                                Value = 10.50M,
                                                currency = BaseCurrencyCode.GBP
                                            }
                                       }
                                   }
                               }
                           }
                       }
                }
            });
            createDocument.AddOrderAdjustmentMessage(list);
            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_PAYMENT_ADJUSTMENT_DATA);
        }
    }
}
