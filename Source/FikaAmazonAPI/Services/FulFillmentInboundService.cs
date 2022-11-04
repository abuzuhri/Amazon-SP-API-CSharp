using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound;
using FikaAmazonAPI.Parameter.FulFillmentInbound;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class FulFillmentInboundService : RequestService
    {
        public FulFillmentInboundService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public GetInboundGuidanceResult GetInboundGuidance(ParameterGetInboundGuidance parameterGetInboundGuidance) =>
            Task.Run(() => GetInboundGuidanceAsync(parameterGetInboundGuidance)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetInboundGuidanceResult> GetInboundGuidanceAsync(ParameterGetInboundGuidance parameterGetInboundGuidance)
        {
            var parameter = parameterGetInboundGuidance.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetInboundGuidance, RestSharp.Method.Get, parameter);

            var response = await ExecuteRequestAsync<GetInboundGuidanceResponse>(RateLimitType.FulFillmentInbound_GetInboundGuidance);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public CreateInboundShipmentPlanResult CreateInboundShipmentPlan(CreateInboundShipmentPlanRequest createInboundShipmentPlanRequest) =>
            Task.Run(() => CreateInboundShipmentPlanAsync(createInboundShipmentPlanRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<CreateInboundShipmentPlanResult> CreateInboundShipmentPlanAsync(CreateInboundShipmentPlanRequest createInboundShipmentPlanRequest)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.CreateInboundShipmentPlan, RestSharp.Method.Post, postJsonObj: createInboundShipmentPlanRequest);

            var response = await ExecuteRequestAsync<CreateInboundShipmentPlanResponse>(RateLimitType.FulFillmentInbound_CreateInboundShipmentPlan);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public InboundShipmentResult UpdateInboundShipment(string shipmentId, InboundShipmentRequest inboundShipmentRequest) =>
            Task.Run(() => UpdateInboundShipmentAsync(shipmentId, inboundShipmentRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<InboundShipmentResult> UpdateInboundShipmentAsync(string shipmentId, InboundShipmentRequest inboundShipmentRequest)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateInboundShipment(shipmentId), RestSharp.Method.Put, postJsonObj: inboundShipmentRequest);

            var response = await ExecuteRequestAsync<InboundShipmentResponse>(RateLimitType.FulFillmentInbound_UpdateInboundShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public InboundShipmentResult CreateInboundShipment(string shipmentId, InboundShipmentRequest inboundShipmentRequest) =>
            Task.Run(() => CreateInboundShipmentAsync(shipmentId, inboundShipmentRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<InboundShipmentResult> CreateInboundShipmentAsync(string shipmentId, InboundShipmentRequest inboundShipmentRequest)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.CreateInboundShipment(shipmentId), RestSharp.Method.Post, postJsonObj: inboundShipmentRequest);

            var response = await ExecuteRequestAsync<InboundShipmentResponse>(RateLimitType.FulFillmentInbound_CreateInboundShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public InboundShipmentResult GetPreorderInfo(string shipmentId) =>
            Task.Run(() => GetPreorderInfoAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<InboundShipmentResult> GetPreorderInfoAsync(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetPreorderInfo(shipmentId), RestSharp.Method.Get, queryParameters);

            var response = await ExecuteRequestAsync<InboundShipmentResponse>(RateLimitType.FulFillmentInbound_GetPreorderInfo);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public ConfirmPreorderResult ConfirmPreorder(string shipmentId, DateTime NeedByDate) =>
            Task.Run(() => ConfirmPreorderAsync(shipmentId, NeedByDate)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ConfirmPreorderResult> ConfirmPreorderAsync(string shipmentId, DateTime NeedByDate)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));
            queryParameters.Add(new KeyValuePair<string, string>("NeedByDate", NeedByDate.ToString("YYYY-MM-DD")));

            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmPreorder(shipmentId), RestSharp.Method.Get, queryParameters);

            var response = await ExecuteRequestAsync<ConfirmPreorderResponse>(RateLimitType.FulFillmentInbound_ConfirmPreorder);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetPrepInstructionsResult GetPrepInstructions(ParameterGetPrepInstructions parameterGetPrepInstructions) =>
            Task.Run(() => GetPrepInstructionsAsync(parameterGetPrepInstructions)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetPrepInstructionsResult> GetPrepInstructionsAsync(ParameterGetPrepInstructions parameterGetPrepInstructions)
        {
            var parameter = parameterGetPrepInstructions.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetPrepInstructions, RestSharp.Method.Get, parameter);

            var response = await ExecuteRequestAsync<GetPrepInstructionsResponse>(RateLimitType.FulFillmentInbound_GetPrepInstructions);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetTransportDetailsResult GetTransportDetails(string shipmentId) =>
            Task.Run(() => GetTransportDetailsAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetTransportDetailsResult> GetTransportDetailsAsync(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetTransportDetails(shipmentId), RestSharp.Method.Get, queryParameters);

            var response = await ExecuteRequestAsync<GetTransportDetailsResponse>(RateLimitType.FulFillmentInbound_GetTransportDetails);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public CommonTransportResult PutTransportDetails(string shipmentId, PutTransportDetailsRequest putTransportDetailsRequest) =>
            Task.Run(() => PutTransportDetailsAsync(shipmentId, putTransportDetailsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CommonTransportResult> PutTransportDetailsAsync(string shipmentId, PutTransportDetailsRequest putTransportDetailsRequest)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.PutTransportDetails(shipmentId), RestSharp.Method.Put, postJsonObj: putTransportDetailsRequest);

            var response = await ExecuteRequestAsync<PutTransportDetailsResponse>(RateLimitType.FulFillmentInbound_PutTransportDetails);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public CommonTransportResult VoidTransport(string shipmentId) =>
            Task.Run(() => VoidTransportAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CommonTransportResult> VoidTransportAsync(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.VoidTransport(shipmentId), RestSharp.Method.Post, queryParameters);

            var response = await ExecuteRequestAsync<VoidTransportResponse>(RateLimitType.FulFillmentInbound_VoidTransport);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public CommonTransportResult EstimateTransport(string shipmentId) =>
            Task.Run(() => EstimateTransportAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CommonTransportResult> EstimateTransportAsync(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.EstimateTransport(shipmentId), RestSharp.Method.Post, queryParameters);

            var response = await ExecuteRequestAsync<EstimateTransportResponse>(RateLimitType.FulFillmentInbound_EstimateTransport);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public CommonTransportResult ConfirmTransport(string shipmentId) =>
            Task.Run(() => ConfirmTransportAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CommonTransportResult> ConfirmTransportAsync(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmTransport(shipmentId), RestSharp.Method.Post, queryParameters);

            var response = await ExecuteRequestAsync<ConfirmTransportResponse>(RateLimitType.FulFillmentInbound_ConfirmTransport);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public LabelDownloadURL GetLabels(ParameterGetLabels parameterGetLabels) =>
            Task.Run(() => GetLabelsAsync(parameterGetLabels)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<LabelDownloadURL> GetLabelsAsync(ParameterGetLabels parameterGetLabels)
        {
            var parameter = parameterGetLabels.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetLabels(parameterGetLabels.shipmentId), RestSharp.Method.Get, parameter);

            var response = await ExecuteRequestAsync<GetLabelsResponse>(RateLimitType.FulFillmentInbound_GetLabels);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public BillOfLadingDownloadURL GetBillOfLading(string shipmentId) =>
            Task.Run(() => GetBillOfLadingAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<BillOfLadingDownloadURL> GetBillOfLadingAsync(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetBillOfLading(shipmentId), RestSharp.Method.Get, queryParameters);

            var response = await ExecuteRequestAsync<GetBillOfLadingResponse>(RateLimitType.FulFillmentInbound_GetBillOfLading);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetShipmentsResult GetShipments(ParameterGetShipments parameterGetLabels) =>
            Task.Run(() => GetShipmentsAsync(parameterGetLabels)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetShipmentsResult> GetShipmentsAsync(ParameterGetShipments parameterGetLabels)
        {
            var parameter = parameterGetLabels.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetShipments, RestSharp.Method.Get, parameter);

            var response = await ExecuteRequestAsync<GetShipmentsResponse>(RateLimitType.FulFillmentInbound_GetShipments);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetShipmentItemsResult GetShipmentItemsByShipmentId(string shipmentId) =>
            Task.Run(() => GetShipmentItemsByShipmentIdAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetShipmentItemsResult> GetShipmentItemsByShipmentIdAsync(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetShipmentItemsByShipmentId(shipmentId), RestSharp.Method.Get, queryParameters);

            var response = await ExecuteRequestAsync<GetShipmentItemsResponse>(RateLimitType.FulFillmentInbound_GetShipmentItemsByShipmentId);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public List<InboundShipmentItem> GetShipmentItems(ParameterGetShipmentItems parameterShipmentItems) =>
            Task.Run(() => GetShipmentItemsAsync(parameterShipmentItems)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<InboundShipmentItem>> GetShipmentItemsAsync(ParameterGetShipmentItems parameterShipmentItems)
        {
            var shipmentItemList = new List<InboundShipmentItem>();

            var parameter = parameterShipmentItems.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetShipmentItems, RestSharp.Method.Get, parameter);

            var response = await ExecuteRequestAsync<GetShipmentItemsResponse>(RateLimitType.FulFillmentInbound_GetShipmentItems);

            var nextToken = response.Payload?.NextToken;
            shipmentItemList = response.Payload?.ItemData;
            int PageCount = 1;
            while (!string.IsNullOrEmpty(nextToken))
            {
                var orderPayload = await GetShipmentItemsByNextTokenAsync(nextToken, parameterShipmentItems);
                shipmentItemList.AddRange(orderPayload.ItemData);
                nextToken = orderPayload.NextToken;

                if (parameterShipmentItems.MaxNumberOfPages.HasValue)
                {
                    PageCount++;
                    if (PageCount >= parameterShipmentItems.MaxNumberOfPages.Value)
                        break;
                }
            }

            return shipmentItemList;
        }

        public async Task<GetShipmentItemsResult> GetShipmentItemsByNextTokenAsync(string nextToken, ParameterGetShipmentItems parameterShipmentItems)
        {
            parameterShipmentItems.NextToken = nextToken;
            parameterShipmentItems.QueryType = Constants.QueryType.NEXT_TOKEN;
            parameterShipmentItems.LastUpdatedBefore = null;
            parameterShipmentItems.LastUpdatedAfter = null;

            var parameter = parameterShipmentItems.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetShipmentItems, RestSharp.Method.Get, parameter);

            var response = await ExecuteRequestAsync<GetShipmentItemsResponse>(RateLimitType.FulFillmentInbound_GetShipmentItems);

            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
