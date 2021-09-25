using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Parameter.FulFillmentOutbound
{
    public class ParameterListAllFulfillmentOrders : ParameterBased
    {
        public DateTime? queryStartDate { get; set; }
        public string nextToken { get; set; }
    }
}
