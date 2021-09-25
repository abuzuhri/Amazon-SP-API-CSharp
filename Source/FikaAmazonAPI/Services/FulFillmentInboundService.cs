using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound;
using FikaAmazonAPI.Parameter.FulFillmentInbound;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class FulFillmentInboundService : RequestService
    {
        public FulFillmentInboundService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public GetInboundGuidanceResult GetInboundGuidance(ParameterGetInboundGuidance parameterGetInboundGuidance)
        {
            var parameter = parameterGetInboundGuidance.getParameters();
            CreateAuthorizedRequest(FulFillmentInboundApiUrls.GetInboundGuidance, RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<GetInboundGuidanceResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public CreateInboundShipmentPlanResult CreateInboundShipmentPlan(CreateInboundShipmentPlanRequest createInboundShipmentPlanRequest)
        {
            CreateAuthorizedRequest(FulFillmentInboundApiUrls.CreateInboundShipmentPlan, RestSharp.Method.POST,postJsonObj: createInboundShipmentPlanRequest);

            var response = ExecuteRequest<CreateInboundShipmentPlanResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public InboundShipmentResult UpdateInboundShipment(string shipmentId, InboundShipmentRequest inboundShipmentRequest)
        {
            CreateAuthorizedRequest(FulFillmentInboundApiUrls.UpdateInboundShipment(shipmentId), RestSharp.Method.PUT,postJsonObj: inboundShipmentRequest);

            var response = ExecuteRequest<InboundShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public InboundShipmentResult CreateInboundShipment(string shipmentId, InboundShipmentRequest inboundShipmentRequest)
        {
            CreateAuthorizedRequest(FulFillmentInboundApiUrls.CreateInboundShipment(shipmentId), RestSharp.Method.POST,postJsonObj: inboundShipmentRequest);

            var response = ExecuteRequest<InboundShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public InboundShipmentResult GetPreorderInfo(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentInboundApiUrls.GetPreorderInfo(shipmentId), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<InboundShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public ConfirmPreorderResult ConfirmPreorder(string shipmentId,DateTime NeedByDate)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));
            queryParameters.Add(new KeyValuePair<string, string>("NeedByDate", NeedByDate.ToString("YYYY-MM-DD")));

            CreateAuthorizedRequest(FulFillmentInboundApiUrls.ConfirmPreorder(shipmentId), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<ConfirmPreorderResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetPrepInstructionsResult GetPrepInstructions(ParameterGetPrepInstructions parameterGetPrepInstructions)
        {
            var parameter = parameterGetPrepInstructions.getParameters();
            CreateAuthorizedRequest(FulFillmentInboundApiUrls.GetInboundGuidance, RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<GetPrepInstructionsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetTransportDetailsResult GetTransportDetails(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentInboundApiUrls.GetTransportDetails(shipmentId), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetTransportDetailsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public CommonTransportResult PutTransportDetails(string shipmentId, PutTransportDetailsRequest putTransportDetailsRequest)
        {
            CreateAuthorizedRequest(FulFillmentInboundApiUrls.PutTransportDetails(shipmentId), RestSharp.Method.PUT, postJsonObj: putTransportDetailsRequest);

            var response = ExecuteRequest<PutTransportDetailsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public CommonTransportResult VoidTransport(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentInboundApiUrls.VoidTransport(shipmentId), RestSharp.Method.POST, queryParameters);

            var response = ExecuteRequest<VoidTransportResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public CommonTransportResult EstimateTransport(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentInboundApiUrls.EstimateTransport(shipmentId), RestSharp.Method.POST, queryParameters);

            var response = ExecuteRequest<EstimateTransportResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public CommonTransportResult ConfirmTransport(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentInboundApiUrls.ConfirmTransport(shipmentId), RestSharp.Method.POST, queryParameters);

            var response = ExecuteRequest<ConfirmTransportResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetPrepInstructionsResult GetLabels(ParameterGetLabels parameterGetLabels)
        {
            var parameter = parameterGetLabels.getParameters();
            CreateAuthorizedRequest(FulFillmentInboundApiUrls.GetLabels(parameterGetLabels.shipmentId), RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<GetPrepInstructionsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public BillOfLadingDownloadURL GetBillOfLading(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentInboundApiUrls.GetBillOfLading(shipmentId), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetBillOfLadingResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetShipmentsResult GetShipments(ParameterGetShipments parameterGetLabels)
        {
            var parameter = parameterGetLabels.getParameters();
            CreateAuthorizedRequest(FulFillmentInboundApiUrls.GetShipments, RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<GetShipmentsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetShipmentsResult GetShipmentItems(ParameterListReturnReasonCodes parameterShipmentItems)
        {
            var parameter = parameterShipmentItems.getParameters();
            CreateAuthorizedRequest(FulFillmentInboundApiUrls.GetShipmentItems, RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<GetShipmentsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetShipmentItemsResult GetShipmentItemsByShipmentId(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentInboundApiUrls.GetShipmentItemsByShipmentId(shipmentId), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetShipmentItemsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
