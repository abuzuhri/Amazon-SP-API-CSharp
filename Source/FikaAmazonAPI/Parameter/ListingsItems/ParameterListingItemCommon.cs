using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Parameter.ListingItem
{
    public class ParameterListingItemCommon
    {
        public string SellerId { get; set; }

        public string Sku { get; set; }

        public IList<string> MarketplaceIds { get; set; }
    }
}
