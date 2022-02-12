using FikaAmazonAPI.AmazonSpApiSDK.Models.Shipping;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Utils;

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
            var response = ExecuteRequest<GetShipmentResponse>(RateLimitType.Shipping_CreateShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Shipment GetShipment(string shipmentId, ParameterBasedPII parameterBasedPII)
        {
            CreateAuthorizedRequest(ShippingApiUrls.GetShipment(shipmentId), RestSharp.Method.GET,parameter: parameterBasedPII);
            var response = ExecuteRequest<GetShipmentResponse>(RateLimitType.Shipping_GetShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public bool CancelShipment(string shipmentId)
        {
            CreateAuthorizedRequest(ShippingApiUrls.CancelShipment(shipmentId), RestSharp.Method.POST);
            var response = ExecuteRequest<CancelShipmentResponse>(RateLimitType.Shipping_CancelShipment);
            if (response != null )
                return true;
            return false;
        }


        public PurchaseLabelsResult PurchaseLabels(string shipmentId, PurchaseLabelsRequest purchaseLabelsRequest)
        {
            CreateAuthorizedRequest(ShippingApiUrls.PurchaseLabels(shipmentId), RestSharp.Method.POST, postJsonObj: purchaseLabelsRequest);
            var response = ExecuteRequest<PurchaseLabelsResponse>(RateLimitType.Shipping_PurchaseLabels);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        
        public RetrieveShippingLabelResult RetrieveShippingLabel(string shipmentId,string trackingId, RetrieveShippingLabelRequest retrieveShippingLabelRequest)
        {
            CreateAuthorizedRequest(ShippingApiUrls.RetrieveShippingLabel(shipmentId,trackingId), RestSharp.Method.POST, postJsonObj: retrieveShippingLabelRequest);
            var response = ExecuteRequest<RetrieveShippingLabelResponse>(RateLimitType.Shipping_RetrieveShippingLabel);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public PurchaseShipmentResult PurchaseShipment(PurchaseShipmentRequest purchaseShipmentRequest)
        {
            CreateAuthorizedRequest(ShippingApiUrls.PurchaseShipment, RestSharp.Method.POST, postJsonObj: purchaseShipmentRequest);
            var response = ExecuteRequest<PurchaseShipmentResponse>(RateLimitType.Shipping_PurchaseShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        
        public GetRatesResult GetRates(GetRatesRequest getRatesRequest)
        {
            CreateAuthorizedRequest(ShippingApiUrls.GetRates, RestSharp.Method.POST, postJsonObj: getRatesRequest);
            var response = ExecuteRequest<GetRatesResponse>(RateLimitType.Shipping_GetRates);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Account GetAccount()
        {
            CreateAuthorizedRequest(ShippingApiUrls.GetAccount, RestSharp.Method.GET);
            var response = ExecuteRequest<GetAccountResponse>(RateLimitType.Shipping_GetAccount);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public TrackingInformation GetTrackingInformation(string trackingId)
        {
            CreateAuthorizedRequest(ShippingApiUrls.GetTrackingInformation(trackingId), RestSharp.Method.GET);
            var response = ExecuteRequest<GetTrackingInformationResponse>(RateLimitType.Shipping_GetTrackingInformation);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
