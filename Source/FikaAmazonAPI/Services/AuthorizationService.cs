using FikaAmazonAPI.AmazonSpApiSDK.Models.Authorization;
using FikaAmazonAPI.Parameter.Authorization;
using System.Threading.Tasks;

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
            await CreateAuthorizedRequestAsync(AuthorizationsApiUrls.GetAuthorizationCode, RestSharp.Method.GET, param);
            var response = await ExecuteRequestAsync<GetAuthorizationCodeResponse>();
            if (response != null && response.Payload != null)
                return response.Payload._AuthorizationCode;
            return null;
        }
    }
}
