using FikaAmazonAPI.AmazonSpApiSDK.Models.ShipmentInvoicing;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Utils;

namespace FikaAmazonAPI.Services
{
    public partial class ShipmentInvoicingService : RequestService
    {
        public ShipmentInvoicingService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public ShipmentDetail GetShipmentDetails(string shipmentId, ParameterBasedPII parameterBasedPII)
        {
            CreateAuthorizedRequest(ShipmentInvoicingApiUrls.GetShipmentDetails(shipmentId), RestSharp.Method.GET,parameter: parameterBasedPII);
            var response = ExecuteRequest<GetShipmentDetailsResponse>(RateLimitType.ShipmentInvoicing_GetShipmentDetails);

            if(response!=null && response.Payload!=null)
                return response.Payload;

            return null;
        }
        public bool SubmitInvoice(string shipmentId, SubmitInvoiceRequest submitInvoiceRequest)
        {
            CreateAuthorizedRequest(ShipmentInvoicingApiUrls.SubmitInvoice(shipmentId), RestSharp.Method.POST,postJsonObj: submitInvoiceRequest);
            var response = ExecuteRequest<SubmitInvoiceResponse>(RateLimitType.ShipmentInvoicing_SubmitInvoice);

            return true;
        }
        public ShipmentInvoiceStatusInfo GetInvoiceStatus(string shipmentId)
        {
            CreateAuthorizedRequest(ShipmentInvoicingApiUrls.GetInvoiceStatus(shipmentId), RestSharp.Method.GET);
            var response = ExecuteRequest<GetInvoiceStatusResponse>(RateLimitType.ShipmentInvoicing_GetInvoiceStatus);

            if (response != null && response.Payload != null)
                return response.Payload;

            return null;
        }
    }
}
