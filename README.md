# ☕Amazon Selling Partner API C# 🚀 [![.NET](https://github.com/abuzuhri/Amazon-SP-API-CSharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/abuzuhri/Amazon-SP-API-CSharp/actions/workflows/dotnet.yml) [![NuGet](https://img.shields.io/nuget/v/CSharpAmazonSpAPI.svg)](https://www.nuget.org/packages/CSharpAmazonSpAPI/) [![Gitter Chat](https://badges.gitter.im/bitwarden/Lobby.svg)](https://gitter.im/Amazon-SP-API-CSharp/community)


This is an API Binding in .Net C# for the new Amazon Selling Partner API.

This library is based on the output of [swagger-codegen](https://app.swaggerhub.com/home) with the [OpenAPI files provided by Amazon (Models)](https://github.com/amzn/selling-partner-api-models/tree/main/models) and has been modified by the contributors.

The purpose of this package is to have an easy way of getting started with the Amazon Selling Partner API using C#, you can watch this 📷 [Youtube](https://www.youtube.com/watch?v=1gZJBCoMr70) 📣 video for easy start your project

---
### Requirements
- [AWSSDK.SecurityToken](https://www.nuget.org/packages/AWSSDK.SecurityToken/)
- [AWSSDK.SQS](https://www.nuget.org/packages/AWSSDK.SQS/)
- [Microsoft.CSharp](https://www.nuget.org/packages/Microsoft.CSharp/)
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)
- [RestSharp](https://www.nuget.org/packages/RestSharp/)
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations/)
- [System.Reflection](https://www.nuget.org/packages/System.Reflection/)


---
## Installation [![NuGet](https://img.shields.io/nuget/v/CSharpAmazonSpAPI.svg)](https://www.nuget.org/packages/CSharpAmazonSpAPI/)

```powershell
Install-Package CSharpAmazonSpAPI
```

---
### Tasks
#### Seller

- [x] [OrdersV0](https://developer-docs.amazon.com/sp-api/docs/orders-api-v0-reference)
- [x] [Reports](https://developer-docs.amazon.com/sp-api/docs/reports-api-v2021-06-30-reference)
- [x] [FinancesV0](https://developer-docs.amazon.com/sp-api/docs/finances-api-reference)
- [x] [Feeds](https://developer-docs.amazon.com/sp-api/docs/feeds-api-v2021-06-30-reference) [Use Case Guide](https://developer-docs.amazon.com/sp-api/docs/feeds-api-v2021-06-30-use-case-guide) [feedType](https://developer-docs.amazon.com/sp-api/docs/feed-type-values)
- [x] [ListingsItems](https://developer-docs.amazon.com/sp-api/docs/listings-items-api-v2021-08-01-reference)  [Use Case Guide](https://developer-docs.amazon.com/sp-api/docs/listings-items-api-v2021-08-01-use-case-guide)
- [x] [Restrictions](https://developer-docs.amazon.com/sp-api/docs/listings-restrictions-api-v2021-08-01-reference)  [Use Case Guide](https://developer-docs.amazon.com/sp-api/docs/listings-restrictions-api-v2021-08-01-use-case-guide)
- [x] [ProductTypes](https://developer-docs.amazon.com/sp-api/docs/product-type-definitions-api-v2020-09-01-reference)  [Use Case Guide](https://developer-docs.amazon.com/sp-api/docs/product-type-api-use-case-guide)
- [x] [Uploads](https://developer-docs.amazon.com/sp-api/docs/uploads-api-reference)  [Use Case Guide](https://developer-docs.amazon.com/sp-api/docs/uploads-api-use-case-guide)
- [x] [shipmentInvoicingV0](https://developer-docs.amazon.com/sp-api/docs/shipment-invoicing-api-v0-reference)
- [x] [Shippings](https://developer-docs.amazon.com/sp-api/docs/shipping-api-v1-reference)
- [x] [CatalogItemsV0](https://developer-docs.amazon.com/sp-api/docs/catalog-items-api-v0-reference)
- [x] [CatalogItemsV20220401](https://developer-docs.amazon.com/sp-api/docs/catalog-items-api-v2022-04-01-reference)
- [x] [FBAInventory](https://developer-docs.amazon.com/sp-api/docs/fbainventory-api-v1-reference)
- [x] [FBASmallAndLight](https://developer-docs.amazon.com/sp-api/docs/fbasmallandlight-api-v1-reference)
- [x] [FBAInboundEligibility](https://developer-docs.amazon.com/sp-api/docs/fbainboundeligibility-api-v1-reference)
- [x] [FulFillmentInbound](https://developer-docs.amazon.com/sp-api/docs/fulfillment-inbound-api-v0-reference)
- [x] [FulFillmentOutbound](https://developer-docs.amazon.com/sp-api/docs/fulfillment-outbound-api-v2020-07-01-reference)
- [x] [MerchantFulFillment](https://developer-docs.amazon.com/sp-api/docs/merchant-fulfillment-api-v0-reference)
- [x] [Messaging](https://developer-docs.amazon.com/sp-api/docs/messaging-api-v1-reference)
- [x] [Notifications](https://developer-docs.amazon.com/sp-api/docs/notifications-api-v1-reference)  [Use Case Guide](https://developer-docs.amazon.com/sp-api/docs/notifications-api-v1-use-case-guide)
- [x] [ProductFeesV0](https://developer-docs.amazon.com/sp-api/docs/product-fees-api-v0-reference)
- [x] [ProductPricingV0](https://developer-docs.amazon.com/sp-api/docs/product-pricing-api-v0-reference)
- [x] [Sales](https://developer-docs.amazon.com/sp-api/docs/sales-api-v1-reference)
- [x] [Sellers](https://developer-docs.amazon.com/sp-api/docs/sellers-api-v1-reference)
- [ ] [Services](https://developer-docs.amazon.com/sp-api/docs/services-api-v1-reference)
- [x] [Solicitations](https://developer-docs.amazon.com/sp-api/docs/solicitations-api-v1-reference)
- [x] [Token](https://developer-docs.amazon.com/sp-api/docs/tokens-api-v2021-03-01-reference)  [Use Case Guide](https://developer-docs.amazon.com/sp-api/docs/tokens-api-use-case-guide)
- [x] [Authorization](https://developer-docs.amazon.com/sp-api/docs/authorization-api-v1-reference)
- [x] [Easy Ship](https://developer-docs.amazon.com/sp-api/docs/easy-ship-api-v2022-03-23-reference)
- [ ] [A+ Content](https://developer-docs.amazon.com/sp-api/docs/selling-partner-api-for-a-content-management)
- [ ] [Replenishment](https://developer-docs.amazon.com/sp-api/docs/replenishment-api-v2022-11-07-reference)


#### Vendor 

- [ ] [VendorDirectFulfillmentInventoryV1](https://developer-docs.amazon.com/sp-api/docs/vendor-direct-fulfillment-inventory-api-v1-reference)
- [x] [VendorDirectFulfillmentOrdersV1](https://developer-docs.amazon.com/sp-api/docs/vendor-direct-fulfillment-orders-api-v1-reference)
- [ ] [VendorDirectFulfillmentPaymentsV1](https://developer-docs.amazon.com/sp-api/docs/vendor-direct-fulfillment-payments-api-v1-reference)
- [ ] [VendorDirectFulfillmentShippingV1](https://developer-docs.amazon.com/sp-api/docs/vendor-direct-fulfillment-shipping-api-v1-reference)
- [ ] [VendorDirectFulfillmentTransactionsV1](https://developer-docs.amazon.com/sp-api/docs/vendor-direct-fulfillment-transactions-api-v1-reference)
- [x] [VendorOrders](https://developer-docs.amazon.com/sp-api/docs/vendor-orders-api-v1-reference)
- [ ] [vendorInvoices](https://developer-docs.amazon.com/sp-api/docs/vendor-invoices-api-v1-reference)
- [ ] [VendorShipments](https://developer-docs.amazon.com/sp-api/docs/vendor-shipments-api-v1-reference)
- [ ] [VendorTransactionStatus](https://developer-docs.amazon.com/sp-api/docs/vendor-transaction-status-api-v1-reference)



---
## Keys
To get all keys needed you need to follow this step [Creating and configuring IAM policies and entities](https://developer-docs.amazon.com/sp-api/docs/creating-and-configuring-iam-policies-and-entities) and then you need to [Registering your Application](https://developer-docs.amazon.com/sp-api/docs/registering-your-application) then [Authorizing Selling Partner API applications
](https://developer-docs.amazon.com/sp-api/docs/authorizing-selling-partner-api-applications#step-1-request-a-login-with-amazon-access-token)


| Name | Description |
| --- | --- |
| Marketplace | Marketplace region [List of Marketplaces](https://developer-docs.amazon.com/sp-api/docs/marketplace-ids)|
| ClientId | Your amazon app id |
| ClientSecret | Your amazon app secret |
| RefreshToken | Check how to get [RefreshToken](https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/developer-guide/SellingPartnerApiDeveloperGuide.md#Self-authorization) |


For more information about keys please check [New Amazon doc for create keys Developer ](https://developer-docs.amazon.com/sp-api/docs/creating-and-configuring-iam-policies-and-entities) , If you are not registered as developer please [Register](https://developer.amazonservices.com/) to be able to create application. 

---
## Usage

> ### Please be aware there has been a change to the _Orders.GetOrderAddress()_ method please reference the new sample code for more details.

### Configuration
You can configure a connection like so please see [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/Program.cs) for the relevant code file.
```CSharp
AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
{
     ClientId = "amzn1.application-XXX-client.XXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     ClientSecret = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     RefreshToken= "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     MarketPlace = MarketPlace.UnitedArabEmirates, //MarketPlace.GetMarketPlaceByID("A2VIGQ35RCS4UG") 
});

or 

AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
{
     ClientId = "amzn1.application-XXX-client.XXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     ClientSecret = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     RefreshToken= "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     MarketPlaceID = "A2VIGQ35RCS4UG"
});

```

### Configuration using a proxy
Please see [here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/Program.cs) for the relevant code file.
>```csharp
>AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
>{
>     ClientId = "amzn1.application-XXX-client.XXXXXXXXXXXXXXXXXXXXXXXXXXXX",
>     ClientSecret = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
>     RefreshToken= "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
>     MarketPlaceID = "A2VIGQ35RCS4UG",
>     ProxyAddress = "http(s)://xxx.xxx.xxx.xxx:xxxx",
>});
>```
>> * Assign your proxy address to the ProxyAddress Property and you'll be able to use a proxy account. 
>>
>> ***This is not required and will operate normally without the ProxyAddress being set.***

### Order List, For more orders sample please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/ReportsSample.cs).
```CSharp
ParameterOrderList serachOrderList = new ParameterOrderList();
serachOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);
serachOrderList.OrderStatuses = new List<OrderStatuses>();
serachOrderList.OrderStatuses.Add(OrderStatuses.Canceled);
var orders = amazonConnection.Orders.GetOrders(serachOrderList);

```


### Order List with parameter
```CSharp
ParameterOrderList serachOrderList = new ParameterOrderList();
serachOrderList.CreatedAfter = DateTime.UtcNow.AddHours(-24);
serachOrderList.OrderStatuses = new List<OrderStatuses>();
serachOrderList.OrderStatuses.Add(OrderStatuses.Unshipped);
serachOrderList.MarketplaceIds = new List<string> { MarketPlace.UnitedArabEmirates.ID };

var orders = amazonConnection.Orders.GetOrders(serachOrderList);

```


### Order List with parameter including PII data Simple
```CSharp
var parameterOrderList = new ParameterOrderList
        {
            CreatedAfter = DateTime.UtcNow.AddHours(-24),
            OrderStatuses = new List<OrderStatuses> { OrderStatuses.Unshipped },
            MarketplaceIds = new List<string> { MarketPlace.UnitedArabEmirates.ID },
            IsNeedRestrictedDataToken = true
        };

var orders = _amazonConnection.Orders.GetOrders(parameterOrderList);

```

### Order List with parameter including PII data Advance (if you want to get specific data Elements object only)
```CSharp
var parameterOrderList = new ParameterOrderList
        {
            CreatedAfter = DateTime.UtcNow.AddHours(-24),
            OrderStatuses = new List<OrderStatuses> { OrderStatuses.Unshipped },
            MarketplaceIds = new List<string> { MarketPlace.UnitedArabEmirates.ID },
            IsNeedRestrictedDataToken = true,
            RestrictedDataTokenRequest = new CreateRestrictedDataTokenRequest
            {
                restrictedResources = new List<RestrictedResource>
                {
                    new RestrictedResource
                    {
                        method = Method.GET.ToString(),
                        path = ApiUrls.OrdersApiUrls.Orders,
                        dataElements = new List<string> { "buyerInfo", "shippingAddress" }
                    }
                }
            }
        };

var orders = _amazonConnection.Orders.GetOrders(parameterOrderList);

```

### Order List data from Sandbox
```CSharp
AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
{
     ClientId = "amzn1.application-XXX-client.XXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     ClientSecret = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     RefreshToken= "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     Environment=Environments.Sandbox
});

var orders = amazonConnection.Orders.GetOrders
(
     new FikaAmazonAPI.Parameter.Order.ParameterOrderList
     {
         TestCase = Constants.TestCase200
     }
);
```

### Report List, For more report sample please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/OrdersSample.cs).
```CSharp
var parameters = new ParameterReportList();
parameters.pageSize = 100;
parameters.reportTypes = new List<ReportTypes>();
parameters.reportTypes.Add(ReportTypes.GET_AFN_INVENTORY_DATA);
parameters.marketplaceIds = new List<string>();
parameters.marketplaceIds.Add(MarketPlace.UnitedArabEmirates.ID);
var reports=amazonConnection.Reports.GetReports(parameters);
```

### Custom Report
```CSharp
var parameters = new ParameterCreateReportSpecification();
parameters.reportType = ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL;
parameters.dataStartTime = DateTime.UtcNow.AddDays(-30);
parameters.dataEndTime = DateTime.UtcNow.AddDays(-10);
parameters.marketplaceIds = new MarketplaceIds();
parameters.marketplaceIds.Add(MarketPlace.UnitedArabEmirates.ID);
parameters.reportOptions = new AmazonSpApiSDK.Models.Reports.ReportOptions();

var report= amazonConnection.Reports.CreateReport(parameters);
```

### Get Report with PII

```Csharp

//use this method automatically know if the report are RDT or not
var data2 = amazonConnection.Reports.CreateReportAndDownloadFile(ReportTypes.GET_EASYSHIP_DOCUMENTS, startDate, null, null);

// OR USE this method to get the document and pass parameter isRestrictedReport = true in case the report will return  PII data

var data = amazonConnection.Reports.GetReportDocument("50039018869997",true);
```


### Report Manager 🚀🧑‍🚀✨
Easy way to get the report you need and convert the file return from amazon to class or list, this feature only ready for some reports as its will take much times to finish for  [All report type](https://github.com/amzn/selling-partner-api-docs/blob/main/references/reports-api/reporttype-values.md)  .... 
```CSharp
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
var LedgerDetails = reportManager.GetLedgerDetailAsync(10); //GET_LEDGER_DETAIL_VIEW_DATA
var UnsuppressedInventory = reportManager.GetUnsuppressedInventoryDataAsync().ConfigureAwait(false).GetAwaiter().GetResult(); //GET_FBA_MYI_UNSUPPRESSED_INVENTORY_DATA
```


### Report GET_MERCHANT_LISTINGS_ALL_DATA sample
```CSharp
var parameters = new ParameterCreateReportSpecification();
parameters.reportType = ReportTypes.GET_MERCHANT_LISTINGS_ALL_DATA;

parameters.marketplaceIds = new MarketplaceIds();
parameters.marketplaceIds.Add(MarketPlace.UnitedArabEmirates.ID);

parameters.reportOptions = new FikaAmazonAPI.AmazonSpApiSDK.Models.Reports.ReportOptions();

var reportId = amazonConnection.Reports.CreateReport(parameters);
var filePath = string.Empty;
string ReportDocumentId = string.Empty;

while (string.IsNullOrEmpty(ReportDocumentId))
{
    Thread.Sleep(1000 * 60);
    var reportData = amazonConnection.Reports.GetReport(reportId);
    if (!string.IsNullOrEmpty(reportData.ReportDocumentId))
    {
        filePath = amazonConnection.Reports.GetReportFile(reportData.ReportDocumentId);
        break;
    }
}

//filePath for report
```

### Product GetCatalogItem Version 2022-04-01
```CSharp
var data = await amazonConnection.CatalogItem.GetCatalogItem202204Async(
    new Parameter.CatalogItems.ParameterGetCatalogItem
            {
                ASIN = "B00JK2YANC",
                includedData = new[] { IncludedData.attributes, 
                                       IncludedData.salesRanks,
                                       IncludedData.summaries, 
                                       IncludedData.productTypes, 
                                       IncludedData.relationships, 
                                       IncludedData.dimensions, 
                                       IncludedData.identifiers, 
                                       IncludedData.images }
            });
```

### Product SearchCatalogItems Version 2022-04-01
```CSharp
var data = await amazonConnection.CatalogItem.SearchCatalogItems202204Async(
    new Parameter.CatalogItems.ParameterSearchCatalogItems202204
            {
                keywords = new[] { "vitamin c" },
                includedData = new[] { IncludedData.attributes, 
                                       IncludedData.salesRanks,
                                       IncludedData.summaries, 
                                       IncludedData.productTypes, 
                                       IncludedData.relationships, 
                                       IncludedData.dimensions, 
                                       IncludedData.identifiers, 
                                       IncludedData.images }
            });
```



### Product Pricing, For more Pricing sample please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/ProductPricingSample.cs).
```CSharp

var data = amazonConnection.ProductPricing.GetPricing(
    new Parameter.ProductPricing.ParameterGetPricing()
    {
        MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
        Asins = new string[] { "B00CZC5F0G" }
    });

```

### Product Competitive Price
```CSharp

var data = amazonConnection.ProductPricing.GetCompetitivePricing(
    new Parameter.ProductPricing.ParameterGetCompetitivePricing()
    {
        MarketplaceId = MarketPlace.UnitedArabEmirates.ID,
        Asins = new string[] { "B00CZC5F0G" },
    });
```

### GetFeaturedOfferExpectedPriceBatch
```CSharp

 var priceDemo = new ProductPricingSample(amazonConnection);
 await priceDemo.GetFeaturedOfferExpectedPriceBatch();
```


### Notifications Create Destination, For more Notifications sample please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/NotificationsSample.cs).
```CSharp

//EventBridge
var data = amazonConnection.Notification.CreateDestination(
    new Notifications.CreateDestinationRequest()
    {
        Name = "CompanyName",
        ResourceSpecification = new Notifications.DestinationResourceSpecification()
        {
            EventBridge = new Notifications.EventBridgeResourceSpecification("us-east-2", "999999999")
        }
    });

//SQS
var dataSqs = amazonConnection.Notification.CreateDestination(
    new Notifications.CreateDestinationRequest()
    {
        Name = "CompanyName_AE",
        ResourceSpecification = new Notifications.DestinationResourceSpecification
        {
            Sqs = new Notifications.SqsResource("arn:aws:sqs:us-east-2:9999999999999:NAME")
        }
    });
```

### Notifications Create Subscription, For more Notifications sample please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/NotificationsSample.cs).
```CSharp

//SQS
var result = amazonConnection.Notification.CreateSubscription(
    new ParameterCreateSubscription()
    {
        destinationId = "xxxxxxxxxxxxxxx", // take this from CreateDestination or GetDestinations response 
        notificationType = NotificationType.ANY_OFFER_CHANGED, // or B2B_ANY_OFFER_CHANGED for B2B prices
        payloadVersion = "1.0"
    });
```

### Notifications read messages
```CSharp

var SQS_URL = "https://sqs.us-east-2.amazonaws.com/9999999999999/IUSER_SQS";
ParameterMessageReceiver param = new ParameterMessageReceiver(
                    Environment.GetEnvironmentVariable("AccessKey"), 
                    Environment.GetEnvironmentVariable("SecretKey"), 
                    SQS_URL, Amazon.RegionEndpoint.USEast2);

CustomMessageReceiver messageReceiver = new CustomMessageReceiver();


amazonConnection.Notification.StartReceivingNotificationMessages(param, messageReceiver);
public class CustomMessageReceiver : IMessageReceiver
{
     public void ErrorCatch(Exception ex)
     {
         //Your code here
     }

     public void NewMessageRevicedTriger(NotificationMessageResponce message)
     {
         //Your Code here
     }
}

```

### Feed Submit
Here full sample for submit feed to change price and generate XML and get final report for result same as in [doc](https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/use-case-guides/feeds-api-use-case-guide/feeds-api-use-case-guide_2021-06-30.md).
Notes: not all [feed type](https://github.com/amzn/selling-partner-api-docs/blob/main/references/feeds-api/feedtype-values.md) finished as it's big work and effort but all classes are partial for easy change and you can generate XML outside and use our library to get data, now we support only submit existing product, change quantity and change price , I list most of XSD here Source\FikaAmazonAPI\ConstructFeed\xsd its will help you easy generate class and add it in your app to generate final feed xml.

#### Feed Submit for change price , For more Feed sample please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/FeedsSample.cs).
```CSharp
ConstructFeedService createDocument = new ConstructFeedService("{SellerID}", "1.02");

var list = new List<PriceMessage>();
list.Add(new PriceMessage()
{
    SKU = "8201031206122...",
    StandardPrice = new StandardPrice()
    {
        currency = amazonConnection.GetCurrentMarketplace.CurrencyCode.ToString(),
        Value = (201.0522M).ToString("0.00")
    }
});
createDocument.AddPriceMessage(list);

var xml = createDocument.GetXML();

var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_PRODUCT_PRICING_DATA);

Thread.Sleep(1000*30);

var feedOutput=amazonConnection.Feed.GetFeed(feedID);

var outPut=amazonConnection.Feed.GetFeedDocument(feedOutput.ResultFeedDocumentId);

var reportOutpit = outPut.Url;

var processingReport = amazonConnection.Feed.GetFeedDocumentProcessingReport(outPut.Url);

```


#### Feed Submit for change Quantity
```CSharp
ConstructFeedService createDocument = new ConstructFeedService("{SellerID}", "1.02");

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

Thread.Sleep(1000*30);

var feedOutput=amazonConnection.Feed.GetFeed(feedID);

var outPut=amazonConnection.Feed.GetFeedDocument(feedOutput.ResultFeedDocumentId);

var reportOutpit = outPut.Url;

var processingReport = amazonConnection.Feed.GetFeedDocumentProcessingReport(outPut.Url);

```

#### Feed Submit for change ProdcutImage
```CSharp
public void SubmitFeedProductImage()
{
    ConstructFeedService createDocument = new ConstructFeedService("A3J37AJU4O9RHK", "1.02");
    var list = new List<ProductImageMessage>();
    list.Add(new ProductImageMessage()
    {
	SKU = "8201031206122...",
	ImageLocation = "http://xxxx.com/1.jpeg",
	ImageType = ImageType.Main
    }) ;
    createDocument.AddProductImageMessage(list);
    var xml = createDocument.GetXML();

    var feedID = amazonConnection.Feed.SubmitFeed(xml, FeedType.POST_PRODUCT_IMAGE_DATA);

}
```

#### Feed Submit for change FULFILLMENT DATA (add tracking number for shipment)
```CSharp

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

```


#### Feed Submit for change Order Adjustments
```CSharp
public void SubmitFeedOrderAdjustment()
{
            ConstructFeedService createDocument = new ConstructFeedService("A3J37AJU4O9RHK", "1.02");
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
}
```
 
---
## Usage Plans and Rate Limits in the Selling Partner API

Please read this doc to get all information about this limitation
https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/usage-plans-rate-limits/Usage-Plans-and-Rate-Limits.md

we calc waiting time by read x-amzn-RateLimit-Limit header 

`int sleepTime = (int)((1 / header["x-amzn-RateLimit-Limit"] ) * 1000);`

You can also disable libary from handelling limitaion by set IsActiveLimitRate=false in AmazonCredential
```CSharp
var amazonConnection = new AmazonConnection(new AmazonCredential()
{
      .
      .
      IsActiveLimitRate=false
});
```

---

## Enable debug mode
You can also enable log for all http request and response you can set IsDebugMode=true in AmazonCredential
```CSharp
var amazonConnection = new AmazonConnection(new AmazonCredential()
{
      .
      .
      IsDebugMode = true
});
```

---

## Get restrictions before try to add new lists

```CSharp
var result = amazonConnection.Restrictions.GetListingsRestrictions(
    new Parameter.Restrictions.ParameterGetListingsRestrictions
            {
                asin = "AAAAAAAAAA",
                sellerId = "AXXXXXXXXXXXX"
            });
```
---
## Create shipment operation from MerchantFulfillment

```CSharp
ShipmentRequestDetails shipmentRequestDetails = new ShipmentRequestDetails()
{
    AmazonOrderId = "999-9999-999999",
    ItemList = new ItemList()
    {
        new FikaAmazonAPI.AmazonSpApiSDK.Models.MerchantFulfillment.Item()
        {
		OrderItemId = "52986411826454",
            Quantity = 1
        }

    },
    ShipFromAddress = new Address()
    {
        AddressLine1 = "300 St",
        City = "City",
        PostalCode = "48123",
        Email = "[mail@yahoo.com](mailto:mail@yahoo.com)",
        Phone = "999999999",
        StateOrProvinceCode = "MI",
        CountryCode = "US",
        Name = "FirstName LastName"
    },
    PackageDimensions = new PackageDimensions()
    {
        Height = 10,
        Width = 10,
        Length = 10,
        Unit = UnitOfLength.Inches
    },
    Weight = new Weight()
    {
        Value = 10,
        Unit = UnitOfWeight.Oz
    },
    ShippingServiceOptions = new ShippingServiceOptions()
    {
        DeliveryExperience = DeliveryExperienceType.NoTracking,
        CarrierWillPickUp = false,
        CarrierWillPickUpOption = CarrierWillPickUpOption.ShipperWillDropOff
    }
};

var shipmentRequest = new CreateShipmentRequest(
			shipmentRequestDetails, 
			shippingServiceId: "UPS_PTP_2ND_DAY_AIR", 
			shippingServiceOfferId: "WHgxtyn6qjGGaC");

 var shipmentResponse = amazonConnection.MerchantFulfillment.CreateShipment(shipmentRequest);
```

## ProductTypes SearchDefinitions

```CSharp
var list = amazonConnection.ProductType.SearchDefinitionsProductTypes(
  new Parameter.ProductTypes.SearchDefinitionsProductTypesParameter()
   {
    keywords = new List<string> { String.Empty },
   });
```

## ProductTypes GetDefinitions

```CSharp
var def = amazonConnection.ProductType.GetDefinitionsProductType(
   new Parameter.ProductTypes.GetDefinitionsProductTypeParameter()
    {
     productType = "PRODUCT",
     requirements = RequirementsEnum.LISTING,
     locale = AmazonSpApiSDK.Models.ProductTypes.LocaleEnum.en_US
     });
```

---
## Sales Performance Sample

```CSharp
     DateTime queryStart = DateTime.UtcNow.AddDays(-11).Date;
     DateTime queryEnd = DateTime.UtcNow;
     var parameters = new ParameterGetOrderMetrics();
     parameters.marketplaceIds = new MarketplaceIds();
     parameters.marketplaceIds.Add(MarketPlace.UnitedArabEmirates.ID);
     parameters.interval = queryStart.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture) + "Z--" + queryEnd.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture) + "Z";
     parameters.granularity = Constants.GranularityEnum.Day;
     parameters.firstDayOfWeek = Constants.FirstDayOfWeek.monday;

     var sales = amazonConnection.Sales.GetOrderMetrics(parameters);
```
---
## Q & A

If you have questions, please ask in GitHub discussions 

[![discussions](https://img.shields.io/badge/github-discussions-brightgreen?style=for-the-badge&logo=github)](https://github.com/abuzuhri/Amazon-SP-API-CSharp/discussions)

---
## ToDo

- Improve documentation

---
### Useful links
##### [Selling Partner API](https://developer-docs.amazon.com/sp-api)
##### [Amazon MWS to SP-API Migration Guide](https://developer-docs.amazon.com/sp-api/docs/amazon-mws-to-sp-api-migration-guide#mapping-apis-from-amazon-mws-to-the-selling-partner-api)
##### [SP-API models](https://developer-docs.amazon.com/sp-api/page/sp-api-models)
##### [Using Postman for Selling Partner API models](https://developer-docs.amazon.com/sp-api/page/sp-api-models)
##### [Test Project with pure C# code](https://github.com/abuzuhri/Amazon-SP-API-CSharp/tree/main/Others/PureCodeSampleForTest)
##### [Sample Code](https://github.com/abuzuhri/Amazon-SP-API-CSharp/tree/main/Source/FikaAmazonAPI.SampleCode)
##### [Creating And Configuring AWS](https://developer-docs.amazon.com/sp-api/docs/creating-and-configuring-iam-policies-and-entities)

---
## Contributing

1. Fork it (https://github.com/abuzuhri/Amazon-SP-API-CSharp/fork)
2. Clone it (`git clone https://github.com/{YOUR_USERNAME}/Amazon-SP-API-CSharp`)
3. Create your feature branch (`git checkout -b your_branch_name`)
4. Commit your changes (`git commit -m 'Description of a commit'`)
5. Push to the branch (`git push origin your_branch_name`)
6. Create a new Pull Request

---
## Notes

If you are looking for a complete Feedback solution, you might want to consider giving [Soon.se](https://www.soon.se) a shot.

---
## Support & Consultation

We offer consultation on everything SP-API related. Book your meeting here:

[![Book Meeting](https://img.shields.io/badge/meeting-book%20now-blue?style=for-the-badge)](https://calendly.com/tareq-abuzuhri/)

---
## Thanks

Thanks go out to everybody who worked on this package.

