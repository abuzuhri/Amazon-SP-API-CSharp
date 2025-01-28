using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    [CamelCase]
    public class ParameterListPrepDetails : ParameterBased
    {
        public string MarketplaceId { get; set; }

        public ICollection<string> Mskus { get; set; }
    }
}
