using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaSmallandLight;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
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

        public async Task<SmallAndLightEnrollment> GetSmallAndLightEnrollmentBySellerSKUAsync(string sellerSKU)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.GetSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.Get, queryParameters: queryParameters);

            var response = await ExecuteRequestAsync<SmallAndLightEnrollment>(RateLimitType.FbaSmallandLight_GetSmallAndLightEnrollmentBySellerSKU);

            return response;

        }

        public SmallAndLightEnrollment PutSmallAndLightEnrollmentBySellerSKU(string sellerSKU) =>
            Task.Run(() => PutSmallAndLightEnrollmentBySellerSKUAsync(sellerSKU)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SmallAndLightEnrollment> PutSmallAndLightEnrollmentBySellerSKUAsync(string sellerSKU)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.PutSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.Put, queryParameters);

            var response = await ExecuteRequestAsync<SmallAndLightEnrollment>(RateLimitType.FbaSmallandLight_PutSmallAndLightEnrollmentBySellerSKU);

            return response;

        }

        public bool DeleteSmallAndLightEnrollmentBySellerSKU(string sellerSKU) =>
            Task.Run(() => DeleteSmallAndLightEnrollmentBySellerSKUAsync(sellerSKU)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<bool> DeleteSmallAndLightEnrollmentBySellerSKUAsync(string sellerSKU)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.DeleteSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.Delete, queryParameters);

            var response = await ExecuteRequestAsync<object>(RateLimitType.FbaSmallandLight_DeleteSmallAndLightEnrollmentBySellerSKU);

            return true;

        }

        public SmallAndLightEligibility GetSmallAndLightEligibilityBySellerSKU(string sellerSKU) =>
            Task.Run(() => GetSmallAndLightEligibilityBySellerSKUAsync(sellerSKU)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SmallAndLightEligibility> GetSmallAndLightEligibilityBySellerSKUAsync(string sellerSKU)
        {

            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.GetSmallAndLightEligibilityBySellerSKU(sellerSKU), RestSharp.Method.Get, queryParameters);

            var response = await ExecuteRequestAsync<SmallAndLightEligibility>(RateLimitType.FbaSmallandLight_GetSmallAndLightEligibilityBySellerSKU);

            return response;

        }

        public List<FeePreview> GetSmallAndLightFeePreview(SmallAndLightFeePreviewRequest smallAndLightFeePreviewRequest) =>
            Task.Run(() => GetSmallAndLightFeePreviewAsync(smallAndLightFeePreviewRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<FeePreview>> GetSmallAndLightFeePreviewAsync(SmallAndLightFeePreviewRequest smallAndLightFeePreviewRequest)
        {
            await CreateAuthorizedRequestAsync(FBASmallAndLightApiUrls.GetSmallAndLightFeePreview, RestSharp.Method.Post, postJsonObj: smallAndLightFeePreviewRequest);

            var response = await ExecuteRequestAsync<SmallAndLightFeePreviews>(RateLimitType.FbaSmallandLight_GetSmallAndLightFeePreview);
            if (response != null && response.Data != null)
                return response.Data;

            return null;

        }
    }
}
