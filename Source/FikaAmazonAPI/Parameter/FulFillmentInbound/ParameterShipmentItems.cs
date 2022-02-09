using FikaAmazonAPI.Search;
using System;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound
{
    public class ParameterShipmentItems : ParameterBased
    {
        public DateTime? LastUpdatedAfter { get; set; }
        public DateTime? LastUpdatedBefore { get; set; }
        public QueryType QueryType { get; set; }
        public string NextToken { get; set; }
        public string MarketplaceId { get; set; }
    }
}
