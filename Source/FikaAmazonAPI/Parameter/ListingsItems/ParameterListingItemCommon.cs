using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.ListingItem
{
    public class ParameterListingItemCommon
    {
        public string SellerId { get; set; }

        public string Sku { get; set; }

        public ICollection<string> MarketplaceIds { get; set; }
    }
}
