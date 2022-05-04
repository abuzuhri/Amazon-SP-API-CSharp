using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
    public class FbaSmallAndLightSample
    {
        string sellerSKU = "530487_1-hyx";

        AmazonConnection amazonConnection;
        public FbaSmallAndLightSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;

        }

        public async Task GetSmallAndLightEnrollmentBySellerSKUAsync()
        {
            var smallAndLightEnrollment = await amazonConnection.FbaSmallandLight.GetSmallAndLightEnrollmentBySellerSKUAsync(sellerSKU);
        }


        public async Task GetSmallAndLightEligibilityBySellerSKUAsync()
        {
            //string sellerSKU = "530487_1-hyx";

            var smallAndLightEnrollment = await amazonConnection.FbaSmallandLight.GetSmallAndLightEligibilityBySellerSKUAsync(sellerSKU);
        }

        public async Task GetSmallAndLightFeePreviewAsync()
        {

            var smallAndLightEnrollment = await amazonConnection.FbaSmallandLight.GetSmallAndLightFeePreviewAsync(new AmazonSpApiSDK.Models.FbaSmallandLight.SmallAndLightFeePreviewRequest(MarketPlace.UnitedKingdom.ID, new List<AmazonSpApiSDK.Models.FbaSmallandLight.Item>
            {
                new AmazonSpApiSDK.Models.FbaSmallandLight.Item("B09TB5PJ9Q",
                new AmazonSpApiSDK.Models.FbaSmallandLight.MoneyType("GBP",3.69m))
            }));
        }
    }
}
