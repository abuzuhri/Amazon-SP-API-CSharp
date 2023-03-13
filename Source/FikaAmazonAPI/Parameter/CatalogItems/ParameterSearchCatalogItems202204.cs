using FikaAmazonAPI.Search;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.CatalogItems
{
    public class ParameterSearchCatalogItems202204 : PaginationParameter
    {
        public ICollection<string> identifiers { get; set; }
        public ICollection<string> marketplaceIds { get; set; } = new List<string>();
        public IdentifiersType? identifiersType { get; set; }
        public ICollection<IncludedData> includedData { get; set; }
        public string locale { get; set; }
        public string sellerId { get; set; }
        public ICollection<string> keywords { get; set; } = new List<string>();
        public ICollection<string> brandNames { get; set; } = new List<string>();
        public ICollection<string> classificationIds { get; set; } = new List<string>();
        public string pageToken { get; set; }
        public string keywordsLocale { get; set; }        
    }
}
