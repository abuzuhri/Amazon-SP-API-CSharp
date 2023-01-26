using FikaAmazonAPI.Search;
using System.Collections.Generic;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.FbaInbound.ItemEligibilityPreview;

namespace FikaAmazonAPI.Parameter.FbaInboundEligibility
{
    public class ParameterGetItemEligibilityPreview : ParameterBased
    {
        public ICollection<string> marketplaceIds { get; set; }
        public string asin { get; set; }
        public ProgramEnum program { get; set; }
    }
}
