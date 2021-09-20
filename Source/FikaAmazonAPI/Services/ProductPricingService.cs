using FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing;
using FikaAmazonAPI.Parameter.ProductPricing;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class ProductPricingService : RequestService
    {
        public ProductPricingService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public IList<Price> GetPricing(ParameterGetPricing parameterGetPricing)
        {
            var param = parameterGetPricing.getParameters();

            CreateAuthorizedRequest(ProductPricingApiUrls.GetPricing, RestSharp.Method.GET, param);
            var response = ExecuteRequest<GetPricingResponse>();
            if (response != null && response.Payload!=null)
                return response.Payload;
            return null;
        }

        public IList<Price> GetCompetitivePricing(ParameterGetCompetitivePricing parameterGetCompetitivePricing)
        {
            var param = parameterGetCompetitivePricing.getParameters();

            CreateAuthorizedRequest(ProductPricingApiUrls.GetCompetitivePricing, RestSharp.Method.GET, param);
            var response = ExecuteRequest<GetPricingResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetOffersResult GetListingOffers(ParameterGetListingOffers parameterGetListingOffers)
        {
            var param = parameterGetListingOffers.getParameters();

            CreateAuthorizedRequest(ProductPricingApiUrls.GetListingOffers(parameterGetListingOffers.SellerSKU), RestSharp.Method.GET, param);
            var response = ExecuteRequest<GetOffersResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetOffersResult GetItemOffers(ParameterGetItemOffers parameterGetItemOffers)
        {
            var param = parameterGetItemOffers.getParameters();

            CreateAuthorizedRequest(ProductPricingApiUrls.GetItemOffers(parameterGetItemOffers.Asin), RestSharp.Method.GET, param);
            var response = ExecuteRequest<GetOffersResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

    }
}
