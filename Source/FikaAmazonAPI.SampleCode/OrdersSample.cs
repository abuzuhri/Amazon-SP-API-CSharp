using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.AmazonSpApiSDK.Services;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Utils;
using System.Linq;
using System.Net.WebSockets;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.SampleCode
{
    public class OrdersSample
    {
        AmazonConnection amazonConnection;
        public OrdersSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        /// <summary>
        /// Only retrieve one page of results and manually paginate with PaginationToken.
        /// PaginationToken replaces NextToken from v0, but note that it expires after 24 hours.
        /// 
        /// v0-Version of: GetOrders with MaxNumberOfPages=1, then GetGetOrdersByNextToken
        /// </summary>
        public void SearchOrdersOnePageWithPaginationToken()
        {
            var parameter = new ParameterSearchOrders
            {
                CreatedAfter = DateTime.UtcNow.AddMinutes(-600000),
                MaxNumberOfPages = 1,
                FulfillmentStatuses = new List<FulfillmentStatus20260101>
                {
                    FulfillmentStatus20260101.SHIPPED
                }
            };

            // Get First Page
            var firstPage = amazonConnection.Orders.SearchOrdersPage(parameter);

            Console.WriteLine($"First Page: {firstPage.Orders?.Count} Orders");

            // Manually paginate with PaginationToken
            var paginationToken = firstPage.PaginationToken;
            while (!string.IsNullOrEmpty(paginationToken))
            {
                parameter.PaginationToken = paginationToken;
                var nextPage = amazonConnection.Orders.SearchOrdersPage(parameter);

                Console.WriteLine($"Next Page: {nextPage.Orders?.Count} Orders");
                paginationToken = nextPage.PaginationToken;
            }
        }


        // ------------------------------------------------------------------
        // SearchOrders - v2026-01-01
        // ------------------------------------------------------------------

        /// <summary>
        /// Simple Example: Retrieve all shipped orders from the last 7 days.
        /// Library automatically paginates through all pages.
        /// 
        /// v0-version of: GetOrders mit OrderStatuses = Shipped
        /// </summary>
        public void SearchOrders()
        {
            var parameter = new ParameterSearchOrders
            {
                CreatedAfter = DateTime.UtcNow.AddDays(-7),
                FulfillmentStatuses = new List<FulfillmentStatus20260101>
                {
                    FulfillmentStatus20260101.SHIPPED
                },
                AmazonOrderIds = new List<string>
                {
                    "403-1710607-6240347",
                    "403-5583945-7236361",
                    "403-3320829-4528316",
                    "406-2574982-2047546"
                }
            };

            var orders = amazonConnection.Orders.SearchOrders(parameter);

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
            var parameter = new ParameterSearchOrders
            {
                CreatedAfter = DateTime.UtcNow.AddDays(-30),
                AmazonOrderIds = new List<string>() { "403-1710607-6240347" }
            };

            var orders = amazonConnection.Orders.SearchOrders(parameter);
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
            var parameter = new ParameterSearchOrders
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

            var orders = amazonConnection.Orders.SearchOrders(parameter);
        }

        // ------------------------------------------------------------------
        // GetOrder - v2026-01-01
        // ------------------------------------------------------------------

        /// <summary>
        /// Single order retrieval – items are ALWAYS included in the response.
        /// Added "Single" to give the Original GetOrder a deprication Msg + Error.
        /// v0-version of: GetOrder + GetOrderItems (2 Calls → 1 Call)
        /// </summary>
        public void GetSingleOrder()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = "402-0467973-4229120",
            };
            var order = amazonConnection.Orders.GetOrder(parameter);
        }

        /// <summary>
        /// Single order retrieval – added FilfillmentInfos.
        /// </summary>
        public void GetOrderFulfillmentInfo()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = "402-0467973-4229120",
                IncludedData = new List<IncludedData20260101>
                {
                    IncludedData20260101.FULFILLMENT
                }
            };
            var order = amazonConnection.Orders.GetOrder(parameter);
            var FulfillmentBy = order?.Fulfillment?.FulfilledBy;
            var FulfillmentStatus = order?.Fulfillment?.FulfillmentStatus;
        }

        /// <summary>
        /// All data at once – convenience method to retrieve all available data in one call. Just set all IncludedData values.
        /// v0-version of: GetOrder + GetOrderItems + GetOrderBuyerInfo + GetOrderAddress + GetOrderItemsBuyerInfo (5 Calls → 1 Call)
        /// </summary>
        public void GetOrderFull()
        {
            var order = amazonConnection.Orders.GetOrderFull("402-0467973-4229120");
            Buyer? BuyerInfo = order?.Buyer;
            Recipient? RecipientInfo = order?.Recipient;
            OrderFulfillment? FulfillmentInfo = order?.Fulfillment;
            OrderProceeds? ProceedsInfo = order?.Proceeds;
            // Expenses are infos that gets added to the Order and OrderItems, they are not in a separate node in the response like the other includedData, so you can find them directly in the Order and OrderItems objects.
            // Attached to OrderItems:
            OrderItemExpense? Expenses = order?.OrderItems.FirstOrDefault()?.Expense;
            OrderItemPromotion? PromotionInfo = order?.OrderItems.FirstOrDefault()?.Promotion;
            OrderItemCancellation? CancellationInfo = order?.OrderItems.FirstOrDefault()?.Cancellation;
            List<Package>? PackagesList = order?.Packages.ToList();

            OrderConverter.OrderProgramInfo allProgramsInfos = OrderConverter.OrderProgramInfoEx(order);
            List<OrderConverter.OrderItemProgramInfo> AllOrderItemInfos = allProgramsInfos.orderItems;
        }

        /// <summary>
        /// Easy to Use Converters for order programs. Just pass the Order object to the constructor and it will parse the program information for you and give you easy to use boolean properties.
        /// </summary>
        public void GetProgramsFromOrder()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = "402-0467973-4229120",
            };
            var order = amazonConnection.Orders.GetOrder(parameter);

            OrderConverter.OrderProgramInfo ProgramInfos = new OrderConverter.OrderProgramInfo(order);

            bool isPrime = ProgramInfos.isPrime;
            bool isPremium = ProgramInfos.isPremium;
            bool isInStorePickUp = ProgramInfos.isInStorePickUp;
            bool isFBMShipPlus = ProgramInfos.isFBMShipPlus;
            bool isDeliveryByAmazon = ProgramInfos.isDeliveryByAmazon;
            bool isAmazonHaul = ProgramInfos.isAmazonHaul;
            bool isAmazonEasyShip = ProgramInfos.isAmazonEasyShip;
            bool isAmazonBusiness = ProgramInfos.isAmazonBusiness;
            bool isAmazonBazaar = ProgramInfos.isAmazonBazaar;
            bool isPreorder = ProgramInfos.isPreorder;
        }

        /// <summary>
        /// Easy to Use Converters for order item programs. Just pass the Order object to the constructor and it will parse the program information for each order item and give you easy to use boolean properties.
        /// </summary>
        public void GetProgramsFromOrderItems()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = "402-0467973-4229120",
            };
            var order = amazonConnection.Orders.GetOrder(parameter);

            OrderConverter.OrderProgramInfo allProgramsInfos = OrderConverter.OrderProgramInfoEx(order);

            List<OrderConverter.OrderItemProgramInfo> AllOrderItemInfos = allProgramsInfos.orderItems;

            foreach (OrderConverter.OrderItemProgramInfo item in allProgramsInfos.orderItems)
            {
                bool isTransparent = item.isTransparency;
                bool isSubscribeAndSave = item.isSubscribe_And_Save;
            }
        }


        // ------------------------------------------------------------------
        // Reworked GetOrderFunctions to fit the new GetOrder endpoint with includedData parameter
        // ------------------------------------------------------------------

        public void GetOrderBuyerInfo()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = "402-0467973-4229120",
                IncludedData = new List<IncludedData20260101>
                {
                    IncludedData20260101.BUYER
                }
            };
            var order = amazonConnection.Orders.GetOrder(parameter);
            var BuyerInfo = order?.Buyer;
        }

        public void GetOrderAddress()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = "402-0467973-4229120",
                IncludedData = new List<IncludedData20260101>
                {
                    IncludedData20260101.RECIPIENT,
                    IncludedData20260101.BUYER,
                }
            };
            var order = amazonConnection.Orders.GetOrder(parameter);
            var BuyerCompanyName = order?.Buyer?.BuyerCompanyName;
            var ShippingAddress = order?.Recipient?.DeliveryAddress;
            var DeliveryPreferences = order?.Recipient?.DeliveryPreference;
        }

        public void GetOrderItems()
        {
            var parameter = new ParameterGetOrder20260101
            {
                OrderId = "402-0467973-4229120",
                // No need to specify IncludedData to get order items – they are always included in the response.
            };
            var order = amazonConnection.Orders.GetOrder(parameter);
            var orderItems = order?.OrderItems;
        }

        public List<Order20260101> GetOrderListFulfillmentChannels()
        {
            var parameter = new ParameterSearchOrders
            {
                CreatedAfter = DateTime.UtcNow.AddDays(-24),
                FulfillmentStatuses = new List<FulfillmentStatus20260101> { FulfillmentStatus20260101.SHIPPED }
            };
            var orders = amazonConnection.Orders.SearchOrders(parameter);

            return orders.ToList();
        }



        #region Obsolete v0 methods

        /// <summary>
        /// You must have valid PII developer to be able to call this method
        /// </summary>
        [Obsolete("This method is using GetOrders which is deprecated, please use SearchOrdersPII instead.")]
        public void GetOrdersPIISimple()
        {
            /*
            ParameterOrderList searchOrderList = new ParameterOrderList();
            searchOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);

            searchOrderList.OrderStatuses = new List<OrderStatuses>();
            searchOrderList.OrderStatuses.Add(OrderStatuses.Unshipped);

            //You must have valid PII developer to be able to call this
            searchOrderList.IsNeedRestrictedDataToken = true;

            var orders = amazonConnection.Orders.GetOrders(searchOrderList);
            */
            throw new NotImplementedException("This method is using GetOrders which is deprecated, please use SearchOrdersPII instead.");
        }

        [Obsolete("This method is using GetOrders which is deprecated, please use SearchOrdersPII instead.")]
        public void GetOrdersPIIAdvance()
        {
            /*
            ParameterOrderList searchOrderList = new ParameterOrderList();
            searchOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);

            searchOrderList.OrderStatuses = new List<OrderStatuses>();
            searchOrderList.OrderStatuses.Add(OrderStatuses.Unshipped);

            //You must have valid PII developer to be able to call this 
            var restrictedResource = new RestrictedResource();
            restrictedResource.method = Method.GET.ToString();
            restrictedResource.path = ApiUrls.OrdersApiUrls.Orders;
            restrictedResource.dataElements = new List<string> { "buyerInfo", "shippingAddress" };


            var createRDT = new CreateRestrictedDataTokenRequest()
            {
                restrictedResources = new List<RestrictedResource> { restrictedResource }
            };
            searchOrderList.RestrictedDataTokenRequest = createRDT;
            searchOrderList.IsNeedRestrictedDataToken = true;

            var orders = amazonConnection.Orders.GetOrders(searchOrderList);
            */
            throw new NotImplementedException("This method is using GetOrders which is deprecated, please use SearchOrdersPII instead.");
        }

        /// <summary>
        /// You must have valid PII developer to be able to call this method
        /// </summary>
        [Obsolete("GetOrderItemsPIISimple is depricated, use GetOrder")]
        public void GetOrderItemsPIISimple()
        {
            /*
            ParameterBasedPII parameterBasedPII = new ParameterBasedPII();
            parameterBasedPII.IsNeedRestrictedDataToken = true;

            var order = amazonConnection.Orders.GetOrderItems("405-0426616-1636335", parameterBasedPII);
            */
            throw new NotImplementedException("GetOrderItemsPIISimple is depricated, use GetOrderItems");
        }

        /// <summary>
        /// You must have valid PII developer to be able to call this method
        /// </summary>
        [Obsolete("GetOrderItemsPII is depricated, use GetOrder")]
        public void GetOrderItemsPII()
        {
            /*
            var restrictedResource = new RestrictedResource();
            restrictedResource.method = Method.GET.ToString();
            restrictedResource.path = ApiUrls.OrdersApiUrls.OrderItems("405-0426616-1636335");
            //restrictedResource.dataElements = new List<string> { "buyerInfo", "shippingAddress" };


            var createRDT = new CreateRestrictedDataTokenRequest()
            {
                restrictedResources = new List<RestrictedResource> { restrictedResource }
            };

            ParameterBasedPII parameterBasedPII = new ParameterBasedPII();
            parameterBasedPII.IsNeedRestrictedDataToken = true;
            parameterBasedPII.RestrictedDataTokenRequest = createRDT;

            var order = amazonConnection.Orders.GetOrderItems("405-0426616-1636335", parameterBasedPII);
            */
            throw new NotImplementedException("GetOrderItemsPII is depricated, use GetOrderItems");
        }

        [Obsolete("GetOrdersOnePageWithNextPageToken is using NextToken which is deprecated, please use SearchOrdersOnePageWithPaginationToken instead which uses PaginationToken and note that PaginationToken expires after 24 hours.")]
        public void GetOrdersOnePageWithNextPageToken()
        {
            // ONLY USE THIS SAMPLE IF YOU NEED TO GET ONE PAGE EACH TIME other wise remove parameter 'MaxNumberOfPages' and libaray will fetch all orders to you
            /* 
            ParameterOrderList searchOrderList = new ParameterOrderList();
            searchOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);
            searchOrderList.MaxNumberOfPages = 1;
            searchOrderList.OrderStatuses = new List<OrderStatuses>();
            searchOrderList.OrderStatuses.Add(OrderStatuses.Shipped);

            searchOrderList.AmazonOrderIds = new List<string>();

            var orders = amazonConnection.Orders.GetOrders(searchOrderList);
            var nextPageToken = orders.NextToken;
            while (!string.IsNullOrEmpty(nextPageToken))
            {
                var moreOrders = amazonConnection.Orders.GetGetOrdersByNextToken(nextPageToken, searchOrderList);
                nextPageToken = moreOrders.NextToken;
            }
            */
            throw new NotImplementedException("GetOrdersOnePageWithNextPageToken is using NextToken which is deprecated, please use SearchOrdersOnePageWithPaginationToken instead which uses PaginationToken and note that PaginationToken expires after 24 hours.");
        }

        [Obsolete("This method is using GetOrders which is deprecated, please use SearchOrders instead.")]
        public void GetOrders()
        {
            /*
            ParameterOrderList searchOrderList = new ParameterOrderList();
            searchOrderList.CreatedAfter = DateTime.UtcNow.AddMinutes(-600000);

            searchOrderList.OrderStatuses = new List<OrderStatuses>();
            searchOrderList.OrderStatuses.Add(OrderStatuses.Shipped);

            searchOrderList.AmazonOrderIds = new List<string>();
            searchOrderList.AmazonOrderIds.Add("403-1710607-6240347");
            searchOrderList.AmazonOrderIds.Add("403-5583945-7236361");
            searchOrderList.AmazonOrderIds.Add("403-3320829-4528316");
            searchOrderList.AmazonOrderIds.Add("406-2574982-2047546");

            var orders = amazonConnection.Orders.GetOrders(searchOrderList);
            */
            throw new NotImplementedException("This method is using GetOrders which is deprecated, please use SearchOrders instead.");
        }

        [Obsolete("This method is using GetOrderItems which is deprecated, please use GetOrder instead with IncludedData=BUYER to get buyer info together with order items.")]
        public void GetOrderItemsBuyerInfo()
        {

            /*
            var ItemsBuyerInfo = amazonConnection.Orders.GetOrderItemsBuyerInfo("402-0467973-4229120");
            */
            throw new NotImplementedException("This method is using GetOrderItems which is deprecated, please use GetOrder instead with IncludedData=BUYER to get buyer info together with order items.");
        }

        #endregion

    }
}
