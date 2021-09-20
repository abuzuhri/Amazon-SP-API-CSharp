using FikaAmazonAPI.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Test
{
    [TestClass]
    public class FbaInboundEligibility
    {
        AmazonConnection amazonConnection;
        public FbaInboundEligibility()
        {
            amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
                SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
                RoleArn = Environment.GetEnvironmentVariable("RoleArn"),
                ClientId = Environment.GetEnvironmentVariable("ClientId"),
                ClientSecret = Environment.GetEnvironmentVariable("ClientSecret"),
                RefreshToken = Environment.GetEnvironmentVariable("RefreshToken"),
                MarketPlace = MarketPlace.UnitedArabEmirates

            });

        }



        [TestMethod]
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
