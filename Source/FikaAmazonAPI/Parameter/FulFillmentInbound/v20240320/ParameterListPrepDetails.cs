using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320
{
    public class ParameterListPrepDetails : ParameterBased
    {
        public string marketplaceId { get; set; }

        public ICollection<string> mskus { get; set; }
    }
}
