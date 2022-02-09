using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaInbound;
using FikaAmazonAPI.Parameter.FbaInboundEligibility;

namespace FikaAmazonAPI.Services
{
    public class FbaInboundEligibilityService : RequestService
    {
        public FbaInboundEligibilityService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public ItemEligibilityPreview GetItemEligibilityPreview(ParameterGetItemEligibilityPreview parameterGetItemEligibilityPreview)
        {
            var parameter = parameterGetItemEligibilityPreview.getParameters();
            CreateAuthorizedRequest(FBAInboundEligibiltyApiUrls.GetItemEligibilityPreview, RestSharp.Method.GET, parameter);
            var response = ExecuteRequest<GetItemEligibilityPreviewResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
