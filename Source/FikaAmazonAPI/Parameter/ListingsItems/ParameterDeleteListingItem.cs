using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.Parameter.ListingItem
{
    public class ParameterDeleteListingItem: ParameterBased
    {
        public bool Check()
        {
            if (TestCase == Constants.TestCase400)
                sku = "BadSKU";
            if (string.IsNullOrWhiteSpace(this.sellerId))
            {
                throw new InvalidDataException("SellerId is a required property for ParameterDeleteListingItem and cannot be null");
            }
            if (string.IsNullOrWhiteSpace(this.sku))
            {
                throw new InvalidDataException("Sku is a required property for ParameterDeleteListingItem and cannot be null");
            }
            if (this.marketplaceIds == null || !marketplaceIds.Any())
            {
                throw new InvalidDataException("MarketplaceIds is a required property for ParameterDeleteListingItem and cannot be null");
            }
            return true;
        }

        public string sellerId { get; set; }

        public string sku { get; set; }

        public ICollection<string> marketplaceIds { get; set; }

        public string issueLocale { get; set; }
    }
}
