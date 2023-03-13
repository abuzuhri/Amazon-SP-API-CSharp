using FikaAmazonAPI.AmazonSpApiSDK.Models.ProductFees;
using FikaAmazonAPI.Parameter.ProductFee;
using FikaAmazonAPI.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class ProductFeeService : RequestService
    {
        public ProductFeeService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public FeesEstimateResult GetMyFeesEstimateForSKU(string SKU, FeesEstimateRequest feesEstimateRequest) =>
            Task.Run(() => GetMyFeesEstimateForSKUAsync(SKU, feesEstimateRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<FeesEstimateResult> GetMyFeesEstimateForSKUAsync(string SKU, FeesEstimateRequest feesEstimateRequest, CancellationToken cancellationToken = default)
        {
            var Payload = new { FeesEstimateRequest = feesEstimateRequest };

            await CreateAuthorizedRequestAsync(ProductFeeApiUrls.GetMyFeesEstimateForSKU(SKU), RestSharp.Method.Post, postJsonObj: Payload, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetMyFeesEstimateResponse>(RateLimitType.ProductFees_GetMyFeesEstimateForSKU, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload.FeesEstimateResult;
            return null;
        }

        public FeesEstimateResult GetMyFeesEstimateForASIN(string ASIN, FeesEstimateRequest feesEstimateRequest) =>
            Task.Run(() => GetMyFeesEstimateForASINAsync(ASIN, feesEstimateRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<FeesEstimateResult> GetMyFeesEstimateForASINAsync(string ASIN, FeesEstimateRequest feesEstimateRequest, CancellationToken cancellationToken = default)
        {
            var Payload = new { FeesEstimateRequest = feesEstimateRequest };

            await CreateAuthorizedRequestAsync(ProductFeeApiUrls.GetMyFeesEstimateForASIN(ASIN), RestSharp.Method.Post, postJsonObj: Payload, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetMyFeesEstimateResponse>(RateLimitType.ProductFees_GetMyFeesEstimateForASIN, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload.FeesEstimateResult;
            return null;
        }


        public GetMyFeesEstimatesResponse GetMyFeesEstimate(FeesEstimateByIdRequest[] feesEstimateRequest) =>
    Task.Run(() => GetMyFeesEstimateAsync(feesEstimateRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetMyFeesEstimatesResponse> GetMyFeesEstimateAsync(FeesEstimateByIdRequest[] feesEstimateRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ProductFeeApiUrls.GetMyFeesEstimate, RestSharp.Method.Post, postJsonObj: feesEstimateRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetMyFeesEstimatesResponse>(RateLimitType.ProductFees_GetMyFeesEstimate, cancellationToken);
            return response;
        }
    }
}
