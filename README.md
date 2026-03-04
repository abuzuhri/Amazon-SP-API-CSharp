# ☕Amazon Selling Partner API C# 🚀 [![.NET](https://github.com/abuzuhri/Amazon-SP-API-CSharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/abuzuhri/Amazon-SP-API-CSharp/actions/workflows/dotnet.yml) [![NuGet](https://img.shields.io/nuget/v/CSharpAmazonSpAPI.svg)](https://www.nuget.org/packages/CSharpAmazonSpAPI/) [![Gitter Chat](https://badges.gitter.im/bitwarden/Lobby.svg)](https://gitter.im/Amazon-SP-API-CSharp/community)


This is an API Binding in .Net C# for the new Amazon Selling Partner API.

This library is based on the output of [swagger-codegen](https://app.swaggerhub.com/home) with the [OpenAPI files provided by Amazon (Models)](https://github.com/amzn/selling-partner-api-models/tree/main/models) and has been modified by the contributors.

The purpose of this package is to have an easy way of getting started with the Amazon Selling Partner API using C#. You can watch this 📷 [YouTube](https://www.youtube.com/watch?v=1gZJBCoMr70) 📣 video to get started quickly.

---
### Requirements
- [AWSSDK.SecurityToken](https://www.nuget.org/packages/AWSSDK.SecurityToken/)
- [AWSSDK.SQS](https://www.nuget.org/packages/AWSSDK.SQS/)
- [Microsoft.CSharp](https://www.nuget.org/packages/Microsoft.CSharp/)
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

- [x] [OrdersV2026-01-01](https://developer-docs.amazon.com/sp-api/reference/orders-v2026-01-01)
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
To get all the keys you need, follow these steps:
1. [Create and configure IAM policies and entities](https://developer-docs.amazon.com/sp-api/docs/creating-and-configuring-iam-policies-and-entities)
2. [Register your Application](https://developer-docs.amazon.com/sp-api/docs/registering-your-application)
3. [Authorize Selling Partner API applications](https://developer-docs.amazon.com/sp-api/docs/authorizing-selling-partner-api-applications#step-1-request-a-login-with-amazon-access-token)


| Name | Description |
| --- | --- |
| Marketplace | Marketplace region [List of Marketplaces](https://developer-docs.amazon.com/sp-api/docs/marketplace-ids)|
| ClientId | Your amazon app id |
| ClientSecret | Your amazon app secret |
| RefreshToken | Check how to get [RefreshToken](https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/developer-guide/SellingPartnerApiDeveloperGuide.md#Self-authorization) |


For more information about keys, check the [Amazon developer documentation](https://developer-docs.amazon.com/sp-api/docs/creating-and-configuring-iam-policies-and-entities). If you are not registered as a developer, please [Register](https://developer.amazonservices.com/) to be able to create an application.

---
## Usage

> ### Please be aware there has been a change to the _Orders.GetOrderAddress()_ method please reference the new sample code for more details.

### Configuration
You can configure a connection as shown below. See [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/Program.cs) for the relevant code file.
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

### Order List
For more order samples, please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/OrdersSample.cs).
```CSharp
    ParameterSearchOrders searchOrderList = new ParameterSearchOrders{
        CreatedAfter = DateTime.UtcNow.AddMinutes(-600000),
        MaxNumberOfPages = 1
    };
    var orders = amazonConnection.Orders.SearchOrders(searchOrderList);
```


### Order List with parameter
```CSharp

ParameterSearchOrders searchOrderList = new ParameterSearchOrders{
        CreatedAfter = DateTime.UtcNow.AddHours(-24),
        MaxNumberOfPages = 1,
        FulfillmentStatuses = new List<FulfillmentStatus20260101>
        {
            FulfillmentStatus20260101.UNSHIPPED
        }
        MarketplaceIds = new List<string>
        {
            MarketPlace.Germany.ID,
            MarketPlace.Australia.ID,
            MarketPlace.France.ID
        }
    };
var orders = amazonConnection.Orders.SearchOrders(searchOrderList);

```

#### ParameterSearchOrders (v2026-01-01) Class

```CSharp
ParameterSearchOrders searchOrderList = new ParameterSearchOrders{
    public ICollection<string> MarketplaceIds { get; set; }
    public DateTime? LastUpdatedAfter { get; set; }
    public DateTime? LastUpdatedBefore { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? CreatedBefore { get; set; }
    public int? MaxResultsPerPage { get; set; } = 100;
    public string PaginationToken { get; set; }
    public ICollection<FulfillmentStatus20260101> FulfillmentStatuses { get; set; }
    public ICollection<FulfilledBy20260101> FulfilledBy { get; set; }
    public ICollection<string> AmazonOrderIds { get; set; }
    public ICollection<IncludedData20260101> IncludedData { get; set; }

    // ClientSide
    public int? MaxNumberOfPages { get; set; }
};
```


#### ParameterGetOrder20260101 Class

```CSharp
ParameterGetOrder20260101 GetOrderParam = new ParameterGetOrder20260101{
    public string OrderId { get; set; }
    public ICollection<IncludedData20260101> IncludedData { get; set; }
};
```



### Report List
For more report samples, please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/ReportsSample.cs).
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
An easy way to get the report you need and convert the file returned from Amazon to a class or list. This feature is only available for some reports, as it takes significant effort to cover all [report types](https://github.com/amzn/selling-partner-api-docs/blob/main/references/reports-api/reporttype-values.md).
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


### Notifications — Create Destination
For more notification samples, please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/NotificationsSample.cs).
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

### Notifications — Create Subscription
For more notification samples, please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/NotificationsSample.cs).
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

### Notifications — Read Messages
```CSharp

var SQS_URL = Environment.GetEnvironmentVariable("SQS_URL");
var param = new ParameterMessageReceiver(
    Environment.GetEnvironmentVariable("AccessKey"),
    Environment.GetEnvironmentVariable("SecretKey"),
    SQS_URL,
    Amazon.RegionEndpoint.USEast2,
    WaitTimeSeconds: 20); // Enable SQS long polling to reduce empty receives and cost

var messageReceiver = new CustomMessageReceiver();

// Use CancellationToken for graceful shutdown and wrap in a restart loop
// so the listener recovers from transient errors automatically.
var cts = new CancellationTokenSource();
while (!cts.Token.IsCancellationRequested)
{
    try
    {
        // Static method — no instance needed
        await NotificationService.StartReceivingNotificationMessagesAsync(
            param, messageReceiver, cancellationToken: cts.Token);
    }
    catch (OperationCanceledException) when (cts.Token.IsCancellationRequested)
    {
        break; // Graceful shutdown
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Notification listener crashed, restarting in 10s: {ex.Message}");
        await Task.Delay(TimeSpan.FromSeconds(10), cts.Token);
    }
}

public class CustomMessageReceiver : IMessageReceiver
{
    // Track processed notification IDs to handle SQS duplicate delivery
    private readonly ConcurrentDictionary<string, byte> _processedNotificationIds = new();
    private readonly ConcurrentQueue<string> _idQueue = new();
    private const int MaxTrackedIds = 10_000;

    public void ErrorCatch(Exception ex)
    {
        Console.WriteLine($"Notification error: {ex.Message}");
    }

    public void NewMessageRevicedTriger(NotificationMessageResponce message)
    {
        // Deduplicate: SQS standard queues may deliver the same message more than once
        var notificationId = message?.NotificationMetadata?.NotificationId;
        if (notificationId != null && !_processedNotificationIds.TryAdd(notificationId, 0))
            return;

        // Cap the dedup cache so it doesn't grow forever
        if (notificationId != null)
        {
            _idQueue.Enqueue(notificationId);
            while (_idQueue.Count > MaxTrackedIds && _idQueue.TryDequeue(out var oldId))
                _processedNotificationIds.TryRemove(oldId, out _);
        }

        //Your Code here
    }
}

```

### Notifications — End-to-End SQS Setup
Complete workflow following the [Amazon SQS notification setup guide](https://developer-docs.amazon.com/sp-api/docs/set-up-notifications-with-amazon-sqs). Before running this code, grant SP-API permission to write to your SQS queue in the AWS Console.
```CSharp

// Step 3: Create a destination (grantless operation — no seller authorization needed)
var destination = amazonConnection.Notification.CreateDestination(
    new Notifications.CreateDestinationRequest()
    {
        Name = "CompanyName_SQS",
        ResourceSpecification = new Notifications.DestinationResourceSpecification
        {
            Sqs = new Notifications.SqsResource("arn:aws:sqs:us-east-2:9999999999999:NAME")
        }
    });

// Step 4: Create a subscription using the destinationId from Step 3
// processingDirective is optional — only supported for ANY_OFFER_CHANGED and ORDER_CHANGE
var subscription = amazonConnection.Notification.CreateSubscription(
    new ParameterCreateSubscription()
    {
        destinationId = destination.DestinationId,
        notificationType = NotificationType.ANY_OFFER_CHANGED,
        payloadVersion = "1.0",
        processingDirective = new Notifications.ProcessingDirective
        {
            EventFilter = new Notifications.EventFilter
            {
                EventFilterType = "ANY_OFFER_CHANGED",
                MarketplaceIds = new List<string> { "ATVPDKIKX0DER" },
                AggregationSettings = new Notifications.AggregationSettings
                {
                    AggregationTimePeriod = Notifications.AggregationTimePeriod.FiveMinutes
                }
            }
        }
    });

```

### Feed Submit
Here is a full sample for submitting a feed to change price, generate XML, and get the final processing report, same as in the [documentation](https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/use-case-guides/feeds-api-use-case-guide/feeds-api-use-case-guide_2021-06-30.md).

> **Note:** Not all [feed types](https://github.com/amzn/selling-partner-api-docs/blob/main/references/feeds-api/feedtype-values.md) are implemented yet. All classes are `partial` for easy extension — you can generate XML outside the library and use it to submit data. Currently supported: submit existing product, change quantity, and change price. Most XSD files are listed in `Source\FikaAmazonAPI\ConstructFeed\xsd` to help you generate classes for your app.

#### Feed Submit — Change Price
For more feed samples, please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.SampleCode/FeedsSample.cs).
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


#### JSON_LISTINGS_FEED Submit for change price
```CSharp
string sellerId = "SellerId";
string sku = "SKU";
decimal price = 19.99m;

string jsonString = $@"
{{
    ""header"": {{
    ""sellerId"": ""{sellerId}"",
    ""version"": ""2.0"",
    ""issueLocale"": ""en_US""
    }},
    ""messages"": [
    {{
        ""messageId"": 1,
        ""sku"": ""{sku}"",
        ""operationType"": ""PATCH"",
        ""productType"": ""PRODUCT"",
        ""patches"": [
        {{
            ""op"": ""replace"",
            ""path"": ""/attributes/purchasable_offer"",
            ""value"": [
            {{
                ""currency"": ""USD"",
                ""our_price"": [
                {{
                    ""schedule"": [
                    {{
                        ""value_with_tax"": {price}
                    }}
                    ]
                }}
                ]
            }}
            ]
        }}
        ]
    }}
    ]
}}";

string feedID = await amazonConnection.Feed.SubmitFeedAsync(jsonString, FeedType.JSON_LISTINGS_FEED, new List<string>() { MarketPlace.UnitedArabEmirates.ID }, null, ContentType.JSON);

Thread.Sleep(1000*60);

var feedOutput = amazonConnection.Feed.GetFeed(feedID);

var outPut = amazonConnection.Feed.GetFeedDocument(feedOutput.ResultFeedDocumentId);

var reportOutpit = outPut.Url;

var processingReport = await amazonConnection.Feed.GetJsonFeedDocumentProcessingReportAsync(output);

```

#### Website authorization workflow.
```CSharp
    [HttpGet("AuthorizeAmazon")]
    public async Task<IActionResult> AuthorizeAmazon()
    {
        // Step 2-5 of the website authorization workflow.

        // Step 2-3: Amazon calls our log-in URI with amazon_callback_uri.
        var amazonCallbackUri = Request.Query["amazon_callback_uri"].ToString();
        if (!string.IsNullOrEmpty(amazonCallbackUri))
        {
            var amazonState = Request.Query["amazon_state"].ToString();
            var version = configuration["FikaAmazonAPI:AuthorizeVersion"];
            var redirectUri = configuration["FikaAmazonAPI:AmazonCallbackUri"];

            var generatedState = Guid.NewGuid().ToString("N");
            Response.Cookies.Append("amazon_oauth_state", generatedState, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddMinutes(5)
            });

            var query = new Dictionary<string, string?>
            {
                ["redirect_uri"] = redirectUri,
                ["amazon_state"] = amazonState,
                ["state"] = generatedState
            };

            if (!string.IsNullOrEmpty(version))
            {
                query["version"] = version;
            }

            Response.Headers["Referrer-Policy"] = "no-referrer";
            var redirectUrl = QueryHelpers.AddQueryString(amazonCallbackUri, query!);
            return Redirect(redirectUrl);
        }

        // Step 4-5: Amazon redirects back to our redirect_uri with authorization code.
        var state = Request.Query["state"].ToString();
        var sellingPartnerId = Request.Query["selling_partner_id"].ToString();
        var mwsAuthToken = Request.Query["mws_auth_token"].ToString();
        var code = Request.Query["spapi_oauth_code"].ToString();

        var storedState = Request.Cookies["amazon_oauth_state"];
        if (string.IsNullOrEmpty(state) || storedState != state)
        {
            return BadRequest("Invalid state");
        }

        Response.Cookies.Delete("amazon_oauth_state");

        if (string.IsNullOrEmpty(code))
        {
            return BadRequest("Missing spapi_oauth_code");
        }

        var clientId = configuration["FikaAmazonAPI:ClientId"];
        var clientSecret = configuration["FikaAmazonAPI:ClientSecret"];
        var callbackUri = configuration["FikaAmazonAPI:AmazonCallbackUri"];

        using var httpClient = new HttpClient();
        var form = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["grant_type"] = "authorization_code",
            ["code"] = code,
            ["client_id"] = clientId ?? string.Empty,
            ["client_secret"] = clientSecret ?? string.Empty,
            ["redirect_uri"] = callbackUri ?? string.Empty
        });

        using var response = await httpClient.PostAsync("https://api.amazon.com/auth/o2/token", form);
        var responseBody = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            return BadRequest(responseBody);
        }

        using var document = JsonDocument.Parse(responseBody);
        var refreshToken = document.RootElement.GetProperty("refresh_token").GetString();
        var accessToken = document.RootElement.GetProperty("access_token").GetString();

        return Json(new
        {
            state,
            selling_partner_id = sellingPartnerId,
            mws_auth_token = mwsAuthToken,
            refresh_token = refreshToken,
            access_token = accessToken
        });
    }

```

 
#### Feed Submit — Change Quantity
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

#### Feed Submit — Change Product Image
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

#### Feed Submit — Fulfillment Data (add tracking number for shipment)
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


#### Feed Submit — Order Adjustments
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
https://developer-docs.amazon.com/sp-api/docs/usage-plans-and-rate-limits

We calculate the waiting time by reading the `x-amzn-RateLimit-Limit` header:

`int sleepTime = (int)((1 / header["x-amzn-RateLimit-Limit"] ) * 1000);`

You can also disable the library's rate limit handling by setting `IsActiveLimitRate = false` in `AmazonCredential`:
```CSharp
var amazonConnection = new AmazonConnection(new AmazonCredential()
{
      .
      .
      IsActiveLimitRate=false
});
```

---

## Enable Debug Mode
You can enable logging for all HTTP requests and responses by setting `IsDebugMode = true` in `AmazonCredential`:
```CSharp
var amazonConnection = new AmazonConnection(new AmazonCredential()
{
      .
      .
      IsDebugMode = true
});
```

---

## Get Restrictions Before Adding New Listings

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
     requirements = Requirements.LISTING,
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

