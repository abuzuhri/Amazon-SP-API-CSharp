using FikaAmazonAPI.AmazonSpApiSDK.Models.ShipmentInvoicing;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Utils;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public partial class ShipmentInvoicingService : RequestService
    {
        public ShipmentInvoicingService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public ShipmentDetail GetShipmentDetails(string shipmentId, ParameterBasedPII parameterBasedPII) =>
            Task.Run(() => GetShipmentDetailsAsync(shipmentId, parameterBasedPII)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ShipmentDetail> GetShipmentDetailsAsync(string shipmentId, ParameterBasedPII parameterBasedPII)
        {
            await CreateAuthorizedRequestAsync(ShipmentInvoicingApiUrls.GetShipmentDetails(shipmentId), RestSharp.Method.Get, parameter: parameterBasedPII);
            var response = await ExecuteRequestAsync<GetShipmentDetailsResponse>(RateLimitType.ShipmentInvoicing_GetShipmentDetails);

            if (response != null && response.Payload != null)
                return response.Payload;

            return null;
        }

        public bool SubmitInvoice(string shipmentId, SubmitInvoiceRequest submitInvoiceRequest) =>
            Task.Run(() => SubmitInvoiceAsync(shipmentId, submitInvoiceRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> SubmitInvoiceAsync(string shipmentId, SubmitInvoiceRequest submitInvoiceRequest)
        {
            await CreateAuthorizedRequestAsync(ShipmentInvoicingApiUrls.SubmitInvoice(shipmentId), RestSharp.Method.Post, postJsonObj: submitInvoiceRequest);
            var response = await ExecuteRequestAsync<SubmitInvoiceResponse>(RateLimitType.ShipmentInvoicing_SubmitInvoice);

            return true;
        }

        public ShipmentInvoiceStatusInfo GetInvoiceStatus(string shipmentId) =>
            Task.Run(() => GetInvoiceStatusAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ShipmentInvoiceStatusInfo> GetInvoiceStatusAsync(string shipmentId)
        {
            await CreateAuthorizedRequestAsync(ShipmentInvoicingApiUrls.GetInvoiceStatus(shipmentId), RestSharp.Method.Get);
            var response = await ExecuteRequestAsync<GetInvoiceStatusResponse>(RateLimitType.ShipmentInvoicing_GetInvoiceStatus);

            if (response != null && response.Payload != null)
                return response.Payload;

            return null;
        }
    }
}
