using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaInbound;
using FikaAmazonAPI.Parameter.FbaInboundEligibility;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class FbaInboundEligibilityService : RequestService
    {
        public FbaInboundEligibilityService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {

        }

        public ItemEligibilityPreview GetItemEligibilityPreview(ParameterGetItemEligibilityPreview parameterGetItemEligibilityPreview) =>
            Task.Run(() => GetItemEligibilityPreviewAsync(parameterGetItemEligibilityPreview)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ItemEligibilityPreview> GetItemEligibilityPreviewAsync(ParameterGetItemEligibilityPreview parameterGetItemEligibilityPreview, CancellationToken cancellationToken = default)
        {
            var parameter = parameterGetItemEligibilityPreview.getParameters();
            await CreateAuthorizedRequestAsync(FBAInboundEligibiltyApiUrls.GetItemEligibilityPreview, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetItemEligibilityPreviewResponse>(RateLimitType.FBAInboundEligibility_GetItemEligibilityPreview, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
