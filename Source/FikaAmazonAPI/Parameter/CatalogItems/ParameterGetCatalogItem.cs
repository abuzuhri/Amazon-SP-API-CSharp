using FikaAmazonAPI.Search;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.CatalogItems
{
    public class ParameterGetCatalogItem : ParameterBased
    {
        public string ASIN { get; set; }
        public ICollection<string> marketplaceIds { get; set; } = new List<string>();
        public ICollection<IncludedData> includedData { get; set; }
        public string locale { get; set; }
    }
}
