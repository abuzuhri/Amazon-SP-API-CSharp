using FikaAmazonAPI.Search;
using Newtonsoft.Json;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.ProductPricing
{
    public class ParameterGetItemOffers : ParameterBased
    {
        public string MarketplaceId { get; set; }
        
        [JsonIgnore]
        public string Asin { get; set; }
        
        //[JsonIgnore]
        public CustomerType? CustomerType { get; set; }
        public ItemCondition ItemCondition { get; set; }
    }
}
