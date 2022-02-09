using FikaAmazonAPI.AmazonSpApiSDK.Models.ProductFees;

namespace FikaAmazonAPI.Services
{
    public class ProductFeeService : RequestService
    {
        public ProductFeeService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public FeesEstimateResult GetMyFeesEstimateForSKU(string SKU, FeesEstimateRequest feesEstimateRequest)
        {
            var Payload = new { FeesEstimateRequest = feesEstimateRequest };

            CreateAuthorizedRequest(ProductFeeApiUrls.GetMyFeesEstimateForSKU(SKU), RestSharp.Method.POST,postJsonObj: Payload);
            var response = ExecuteRequest<GetMyFeesEstimateResponse>();
            if (response != null && response.Payload != null)
                return response.Payload.FeesEstimateResult;
            return null;
        }
        public FeesEstimateResult GetMyFeesEstimateForASIN(string ASIN, FeesEstimateRequest feesEstimateRequest)
        {
            var Payload = new { FeesEstimateRequest = feesEstimateRequest };
        
            CreateAuthorizedRequest(ProductFeeApiUrls.GetMyFeesEstimateForASIN(ASIN), RestSharp.Method.POST, postJsonObj: Payload);
            var response = ExecuteRequest<GetMyFeesEstimateResponse>();
            if (response != null && response.Payload != null)
                return response.Payload.FeesEstimateResult;
            return null;
        }
    }
}
