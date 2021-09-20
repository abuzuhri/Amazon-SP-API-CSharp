using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using System.Text;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.FbaInbound.ItemEligibilityPreview;

namespace FikaAmazonAPI.Parameter.FbaInboundEligibility
{
    public class ParameterGetItemEligibilityPreview : ParameterBased
    {
        public IList<string> marketplaceIds { get; set; }
        public string asin { get; set; }
        public ProgramEnum program { get; set; }
    }
}
