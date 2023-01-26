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
            Task.Run(() => CreateShipmentAsync(parameterGetPricing)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Shipment> CreateShipmentAsync(CreateShipmentRequest parameterGetPricing)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.CreateShipment, RestSharp.Method.Post, postJsonObj: parameterGetPricing);
            var response = await ExecuteRequestAsync<GetShipmentResponse>(RateLimitType.Shipping_CreateShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Shipment GetShipment(string shipmentId, ParameterBasedPII parameterBasedPII) =>
            Task.Run(() => GetShipmentAsync(shipmentId, parameterBasedPII)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Shipment> GetShipmentAsync(string shipmentId, ParameterBasedPII parameterBasedPII)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetShipment(shipmentId), RestSharp.Method.Get, parameter: parameterBasedPII);
            var response = await ExecuteRequestAsync<GetShipmentResponse>(RateLimitType.Shipping_GetShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public bool CancelShipment(string shipmentId) =>
            Task.Run(() => CancelShipmentAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CancelShipmentAsync(string shipmentId)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.CancelShipment(shipmentId), RestSharp.Method.Post);
            var response = await ExecuteRequestAsync<CancelShipmentResponse>(RateLimitType.Shipping_CancelShipment);
            if (response != null)
                return true;
            return false;
        }


        public PurchaseLabelsResult PurchaseLabels(string shipmentId, PurchaseLabelsRequest purchaseLabelsRequest) =>
            Task.Run(() => PurchaseLabelsAsync(shipmentId, purchaseLabelsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<PurchaseLabelsResult> PurchaseLabelsAsync(string shipmentId, PurchaseLabelsRequest purchaseLabelsRequest)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.PurchaseLabels(shipmentId), RestSharp.Method.Post, postJsonObj: purchaseLabelsRequest);
            var response = await ExecuteRequestAsync<PurchaseLabelsResponse>(RateLimitType.Shipping_PurchaseLabels);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public RetrieveShippingLabelResult RetrieveShippingLabel(string shipmentId, string trackingId, RetrieveShippingLabelRequest retrieveShippingLabelRequest) =>
            Task.Run(() => RetrieveShippingLabelAsync(shipmentId, trackingId, retrieveShippingLabelRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<RetrieveShippingLabelResult> RetrieveShippingLabelAsync(string shipmentId, string trackingId, RetrieveShippingLabelRequest retrieveShippingLabelRequest)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.RetrieveShippingLabel(shipmentId, trackingId), RestSharp.Method.Post, postJsonObj: retrieveShippingLabelRequest);
            var response = await ExecuteRequestAsync<RetrieveShippingLabelResponse>(RateLimitType.Shipping_RetrieveShippingLabel);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public PurchaseShipmentResult PurchaseShipment(PurchaseShipmentRequest purchaseShipmentRequest) =>
            Task.Run(() => PurchaseShipmentAsync(purchaseShipmentRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<PurchaseShipmentResult> PurchaseShipmentAsync(PurchaseShipmentRequest purchaseShipmentRequest)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.PurchaseShipment, RestSharp.Method.Post, postJsonObj: purchaseShipmentRequest);
            var response = await ExecuteRequestAsync<PurchaseShipmentResponse>(RateLimitType.Shipping_PurchaseShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetRatesResult GetRates(GetRatesRequest getRatesRequest) =>
            Task.Run(() => GetRatesAsync(getRatesRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetRatesResult> GetRatesAsync(GetRatesRequest getRatesRequest)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetRates, RestSharp.Method.Post, postJsonObj: getRatesRequest);
            var response = await ExecuteRequestAsync<GetRatesResponse>(RateLimitType.Shipping_GetRates);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Account GetAccount() =>
            Task.Run(() => GetAccountAsync()).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Account> GetAccountAsync()
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetAccount, RestSharp.Method.Get);
            var response = await ExecuteRequestAsync<GetAccountResponse>(RateLimitType.Shipping_GetAccount);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public TrackingInformation GetTrackingInformation(string trackingId) =>
            Task.Run(() => GetTrackingInformationAsync(trackingId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<TrackingInformation> GetTrackingInformationAsync(string trackingId)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetTrackingInformation(trackingId), RestSharp.Method.Get);
            var response = await ExecuteRequestAsync<GetTrackingInformationResponse>(RateLimitType.Shipping_GetTrackingInformation);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
