using FikaAmazonAPI.Search;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.CatalogItems
{
    public class ParameterSearchCatalogItems202204 : PaginationParameter
    {
        public IList<string> identifiers { get; set; }
        public IList<string> marketplaceIds { get; set; } = new List<string>();
        public IdentifiersType? identifiersType { get; set; }
        public IList<IncludedData> includedData { get; set; }
        public string locale { get; set; }
        public string sellerId { get; set; }
        public IList<string> keywords { get; set; } = new List<string>();
        public IList<string> brandNames { get; set; } = new List<string>();
        public IList<string> classificationIds { get; set; } = new List<string>();
        public string pageToken { get; set; }
        public string keywordsLocale { get; set; }        
    }
}
