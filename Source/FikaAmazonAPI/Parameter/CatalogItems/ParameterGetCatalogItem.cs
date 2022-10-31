using FikaAmazonAPI.Search;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.CatalogItems
{
    public class ParameterGetCatalogItem : ParameterBased
    {
        public string ASIN { get; set; }
        public IList<string> marketplaceIds { get; set; } = new List<string>();
        public IList<IncludedData> includedData { get; set; }
        public string locale { get; set; }
    }
}
