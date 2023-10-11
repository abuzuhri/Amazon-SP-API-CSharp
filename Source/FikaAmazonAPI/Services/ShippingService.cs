using FikaAmazonAPI.AmazonSpApiSDK.Models.Shipping;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class ShippingService : RequestService
    {
        public ShippingService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public Shipment CreateShipment(CreateShipmentRequest parameterShimpmentRequest) =>
            Task.Run(() => CreateShipmentAsync(parameterShimpmentRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Shipment> CreateShipmentAsync(CreateShipmentRequest parameterShipmentRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.CreateShipment, RestSharp.Method.Post, postJsonObj: parameterShipmentRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetShipmentResponse>(RateLimitType.Shipping_CreateShipment, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Shipment GetShipment(string shipmentId, ParameterBasedPII parameterBasedPII) =>
            Task.Run(() => GetShipmentAsync(shipmentId, parameterBasedPII)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Shipment> GetShipmentAsync(string shipmentId, ParameterBasedPII parameterBasedPII, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetShipment(shipmentId), RestSharp.Method.Get, parameter: parameterBasedPII, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetShipmentResponse>(RateLimitType.Shipping_GetShipment, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public bool CancelShipment(string shipmentId) =>
            Task.Run(() => CancelShipmentAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CancelShipmentAsync(string shipmentId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.CancelShipment(shipmentId), RestSharp.Method.Post, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<CancelShipmentResponse>(RateLimitType.Shipping_CancelShipment, cancellationToken);
            if (response != null)
                return true;
            return false;
        }

        public PurchaseLabelsResult PurchaseLabels(string shipmentId, PurchaseLabelsRequest purchaseLabelsRequest) =>
            Task.Run(() => PurchaseLabelsAsync(shipmentId, purchaseLabelsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<PurchaseLabelsResult> PurchaseLabelsAsync(string shipmentId, PurchaseLabelsRequest purchaseLabelsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.PurchaseLabels(shipmentId), RestSharp.Method.Post, postJsonObj: purchaseLabelsRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<PurchaseLabelsResponse>(RateLimitType.Shipping_PurchaseLabels, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public RetrieveShippingLabelResult RetrieveShippingLabel(string shipmentId, string trackingId, RetrieveShippingLabelRequest retrieveShippingLabelRequest) =>
            Task.Run(() => RetrieveShippingLabelAsync(shipmentId, trackingId, retrieveShippingLabelRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<RetrieveShippingLabelResult> RetrieveShippingLabelAsync(string shipmentId, string trackingId, RetrieveShippingLabelRequest retrieveShippingLabelRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.RetrieveShippingLabel(shipmentId, trackingId), RestSharp.Method.Post, postJsonObj: retrieveShippingLabelRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<RetrieveShippingLabelResponse>(RateLimitType.Shipping_RetrieveShippingLabel, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public PurchaseShipmentResult PurchaseShipment(PurchaseShipmentRequest purchaseShipmentRequest) =>
            Task.Run(() => PurchaseShipmentAsync(purchaseShipmentRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<PurchaseShipmentResult> PurchaseShipmentAsync(PurchaseShipmentRequest purchaseShipmentRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.PurchaseShipment, RestSharp.Method.Post, postJsonObj: purchaseShipmentRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<PurchaseShipmentResponse>(RateLimitType.Shipping_PurchaseShipment, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetRatesResult GetRates(GetRatesRequest getRatesRequest) =>
            Task.Run(() => GetRatesAsync(getRatesRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetRatesResult> GetRatesAsync(GetRatesRequest getRatesRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetRates, RestSharp.Method.Post, postJsonObj: getRatesRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetRatesResponse>(RateLimitType.Shipping_GetRates, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Account GetAccount() =>
            Task.Run(() => GetAccountAsync()).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Account> GetAccountAsync(CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetAccount, RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetAccountResponse>(RateLimitType.Shipping_GetAccount, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public TrackingInformation GetTrackingInformation(string trackingId) =>
            Task.Run(() => GetTrackingInformationAsync(trackingId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<TrackingInformation> GetTrackingInformationAsync(string trackingId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiUrls.GetTrackingInformation(trackingId), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetTrackingInformationResponse>(RateLimitType.Shipping_GetTrackingInformation, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
