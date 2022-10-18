using FikaAmazonAPI.Search;
using System;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders.Constants;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.VendorOrders
{
    public class ParameterVendorOrdersGetPurchaseOrdersStatus : ParameterBased
    {
        public long? limit { get; set; }
        public SortOrderEnum? sortOrder { get; set; }
        public string nextToken { get; set; }
        public DateTime? createdAfter { get; set; }
        public DateTime? createdBefore { get; set; }
        public DateTime? updatedAfter { get; set; }
        public DateTime? updatedBefore { get; set; }
        public string purchaseOrderNumber { get; set; }
        public PurchaseOrderStatus? purchaseOrderStatus { get; set; }
        public ItemConfirmationStatus? itemConfirmationStatus { get; set; }
        public ItemReceiveStatus? itemReceiveStatus { get; set; }
        public string offeringVendorCode { get; set; }
        public string shipToPartyId { get; set; }
    }
}
