using FikaAmazonAPI.AmazonSpApiSDK.Models.Shipping;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Utils;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class ShippingService : RequestService
    {
        public ShippingService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }



        public Shipment CreateShipment(CreateShipmentRequest parameterGetPricing) =>
            CreateShipmentAsync(parameterGetPricing).GetAwaiter().GetResult();
        public async Task<Shipment> CreateShipmentAsync(CreateShipmentRequest parameterGetPricing)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.CreateShipment, RestSharp.Method.POST, postJsonObj: parameterGetPricing);
            var response = await ExecuteRequestAsync<GetShipmentResponse>(RateLimitType.Shipping_CreateShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Shipment GetShipment(string shipmentId, ParameterBasedPII parameterBasedPII) =>
            GetShipmentAsync(shipmentId, parameterBasedPII).GetAwaiter().GetResult();
        public async Task<Shipment> GetShipmentAsync(string shipmentId, ParameterBasedPII parameterBasedPII)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetShipment(shipmentId), RestSharp.Method.GET, parameter: parameterBasedPII);
            var response = await ExecuteRequestAsync<GetShipmentResponse>(RateLimitType.Shipping_GetShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public bool CancelShipment(string shipmentId) =>
            CancelShipmentAsync(shipmentId).GetAwaiter().GetResult();
        public async Task<bool> CancelShipmentAsync(string shipmentId)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.CancelShipment(shipmentId), RestSharp.Method.POST);
            var response = await ExecuteRequestAsync<CancelShipmentResponse>(RateLimitType.Shipping_CancelShipment);
            if (response != null)
                return true;
            return false;
        }


        public PurchaseLabelsResult PurchaseLabels(string shipmentId, PurchaseLabelsRequest purchaseLabelsRequest) =>
            PurchaseLabelsAsync(shipmentId, purchaseLabelsRequest).GetAwaiter().GetResult();
        public async Task<PurchaseLabelsResult> PurchaseLabelsAsync(string shipmentId, PurchaseLabelsRequest purchaseLabelsRequest)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.PurchaseLabels(shipmentId), RestSharp.Method.POST, postJsonObj: purchaseLabelsRequest);
            var response = await ExecuteRequestAsync<PurchaseLabelsResponse>(RateLimitType.Shipping_PurchaseLabels);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public RetrieveShippingLabelResult RetrieveShippingLabel(string shipmentId, string trackingId, RetrieveShippingLabelRequest retrieveShippingLabelRequest) =>
            RetrieveShippingLabelAsync(shipmentId, trackingId, retrieveShippingLabelRequest).GetAwaiter().GetResult();
        public async Task<RetrieveShippingLabelResult> RetrieveShippingLabelAsync(string shipmentId, string trackingId, RetrieveShippingLabelRequest retrieveShippingLabelRequest)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.RetrieveShippingLabel(shipmentId, trackingId), RestSharp.Method.POST, postJsonObj: retrieveShippingLabelRequest);
            var response = await ExecuteRequestAsync<RetrieveShippingLabelResponse>(RateLimitType.Shipping_RetrieveShippingLabel);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public PurchaseShipmentResult PurchaseShipment(PurchaseShipmentRequest purchaseShipmentRequest) =>
            PurchaseShipmentAsync(purchaseShipmentRequest).GetAwaiter().GetResult();
        public async Task<PurchaseShipmentResult> PurchaseShipmentAsync(PurchaseShipmentRequest purchaseShipmentRequest)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.PurchaseShipment, RestSharp.Method.POST, postJsonObj: purchaseShipmentRequest);
            var response = await ExecuteRequestAsync<PurchaseShipmentResponse>(RateLimitType.Shipping_PurchaseShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetRatesResult GetRates(GetRatesRequest getRatesRequest) =>
            GetRatesAsync(getRatesRequest).GetAwaiter().GetResult();
        public async Task<GetRatesResult> GetRatesAsync(GetRatesRequest getRatesRequest)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetRates, RestSharp.Method.POST, postJsonObj: getRatesRequest);
            var response = await ExecuteRequestAsync<GetRatesResponse>(RateLimitType.Shipping_GetRates);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Account GetAccount() => GetAccountAsync().GetAwaiter().GetResult();
        public async Task<Account> GetAccountAsync()
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetAccount, RestSharp.Method.GET);
            var response = await ExecuteRequestAsync<GetAccountResponse>(RateLimitType.Shipping_GetAccount);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public TrackingInformation GetTrackingInformation(string trackingId) =>
            GetTrackingInformationAsync(trackingId).GetAwaiter().GetResult();
        public async Task<TrackingInformation> GetTrackingInformationAsync(string trackingId)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetTrackingInformation(trackingId), RestSharp.Method.GET);
            var response = await ExecuteRequestAsync<GetTrackingInformationResponse>(RateLimitType.Shipping_GetTrackingInformation);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
