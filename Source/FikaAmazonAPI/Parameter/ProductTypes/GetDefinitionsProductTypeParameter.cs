using System.Collections.Generic;
using FikaAmazonAPI.AmazonSpApiSDK.Models.ProductTypes;
using FikaAmazonAPI.Parameter.ListingItem;
using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.ProductTypes
{
    public class GetDefinitionsProductTypeParameter : ParameterBased
    {
        public LocaleEnum? locale { get; set; }
        public ICollection<string> marketplaceIds { get; set; } = new List<string>();

        [PathParameter] public string productType { get; set; }

        public string productTypeVersion { get; set; }

        //        public RequirementsEnum? requirements { get; set; }
        public Requirements? requirements { get; set; }

        public RequirementsEnforcedEnum? requirementsEnforced { get; set; }

        public string sellerId { get; set; }
    }
}