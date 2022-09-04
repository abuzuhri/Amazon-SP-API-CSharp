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
        public async void SubmitFeedPRICING(double PRICE, string SKU)
        {

            ConstructFeedService createDocument = new ConstructFeedService("A3J37AJU4O9RHK", "1.02");

            var list = new List<PriceMessage>();
            list.Add(new PriceMessage()
            {
                SKU = SKU,
                StandardPrice = new StandardPrice()
                {
                    currency = BaseCurrencyCode.AED.ToString(),
                    Value = (PRICE).ToString("0.00")
                }
            });
            createDocument.AddPriceMessage(list);

            var xml = createDocument.GetXML();

            var feedID = await amazonConnection.Feed.SubmitFeedAsync(xml, FeedType.POST_PRODUCT_PRICING_DATA);

            string ResultFeedDocumentId = string.Empty;
            while (string.IsNullOrEmpty(ResultFeedDocumentId))
            {
                var feedOutput = await amazonConnection.Feed.GetFeedAsync(feedID);
                if (feedOutput.ProcessingStatus == AmazonSpApiSDK.Models.Feeds.Feed.ProcessingStatusEnum.DONE)
                {
                    var outPut = await amazonConnection.Feed.GetFeedDocumentAsync(feedOutput.ResultFeedDocumentId);

                    var reportOutput = outPut.Url;

                    var processingReport = await amazonConnection.Feed.GetFeedDocumentProcessingReportAsync(reportOutput);

                    Console.WriteLine("MessagesProcessed=" + processingReport.ProcessingSummary.MessagesProcessed);
                    Console.WriteLine("MessagesSuccessful= " + processingReport.ProcessingSummary.MessagesSuccessful);
                    Console.WriteLine("MessagesWithError=" + processingReport.ProcessingSummary.MessagesWithError);
                    Console.WriteLine("MessagesWithWarning=" + processingReport.ProcessingSummary.MessagesWithWarning);
                    Console.WriteLine("ResultDescription=" + processingReport.Result.FirstOrDefault()?.ResultDescription);
                }

                if (!(feedOutput.ProcessingStatus == AmazonSpApiSDK.Models.Feeds.Feed.ProcessingStatusEnum.INPROGRESS ||
                    feedOutput.ProcessingStatus == AmazonSpApiSDK.Models.Feeds.Feed.ProcessingStatusEnum.INQUEUE))
                    break;
                else Thread.Sleep(10000);
            }



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

        public void CartonContentsRequestFeed()
        {
            ConstructFeedService createDocument2 = new ConstructFeedService("{SellerID}", "1.02");

            var list22 = new List<CartonContentsRequest>();
            list22.Add(new CartonContentsRequest()
            {
                ShipmentId = "FBA123456",
                Carton = new List<Carton> {
                    new Carton() {
                    CartonId="1",
                    Item=new List<CartonItem>(){
                        new CartonItem() {
                            QuantityInCase=1,
                        QuantityShipped=1,
                        SKU="7004"
                        }
                    }
                    },
                    new Carton() {
                    CartonId="2",
                    Item=new List<CartonItem>(){
                        new CartonItem() {
                            QuantityInCase=12,
                        QuantityShipped=12,
                        SKU="4051"
                        }
                    }
                    }
                }
            });

            createDocument2.AddCartonContentsRequest(list22);

            var xml222 = createDocument2.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml222, FeedType.POST_FBA_INBOUND_CARTON_CONTENTS);
        }
    }
}
