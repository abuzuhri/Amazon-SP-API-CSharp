using FikaAmazonAPI.AmazonSpApiSDK.Models.Feeds;
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

        public void CallFlatfile()
        {
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
                SKU = "API.853038006021.20789.1001",
                Quantity = 1
            });
            createDocument.AddInventoryMessage(list);
            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_INVENTORY_AVAILABILITY_DATA);
            GetFeedDetails(feedID);
        }

        /// <summary>
        /// UnderTest
        /// </summary>
        public void SubmitFeedAddProductMessage(string ASIN, string SKU)
        {
            ConstructFeedService createDocument = new ConstructFeedService(amazonConnection.GetCurrentSellerID, "1.02");

            var list = new List<ProductMessage>();
            list.Add(new ProductMessage()
            {
                SKU = SKU,

                StandardProductID = new ConstructFeed.Messages.StandardProductID()
                {
                    Type = "ASIN",
                    Value = ASIN
                }
            });
            createDocument.AddProductMessage(list, OperationType.Update);
            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_PRODUCT_DATA);

            GetFeedDetails(feedID);
        }

        public void SubmitFeedDeleteAddProductMessage()
        {
            ConstructFeedService createDocument = new ConstructFeedService("A3J37AJU4O9RHK", "1.02");

            var list = new List<ProductMessage>();
            list.Add(new ProductMessage()
            {
                SKU = "8432225129778...."
            });
            createDocument.AddProductMessage(list, OperationType.Delete);
            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeedContent(xml, FeedType.POST_PRODUCT_DATA);

            GetFeedDetails(feedID);
        }
        public void AddOfferMessageMessage()
        {
            ConstructFeedService createDocument = new ConstructFeedService("A3J37AJU4O9RHK", "1.02");

            var list = new List<OfferMessage>();
            list.Add(new OfferMessage()
            {
                SKU = "4049639414402_b"
            });
            createDocument.AddOfferMessage(list, OperationType.Delete);
            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_PRODUCT_DATA);

            GetFeedDetails(feedID);
        }

        public void SubmitFeedPRICING(double PRICE, string SKU)
        {

            ConstructFeedService createDocument = new ConstructFeedService(amazonConnection.GetCurrentSellerID, "1.02");

            var list = new List<PriceMessage>();
            list.Add(new PriceMessage()
            {
                SKU = SKU,
                StandardPrice = new StandardPrice()
                {
                    currency = amazonConnection.GetCurrentMarketplace.CurrencyCode.ToString(),
                    Value = (PRICE).ToString("0.00")
                }
            });
            createDocument.AddPriceMessage(list);

            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_PRODUCT_PRICING_DATA);

            GetFeedDetails(feedID);

        }

        public async Task SubmitFeedPricingWithSalePrice(string sku, decimal price, decimal salePrice, DateTime startDate, DateTime endDate)
        {
            var currencyCode = amazonConnection.GetCurrentMarketplace.CurrencyCode.ToString();

            var createDocument = new ConstructFeedService("A3J37AJU4O9RHK", "1.02");

            var list = new List<PriceMessage>();
            list.Add(new PriceMessage
            {
                SKU = sku,
                StandardPrice = new StandardPrice
                {
                    currency = currencyCode,
                    Value = price.ToString("0.00")
                },
                Sale = new Sale
                {
                    SalePrice = new StandardPrice
                    {
                        currency = currencyCode,
                        Value = salePrice.ToString("0.00")
                    },
                    StartDate = startDate.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fffK"),
                    EndDate = endDate.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fffK")
                }
            });
            createDocument.AddPriceMessage(list);

            var xml = createDocument.GetXML();

            var feedId = await amazonConnection.Feed.SubmitFeedAsync(xml, FeedType.POST_PRODUCT_PRICING_DATA);

            GetFeedDetails(feedId);
        }


        public void SubmitFeedSale(double PRICE, string SKU)
        {

            ConstructFeedService createDocument = new ConstructFeedService("A3J37AJU4O9RHK", "1.02");

            var list = new List<PriceMessage>();
            list.Add(new PriceMessage()
            {
                SKU = SKU,
                StandardPrice = new StandardPrice()
                {
                    currency = amazonConnection.GetCurrentMarketplace.CurrencyCode.ToString(),
                    Value = (PRICE).ToString("0.00")
                },
                Sale = new Sale()
                {
                    StartDate = DateTime.UtcNow.AddDays(+1).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK"),
                    EndDate = DateTime.UtcNow.AddDays(+2).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK"),
                    SalePrice = new StandardPrice()
                    {
                        currency = amazonConnection.GetCurrentMarketplace.CurrencyCode.ToString(),
                        Value = (PRICE - 10).ToString("0.00")
                    }
                }
            });
            createDocument.AddPriceMessage(list);

            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_PRODUCT_PRICING_DATA);

            GetFeedDetails(feedID);

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


            GetFeedDetails(feedID);
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
            GetFeedDetails(feedID);
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
                                                currency = amazonConnection.GetCurrentMarketplace.CurrencyCode
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
            GetFeedDetails(feedID);
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
                        SKU="4051",
                        ExpirationDate=DateTime.Now,
                        }
                    }
                    }
                }
            });

            createDocument2.AddCartonContentsRequest(list22);

            var xml222 = createDocument2.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml222, FeedType.POST_FBA_INBOUND_CARTON_CONTENTS);
            GetFeedDetails(feedID);
        }

        public void SubmitFeedEasyShipDocument()
        {
            ConstructFeedService createDocument = new ConstructFeedService("{sellerId}", "1.02");
            var list = new List<EasyShipDocumentMessage>();
            list.Add(new EasyShipDocumentMessage()
            {
                AmazonOrderID = "AMZ1234567890123",
                DocumentTypes = new List<EasyShipDocumentType>() {
                    EasyShipDocumentType.ShippingLabel
                }
            });
            createDocument.AddEasyShipDocumentMessage(list);
            var xml = createDocument.GetXML();

            var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_EASYSHIP_DOCUMENTS);
            GetFeedDetails(feedID);
        }

        public void GetFeedDetails(string feedID)
        {
            string ResultFeedDocumentId = string.Empty;
            while (string.IsNullOrEmpty(ResultFeedDocumentId))
            {
                var feedOutput = amazonConnection.Feed.GetFeed(feedID);
                if (feedOutput.ProcessingStatus == Feed.ProcessingStatusEnum.DONE)
                {
                    var outPut = amazonConnection.Feed.GetFeedDocument(feedOutput.ResultFeedDocumentId);

                    var reportOutput = outPut.Url;

                    var processingReport = amazonConnection.Feed.GetFeedDocumentProcessingReport(outPut);

                    DisplayProcessingReportMessage(processingReport);

                    break;
                }

                if (!(feedOutput.ProcessingStatus == Feed.ProcessingStatusEnum.INPROGRESS ||
                    feedOutput.ProcessingStatus == Feed.ProcessingStatusEnum.INQUEUE))
                    break;
                else Thread.Sleep(10000);
            }
        }
        private void DisplayProcessingReportMessage(ProcessingReportMessage processingReport)
        {
            Console.WriteLine("MessagesProcessed=" + processingReport.ProcessingSummary.MessagesProcessed);
            Console.WriteLine("MessagesSuccessful= " + processingReport.ProcessingSummary.MessagesSuccessful);
            Console.WriteLine("MessagesWithError=" + processingReport.ProcessingSummary.MessagesWithError);
            Console.WriteLine("MessagesWithWarning=" + processingReport.ProcessingSummary.MessagesWithWarning);

            if (processingReport.Result != null && processingReport.Result.Count > 0)
            {
                foreach (var itm in processingReport.Result)
                {
                    Console.WriteLine("ResultDescription=" + (itm.AdditionalInfo?.SKU ?? string.Empty) + " > " + itm.ResultDescription);
                }
            }
        }
    }
}
