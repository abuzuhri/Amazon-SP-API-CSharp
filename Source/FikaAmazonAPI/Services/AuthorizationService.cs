using FikaAmazonAPI.AmazonSpApiSDK.Models.Authorization;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
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
            await CreateAuthorizedRequestAsync(AuthorizationsApiUrls.GetAuthorizationCode, RestSharp.Method.Get, param, tokenDataType: TokenDataType.Grantless);

            var response = await ExecuteRequestAsync<GetAuthorizationCodeResponse>(Utils.RateLimitType.Authorization_GetAuthorizationCode);
            if (response != null && response.Payload != null)
                return response.Payload._AuthorizationCode;
            return null;
        }

        public async Task<TokenResponse> GetAccessTokenFromCodeAsync(string code, string appRedirectUri)
        {
            return await TokenGeneration.GetAccessTokenFromCodeAsync(AmazonCredential.ClientId, AmazonCredential.ClientSecret, code, appRedirectUri);
        }

        public async Task<TokenResponse> GetRefreshTokenFromCodeAsync(string code, string appRedirectUri)
        {
            return await TokenGeneration.GetAccessTokenFromCodeAsync(AmazonCredential.ClientId, AmazonCredential.ClientSecret, code, appRedirectUri, grant_type: "authorization_code");
        }

        public static async Task<TokenResponse> GetAccessTokenFromCodeAsync(string clientId, string clientSecret, string code, string appRedirectUri)
        {
            return await TokenGeneration.GetAccessTokenFromCodeAsync(clientId, clientSecret, code, appRedirectUri);
        }

        public static async Task<TokenResponse> GetRefreshTokenFromCodeAsync(string clientId, string clientSecret, string code, string appRedirectUri)
        {
            return await TokenGeneration.GetAccessTokenFromCodeAsync(clientId, clientSecret, code, appRedirectUri, grant_type: "authorization_code");
        }
    }
}
