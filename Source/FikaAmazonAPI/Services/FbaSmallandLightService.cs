using AmazonSpApiSDK.Models.FbaSmallandLight;
using System;
using System.Collections.Generic;
using System.Text;

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
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", MarketPlace.ID));

            CreateAuthorizedRequest(FBASmallAndLightApiUrls.GetSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.GET);

            var response = ExecuteRequest<SmallAndLightEnrollment>();

            return response;

        }
        public SmallAndLightEnrollment PutSmallAndLightEnrollmentBySellerSKU(string sellerSKU)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", MarketPlace.ID));


            CreateAuthorizedRequest(FBASmallAndLightApiUrls.PutSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.PUT, queryParameters);

            var response = ExecuteRequest<SmallAndLightEnrollment>();

            return response;

        }
        public bool DeleteSmallAndLightEnrollmentBySellerSKU(string sellerSKU)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", MarketPlace.ID));


            CreateAuthorizedRequest(FBASmallAndLightApiUrls.DeleteSmallAndLightEnrollmentBySellerSKU(sellerSKU), RestSharp.Method.DELETE, queryParameters);

            var response = ExecuteRequest<object>();

            return true;

        }

        public SmallAndLightEligibility GetSmallAndLightEligibilityBySellerSKU(string sellerSKU)
        {

            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", MarketPlace.ID));


            CreateAuthorizedRequest(FBASmallAndLightApiUrls.GetSmallAndLightEligibilityBySellerSKU(sellerSKU), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<SmallAndLightEligibility>();

            return response;

        }
        public List<FeePreview> GetSmallAndLightFeePreview(SmallAndLightFeePreviewRequest smallAndLightFeePreviewRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", MarketPlace.ID));

            CreateAuthorizedRequest(FBASmallAndLightApiUrls.GetSmallAndLightFeePreview, RestSharp.Method.POST,postJsonObj: smallAndLightFeePreviewRequest);

            var response = ExecuteRequest<SmallAndLightFeePreviews>();
            if (response != null && response.Data != null)
                return response.Data;

            return null;

        }
    }
}
