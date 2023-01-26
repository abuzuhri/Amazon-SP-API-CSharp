using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;
using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterGetShipments : ParameterBased
    {
        public IList<ShipmentStatus> ShipmentStatusList { get; set; }
        public IList<string> ShipmentIdList { get; set; }
        public DateTime? LastUpdatedAfter { get; set; }
        public DateTime? LastUpdatedBefore { get; set; }
        public QueryType QueryType { get; set; }
        public string NextToken { get; set; }
        public string MarketplaceId { get; set; }
    }
}
