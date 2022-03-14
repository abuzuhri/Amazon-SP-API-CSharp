using FikaAmazonAPI.AmazonSpApiSDK.Models.Authorization;
using FikaAmazonAPI.Parameter.Authorization;
using System.Threading.Tasks;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.CacheTokenData;

namespace FikaAmazonAPI.Services
{
    public class AuthorizationService : RequestService
    {
        public AuthorizationService(AmazonCredential amazonCredential) : base(amazonCredential)
        {
        }
        public string GetAuthorizationCode(ParameterAuthorizationCode parameterGetOrderMetrics) =>
            Task.Run(() => GetAuthorizationCodeAsync(parameterGetOrderMetrics)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<string> GetAuthorizationCodeAsync(ParameterAuthorizationCode parameter)
        {
            var param = parameter.getParameters();
            await CreateAuthorizedRequestAsync(AuthorizationsApiUrls.GetAuthorizationCode, RestSharp.Method.GET, param, tokenDataType: TokenDataType.MigrationOnly);

            var response = await ExecuteRequestAsync<GetAuthorizationCodeResponse>(Utils.RateLimitType.Authorization_GetAuthorizationCode);
            if (response != null && response.Payload != null)
                return response.Payload._AuthorizationCode;
            return null;
        }
    }
}
