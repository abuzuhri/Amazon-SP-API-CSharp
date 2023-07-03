using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders;
using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.Order
{
    public class ParameterGetOrderItemsApprovals : ParameterBased
    {
        public string OrderId { get; set; }
        public string NextToken { get; set; }
        public IList<ItemApprovalType> ItemApprovalTypes { get; set; }
        public IList<ItemApprovalStatus> ItemApprovalStatus { get; set; }
    }
}
