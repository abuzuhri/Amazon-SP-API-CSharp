using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.EasyShip
{
    public class ParameterGetScheduledPackage : ParameterBased
    {
        public string marketplaceId { get; set; }
        public string amazonOrderId { get; set; }
    }
}
