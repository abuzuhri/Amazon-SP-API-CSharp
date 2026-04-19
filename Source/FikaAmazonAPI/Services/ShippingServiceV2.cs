using FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class ShippingServiceV2 : RequestService
    {
        public ShippingServiceV2(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {

        }

        public bool CancelShipment(string shipmentId) =>
            Task.Run(() => CancelShipmentAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CancelShipmentAsync(string shipmentId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiV2Urls.CancelShipment(shipmentId), RestSharp.Method.Put, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<CancelShipmentResponse>(RateLimitType.ShippingV2_CancelShipment, cancellationToken);
            if (response != null)
                return true;
            return false;
        }


        public PurchaseShipmentResult PurchaseShipment(PurchaseShipmentRequest purchaseShipmentRequest) =>
            Task.Run(() => PurchaseShipmentAsync(purchaseShipmentRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<PurchaseShipmentResult> PurchaseShipmentAsync(PurchaseShipmentRequest purchaseShipmentRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiV2Urls.PurchaseShipment, RestSharp.Method.Post, postJsonObj: purchaseShipmentRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<PurchaseShipmentResponse>(RateLimitType.ShippingV2_PurchaseShipment, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetRatesResult GetRates(GetRatesRequest getRatesRequest) =>
            Task.Run(() => GetRatesAsync(getRatesRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetRatesResult> GetRatesAsync(GetRatesRequest getRatesRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiV2Urls.GetRates, RestSharp.Method.Post, postJsonObj: getRatesRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetRatesResponse>(RateLimitType.ShippingV2_GetRates, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetAdditionalInputsResult GetAdditionalInputs(GetAdditionalInputsRequest getRatesRequest) =>
            Task.Run(() => GetAdditionalInputsAsync(getRatesRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetAdditionalInputsResult> GetAdditionalInputsAsync(GetAdditionalInputsRequest getRatesRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiV2Urls.GetAdditionalInputs(getRatesRequest.RequestToken, getRatesRequest.RateId), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetAdditionalInputsResponse>(RateLimitType.ShippingV2_GetAdditionalInputs, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetTrackingResult GetTracking(string carrierId, string trackingId) =>
            Task.Run(() => GetTrackingAsync(carrierId, trackingId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetTrackingResult> GetTrackingAsync(string carrierId, string trackingId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiV2Urls.GetTracking(carrierId, trackingId), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetTrackingResponse>(RateLimitType.ShippingV2_GetTracking, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetShipmentDocumentsResult GetShipmentDocuments(string shipmentId, string packageClientReferenceId, string format) =>
             Task.Run(() => GetShipmentDocumentsAsync(shipmentId, packageClientReferenceId, format)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetShipmentDocumentsResult> GetShipmentDocumentsAsync(string shipmentId, string packageClientReferenceId, string format, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ShippingApiV2Urls.GetShipmentDocuments(shipmentId, packageClientReferenceId, format), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetShipmentDocumentsResponse>(RateLimitType.ShippingV2_GetShipmentDocument, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
