using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentOutbound;
using FikaAmazonAPI.Parameter.FulFillmentInbound;
using FikaAmazonAPI.Parameter.FulFillmentOutbound;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class FulFillmentOutboundService : RequestService
    {
        public FulFillmentOutboundService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }
        public GetFulfillmentPreviewResult GetFulfillmentPreview(GetFulfillmentPreviewRequest getFulfillmentPreviewRequest)
        {
            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.GetFulfillmentPreview, RestSharp.Method.POST,postJsonObj: getFulfillmentPreviewRequest);

            var response = ExecuteRequest<GetFulfillmentPreviewResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public ListAllFulfillmentOrdersResult ListAllFulfillmentOrders(ParameterListAllFulfillmentOrders parameterListAllFulfillmentOrders)
        {
            var parameter = parameterListAllFulfillmentOrders.getParameters();
            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.ListAllFulfillmentOrders, RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<ListAllFulfillmentOrdersResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public bool CreateFulfillmentOrder(CreateFulfillmentOrderRequest createFulfillmentOrderRequest)
        {
            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.CreateFulfillmentOrder, RestSharp.Method.POST,postJsonObj: createFulfillmentOrderRequest);

            var response = ExecuteRequest<CreateFulfillmentOrderResponse>();
            if (response != null && response.Errors != null && response.Errors.Count>0)
                return false;
            return true;
        }
        public PackageTrackingDetails GetPackageTrackingDetails(int packageNumber)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("packageNumber", packageNumber.ToString()));

            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.GetPackageTrackingDetails, RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetPackageTrackingDetailsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public ListReturnReasonCodesResult ListReturnReasonCodes(ParameterListReturnReasonCodes parameterListReturnReasonCodes)
        {
            var parameter = parameterListReturnReasonCodes.getParameters();

            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.ListReturnReasonCodes, RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<ListReturnReasonCodesResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public CreateFulfillmentReturnResult ListReturnReasonCodes(string sellerFulfillmentOrderId, CreateFulfillmentReturnRequest createFulfillmentReturnRequest)
        {
            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.CreateFulfillmentReturn(sellerFulfillmentOrderId), RestSharp.Method.PUT, postJsonObj: createFulfillmentReturnRequest);

            var response = ExecuteRequest<CreateFulfillmentReturnResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetFulfillmentOrderResult GetFulfillmentOrder(string sellerFulfillmentOrderId)
        {
            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.GetFulfillmentOrder(sellerFulfillmentOrderId), RestSharp.Method.GET);

            var response = ExecuteRequest<GetFulfillmentOrderResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public bool UpdateFulfillmentOrder(string sellerFulfillmentOrderId, UpdateFulfillmentOrderRequest updateFulfillmentOrderRequest)
        {
            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.UpdateFulfillmentOrder(sellerFulfillmentOrderId), RestSharp.Method.PUT,postJsonObj: updateFulfillmentOrderRequest);

            var response = ExecuteRequest<UpdateFulfillmentOrderResponse>();
            if (response != null && response.Errors != null && response.Errors.Count>0)
                return false;
            return true;
        }
        public bool UpdateFulfillmentOrder(string sellerFulfillmentOrderId)
        {
            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.CancelFulfillmentOrder(sellerFulfillmentOrderId), RestSharp.Method.PUT);

            var response = ExecuteRequest<CancelFulfillmentOrderResponse>();
            if (response != null && response.Errors != null && response.Errors.Count>0)
                return false;
            return true;
        }
        public GetFeaturesResult GetFeatures()
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.GetFeatures, RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetFeaturesResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetFeatureInventoryResult GetFeatureInventory(string featureName,string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));
            if(string.IsNullOrEmpty(nextToken))
                queryParameters.Add(new KeyValuePair<string, string>("nextToken", nextToken));
            if (string.IsNullOrEmpty(featureName))
                queryParameters.Add(new KeyValuePair<string, string>("featureName", featureName));

            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.GetFeatureInventory(featureName), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetFeatureInventoryResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetFeatureSkuResult GetFeatureSKU(string featureName,string sellerSku, string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));
            if(string.IsNullOrEmpty(nextToken))
                queryParameters.Add(new KeyValuePair<string, string>("nextToken", nextToken));
            if (string.IsNullOrEmpty(featureName))
                queryParameters.Add(new KeyValuePair<string, string>("featureName", featureName));

            CreateAuthorizedRequest(FulFillmentOutboundApiUrls.GetFeatureSKU(featureName, sellerSku), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetFeatureSkuResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
