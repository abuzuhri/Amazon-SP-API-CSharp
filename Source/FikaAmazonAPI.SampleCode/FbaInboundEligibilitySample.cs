using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
    public class FbaInboundEligibilitySample
    {
        AmazonConnection amazonConnection;
        public FbaInboundEligibilitySample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public void GetItemEligibilityPreview()
        {


            var all = amazonConnection.FbaInboundEligibility.GetItemEligibilityPreview(new Parameter.FbaInboundEligibility.ParameterGetItemEligibilityPreview()
            {
                marketplaceIds = new List<string> { MarketPlace.UnitedArabEmirates.ID },
                asin = "B07Q2R45XG",
                program = FikaAmazonAPI.AmazonSpApiSDK.Models.FbaInbound.ItemEligibilityPreview.ProgramEnum.INBOUND
            });
        }
    }
}
