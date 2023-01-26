using System.Collections.Generic;

namespace FikaAmazonAPI.Search
{
    public class ParameterMarketplaceId : ParameterBased
    {
        public ParameterMarketplaceId()
        {
            marketplaceIds = new List<string>();
        }
        public ParameterMarketplaceId(string marketplaceId)
        {
            marketplaceIds = new List<string>();
            marketplaceIds.Add(marketplaceId);
        }
        public ICollection<string> marketplaceIds { get; set; }
    }
}
