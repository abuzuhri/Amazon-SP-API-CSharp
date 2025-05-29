using System.Threading;
using System.Threading.Tasks;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorDirectFulfillmentInventory;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class VendorDirectFulfillmentInventoryService : RequestService
    {
        public VendorDirectFulfillmentInventoryService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory)
            : base(amazonCredential, loggerFactory)
        {
        }

        public TransactionReference SubmitInventoryUpdate(string warehouseId, SubmitInventoryUpdateRequest submitInventoryUpdateRequest) =>
            Task.Run(() => SubmitInventoryUpdateAsync(warehouseId, submitInventoryUpdateRequest)).ConfigureAwait(false)
                .GetAwaiter().GetResult();

        public async Task<TransactionReference> SubmitInventoryUpdateAsync(string warehouseId, SubmitInventoryUpdateRequest submitInventoryUpdateRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentInventoryApiUrls.SubmitInventoryUpdate(warehouseId), RestSharp.Method.Post, postJsonObj: submitInventoryUpdateRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<SubmitInventoryUpdateResponse>(RateLimitType.VendorDirectFulfillmentInventory_SubmitInventoryUpdate, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}