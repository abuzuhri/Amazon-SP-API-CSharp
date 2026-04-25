using FikaAmazonAPI.AmazonSpApiSDK.Models.ApplicationManagement;
using FikaAmazonAPI.AmazonSpApiSDK.Runtime;
using FikaAmazonAPI.RestSharp;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using RestSharp.Serializers.NewtonsoftJson;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    /// <summary>
    /// Application Management API v2023-11-30 — programmatic LWA client-secret rotation.
    /// See https://developer-docs.amazon.com/sp-api/docs/rotate-your-application-client-secret
    ///
    /// Important: this operation uses a different LWA grant_type than the rest of the SDK
    /// (client_credentials with the rotation scope, not refresh_token), so it bypasses the
    /// standard cached-token flow. The rotated secret is NOT returned in the HTTP response —
    /// Amazon delivers it asynchronously to a developer-registered SQS queue subscribed to
    /// the APPLICATION_OAUTH_CLIENT_NEW_SECRET notification.
    /// </summary>
    public class ApplicationManagementService : RequestService
    {
        public ApplicationManagementService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory)
            : base(amazonCredential, loggerFactory)
        {
        }

        /// <summary>
        /// Triggers an LWA client-secret rotation. Returns when Amazon has accepted the
        /// request (HTTP 200). The new secret is delivered asynchronously via SQS — the
        /// caller must subscribe to APPLICATION_OAUTH_CLIENT_NEW_SECRET separately.
        /// </summary>
        public RotateApplicationClientSecretResponse RotateApplicationClientSecret() =>
            Task.Run(() => RotateApplicationClientSecretAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<RotateApplicationClientSecretResponse> RotateApplicationClientSecretAsync(CancellationToken cancellationToken = default)
        {
            // Rotation requires a client_credentials-grant token scoped to
            // sellingpartnerapi::client_credential:rotation. The standard refresh_token-based
            // flow used by every other call won't authorize this endpoint, so fetch a token
            // directly and inject it via the inherited AccessToken property.
            var token = await TokenGeneration.GetAccessTokenFromScopeAsync(
                AmazonCredential,
                grant_type: "client_credentials",
                scope: ScopeConstants.ScopeClientCredentialRotationAPI,
                cancellationToken);
            AccessToken = token.access_token;

            // Build the RestClient + RestRequest manually (RequestService.CreateRequest is
            // private and CreateAuthorizedRequestAsync would overwrite AccessToken with a
            // refresh_token-grant token).
            var options = new RestClientOptions(ApiBaseUrl) { Proxy = AmazonCredential.Proxy };
            RequestClient = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
            Request = new RestRequest(ApplicationManagementApiUrls.RotateApplicationClientSecret, RestSharp.Method.Post);

            return await ExecuteRequestAsync<RotateApplicationClientSecretResponse>(
                RateLimitType.ApplicationManagement_RotateApplicationClientSecret,
                cancellationToken);
        }
    }
}
