using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorTransactions;
using FikaAmazonAPI.Parameter.VendorOrders;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class VendorTransactionStatusService : RequestService
    {
        public VendorTransactionStatusService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public Transaction GetTransaction(string TransactionId) =>
            Task.Run(() => GetTransactionAsync(TransactionId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Transaction> GetTransactionAsync(string TransactionId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorTransactionStatusApiUrls.GetTransaction(TransactionId), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetTransactionResponse>(RateLimitType.VendorTransactionStatus_GetTransaction);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
