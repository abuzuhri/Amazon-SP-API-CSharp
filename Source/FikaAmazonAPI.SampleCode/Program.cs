﻿using FikaAmazonAPI.ConstructFeed;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Parameter.Finance;
using FikaAmazonAPI.Parameter.ListingItem;
using FikaAmazonAPI.Parameter.ListingsItems;
using FikaAmazonAPI.ReportGeneration;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Configuration;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.ListingsItems.ListingsItemPutRequest;
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
            });

            var urlNew = "https://tortuga-prod-eu.s3-eu-west-1.amazonaws.com/%2FNinetyDays/amzn1.tortuga.4.eu.dc22ade9-9019-4a81-abf8-a8bdb149cc40.T1GGA0FP21DYTU?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Date=20221022T062953Z&X-Amz-SignedHeaders=host&X-Amz-Expires=300&X-Amz-Credential=AKIAX2ZVOZFBEDHGMMEW%2F20221022%2Feu-west-1%2Fs3%2Faws4_request&X-Amz-Signature=d449493eeeb8a758de9173752af16255638f3ad8b178bdfe89bf50a898672a28";
            var processingReport = amazonConnection.Feed.GetFeedDocumentProcessingReport(urlNew);

            FeedsSample feedsSample = new FeedsSample(amazonConnection);
            feedsSample.SubmitFeedAddProductMessage();
            feedsSample.SubmitFeedInventory();
            feedsSample.SubmitFeedPRICING(50, "8432225129778...");

            ReportManager reportManageree = new ReportManager(amazonConnection);
            var allll = reportManageree.GetInventoryAging();



            var offfers = amazonConnection.ProductPricing.GetItemOffers(new Parameter.ProductPricing.ParameterGetItemOffers
            {
                Asin = "B000GGFYZE"
            });


            var headers = amazonConnection.ProductPricing.LastResponseHeader;


            var productsttt = reportManageree.GetProducts(); //GET_MERCHANT_LISTINGS_ALL_DATA

            Thread.Sleep(1000 * 60 * 15);


            double priceNow = 62;
            double minPrice = 0.12;
            while (true)
            {

                //Thread MapBarcodeToASIN = new Thread(() => feedsSample.SubmitFeedPRICING(priceNow, "843076000518"));
                //MapBarcodeToASIN.Start();

                Thread MapBarcodeToASIN2 = new Thread(() => feedsSample.SubmitFeedPRICING(priceNow, "074312026102..."));
                MapBarcodeToASIN2.Start();

                priceNow = priceNow - minPrice;
                Thread.Sleep(1000 * 60 * 3);

                if (priceNow < 54)
                    priceNow = 62;
            }

            var alllll = amazonConnection.ProductPricing.GetItemOffers(new Parameter.ProductPricing.ParameterGetItemOffers
            {
                Asin = "B00DLWONF2",
                ItemCondition = ItemCondition.New,
            });

            var Headers = amazonConnection.ProductPricing.LastResponseHeader;

            //use this method automatically know if the report are RDT or not
            var data2222 = amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FLAT_FILE_ACTIONABLE_ORDER_DATA_SHIPPING, DateTime.UtcNow.AddDays(-2), DateTime.UtcNow, null);

            // OR USE this method to get the document and pass parameter isRestrictedReport = true in case the report will return  PII data

            var data11111 = amazonConnection.Reports.GetReportDocument("50039018869997", true);







            var GetCatalogItem202204 = await amazonConnection.CatalogItem.GetCatalogItem202204Async(new Parameter.CatalogItems.ParameterGetCatalogItem
            {
                ASIN = "B00JK2YANC",
                includedData = new[] { IncludedData.attributes, IncludedData.salesRanks, IncludedData.summaries, IncludedData.productTypes, IncludedData.relationships, IncludedData.dimensions, IncludedData.identifiers, IncludedData.images }
            });

            var lissting = await amazonConnection.CatalogItem.SearchCatalogItems202204Async(new Parameter.CatalogItems.ParameterSearchCatalogItems202204
            {
                keywords = new[] { "vitamin c" },
                includedData = new[] { IncludedData.attributes, IncludedData.salesRanks, IncludedData.summaries, IncludedData.productTypes, IncludedData.relationships, IncludedData.dimensions, IncludedData.identifiers, IncludedData.images }
            });

            //IncludedData.images, IncludedData.identifiers, IncludedData.productTypes, IncludedData.salesRanks, IncludedData.summaries, IncludedData.variations, IncludedData.vendorDetails


            var test = amazonConnection.ProductPricing.GetItemOffers(new Parameter.ProductPricing.ParameterGetItemOffers()
            {
                Asin = "B000RTDUOW"
            });

            var result = amazonConnection.Financial.ListFinancialEventsAsync(new ParameterListFinancialEvents()
            {
                MaxNumberOfPages = 4,
                PostedAfter = new DateTime(2021, 1, 1),
                PostedBefore = new DateTime(2021, 5, 13)
            });
            DateTime startDate = new DateTime(2021, 10, 03);
            var data = amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_FBA_REIMBURSEMENTS_DATA, startDate, null, null);


            //DateTime startDate = new DateTime(2021, 10, 03);
            var data2 = amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_EASYSHIP_DOCUMENTS, startDate, null, null);








            var fbaSmallAndLightSample = new FbaSmallAndLightSample(amazonConnection);

            ////await fbaSmallAndLightSample.GetSmallAndLightEnrollmentBySellerSKUAsync();
            ////await fbaSmallAndLightSample.GetSmallAndLightEligibilityBySellerSKUAsync();
            //await fbaSmallAndLightSample.GetSmallAndLightFeePreviewAsync();
            //return;



            var dataShipment = amazonConnection.FulFillmentInbound.GetShipmentItemsByShipmentId("FBA15D7NR6M9");

            AmazonConnection codeAmazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = config.GetSection("MWSAmazonAPI:AccessKey").Value,
                SecretKey = config.GetSection("MWSAmazonAPI:SecretKey").Value,
                RoleArn = config.GetSection("MWSAmazonAPI:RoleArn").Value,
                ClientId = config.GetSection("MWSAmazonAPI:ClientId").Value,
                ClientSecret = config.GetSection("MWSAmazonAPI:ClientSecret").Value,
                MarketPlace = MarketPlace.GetMarketPlaceByID(config.GetSection("MWSAmazonAPI:MarketPlaceID").Value),
                IsActiveLimitRate = true
            });

            CreateShipmentPlan(amazonConnection);



            var aha = amazonConnection.ProductType.SearchDefinitionsProductTypes(new Parameter.ProductTypes.SearchDefinitionsProductTypesParameter()
            {
                keywords = new List<string> { String.Empty },
            });

            var def = amazonConnection.ProductType.GetDefinitionsProductType(new Parameter.ProductTypes.GetDefinitionsProductTypeParameter()
            {
                productType = "PRODUCT",
                requirements = RequirementsEnum.LISTING,
                locale = AmazonSpApiSDK.Models.ProductTypes.LocaleEnum.en_US
            });

            var result33 = amazonConnection.Restrictions.GetListingsRestrictions(new Parameter.Restrictions.ParameterGetListingsRestrictions
            {
                asin = "B07GY3J99B",
                sellerId = "A3J37AJU4O9RHK"
            });

            var SKU = "693749790020";
            var sellerId = "A3J37AJU4O9RHK";

            ParameterPutListingItem myListing = new ParameterPutListingItem()
            {
                sellerId = sellerId,
                marketplaceIds = new string[] { MarketPlace.UnitedArabEmirates.ID },
                sku = SKU,
                listingsItemPutRequest = new ListingsItemPutRequest()
                {
                    productType = "PRODUCT",
                    requirements = Requirements.LISTING,

                    //Example from https://developer-docs.amazon.com/sp-api/docs/listings-items-api-v2020-09-01-use-case-guide
                    attributes = new ParameterAttributes()
                    {
                        condition_type = new List<ParameterAttributeItem>() {
                                new ParameterAttributeItem()
                                {
                                    value = "new_new",
                                    marketplace_id = MarketPlace.UnitedArabEmirates.ID
                                }
                            },
                        item_name = new List<ParameterAttributeItem>()
                            {
                                new ParameterAttributeItem()
                                {
                                    value = "Thorne Research - Diabenil - Support for Maintaining Healthy Blood Sugar Levels - with Chromium, ALA, and Quercetin Phytosome - 90 Capsules - ",
                                    language_tag = "en_US",
                                    marketplace_id = MarketPlace.UnitedArabEmirates.ID
                                }
                            }
                    }
                }
            };

            var response = amazonConnection.ListingsItem.PutListingsItem(myListing);


            ReportManager reportManager2 = new ReportManager(amazonConnection);
            var products2 = await reportManager2.GetReturnFBAOrderAsync(3); //GET_MERCHANT_LISTINGS_ALL_DATA




            //var parameterOrderList = new ParameterOrderList
            //{
            //    CreatedAfter = DateTime.UtcNow.AddHours(-24),
            //    OrderStatuses = new List<OrderStatuses> { OrderStatuses.Unshipped },
            //    IsNeedRestrictedDataToken = true,
            //    RestrictedDataTokenRequest = new CreateRestrictedDataTokenRequest
            //    {
            //        restrictedResources = new List<RestrictedResource>
            //    {
            //        new RestrictedResource
            //        {
            //            method = Method.GET.ToString(),
            //            path = ApiUrls.OrdersApiUrls.Orders,
            //            dataElements = new List<string> { "buyerInfo", "shippingAddress" }
            //        }
            //    }
            //    }
            //};

            //var ordersqqqq = await amazonConnection.Orders.GetOrdersAsync(parameterOrderList);




            var seller = await amazonConnection.Seller.GetMarketplaceParticipationsAsync();

            var dataaa = await amazonConnection.FbaInventory.GetInventorySummariesAsync(new Parameter.FbaInventory.ParameterGetInventorySummaries
            {
                granularityType = AmazonSpApiSDK.Models.FbaInventory.Granularity.GranularityTypeEnum.Marketplace,
                granularityId = config.GetSection("FikaAmazonAPI:MarketPlaceID").Value
            });

            ReportManager reportManager = new ReportManager(amazonConnection);
            var products = reportManager.GetProducts(); //GET_MERCHANT_LISTINGS_ALL_DATA
            var inventoryAging = reportManager.GetInventoryAging(); //GET_FBA_INVENTORY_AGED_DATA
            var ordersByDate = await reportManager.GetOrdersByOrderDateAsync(90); //GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL
            var ordersByLastUpdate = await reportManager.GetOrdersByLastUpdateAsync(90); //GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL
            var settlementOrder = reportManager.GetSettlementOrder(90); //GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2
            var returnMFNOrder = reportManager.GetReturnMFNOrder(90); //GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE
            var returnFBAOrder = reportManager.GetReturnFBAOrder(90); //GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA
            var reimbursementsOrder = reportManager.GetReimbursementsOrder(180); //GET_FBA_REIMBURSEMENTS_DATA
            var feedbacks = reportManager.GetFeedbackFromDays(180); //GET_SELLER_FEEDBACK_DATA





            OrdersSample ordersSample = new OrdersSample(amazonConnection);

            ordersSample.GetOrderListFulfillmentChannels();





            var list3 = amazonConnection.Financial.ListFinancialEvents(new ParameterListFinancialEvents()
            {
                PostedAfter = DateTime.UtcNow.AddDays(-15)
            });











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


        public static void CreateShipmentPlan(AmazonConnection amazonConnection)
        {
            FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.CreateInboundShipmentPlanRequest oCreateInboundShipmentPlanRequest = new FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.CreateInboundShipmentPlanRequest();

            oCreateInboundShipmentPlanRequest.ShipToCountryCode = "AE";
            oCreateInboundShipmentPlanRequest.LabelPrepPreference = FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.LabelPrepPreference.SELLERLABEL;


            oCreateInboundShipmentPlanRequest.ShipFromAddress = new FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.Address();
            oCreateInboundShipmentPlanRequest.ShipFromAddress.AddressLine1 = "Add";
            oCreateInboundShipmentPlanRequest.ShipFromAddress.AddressLine2 = "ADD2";
            oCreateInboundShipmentPlanRequest.ShipFromAddress.City = "City";
            oCreateInboundShipmentPlanRequest.ShipFromAddress.CountryCode = "AE";
            oCreateInboundShipmentPlanRequest.ShipFromAddress.PostalCode = "0000";
            oCreateInboundShipmentPlanRequest.ShipFromAddress.Name = "Name";



            oCreateInboundShipmentPlanRequest.InboundShipmentPlanRequestItems = new FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.InboundShipmentPlanRequestItemList();
            FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.InboundShipmentPlanRequestItem oInboundShipmentPlanRequestItem = new FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.InboundShipmentPlanRequestItem();
            oInboundShipmentPlanRequestItem.SellerSKU = "16118";
            oInboundShipmentPlanRequestItem.ASIN = "B08BXH6234";
            oInboundShipmentPlanRequestItem.Quantity = 1;
            oInboundShipmentPlanRequestItem.Condition = FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.Condition.NewItem;

            oCreateInboundShipmentPlanRequest.InboundShipmentPlanRequestItems.Add(oInboundShipmentPlanRequestItem);
            FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound.CreateInboundShipmentPlanResult oResult = amazonConnection.FulFillmentInbound.CreateInboundShipmentPlan(oCreateInboundShipmentPlanRequest);

        }



    }
}
