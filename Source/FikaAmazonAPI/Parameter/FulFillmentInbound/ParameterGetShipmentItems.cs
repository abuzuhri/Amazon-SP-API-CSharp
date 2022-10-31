using FikaAmazonAPI.Search;
using System;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterGetShipmentItems : ParameterBased
    {
        public DateTime? LastUpdatedAfter { get; set; }
        public DateTime? LastUpdatedBefore { get; set; }
        public QueryType QueryType { get; set; }
        public string NextToken { get; set; }
        public string MarketplaceId { get; set; }
        public string ShipmentId { get; set; }
        public int? MaxNumberOfPages { get; set; }
    }
}
