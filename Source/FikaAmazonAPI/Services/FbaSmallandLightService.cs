using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaSmallandLight;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;

namespace FikaAmazonAPI.Services
{
    public class FbaSmallandLightService : RequestService
    {

        public FbaSmallandLightService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public SmallAndLightEnrollment GetSmallAndLightEnrollmentBySellerSKU(string sellerSKU)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(FBASmallAndLightApiUrls.GetSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.GET);

            var response = ExecuteRequest<SmallAndLightEnrollment>(RateLimitType.FbaSmallandLight_GetSmallAndLightEnrollmentBySellerSKU);

            return response;

        }
        public SmallAndLightEnrollment PutSmallAndLightEnrollmentBySellerSKU(string sellerSKU)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            CreateAuthorizedRequest(FBASmallAndLightApiUrls.PutSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.PUT, queryParameters);

            var response = ExecuteRequest<SmallAndLightEnrollment>(RateLimitType.FbaSmallandLight_PutSmallAndLightEnrollmentBySellerSKU);

            return response;

        }
        public bool DeleteSmallAndLightEnrollmentBySellerSKU(string sellerSKU)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            CreateAuthorizedRequest(FBASmallAndLightApiUrls.DeleteSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.DELETE, queryParameters);

            var response = ExecuteRequest<object>(RateLimitType.FbaSmallandLight_DeleteSmallAndLightEnrollmentBySellerSKU);

            return true;

        }

        public SmallAndLightEligibility GetSmallAndLightEligibilityBySellerSKU(string sellerSKU)
        {

            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));


            CreateAuthorizedRequest(FBASmallAndLightApiUrls.GetSmallAndLightEligibilityBySellerSKU(sellerSKU), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<SmallAndLightEligibility>(RateLimitType.FbaSmallandLight_GetSmallAndLightEligibilityBySellerSKU);

            return response;

        }
        public List<FeePreview> GetSmallAndLightFeePreview(SmallAndLightFeePreviewRequest smallAndLightFeePreviewRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(FBASmallAndLightApiUrls.GetSmallAndLightFeePreview, RestSharp.Method.POST,postJsonObj: smallAndLightFeePreviewRequest);

            var response = ExecuteRequest<SmallAndLightFeePreviews>(RateLimitType.FbaSmallandLight_GetSmallAndLightFeePreview);
            if (response != null && response.Data != null)
                return response.Data;

            return null;

        }
    }
}
