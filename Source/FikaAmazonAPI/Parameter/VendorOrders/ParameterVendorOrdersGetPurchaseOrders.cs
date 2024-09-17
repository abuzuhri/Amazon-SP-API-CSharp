using FikaAmazonAPI.Search;
using System;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders.Constants;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.VendorOrders
{
    public class ParameterVendorOrdersGetPurchaseOrders : ParameterBased
    {
        public long? limit { get; set; }
        public DateTime? createdAfter { get; set; }
        public DateTime? createdBefore { get; set; }
        public SortOrderEnum? sortOrder { get; set; }
        public string nextToken { get; set; }
        public bool? includeDetails { get; set; }
        public DateTime? changedAfter { get; set; }
        public DateTime? changedBefore { get; set; }
        public PoItemState? poItemState { get; set; }
        public bool? isPOChanged { get; set; }
        public PurchaseOrderState? purchaseOrderState { get; set; }
        public string orderingVendorCode { get; set; }
    }
}
