# Amazon Selling Partner API C# 🚀  [![Build status](https://dev.azure.com/FikaAmazonSpAPI/Amazon-SP-API-CSharp/_apis/build/status/Amazon-SP-API-CSharp)](https://dev.azure.com/FikaAmazonSpAPI/Amazon-SP-API-CSharp/_build/latest?definitionId=4) [![NuGet](https://img.shields.io/nuget/v/CSharpAmazonSpAPI.svg)](https://www.nuget.org/packages/CSharpAmazonSpAPI/) [![Gitter Chat](https://badges.gitter.im/bitwarden/Lobby.svg)](https://gitter.im/Amazon-SP-API-CSharp/community)


This is an API Binding in .Net C# for the new Amazon Selling Partner API.

This library is based on the output of [swagger-codegen](https://app.swaggerhub.com/home) with the [OpenAPI files provided by Amazon](https://github.com/amzn/selling-partner-api-models/tree/main/models) and has been modified by the contributors.

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
### Useful links
##### [Selling Partner API](https://developer-docs.amazon.com/sp-api)
##### [Amazon MWS to SP-API Migration Guide](https://developer-docs.amazon.com/sp-api/docs/amazon-mws-to-sp-api-migration-guide#mapping-apis-from-amazon-mws-to-the-selling-partner-api)
##### [SP-API models](https://developer-docs.amazon.com/sp-api/page/sp-api-models)


---
### Tasks
#### Seller

- [x] [OrdersV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/orders-api/ordersV0.md)
- [x] [Reports](https://github.com/amzn/selling-partner-api-docs/blob/main/references/reports-api/reports_2020-09-04.md)
- [x] [FinancesV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/finances-api/financesV0.md)
- [x] [Feeds](https://github.com/amzn/selling-partner-api-docs/blob/main/references/feeds-api/feeds_2021-06-30.md) for [feedType](https://github.com/amzn/selling-partner-api-docs/blob/main/references/feeds-api/feedtype-values.md) for step to call feed read [doc](https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/use-case-guides/feeds-api-use-case-guide/feeds-api-use-case-guide_2021-06-30.md)
- [ ] [ListingsItems](https://github.com/amzn/selling-partner-api-docs/blob/main/references/listings-items-api/listingsItems_2021-08-01.md)
- [x] [Uploads](https://github.com/amzn/selling-partner-api-docs/blob/main/references/uploads-api/uploads_2020-11-01.md)
- [x] [shipmentInvoicingV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/shipment-invoicing-api/shipmentInvoicingV0.md)
- [x] [Shippings](https://github.com/amzn/selling-partner-api-docs/blob/main/references/shipping-api/shipping.md)
- [x] [CatalogItemsV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/catalog-items-api/catalogItemsV0.md)
- [x] [FBAInventory](https://github.com/amzn/selling-partner-api-docs/tree/main/references/fba-inventory-api)
- [x] [FBASmallAndLight](https://github.com/amzn/selling-partner-api-docs/blob/main/references/fba-small-and-light-api/fbaSmallandLight.md)
- [x] [FBAInboundEligibility](https://github.com/amzn/selling-partner-api-docs/blob/main/references/fba-inbound-eligibility-api/fbaInbound.md)
- [x] [FulFillmentInbound](https://github.com/amzn/selling-partner-api-docs/blob/main/references/fulfillment-inbound-api/fulfillmentInboundV0.md)
- [x] [FulFillmentOutbound](https://github.com/amzn/selling-partner-api-docs/tree/main/references/fulfillment-outbound-api)
- [x] [MerchantFulFillment](https://github.com/amzn/selling-partner-api-docs/blob/main/references/merchant-fulfillment-api/merchantFulfillmentV0.md)
- [x] [Messaging](https://github.com/amzn/selling-partner-api-docs/blob/main/references/messaging-api/messaging.md)
- [x] [Notifications](https://github.com/amzn/selling-partner-api-docs/blob/main/references/notifications-api/notifications.md) for configuration read [doc](https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/use-case-guides/notifications-api-use-case-guide/notifications-use-case-guide-v1.md)
- [x] [ProductFeesV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/product-fees-api/productFeesV0.md)
- [x] [ProductPricingV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/product-pricing-api/productPricingV0.md)
- [x] [Sales](https://github.com/amzn/selling-partner-api-docs/blob/main/references/sales-api/sales.md)
- [x] [Sellers](https://github.com/amzn/selling-partner-api-docs/blob/main/references/sellers-api/sellers.md)
- [ ] [Services](https://github.com/amzn/selling-partner-api-docs/blob/main/references/services-api/services.md)
- [x] [Solicitations](https://github.com/amzn/selling-partner-api-docs/blob/main/references/solicitations-api/solicitations.md)
- [x] [Token](https://github.com/amzn/selling-partner-api-docs/blob/main/references/tokens-api/tokens_2021-03-01.md) for [doc PII](https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/use-case-guides/tokens-api-use-case-guide/tokens-API-use-case-guide-2021-03-01.md)

#### Vendor 
- [ ] [VendorOrders](https://github.com/amzn/selling-partner-api-docs/blob/main/references/vendor-orders-api/vendorOrders.md)
- [ ] [VendorDirectFulfillmentInventoryV1](https://github.com/amzn/selling-partner-api-docs/blob/main/references/vendor-direct-fulfillment-inventory-api/vendorDirectFulfillmentInventoryV1.md)
- [x] [VendorDirectFulfillmentOrdersV1](https://github.com/amzn/selling-partner-api-docs/blob/main/references/vendor-direct-fulfillment-orders-api/vendorDirectFulfillmentOrdersV1.md)
- [ ] [VendorDirectFulfillmentPaymentsV1](https://github.com/amzn/selling-partner-api-docs/blob/main/references/vendor-direct-fulfillment-payments-api/vendorDirectFulfillmentPaymentsV1.md)
- [ ] [VendorDirectFulfillmentShippingV1](https://github.com/amzn/selling-partner-api-docs/blob/main/references/vendor-direct-fulfillment-shipping-api/vendorDirectFulfillmentShippingV1.md)
- [ ] [VendorDirectFulfillmentTransactionsV1](https://github.com/amzn/selling-partner-api-docs/tree/main/references/vendor-direct-fulfillment-transactions-api)
- [ ] [vendorInvoices](https://github.com/amzn/selling-partner-api-docs/blob/main/references/vendor-invoices-api/vendorInvoices.md)
- [ ] [VendorShipments](https://github.com/amzn/selling-partner-api-docs/tree/main/references/vendor-shipments-api)
- [ ] [VendorTransactionStatus](https://github.com/amzn/selling-partner-api-docs/tree/main/references/vendor-transaction-status-api)



---
## Installation [![NuGet](https://img.shields.io/nuget/v/CSharpAmazonSpAPI.svg)](https://www.nuget.org/packages/CSharpAmazonSpAPI/)

```powershell
Install-Package CSharpAmazonSpAPI
```

---
## Keys
| Name | Description |
| --- | --- |
| AccessKey | AWS USER ACCESS KEY |
| SecretKey | AWS USER SECRET KEY |
| RoleArn | AWS IAM Role ARN (needs permission to “Assume Role” STS) |
| Region | Marketplace region |
| ClientId | Your amazon app id |
| ClientSecret | Your amazon app secret |
| RefreshToken | Check how to get [RefreshToken](https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/developer-guide/SellingPartnerApiDeveloperGuide.md#Self-authorization) |


For more information about keys please check [Amazon Selling Partner API developer guide](https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/developer-guide/SellingPartnerApiDeveloperGuide.md) , If you are not registered as developer please [Register](https://developer.amazonservices.com/) to be able to create application. 

---
## Usage

### Configuration
```CSharp
AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
{
     AccessKey = "AKIAXXXXXXXXXXXXXXX",
     SecretKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     RoleArn = "arn:aws:iam::XXXXXXXXXXXXX:role/XXXXXXXXXXXX",
     ClientId = "amzn1.application-XXX-client.XXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     ClientSecret = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     RefreshToken= "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     MarketPlace = MarketPlace.UnitedArabEmirates, //MarketPlace.GetMarketPlaceByID("A2VIGQ35RCS4UG")
});

```

### Order List, For more orders sample please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.Test/Reports.cs).
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

### Order List data from Sandbox
```CSharp
AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
{
     AccessKey = "AKIAXXXXXXXXXXXXXXX",
     SecretKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     RoleArn = "arn:aws:iam::XXXXXXXXXXXXX:role/XXXXXXXXXXXX",
     ClientId = "amzn1.application-XXX-client.XXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     ClientSecret = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     RefreshToken= "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
     Environment=Environments.Sandbox
});

var orders = amazonConnection.Orders.GetOrders
        (
         new FikaAmazonAPI.Parameter.Order.ParameterOrderList()
             {
              TestCase = Constants.TestCase200
             }
        );
```

### Report List, For more report sample please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.Test/Orders.cs).
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

### Report Manager 🚀🧑‍🚀✨
Easy way to get the report you need and convert the file return from amazon to class or list, this feature only ready for some reports as its will take much times to finish for all reports ....
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

### Product Pricing, For more Pricing sample please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.Test/ProductPricing.cs).
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


### Notifications Create Destination, For more Notifications sample please check [Here](https://github.com/abuzuhri/Amazon-SP-API-CSharp/blob/main/Source/FikaAmazonAPI.Test/Notifications.cs).
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

#### Feed Submit for change price
```CSharp
ConstructFeedService createDocument = new ConstructFeedService("{SellerID}", "1.02");

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
## Q & A

If you have questions, please ask in GitHub discussions 

[![discussions](https://img.shields.io/badge/github-discussions-brightgreen?style=for-the-badge&logo=github)](https://github.com/abuzuhri/Amazon-SP-API-CSharp/discussions)

---
## ToDo

- Improve documentation

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

