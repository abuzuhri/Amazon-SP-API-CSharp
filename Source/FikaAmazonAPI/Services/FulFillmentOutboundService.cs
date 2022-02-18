using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentOutbound;
using FikaAmazonAPI.Parameter.FulFillmentInbound;
using FikaAmazonAPI.Parameter.FulFillmentOutbound;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class FulFillmentOutboundService : RequestService
    {
        public FulFillmentOutboundService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }
        public GetFulfillmentPreviewResult GetFulfillmentPreview(GetFulfillmentPreviewRequest getFulfillmentPreviewRequest) =>
             GetFulfillmentPreviewAsync(getFulfillmentPreviewRequest).GetAwaiter().GetResult();
        public async Task<GetFulfillmentPreviewResult> GetFulfillmentPreviewAsync(GetFulfillmentPreviewRequest getFulfillmentPreviewRequest)
        {
            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.GetFulfillmentPreview, RestSharp.Method.POST, postJsonObj: getFulfillmentPreviewRequest);

            var response = await ExecuteRequestAsync<GetFulfillmentPreviewResponse>(RateLimitType.FulFillmentOutbound_GetFulfillmentPreview);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public ListAllFulfillmentOrdersResult ListAllFulfillmentOrders(ParameterListAllFulfillmentOrders parameterListAllFulfillmentOrders) =>
            ListAllFulfillmentOrdersAsync(parameterListAllFulfillmentOrders).GetAwaiter().GetResult();
        public async Task<ListAllFulfillmentOrdersResult> ListAllFulfillmentOrdersAsync(ParameterListAllFulfillmentOrders parameterListAllFulfillmentOrders)
        {
            var parameter = parameterListAllFulfillmentOrders.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.ListAllFulfillmentOrders, RestSharp.Method.GET, parameter);

            var response = await ExecuteRequestAsync<ListAllFulfillmentOrdersResponse>(RateLimitType.FulFillmentOutbound_ListAllFulfillmentOrders);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public bool CreateFulfillmentOrder(CreateFulfillmentOrderRequest createFulfillmentOrderRequest) =>
            CreateFulfillmentOrderAsync(createFulfillmentOrderRequest).GetAwaiter().GetResult();

        public async Task<bool> CreateFulfillmentOrderAsync(CreateFulfillmentOrderRequest createFulfillmentOrderRequest)
        {
            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.CreateFulfillmentOrder, RestSharp.Method.POST, postJsonObj: createFulfillmentOrderRequest);

            var response = await ExecuteRequestAsync<CreateFulfillmentOrderResponse>(RateLimitType.FulFillmentOutbound_CreateFulfillmentOrder);
            if (response != null && response.Errors != null && response.Errors.Count > 0)
                return false;
            return true;
        }

        public PackageTrackingDetails GetPackageTrackingDetails(int packageNumber) =>
            GetPackageTrackingDetailsAsync(packageNumber).GetAwaiter().GetResult();

        public async Task<PackageTrackingDetails> GetPackageTrackingDetailsAsync(int packageNumber)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("packageNumber", packageNumber.ToString()));

            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.GetPackageTrackingDetails, RestSharp.Method.GET, queryParameters);

            var response = await ExecuteRequestAsync<GetPackageTrackingDetailsResponse>(RateLimitType.FulFillmentOutbound_GetPackageTrackingDetails);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public ListReturnReasonCodesResult ListReturnReasonCodes(ParameterListReturnReasonCodes parameterListReturnReasonCodes) =>
            ListReturnReasonCodesAsync(parameterListReturnReasonCodes).GetAwaiter().GetResult();

        public async Task<ListReturnReasonCodesResult> ListReturnReasonCodesAsync(ParameterListReturnReasonCodes parameterListReturnReasonCodes)
        {
            var parameter = parameterListReturnReasonCodes.getParameters();

            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.ListReturnReasonCodes, RestSharp.Method.GET, parameter);

            var response = await ExecuteRequestAsync<ListReturnReasonCodesResponse>(RateLimitType.FulFillmentOutbound_ListReturnReasonCodes);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public CreateFulfillmentReturnResult ListReturnReasonCodes(string sellerFulfillmentOrderId, CreateFulfillmentReturnRequest createFulfillmentReturnRequest) =>
            ListReturnReasonCodesAsync(sellerFulfillmentOrderId, createFulfillmentReturnRequest).GetAwaiter().GetResult();

        public async Task<CreateFulfillmentReturnResult> ListReturnReasonCodesAsync(string sellerFulfillmentOrderId, CreateFulfillmentReturnRequest createFulfillmentReturnRequest)
        {
            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.CreateFulfillmentReturn(sellerFulfillmentOrderId), RestSharp.Method.PUT, postJsonObj: createFulfillmentReturnRequest);

            var response = await ExecuteRequestAsync<CreateFulfillmentReturnResponse>(RateLimitType.FulFillmentOutbound_ListReturnReasonCodes);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetFulfillmentOrderResult GetFulfillmentOrder(string sellerFulfillmentOrderId) =>
            GetFulfillmentOrderAsync(sellerFulfillmentOrderId).GetAwaiter().GetResult();

        public async Task<GetFulfillmentOrderResult> GetFulfillmentOrderAsync(string sellerFulfillmentOrderId)
        {
            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.GetFulfillmentOrder(sellerFulfillmentOrderId), RestSharp.Method.GET);

            var response = await ExecuteRequestAsync<GetFulfillmentOrderResponse>(RateLimitType.FulFillmentOutbound_GetFulfillmentOrder);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public bool UpdateFulfillmentOrder(string sellerFulfillmentOrderId, UpdateFulfillmentOrderRequest updateFulfillmentOrderRequest) =>
            UpdateFulfillmentOrderAsync(sellerFulfillmentOrderId, updateFulfillmentOrderRequest).GetAwaiter().GetResult();
        public async Task<bool> UpdateFulfillmentOrderAsync(string sellerFulfillmentOrderId, UpdateFulfillmentOrderRequest updateFulfillmentOrderRequest)
        {
            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.UpdateFulfillmentOrder(sellerFulfillmentOrderId), RestSharp.Method.PUT, postJsonObj: updateFulfillmentOrderRequest);

            var response = await ExecuteRequestAsync<UpdateFulfillmentOrderResponse>(RateLimitType.FulFillmentOutbound_UpdateFulfillmentOrder);
            if (response != null && response.Errors != null && response.Errors.Count > 0)
                return false;
            return true;
        }

        public bool UpdateFulfillmentOrder(string sellerFulfillmentOrderId) =>
            UpdateFulfillmentOrderAsync(sellerFulfillmentOrderId).GetAwaiter().GetResult();
        public async Task<bool> UpdateFulfillmentOrderAsync(string sellerFulfillmentOrderId)
        {
            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.CancelFulfillmentOrder(sellerFulfillmentOrderId), RestSharp.Method.PUT);

            var response = await ExecuteRequestAsync<CancelFulfillmentOrderResponse>(RateLimitType.FulFillmentOutbound_UpdateFulfillmentOrder);
            if (response != null && response.Errors != null && response.Errors.Count > 0)
                return false;
            return true;
        }

        public GetFeaturesResult GetFeatures() => GetFeaturesAsync().GetAwaiter().GetResult();
        public async Task<GetFeaturesResult> GetFeaturesAsync()
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.GetFeatures, RestSharp.Method.GET, queryParameters);

            var response = await ExecuteRequestAsync<GetFeaturesResponse>(RateLimitType.FulFillmentOutbound_GetFeatures);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetFeatureInventoryResult GetFeatureInventory(string featureName, string nextToken) =>
            GetFeatureInventoryAsync(featureName, nextToken).GetAwaiter().GetResult();
        public async Task<GetFeatureInventoryResult> GetFeatureInventoryAsync(string featureName, string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));
            if (string.IsNullOrEmpty(nextToken))
                queryParameters.Add(new KeyValuePair<string, string>("nextToken", nextToken));
            if (string.IsNullOrEmpty(featureName))
                queryParameters.Add(new KeyValuePair<string, string>("featureName", featureName));

            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.GetFeatureInventory(featureName), RestSharp.Method.GET, queryParameters);

            var response = await ExecuteRequestAsync<GetFeatureInventoryResponse>(RateLimitType.FulFillmentOutbound_GetFeatureInventory);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetFeatureSkuResult GetFeatureSKU(string featureName, string sellerSku, string nextToken) =>
            GetFeatureSKUAsync(featureName, sellerSku, nextToken).GetAwaiter().GetResult();
        public async Task<GetFeatureSkuResult> GetFeatureSKUAsync(string featureName, string sellerSku, string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));
            if (string.IsNullOrEmpty(nextToken))
                queryParameters.Add(new KeyValuePair<string, string>("nextToken", nextToken));
            if (string.IsNullOrEmpty(featureName))
                queryParameters.Add(new KeyValuePair<string, string>("featureName", featureName));

            await CreateAuthorizedRequestAsync(FulFillmentOutboundApiUrls.GetFeatureSKU(featureName, sellerSku), RestSharp.Method.GET, queryParameters);

            var response = await ExecuteRequestAsync<GetFeatureSkuResponse>(RateLimitType.FulFillmentOutbound_GetFeatureSKU);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
