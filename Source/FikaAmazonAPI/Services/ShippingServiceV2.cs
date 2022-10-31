﻿using FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Utils;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class ShippingServiceV2 : RequestService
    {
        public ShippingServiceV2(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public bool CancelShipment(string shipmentId) =>
            Task.Run(() => CancelShipmentAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CancelShipmentAsync(string shipmentId)
        {
            await CreateAuthorizedRequestAsync(ShippingApiV2Urls.CancelShipment(shipmentId), RestSharp.Method.Post);
            var response = await ExecuteRequestAsync<CancelShipmentResponse>(RateLimitType.ShippingV2_CancelShipment);
            if (response != null)
                return true;
            return false;
        }


        public PurchaseShipmentResult PurchaseShipment(PurchaseShipmentRequest purchaseShipmentRequest) =>
            Task.Run(() => PurchaseShipmentAsync(purchaseShipmentRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<PurchaseShipmentResult> PurchaseShipmentAsync(PurchaseShipmentRequest purchaseShipmentRequest)
        {
            await CreateAuthorizedRequestAsync(ShippingApiV2Urls.PurchaseShipment, RestSharp.Method.Post, postJsonObj: purchaseShipmentRequest);
            var response = await ExecuteRequestAsync<PurchaseShipmentResponse>(RateLimitType.ShippingV2_PurchaseShipment);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetRatesResult GetRates(GetRatesRequest getRatesRequest) =>
            Task.Run(() => GetRatesAsync(getRatesRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetRatesResult> GetRatesAsync(GetRatesRequest getRatesRequest)
        {
            await CreateAuthorizedRequestAsync(ShippingApiV2Urls.GetRates, RestSharp.Method.Post, postJsonObj: getRatesRequest);
            var response = await ExecuteRequestAsync<GetRatesResponse>(RateLimitType.ShippingV2_GetRates);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetTrackingResult GetTracking(string carrierId, string trackingId) =>
            Task.Run(() => GetTrackingAsync(carrierId, trackingId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetTrackingResult> GetTrackingAsync(string carrierId, string trackingId)
        {
            await CreateAuthorizedRequestAsync(ShippingApiV2Urls.GetTracking(carrierId, trackingId), RestSharp.Method.Get);
            var response = await ExecuteRequestAsync<GetTrackingResponse>(RateLimitType.ShippingV2_GetTracking);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
