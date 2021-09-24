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
            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.GetInboundGuidance, RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<GetInboundGuidanceResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public CreateInboundShipmentPlanResult CreateInboundShipmentPlan(CreateInboundShipmentPlanRequest createInboundShipmentPlanRequest)
        {
            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.CreateInboundShipmentPlan, RestSharp.Method.POST,postJsonObj: createInboundShipmentPlanRequest);

            var response = ExecuteRequest<CreateInboundShipmentPlanResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public InboundShipmentResult UpdateInboundShipment(string shipmentId, InboundShipmentRequest inboundShipmentRequest)
        {
            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.UpdateInboundShipment(shipmentId), RestSharp.Method.PUT,postJsonObj: inboundShipmentRequest);

            var response = ExecuteRequest<InboundShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public InboundShipmentResult CreateInboundShipment(string shipmentId, InboundShipmentRequest inboundShipmentRequest)
        {
            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.CreateInboundShipment(shipmentId), RestSharp.Method.POST,postJsonObj: inboundShipmentRequest);

            var response = ExecuteRequest<InboundShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public InboundShipmentResult GetPreorderInfo(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.GetPreorderInfo(shipmentId), RestSharp.Method.GET, queryParameters);

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

            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.ConfirmPreorder(shipmentId), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<ConfirmPreorderResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetPrepInstructionsResult GetPrepInstructions(ParameterGetPrepInstructions parameterGetPrepInstructions)
        {
            var parameter = parameterGetPrepInstructions.getParameters();
            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.GetInboundGuidance, RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<GetPrepInstructionsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetTransportDetailsResult GetTransportDetails(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.GetTransportDetails(shipmentId), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetTransportDetailsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public CommonTransportResult PutTransportDetails(string shipmentId, PutTransportDetailsRequest putTransportDetailsRequest)
        {
            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.PutTransportDetails(shipmentId), RestSharp.Method.PUT, postJsonObj: putTransportDetailsRequest);

            var response = ExecuteRequest<PutTransportDetailsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public CommonTransportResult VoidTransport(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.VoidTransport(shipmentId), RestSharp.Method.POST, queryParameters);

            var response = ExecuteRequest<VoidTransportResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public CommonTransportResult EstimateTransport(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.EstimateTransport(shipmentId), RestSharp.Method.POST, queryParameters);

            var response = ExecuteRequest<EstimateTransportResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public CommonTransportResult ConfirmTransport(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.ConfirmTransport(shipmentId), RestSharp.Method.POST, queryParameters);

            var response = ExecuteRequest<ConfirmTransportResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetPrepInstructionsResult GetLabels(ParameterGetLabels parameterGetLabels)
        {
            var parameter = parameterGetLabels.getParameters();
            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.GetLabels(parameterGetLabels.shipmentId), RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<GetPrepInstructionsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public BillOfLadingDownloadURL GetBillOfLading(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.GetBillOfLading(shipmentId), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetBillOfLadingResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetShipmentsResult GetShipments(ParameterGetShipments parameterGetLabels)
        {
            var parameter = parameterGetLabels.getParameters();
            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.GetShipments, RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<GetShipmentsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetShipmentsResult GetShipmentItems(ParameterShipmentItems parameterShipmentItems)
        {
            var parameter = parameterShipmentItems.getParameters();
            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.GetShipmentItems, RestSharp.Method.GET, parameter);

            var response = ExecuteRequest<GetShipmentsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetShipmentItemsResult GetShipmentItemsByShipmentId(string shipmentId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlace.ID));

            CreateAuthorizedRequest(FulFillmentOutboundyApiUrls.GetShipmentItemsByShipmentId(shipmentId), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetShipmentItemsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
