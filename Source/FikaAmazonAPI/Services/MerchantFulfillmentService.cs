using FikaAmazonAPI.AmazonSpApiSDK.Models.MerchantFulfillment;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class MerchantFulfillmentService : RequestService
    {

        public MerchantFulfillmentService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        
        public GetEligibleShipmentServicesResult GetEligibleShipmentServicesOld(GetEligibleShipmentServicesRequest getEligibleShipmentServicesRequest)
        {

            CreateAuthorizedRequest(MerchantFulfillmentApiUrls.GetEligibleShipmentServicesOld, RestSharp.Method.POST,postJsonObj: getEligibleShipmentServicesRequest);

            var response = ExecuteRequest<GetEligibleShipmentServicesResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetEligibleShipmentServicesResult GetEligibleShipmentServices(GetEligibleShipmentServicesRequest getEligibleShipmentServicesRequest)
        {
            CreateAuthorizedRequest(MerchantFulfillmentApiUrls.GetEligibleShipmentServices, RestSharp.Method.POST, postJsonObj: getEligibleShipmentServicesRequest);

            var response = ExecuteRequest<GetEligibleShipmentServicesResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Shipment GetShipment(string shipmentId)
        {
            CreateAuthorizedRequest(MerchantFulfillmentApiUrls.GetShipment(shipmentId), RestSharp.Method.GET);

            var response = ExecuteRequest<GetShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public Shipment CancelShipment(string shipmentId)
        {
            CreateAuthorizedRequest(MerchantFulfillmentApiUrls.GetShipment(shipmentId), RestSharp.Method.DELETE);

            var response = ExecuteRequest<GetShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Shipment CancelShipmentOld(string shipmentId)
        {
            CreateAuthorizedRequest(MerchantFulfillmentApiUrls.CancelShipmentOld(shipmentId), RestSharp.Method.PUT);

            var response = ExecuteRequest<GetShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Shipment CreateShipment(CreateShipmentRequest createShipmentRequest)
        {
            CreateAuthorizedRequest(MerchantFulfillmentApiUrls.CreateShipment, RestSharp.Method.POST,postJsonObj: createShipmentRequest);

            var response = ExecuteRequest<CreateShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetAdditionalSellerInputsResult GetAdditionalSellerInputsOld(GetAdditionalSellerInputsRequest getAdditionalSellerInputsRequest)
        {
            CreateAuthorizedRequest(MerchantFulfillmentApiUrls.GetAdditionalSellerInputsOld, RestSharp.Method.POST,postJsonObj: getAdditionalSellerInputsRequest);

            var response = ExecuteRequest<GetAdditionalSellerInputsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public GetAdditionalSellerInputsResult GetAdditionalSellerInputs(GetAdditionalSellerInputsRequest getAdditionalSellerInputsRequest)
        {
            CreateAuthorizedRequest(MerchantFulfillmentApiUrls.GetAdditionalSellerInputs, RestSharp.Method.POST, postJsonObj: getAdditionalSellerInputsRequest);

            var response = ExecuteRequest<GetAdditionalSellerInputsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
