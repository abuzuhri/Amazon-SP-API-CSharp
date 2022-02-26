using FikaAmazonAPI.AmazonSpApiSDK.Models.ProductFees;
using FikaAmazonAPI.Utils;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class ProductFeeService : RequestService
    {
        public ProductFeeService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public FeesEstimateResult GetMyFeesEstimateForSKU(string SKU, FeesEstimateRequest feesEstimateRequest) =>
            GetMyFeesEstimateForSKUAsync(SKU, feesEstimateRequest).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<FeesEstimateResult> GetMyFeesEstimateForSKUAsync(string SKU, FeesEstimateRequest feesEstimateRequest)
        {
            var Payload = new { FeesEstimateRequest = feesEstimateRequest };

            await CreateAuthorizedRequestAsync(ProductFeeApiUrls.GetMyFeesEstimateForSKU(SKU), RestSharp.Method.POST, postJsonObj: Payload);
            var response = await ExecuteRequestAsync<GetMyFeesEstimateResponse>(RateLimitType.ProductFees_GetMyFeesEstimateForSKU);
            if (response != null && response.Payload != null)
                return response.Payload.FeesEstimateResult;
            return null;
        }

        public FeesEstimateResult GetMyFeesEstimateForASIN(string ASIN, FeesEstimateRequest feesEstimateRequest) =>
            GetMyFeesEstimateForASINAsync(ASIN, feesEstimateRequest).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<FeesEstimateResult> GetMyFeesEstimateForASINAsync(string ASIN, FeesEstimateRequest feesEstimateRequest)
        {
            var Payload = new { FeesEstimateRequest = feesEstimateRequest };

            await CreateAuthorizedRequestAsync(ProductFeeApiUrls.GetMyFeesEstimateForASIN(ASIN), RestSharp.Method.POST, postJsonObj: Payload);
            var response = await ExecuteRequestAsync<GetMyFeesEstimateResponse>(RateLimitType.ProductFees_GetMyFeesEstimateForASIN);
            if (response != null && response.Payload != null)
                return response.Payload.FeesEstimateResult;
            return null;
        }
    }
}
