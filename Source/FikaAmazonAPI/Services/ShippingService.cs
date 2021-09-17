using AmazonSpApiSDK.Models.Shipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class ShippingService : RequestService
    {
        public ShippingService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }



        public Shipment CreateShipment(CreateShipmentRequest parameterGetPricing)
        {
            CreateAuthorizedRequest(ShippingApiUrls.CreateShipment, RestSharp.Method.POST,postJsonObj: parameterGetPricing);
            var response = ExecuteRequest<GetShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Shipment GetShipment(string shipmentId)
        {
            CreateAuthorizedRequest(ShippingApiUrls.GetShipment(shipmentId), RestSharp.Method.GET);
            var response = ExecuteRequest<GetShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public bool CancelShipment(string shipmentId)
        {
            CreateAuthorizedRequest(ShippingApiUrls.CancelShipment(shipmentId), RestSharp.Method.POST);
            var response = ExecuteRequest<CancelShipmentResponse>();
            if (response != null )
                return true;
            return false;
        }


        public PurchaseLabelsResult PurchaseLabels(string shipmentId, PurchaseLabelsRequest purchaseLabelsRequest)
        {
            CreateAuthorizedRequest(ShippingApiUrls.PurchaseLabels(shipmentId), RestSharp.Method.POST, postJsonObj: purchaseLabelsRequest);
            var response = ExecuteRequest<PurchaseLabelsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        
        public RetrieveShippingLabelResult RetrieveShippingLabel(string shipmentId,string trackingId, RetrieveShippingLabelRequest retrieveShippingLabelRequest)
        {
            CreateAuthorizedRequest(ShippingApiUrls.RetrieveShippingLabel(shipmentId,trackingId), RestSharp.Method.POST, postJsonObj: retrieveShippingLabelRequest);
            var response = ExecuteRequest<RetrieveShippingLabelResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public PurchaseShipmentResult PurchaseShipment(PurchaseShipmentRequest purchaseShipmentRequest)
        {
            CreateAuthorizedRequest(ShippingApiUrls.PurchaseShipment, RestSharp.Method.POST, postJsonObj: purchaseShipmentRequest);
            var response = ExecuteRequest<PurchaseShipmentResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        
        public GetRatesResult GetRates(GetRatesRequest getRatesRequest)
        {
            CreateAuthorizedRequest(ShippingApiUrls.GetRates, RestSharp.Method.POST, postJsonObj: getRatesRequest);
            var response = ExecuteRequest<GetRatesResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Account GetAccount()
        {
            CreateAuthorizedRequest(ShippingApiUrls.GetAccount, RestSharp.Method.GET);
            var response = ExecuteRequest<GetAccountResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public TrackingInformation GetTrackingInformation(string trackingId)
        {
            CreateAuthorizedRequest(ShippingApiUrls.GetTrackingInformation(trackingId), RestSharp.Method.GET);
            var response = ExecuteRequest<GetTrackingInformationResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
