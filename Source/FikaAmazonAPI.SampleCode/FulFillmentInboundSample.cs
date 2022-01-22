using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
    public class FulFillmentInboundSample
    {
        AmazonConnection amazonConnection;
        public FulFillmentInboundSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public void GetInboundGuidance()
        {
            var parm = new Parameter.FulFillmentInbound.ParameterGetInboundGuidance() {
                MarketplaceId= MarketPlace.UnitedArabEmirates.ID,
                ASINList=new List<string> { "B071XVSXRL" }
            };
            amazonConnection.FulFillmentInbound.GetInboundGuidance(parm);
        }
        
        public void GetPrepInstructions()
        {
            var parm = new Parameter.FulFillmentInbound.ParameterGetPrepInstructions() {
                ShipToCountryCode = "AE",
                MarketplaceId= MarketPlace.UnitedArabEmirates.ID,
                ASINList =new List<string> { "B071XVSXRL" }
            };
            amazonConnection.FulFillmentInbound.GetPrepInstructions(parm);
        }

    }
}
