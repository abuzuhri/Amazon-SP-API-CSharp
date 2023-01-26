using FikaAmazonAPI.AmazonSpApiSDK.Models.MerchantFulfillment;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class MerchantFulfillmentService : RequestService
    {

        public MerchantFulfillmentService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public GetEligibleShipmentServicesResult GetEligibleShipmentServicesOld(GetEligibleShipmentServicesRequest getEligibleShipmentServicesRequest) =>
            Task.Run(() => GetEligibleShipmentServicesOldAsync(getEligibleShipmentServicesRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetEligibleShipmentServicesResult> GetEligibleShipmentServicesOldAsync(GetEligibleShipmentServicesRequest getEligibleShipmentServicesRequest, CancellationToken cancellationToken = default)
        {

            await CreateAuthorizedRequestAsync(MerchantFulfillmentApiUrls.GetEligibleShipmentServicesOld, RestSharp.Method.Post, postJsonObj: getEligibleShipmentServicesRequest, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<GetEligibleShipmentServicesResponse>(RateLimitType.MerchantFulFillment_GetEligibleShipmentServicesOld, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetEligibleShipmentServicesResult GetEligibleShipmentServices(GetEligibleShipmentServicesRequest getEligibleShipmentServicesRequest) =>
            Task.Run(() => GetEligibleShipmentServicesAsync(getEligibleShipmentServicesRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetEligibleShipmentServicesResult> GetEligibleShipmentServicesAsync(GetEligibleShipmentServicesRequest getEligibleShipmentServicesRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(MerchantFulfillmentApiUrls.GetEligibleShipmentServices, RestSharp.Method.Post, postJsonObj: getEligibleShipmentServicesRequest, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<GetEligibleShipmentServicesResponse>(RateLimitType.MerchantFulFillment_GetEligibleShipmentServices, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Shipment GetShipment(string shipmentId, IParameterBasedPII ParameterBasedPII = null) =>
            Task.Run(() => GetShipmentAsync(shipmentId, ParameterBasedPII = null)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Shipment> GetShipmentAsync(string shipmentId, IParameterBasedPII ParameterBasedPII = null, CancellationToken cancellationToken = default)
        {
            if (ParameterBasedPII != null && ParameterBasedPII.IsNeedRestrictedDataToken && ParameterBasedPII.RestrictedDataTokenRequest == null)
            {
                var restrictedResource = new RestrictedResource();
                restrictedResource.method = Method.GET.ToString();
                restrictedResource.path = MerchantFulfillmentApiUrls.GetShipment(shipmentId);

                var createRDT = new CreateRestrictedDataTokenRequest()
                {
                    restrictedResources = new List<RestrictedResource> { restrictedResource }
                };
                ParameterBasedPII.RestrictedDataTokenRequest = createRDT;
            }

            await CreateAuthorizedRequestAsync(MerchantFulfillmentApiUrls.GetShipment(shipmentId), RestSharp.Method.Get, parameter: ParameterBasedPII, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<GetShipmentResponse>(RateLimitType.MerchantFulFillment_GetShipment, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public Shipment CancelShipment(string shipmentId, IParameterBasedPII parameterBasedPII = null) =>
            Task.Run(() => CancelShipmentAsync(shipmentId, parameterBasedPII)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Shipment> CancelShipmentAsync(string shipmentId, IParameterBasedPII parameterBasedPII = null, CancellationToken cancellationToken = default)
        {
            if (parameterBasedPII != null && parameterBasedPII.IsNeedRestrictedDataToken && parameterBasedPII.RestrictedDataTokenRequest == null)
            {
                var restrictedResource = new RestrictedResource();
                restrictedResource.method = Method.DELETE.ToString();
                restrictedResource.path = MerchantFulfillmentApiUrls.GetShipment(shipmentId);

                var createRDT = new CreateRestrictedDataTokenRequest()
                {
                    restrictedResources = new List<RestrictedResource> { restrictedResource }
                };
                parameterBasedPII.RestrictedDataTokenRequest = createRDT;
            }

            await CreateAuthorizedRequestAsync(MerchantFulfillmentApiUrls.GetShipment(shipmentId), RestSharp.Method.Delete, parameter: parameterBasedPII, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<GetShipmentResponse>(RateLimitType.MerchantFulFillment_CancelShipment, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Shipment CancelShipmentOld(string shipmentId, IParameterBasedPII parameterBasedPII = null) =>
            Task.Run(() => CancelShipmentOldAsync(shipmentId, parameterBasedPII)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Shipment> CancelShipmentOldAsync(string shipmentId, IParameterBasedPII parameterBasedPII = null, CancellationToken cancellationToken = default)
        {
            if (parameterBasedPII != null && parameterBasedPII.IsNeedRestrictedDataToken && parameterBasedPII.RestrictedDataTokenRequest == null)
            {
                var restrictedResource = new RestrictedResource();
                restrictedResource.method = Method.PUT.ToString();
                restrictedResource.path = MerchantFulfillmentApiUrls.CancelShipmentOld(shipmentId);

                var createRDT = new CreateRestrictedDataTokenRequest()
                {
                    restrictedResources = new List<RestrictedResource> { restrictedResource }
                };
                parameterBasedPII.RestrictedDataTokenRequest = createRDT;
            }

            await CreateAuthorizedRequestAsync(MerchantFulfillmentApiUrls.CancelShipmentOld(shipmentId), RestSharp.Method.Put, parameter: parameterBasedPII, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<GetShipmentResponse>(RateLimitType.MerchantFulFillment_CancelShipmentOld, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Shipment CreateShipment(CreateShipmentRequest createShipmentRequest, IParameterBasedPII parameterBasedPII = null) =>
            Task.Run(() => CreateShipmentAsync(createShipmentRequest, parameterBasedPII)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Shipment> CreateShipmentAsync(CreateShipmentRequest createShipmentRequest, IParameterBasedPII parameterBasedPII = null, CancellationToken cancellationToken = default)
        {
            if (parameterBasedPII != null && parameterBasedPII.IsNeedRestrictedDataToken && parameterBasedPII.RestrictedDataTokenRequest == null)
            {
                var restrictedResource = new RestrictedResource();
                restrictedResource.method = Method.POST.ToString();
                restrictedResource.path = MerchantFulfillmentApiUrls.CreateShipment;

                var createRDT = new CreateRestrictedDataTokenRequest()
                {
                    restrictedResources = new List<RestrictedResource> { restrictedResource }
                };
                parameterBasedPII.RestrictedDataTokenRequest = createRDT;
            }

            await CreateAuthorizedRequestAsync(MerchantFulfillmentApiUrls.CreateShipment, RestSharp.Method.Post, postJsonObj: createShipmentRequest, parameter: parameterBasedPII, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<CreateShipmentResponse>(RateLimitType.MerchantFulFillment_CreateShipment, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetAdditionalSellerInputsResult GetAdditionalSellerInputsOld(GetAdditionalSellerInputsRequest getAdditionalSellerInputsRequest) =>
            Task.Run(() => GetAdditionalSellerInputsOldAsync(getAdditionalSellerInputsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetAdditionalSellerInputsResult> GetAdditionalSellerInputsOldAsync(GetAdditionalSellerInputsRequest getAdditionalSellerInputsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(MerchantFulfillmentApiUrls.GetAdditionalSellerInputsOld, RestSharp.Method.Post, postJsonObj: getAdditionalSellerInputsRequest, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<GetAdditionalSellerInputsResponse>(RateLimitType.MerchantFulFillment_GetAdditionalSellerInputsOld, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public GetAdditionalSellerInputsResult GetAdditionalSellerInputs(GetAdditionalSellerInputsRequest getAdditionalSellerInputsRequest) =>
            Task.Run(() => GetAdditionalSellerInputsAsync(getAdditionalSellerInputsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetAdditionalSellerInputsResult> GetAdditionalSellerInputsAsync(GetAdditionalSellerInputsRequest getAdditionalSellerInputsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(MerchantFulfillmentApiUrls.GetAdditionalSellerInputs, RestSharp.Method.Post, postJsonObj: getAdditionalSellerInputsRequest, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<GetAdditionalSellerInputsResponse>(RateLimitType.MerchantFulFillment_GetAdditionalSellerInputs, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
