using FikaAmazonAPI.AmazonSpApiSDK.Models.Authorization;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Parameter.Authorization;
using FikaAmazonAPI.Utils;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.CacheTokenData;

namespace FikaAmazonAPI.Services
{
    public class AuthorizationService : RequestService
    {
        public AuthorizationService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory, IRateLimitingHandler rateLimitingHandler = null) : base(amazonCredential, loggerFactory, rateLimitingHandler)
        {
        }
        public string GetAuthorizationCode(ParameterAuthorizationCode parameterGetOrderMetrics) =>
            Task.Run(() => GetAuthorizationCodeAsync(parameterGetOrderMetrics)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<string> GetAuthorizationCodeAsync(ParameterAuthorizationCode parameter, CancellationToken cancellationToken = default)
        {
            var param = parameter.getParameters();
            await CreateAuthorizedRequestAsync(AuthorizationsApiUrls.GetAuthorizationCode, RestSharp.Method.Get, param, tokenDataType: TokenDataType.Grantless, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<GetAuthorizationCodeResponse>(Utils.RateLimitType.Authorization_GetAuthorizationCode, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload._AuthorizationCode;
            return null;
        }

        public async Task<TokenResponse> GetAccessTokenFromCodeAsync(string code, string appRedirectUri, CancellationToken cancellationToken = default)
        {
            return await TokenGeneration.GetAccessTokenFromCodeAsync(AmazonCredential.ClientId, AmazonCredential.ClientSecret, code, appRedirectUri, cancellationToken: cancellationToken);
        }

        public async Task<TokenResponse> GetRefreshTokenFromCodeAsync(string code, string appRedirectUri, CancellationToken cancellationToken = default)
        {
            return await TokenGeneration.GetAccessTokenFromCodeAsync(AmazonCredential.ClientId, AmazonCredential.ClientSecret, code, appRedirectUri, grant_type: "authorization_code", cancellationToken: cancellationToken);
        }

        public static async Task<TokenResponse> GetAccessTokenFromCodeAsync(string clientId, string clientSecret, string code, string appRedirectUri, CancellationToken cancellationToken = default)
        {
            return await TokenGeneration.GetAccessTokenFromCodeAsync(clientId, clientSecret, code, appRedirectUri, cancellationToken: cancellationToken);
        }

        public static async Task<TokenResponse> GetRefreshTokenFromCodeAsync(string clientId, string clientSecret, string code, string appRedirectUri, CancellationToken cancellationToken = default)
        {
            return await TokenGeneration.GetAccessTokenFromCodeAsync(clientId, clientSecret, code, appRedirectUri, grant_type: "authorization_code", cancellationToken: cancellationToken);
        }
    }
}
