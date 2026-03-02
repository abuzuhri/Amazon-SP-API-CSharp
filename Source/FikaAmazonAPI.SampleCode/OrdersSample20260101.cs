using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101;
using FikaAmazonAPI.Parameter.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FikaAmazonAPI.SampleCode
{
    public class OrdersSample20260101
    {
        AmazonConnection amazonConnection;

        // Example Data - replace with actual values when testing
        private string exampleOrderId = "403-1710607-6240347";
        private string[] exampleOrderIds = new string[]
        {
            "403-1710607-6240347",
            "403-5583945-7236361",
            "403-3320829-4528316",
            "406-2574982-2047546"
        };

        public OrdersSample20260101(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        // ──────────────────────────────────────────────────────────────────
        // SearchOrders
        // ──────────────────────────────────────────────────────────────────

        /// <summary>
        /// Simple Example: Retrieve all shipped orders from the last 7 days.
        /// Library automatically paginates through all pages.
        /// 
        /// v0-version of: GetOrders mit OrderStatuses = Shipped
        /// </summary>
        public void SearchOrders()
        {
            var parameter = new ParameterSearchOrders20260101
            {
                CreatedAfter = DateTime.UtcNow.AddDays(-7),
                FulfillmentStatuses = new List<FulfillmentStatus20260101>
                {
                    FulfillmentStatus20260101.SHIPPED
                }
            };

            var orders = amazonConnection.Orders20260101.SearchOrders(parameter);

            foreach (var order in orders)
            {
                Console.WriteLine($"Order: {order.OrderId}, Status: {order.Fulfillment?.FulfillmentStatus}");
            }
        }

        /// <summary>
        /// Lookup of Orders by their AmazonOrderIds
        /// v0-version of: GetOrders mit AmazonOrderIds
        /// </summary>
        public void SearchOrdersByIds()
        {
            
            var parameter = new ParameterSearchOrders20260101
            {
                CreatedAfter = DateTime.UtcNow.AddDays(-30),
                AmazonOrderIds = new List<string>(this.exampleOrderIds)
            };

            var orders = amazonConnection.Orders20260101.SearchOrders(parameter);

        }

        /// <summary>
        /// Only retrieve one page of results and manually paginate with PaginationToken.
        /// PaginationToken replaces NextToken from v0, but note that it expires after 24 hours.
        /// 
        /// v0-Version of: GetOrders with MaxNumberOfPages=1, then GetGetOrdersByNextToken
        /// </summary>
        public void SearchOrdersOnePageWithPaginationToken()
        {
            var parameter = new ParameterSearchOrders20260101
            {
                CreatedAfter = DateTime.UtcNow.AddDays(-7),
                MaxNumberOfPages = 1,
                FulfillmentStatuses = new List<FulfillmentStatus20260101>
                {
                    FulfillmentStatus20260101.SHIPPED
                }
            };

            // Get First Page
            var firstPage = amazonConnection.Orders20260101.SearchOrdersPage(parameter);

            Console.WriteLine($"First Page: {firstPage.Orders?.Count} Orders");

            // manuel pagination threw Pages
            var paginationToken = firstPage.PaginationToken;
            while (!string.IsNullOrEmpty(paginationToken))
            {
                parameter.PaginationToken = paginationToken;
                var nextPage = amazonConnection.Orders20260101.SearchOrdersPage(parameter);

                Console.WriteLine($"Next Page: {nextPage.Orders?.Count} Orders");
                paginationToken = nextPage.PaginationToken;
            }
        }

        /// <summary>
        /// SearchOrders with IncludedData: Retrieve buyer and recipient data directly in SearchOrders.
        /// Replaces the need to call GetOrderBuyerInfo/GetOrderAddress separately afterwards.
        /// 
        /// v0-version of: GetOrders + GetOrderBuyerInfo + GetOrderAddress (3 Calls → 1 Call)
        /// </summary>
        public void SearchOrdersWithBuyerAndRecipient()
        {
            var parameter = new ParameterSearchOrders20260101
            {
                CreatedAfter = DateTime.UtcNow.AddDays(-1),
                FulfillmentStatuses = new List<FulfillmentStatus20260101>
                {
                    FulfillmentStatus20260101.UNSHIPPED
                },
                IncludedData = new List<IncludedData20260101>
                {
                    IncludedData20260101.BUYER,
                    IncludedData20260101.RECIPIENT
                }
            };

            var orders = amazonConnection.Orders20260101.SearchOrders(parameter);

            foreach (var order in orders)
            {
                // Buyer and Recipient data are directly available – no separate calls needed
                Console.WriteLine($"Order: {order.OrderId}");
                Console.WriteLine($"  Buyer: {order.Buyer?.BuyerName} ({order.Buyer?.BuyerEmail})");
                Console.WriteLine($"  Address: {order.Recipient?.DeliveryAddress?.City}, {order.Recipient?.DeliveryAddress?.PostalCode}");
            }
        }

        /// <summary>
        /// PII access in v2026-01-01 – NO RDT needed!
        /// Easily include buyer and recipient data by setting includedData=BUYER,RECIPIENT. Access is role-based.
        /// 
        /// v0-version of: GetOrders with IsNeedRestrictedDataToken=true + RDT-Creation
        /// </summary>
        public void SearchOrdersPII()
        {
            // No RDT, no IsNeedRestrictedDataToken – just request the data directly.
            // Access to PII data is now role-based, so make sure your app has the appropriate PII roles assigned.
            var parameter = new ParameterSearchOrders20260101
            {
                CreatedAfter = DateTime.UtcNow.AddDays(-1),
                FulfillmentStatuses = new List<FulfillmentStatus20260101>
                {
                    FulfillmentStatus20260101.UNSHIPPED
                },
                IncludedData = new List<IncludedData20260101>
                {
                    IncludedData20260101.BUYER,
                    IncludedData20260101.RECIPIENT
                }
            };

            var orders = amazonConnection.Orders20260101.SearchOrders(parameter);
        }

        /// <summary>
        /// FulfillmentChannel-Filter: AFN/MFN → AMAZON/MERCHANT.
        /// 
        /// v0-version of: GetOrders with FulfillmentChannels = AFN
        /// </summary>
        public void SearchOrdersByFulfillmentChannel()
        {
            var parameter = new ParameterSearchOrders20260101
            {
                CreatedAfter = DateTime.UtcNow.AddDays(-24),
                FulfillmentStatuses = new List<FulfillmentStatus20260101>
                {
                    FulfillmentStatus20260101.SHIPPED
                },
                // AFN → AMAZON, MFN → MERCHANT
                FulfilledBy = new List<FulfilledBy20260101>
                {
                    FulfilledBy20260101.AMAZON
                }
            };

            var orders = amazonConnection.Orders20260101.SearchOrders(parameter);
        }

        // ──────────────────────────────────────────────────────────────────
        // GetOrder - replaces multiple calls from v0 with a single, more powerful call.
        // Replaced calls: GetOrder + GetOrderItems + GetOrderBuyerInfo + GetOrderAddress + GetOrderItemsBuyerInfo
        // ──────────────────────────────────────────────────────────────────

        /// <summary>
        /// Single order retrieval – items are ALWAYS included in the response.
        /// 
        /// v0-version of: GetOrder + GetOrderItems (2 Calls → 1 Call)
        /// </summary>
        public void GetOrder()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = exampleOrderId
            };

            var order = amazonConnection.Orders20260101.GetOrder(parameter);

            Console.WriteLine($"Order: {order.OrderId}");
            Console.WriteLine($"  Status: {order.Fulfillment?.FulfillmentStatus}");
            Console.WriteLine($"  FulfilledBy: {order.Fulfillment?.FulfilledBy}");
            Console.WriteLine($"  Items: {order.OrderItems?.Count}");

            // Items are always included in the response, so you can access them directly without needing a separate GetOrderItems call.
            if (order.OrderItems != null)
            {
                foreach (var item in order.OrderItems)
                {
                    Console.WriteLine($"    - {item.Product?.Title} (ASIN: {item.Product?.Asin}, SKU: {item.Product?.SellerSku})");
                    Console.WriteLine($"      Amount: {item.QuantityOrdered}");
                }
            }
        }

        /// <summary>
        /// Order with Buyer Info.
        /// 
        /// v0-version of: GetOrder + GetOrderBuyerInfo + GetOrderItemsBuyerInfo (3 Calls → 1 Call)
        /// </summary>
        public void GetOrderWithBuyerInfo()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = exampleOrderId,
                IncludedData = new List<IncludedData20260101>
                {
                    IncludedData20260101.BUYER
                }
            };

            var order = amazonConnection.Orders20260101.GetOrder(parameter);

            // Buyer-Data – replaces the need for a separate GetOrderBuyerInfo call
            Console.WriteLine($"Buyer: {order.Buyer?.BuyerName}");
            Console.WriteLine($"Email: {order.Buyer?.BuyerEmail}");
            Console.WriteLine($"Company: {order.Buyer?.BuyerCompanyName}");
            Console.WriteLine($"PO Number: {order.Buyer?.BuyerPurchaseOrderNumber}");
        }

        /// <summary>
        /// Get Order with Recipient data (includedData=RECIPIENT)
        /// 
        /// v0-version of: GetOrder + GetOrderAddress (2 Calls → 1 Call)
        /// </summary>
        public void GetOrderWithAddress()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = exampleOrderId,
                IncludedData = new List<IncludedData20260101>
                {
                    IncludedData20260101.RECIPIENT
                }
            };

            var order = amazonConnection.Orders20260101.GetOrder(parameter);

            var address = order.Recipient?.DeliveryAddress;
            Console.WriteLine($"Name: {address?.Name}");
            Console.WriteLine($"Street: {address?.AddressLine1}");
            Console.WriteLine($"City: {address?.City} {address?.PostalCode}");
            Console.WriteLine($"Country: {address?.CountryCode}");

            // Check AddressType – replaces IsAccessPointOrder from v0
            if (address?.AddressType == "PICKUP_POINT")
            {
                Console.WriteLine("-> Access Point / Pickup-Order");
            }
        }

        /// <summary>
        /// Get Order with Proceeds.
        /// The new hierarchical Proceeds structure replaces the flat price fields from v0.
        /// 
        /// v0-version of: GetOrder + GetOrderItems (ItemPrice, ShippingPrice, ItemTax etc.)
        /// </summary>
        public void GetOrderWithProceeds()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = exampleOrderId,
                IncludedData = new List<IncludedData20260101>
                {
                    IncludedData20260101.PROCEEDS
                }
            };

            var order = amazonConnection.Orders20260101.GetOrder(parameter);

            // Order-Level - Grand Total replaces OrderTotal from v0
            Console.WriteLine($"Grand Total: {order.Proceeds?.GrandTotal?.Amount} {order.Proceeds?.GrandTotal?.CurrencyCode}");

            // Item-Level: Detailed Beakdown
            if (order.OrderItems != null)
            {
                foreach (var item in order.OrderItems)
                {
                    Console.WriteLine($"\n  Item: {item.Product?.Asin}");
                    Console.WriteLine($"  Proceeds Total: {item.Proceeds?.ProceedsTotal?.Amount}");

                    if (item.Proceeds?.Breakdowns != null)
                    {
                        foreach (var breakdown in item.Proceeds.Breakdowns)
                        {
                            // type: ITEM, SHIPPING, DISCOUNT, TAX, COD_FEE, GIFT_WRAP
                            Console.WriteLine($"    {breakdown.Type}: {breakdown.Subtotal?.Amount}");

                            if (breakdown.DetailedBreakdowns != null)
                            {
                                foreach (var detail in breakdown.DetailedBreakdowns)
                                {
                                    Console.WriteLine($"      {detail.Subtype}: {detail.Value?.Amount}");
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get Order with Package Tracking – NEW in v2026-01-01.
        /// New in v2026-01-01
        /// </summary>
        public void GetOrderWithPackages()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = exampleOrderId,
                IncludedData = new List<IncludedData20260101>
                {
                    IncludedData20260101.PACKAGES
                }
            };

            var order = amazonConnection.Orders20260101.GetOrder(parameter);

            if (order.Packages != null)
            {
                foreach (var package in order.Packages)
                {
                    Console.WriteLine($"Package: {package.PackageReferenceId}");
                    Console.WriteLine($"  Carrier: {package.Carrier}");
                    Console.WriteLine($"  Tracking: {package.TrackingNumber}");
                    Console.WriteLine($"  Service: {package.ShippingService}");
                    Console.WriteLine($"  Status: {package.PackageStatus?.Status}");
                    Console.WriteLine($"  Detail: {package.PackageStatus?.DetailedStatus}");
                    Console.WriteLine($"  Shipping: {package.ShipTime}");
                }
            }
        }

        /// <summary>
        /// All data at once – convenience method to retrieve all available data in one call. Just set all IncludedData values.
        /// v0-version of: GetOrder + GetOrderItems + GetOrderBuyerInfo + GetOrderAddress + GetOrderItemsBuyerInfo (5 Calls → 1 Call)
        /// </summary>
        public void GetOrderFull()
        {
            var order = amazonConnection.Orders20260101
                .GetOrderFullAsync(exampleOrderId)
                .ConfigureAwait(false).GetAwaiter().GetResult();

            // Alles in einem Call verfügbar:
            Console.WriteLine($"Order: {order.OrderId}");
            Console.WriteLine($"CreatedAt: {order.CreatedTime}");
            Console.WriteLine($"Buyer: {order.Buyer?.BuyerName}");
            Console.WriteLine($"Address: {order.Recipient?.DeliveryAddress?.City}");
            Console.WriteLine($"Total: {order.Proceeds?.GrandTotal?.Amount}");
            Console.WriteLine($"Items: {order.OrderItems?.Count}");
            Console.WriteLine($"Packages: {order.Packages?.Count}");
        }

        // ──────────────────────────────────────────────────────────────────
        // Programs - replaces the boolean flags from v0 (IsPrime, IsBusinessOrder, IsPremiumOrder, IsISPU) with a flexible list of program identifiers.
        // ──────────────────────────────────────────────────────────────────

        /// <summary>
        /// Check Order Programs – replaces IsPrime, IsBusinessOrder, IsPremiumOrder, IsISPU etc.
        /// 
        /// v0: order.IsPrime, order.IsBusinessOrder, order.IsPremiumOrder
        /// v2026-01-01: order.Programs contains e.g. "PRIME", "AMAZON_BUSINESS", "PREMIUM"
        /// </summary>
        public void CheckOrderPrograms()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = exampleOrderId
            };

            var order = amazonConnection.Orders20260101.GetOrder(parameter);

            // Instead of order.IsPrime
            bool isPrime = order.Programs?.Contains("PRIME") == true;

            // Instead of order.IsBusinessOrder
            bool isBusinessOrder = order.Programs?.Contains("AMAZON_BUSINESS") == true;

            // Instead of order.IsPremiumOrder
            bool isPremium = order.Programs?.Contains("PREMIUM") == true;

            // Instead of order.IsISPU
            bool isPickup = order.Programs?.Contains("IN_STORE_PICK_UP") == true;

            // Neu in v2026-01-01:
            bool isAmazonHaul = order.Programs?.Contains("AMAZON_HAUL") == true;
            bool isEasyShip = order.Programs?.Contains("AMAZON_EASY_SHIP") == true;
            bool isDeliveryByAmazon = order.Programs?.Contains("DELIVERY_BY_AMAZON") == true;

            // Item-Level Programme
            if (order.OrderItems != null)
            {
                foreach (var item in order.OrderItems)
                {
                    // Instead of item.IsTransparency
                    bool isTransparency = item.Programs?.Contains("TRANSPARENCY") == true;

                    bool isSubscribeAndSave = item.Programs?.Contains("SUBSCRIBE_AND_SAVE") == true;
                }
            }

            Console.WriteLine($"Prime: {isPrime}, Business: {isBusinessOrder}, Premium: {isPremium}");
        }

        /// <summary>
        /// Get SellerOrderId - now via OrderAliases instead of a direct property.
        /// 
        /// v0: order.SellerOrderId
        /// v2026-01-01: order.OrderAliases.FirstOrDefault(a => a.AliasType == "SELLER_ORDER_ID")?.AliasId
        /// </summary>
        public void GetSellerOrderId()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = exampleOrderId
            };

            var order = amazonConnection.Orders20260101.GetOrder(parameter);

            var sellerOrderId = order.OrderAliases?
                .FirstOrDefault(a => a.AliasType == "SELLER_ORDER_ID")?.AliasId;

            Console.WriteLine($"Seller Order ID: {sellerOrderId}");
        }

        /// <summary>
        /// Fulfillment-Details abrufen (Versandfenster, Lieferfenster etc.)
        /// Fulfillment details are now included in the main GetOrder response when you set includedData=FULFILLMENT
        /// instead of requiring separate calls or parameters.
        /// 
        /// v0-version of: GetOrder (EarliestShipDate, LatestShipDate, EarliestDeliveryDate, LatestDeliveryDate)
        /// </summary>
        public void GetOrderWithFulfillmentDetails()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = exampleOrderId,
                IncludedData = new List<IncludedData20260101>
                {
                    IncludedData20260101.FULFILLMENT
                }
            };

            var order = amazonConnection.Orders20260101.GetOrder(parameter);

            // Order-Level Fulfillment
            Console.WriteLine($"Status: {order.Fulfillment?.FulfillmentStatus}");
            Console.WriteLine($"FulfilledBy: {order.Fulfillment?.FulfilledBy}");
            Console.WriteLine($"ServiceLevel: {order.Fulfillment?.FulfillmentServiceLevel}");
            Console.WriteLine($"Ship By: {order.Fulfillment?.ShipByWindow?.EarliestDateTime} - {order.Fulfillment?.ShipByWindow?.LatestDateTime}");
            Console.WriteLine($"Deliver By: {order.Fulfillment?.DeliverByWindow?.EarliestDateTime} - {order.Fulfillment?.DeliverByWindow?.LatestDateTime}");

            // Item-Level Fulfillment
            if (order.OrderItems != null)
            {
                foreach (var item in order.OrderItems)
                {
                    Console.WriteLine($"\n  Item {item.OrderItemId}:");
                    Console.WriteLine($"    Fulfilled: {item.Fulfillment?.QuantityFulfilled}");
                    Console.WriteLine($"    Gift: {item.Fulfillment?.Packing?.GiftOption}");
                    Console.WriteLine($"    Gift Message: {item.Fulfillment?.Packing?.GiftMessage}");
                }
            }
        }
    }
}
