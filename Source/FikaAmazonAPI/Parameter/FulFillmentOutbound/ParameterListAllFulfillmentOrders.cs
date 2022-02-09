using FikaAmazonAPI.Search;
using System;

namespace FikaAmazonAPI.Parameter.FulFillmentOutbound
{
    public class ParameterListAllFulfillmentOrders : ParameterBased
    {
        public DateTime? queryStartDate { get; set; }
        public string nextToken { get; set; }
    }
}
