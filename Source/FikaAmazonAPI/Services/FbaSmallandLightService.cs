using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaSmallandLight;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class FbaSmallandLightService : RequestService
    {

        public FbaSmallandLightService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public SmallAndLightEnrollment GetSmallAndLightEnrollmentBySellerSKU(string sellerSKU) =>
            Task.Run(() => GetSmallAndLightEnrollmentBySellerSKUAsync(sellerSKU)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SmallAndLightEnrollment> GetSmallAndLightEnrollmentBySellerSKUAsync(string sellerSKU, CancellationToken cancellationToken = default)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.GetSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.Get, queryParameters: queryParameters, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<SmallAndLightEnrollment>(RateLimitType.FbaSmallandLight_GetSmallAndLightEnrollmentBySellerSKU, cancellationToken);

            return response;

        }

        public SmallAndLightEnrollment PutSmallAndLightEnrollmentBySellerSKU(string sellerSKU) =>
            Task.Run(() => PutSmallAndLightEnrollmentBySellerSKUAsync(sellerSKU)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SmallAndLightEnrollment> PutSmallAndLightEnrollmentBySellerSKUAsync(string sellerSKU, CancellationToken cancellationToken = default)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.PutSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.Put, queryParameters, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<SmallAndLightEnrollment>(RateLimitType.FbaSmallandLight_PutSmallAndLightEnrollmentBySellerSKU, cancellationToken);

            return response;

        }

        public bool DeleteSmallAndLightEnrollmentBySellerSKU(string sellerSKU) =>
            Task.Run(() => DeleteSmallAndLightEnrollmentBySellerSKUAsync(sellerSKU)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<bool> DeleteSmallAndLightEnrollmentBySellerSKUAsync(string sellerSKU, CancellationToken cancellationToken = default)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.DeleteSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.Delete, queryParameters, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<object>(RateLimitType.FbaSmallandLight_DeleteSmallAndLightEnrollmentBySellerSKU, cancellationToken);

            return true;

        }

        public SmallAndLightEligibility GetSmallAndLightEligibilityBySellerSKU(string sellerSKU) =>
            Task.Run(() => GetSmallAndLightEligibilityBySellerSKUAsync(sellerSKU)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SmallAndLightEligibility> GetSmallAndLightEligibilityBySellerSKUAsync(string sellerSKU, CancellationToken cancellationToken = default)
        {

            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.GetSmallAndLightEligibilityBySellerSKU(sellerSKU), RestSharp.Method.Get, queryParameters, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<SmallAndLightEligibility>(RateLimitType.FbaSmallandLight_GetSmallAndLightEligibilityBySellerSKU, cancellationToken);

            return response;

        }

        public List<FeePreview> GetSmallAndLightFeePreview(SmallAndLightFeePreviewRequest smallAndLightFeePreviewRequest) =>
            Task.Run(() => GetSmallAndLightFeePreviewAsync(smallAndLightFeePreviewRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<FeePreview>> GetSmallAndLightFeePreviewAsync(SmallAndLightFeePreviewRequest smallAndLightFeePreviewRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.GetSmallAndLightFeePreview, RestSharp.Method.Post, postJsonObj: smallAndLightFeePreviewRequest, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<SmallAndLightFeePreviews>(RateLimitType.FbaSmallandLight_GetSmallAndLightFeePreview, cancellationToken);
            if (response != null && response.Data != null)
                return response.Data;

            return null;

        }
    }
}
