using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.Order
{
    public class ParameterOrderList : ParameterBased, IParameterBasedPII
    {
        public ParameterOrderList()
        {
        }

        /// <summary>
        /// A date used for selecting orders created after (or at) a specified time. Only orders placed after the specified time are returned. Either the CreatedAfter parameter or the LastUpdatedAfter parameter is required. Both cannot be empty. The date must be in ISO 8601 format.	
        /// </summary>
        public DateTime? CreatedAfter { get; set; }
        /// <summary>
        /// A date used for selecting orders created before (or at) a specified time. Only orders placed before the specified time are returned. The date must be in ISO 8601 format.	
        /// </summary>
        public DateTime? CreatedBefore { get; set; }
        /// <summary>
        /// A date used for selecting orders that were last updated after (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. The date must be in ISO 8601 format.
        /// </summary>
        public DateTime? LastUpdatedAfter { get; set; }
        /// <summary>
        /// A date used for selecting orders that were last updated before (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. The date must be in ISO 8601 format.	
        /// </summary>
        public DateTime? LastUpdatedBefore { get; set; }


        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        /// <summary>
        /// A list of OrderStatus values used to filter the results. Possible values: PendingAvailability (This status is available for pre-orders only. The order has been placed, payment has not been authorized, and the release date of the item is in the future.); Pending (The order has been placed but payment has not been authorized); Unshipped (Payment has been authorized and the order is ready for shipment, but no items in the order have been shipped); PartiallyShipped (One or more, but not all, items in the order have been shipped); Shipped (All items in the order have been shipped); InvoiceUnconfirmed (All items in the order have been shipped. The seller has not yet given confirmation to Amazon that the invoice has been shipped to the buyer.); Canceled (The order has been canceled); and Unfulfillable (The order cannot be fulfilled. This state applies only to Multi-Channel Fulfillment orders.).
        /// </summary>
        public ICollection<Constants.OrderStatuses> OrderStatuses { get; set; }
        /// <summary>
        /// A list of MarketplaceId values. Used to select orders that were placed in the specified marketplaces. Max count : 50
        /// </summary>
        public ICollection<string> MarketplaceIds { get; set; }

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        /// <summary>
        /// A list that indicates how an order was fulfilled. Filters the results by fulfillment channel. Possible values: FBA (Fulfillment by Amazon); SellerFulfilled (Fulfilled by the seller).	
        /// </summary>
        public ICollection<Constants.FulfillmentChannels> FulfillmentChannels { get; set; }

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        /// <summary>
        /// A list of payment method values. Used to select orders paid using the specified payment methods. Possible values: COD (Cash on delivery); CVS (Convenience store payment); Other (Any payment method other than COD or CVS).
        /// </summary>
        public ICollection<Constants.PaymentMethods> PaymentMethods { get; set; }

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public ICollection<Constants.EasyShipShipmentStatuses> EasyShipShipmentStatuses { get; set; }
        /// <summary>
        /// A list of AmazonOrderId values. An AmazonOrderId is an Amazon-defined order identifier, in 3-7-7 format. Max count : 50
        /// </summary>
        public ICollection<string> AmazonOrderIds { get; set; }
        /// <summary>
        /// The email address of a buyer. Used to select orders that contain the specified email address.	
        /// </summary>
        public string BuyerEmail { get; set; }
        /// <summary>
        /// An order identifier that is specified by the seller. Used to select only the orders that match the order identifier. If SellerOrderId is specified, then FulfillmentChannels, OrderStatuses, PaymentMethod, LastUpdatedAfter, LastUpdatedBefore, and BuyerEmail cannot be specified.	
        /// </summary>
        public string SellerOrderId { get; set; }
        /// <summary>
        /// A string token returned in the response of your previous request.
        /// </summary>
        public string NextToken { get; set; }
        public int? MaxResultsPerPage { get; set; } = 100;
        /// <summary>
        /// Denotes the recommended sourceId where the order should be fulfilled from.	
        /// </summary>
        public string ActualFulfillmentSupplySourceId { get; set; }
        /// <summary>
        /// When true, this order is marked to be picked up from a store rather than delivered.	
        /// </summary>
        public bool? IsISPU { get; set; }
        public int? MaxNumberOfPages { get; set; }
        /// <summary>
        /// The store chain store identifier. Linked to a specific store in a store chain.	
        /// </summary>
        public string StoreChainStoreId { get; set; }
        public bool IsNeedRestrictedDataToken { get; set; }
        public CreateRestrictedDataTokenRequest RestrictedDataTokenRequest { get; set; }
    }
}
