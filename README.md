# Amazon Selling Partner API C#  [![Build status](https://dev.azure.com/FikaAmazonSpAPI/Amazon-SP-API-CSharp/_apis/build/status/Amazon-SP-API-CSharp)](https://dev.azure.com/FikaAmazonSpAPI/Amazon-SP-API-CSharp/_build/latest?definitionId=4) [![NuGet](https://img.shields.io/nuget/v/CSharpAmazonSpAPI.svg)](https://www.nuget.org/packages/CSharpAmazonSpAPI/)


This is an API Binding in .Net C# for the new Amazon Selling Partner API.

This library is based on the output of `swagger-codegen` with the [OpenAPI files provided by Amazon](https://github.com/amzn/selling-partner-api-models/tree/main/models) and has been modified by the contributors.

The purpose of this package is to have an easy way of getting started with the Amazon Selling Partner API.

---
### Requirements
- Newtonsoft.Json
- RestSharp
- AWSSDK.SecurityToken


---
### Tasks
- [x] [OrdersV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/orders-api/ordersV0.md)
- [x] [Reports](https://github.com/amzn/selling-partner-api-docs/blob/main/references/reports-api/reports_2020-09-04.md)
- [x] [FinancesV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/finances-api/financesV0.md)
- [ ] [Feeds](https://github.com/amzn/selling-partner-api-docs/blob/main/references/feeds-api/feeds_2020-09-04.md)
- [ ] [Uploads](https://github.com/amzn/selling-partner-api-docs/blob/main/references/uploads-api/uploads_2020-11-01.md)
- [ ] [shipmentInvoicingV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/shipment-invoicing-api/shipmentInvoicingV0.md)
- [ ] [Shippings](https://github.com/amzn/selling-partner-api-docs/blob/main/references/shipping-api/shipping.md)
- [x] [CatalogItemsV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/catalog-items-api/catalogItemsV0.md)
- [ ] [FBAInboundEligibility](https://github.com/amzn/selling-partner-api-docs/blob/main/references/fba-inbound-eligibility-api/fbaInbound.md)
- [x] [FBAInventory](https://github.com/amzn/selling-partner-api-docs/tree/main/references/fba-inventory-api)
- [ ] [FBASmallAndLight](https://github.com/amzn/selling-partner-api-docs/blob/main/references/fba-small-and-light-api/fbaSmallandLight.md)
- [ ] [FulFillmentInbound](https://github.com/amzn/selling-partner-api-docs/blob/main/references/fulfillment-inbound-api/fulfillmentInboundV0.md)
- [ ] [FulFillmentOutbound](https://github.com/amzn/selling-partner-api-docs/tree/main/references/fulfillment-outbound-api)
- [ ] [MerchantFulFillment](https://github.com/amzn/selling-partner-api-docs/blob/main/references/merchant-fulfillment-api/merchantFulfillmentV0.md)
- [ ] [Messaging](https://github.com/amzn/selling-partner-api-docs/blob/main/references/messaging-api/messaging.md)
- [x] [Notifications](https://github.com/amzn/selling-partner-api-docs/blob/main/references/notifications-api/notifications.md)
- [ ] [ProductFeesV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/product-fees-api/productFeesV0.md)
- [x] [ProductPricingV0](https://github.com/amzn/selling-partner-api-docs/blob/main/references/product-pricing-api/productPricingV0.md)
- [x] [Sales](https://github.com/amzn/selling-partner-api-docs/blob/main/references/sales-api/sales.md)
- [ ] [Sellers](https://github.com/amzn/selling-partner-api-docs/blob/main/references/sellers-api/sellers.md)
- [ ] [Services](https://github.com/amzn/selling-partner-api-docs/blob/main/references/services-api/services.md)
- [x] [Solicitations](https://github.com/amzn/selling-partner-api-docs/blob/main/references/solicitations-api/solicitations.md)
- [ ] [Token](https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/use-case-guides/tokens-api-use-case-guide/tokens-API-use-case-guide-2021-03-01.md)


---
### Installation

```powershell
Install-Package CSharpAmazonSpAPI -Version 1.0.0
```

---
### Keys
| Name | Description |
| --- | --- |
| AccessKey | AWS USER ACCESS KEY |
| SecretKey | AWS USER SECRET KEY |
| RoleArn | AWS IAM Role ARN (needs permission to “Assume Role” STS) |
| Region | Marketplace region |
| ClientId | Your amazon app id |
| ClientSecret | Your amazon app secret |

For more information about keys please check [Amazon Selling Partner Api developer guide](https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/developer-guide/SellingPartnerApiDeveloperGuide.md). 

---
### Usage
```CSharp
    AmazonConnection amazonConnection = new AmazonConnection(new AmazonCredential()
    {
         AccessKey = "AKIAXXXXXXXXXXXXXXX",
         SecretKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
         RoleArn = "arn:aws:iam::XXXXXXXXXXXXX:role/XXXXXXXXXXXX",
         ClientId = "amzn1.application-XXX-client.XXXXXXXXXXXXXXXXXXXXXXXXXXXX",
         ClientSecret = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
          RefreshToken= "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
     });

     amazonConnection.Orders.ListOrders();
            
```

---
### Q & A

If you have questions, please ask in GitHub discussions 

[![discussions](https://img.shields.io/badge/github-discussions-brightgreen?style=for-the-badge&logo=github)](https://github.com/abuzuhri/Amazon-SP-API-CSharp/discussions)

---
### ToDo

- Improve documentation

---
### Notes

If you are looking for a complete Feedback solution, you might want to consider giving [Soon.se](https://www.soon.se) a shot.

---
### Support & Consultation

We offer consultation on everything SP-API related. Book your meeting here:

[![Book Meeting](https://img.shields.io/badge/meeting-book%20now-blue?style=for-the-badge)](https://calendly.com/tareq-abuzuhri/)

---
### Thanks

Thanks go out to everybody who worked on this package.

