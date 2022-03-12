using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.ProductTypes
{
    public class SearchDefinitionsProductTypesParameter : ParameterBased
    {
        public IList<string> keywords { get; set; }
        public IList<string> marketplaceIds { get; set; } = new List<string>();
    }
}
