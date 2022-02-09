using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.CatalogItems
{
    public class ParameterListCatalogItems : ParameterBased
    {
        public string MarketplaceId { get; set; }
        public string Query { get; set; }
        public string QueryContextId { get; set; }
        public string SellerSKU { get; set; }
        public string UPC { get; set; }
        public string EAN { get; set; }
        public string ISBN { get; set; }
        public string JAN { get; set; }
    }
}
