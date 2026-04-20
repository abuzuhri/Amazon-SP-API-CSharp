using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.RestSharp;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FikaAmazonAPI.AmazonSpApiSDK.Runtime
{
    public class LWAClient
    {
        public const string AccessTokenKey = "access_token";
        public const string JsonMediaType = "application/json";

        public RestClient RestClient { get; set; }
        public LWAAccessTokenRequestMetaBuilder LWAAccessTokenRequestMetaBuilder { get; set; }
        public LWAAuthorizationCredentials LWAAuthorizationCredentials { get; private set; }


        public LWAClient(LWAAuthorizationCredentials lwaAuthorizationCredentials, IWebProxy proxy = null)
        {

            LWAAuthorizationCredentials = lwaAuthorizationCredentials;
            LWAAccessTokenRequestMetaBuilder = new LWAAccessTokenRequestMetaBuilder();
            var options = new RestClientOptions(LWAAuthorizationCredentials.Endpoint.GetLeftPart(UriPartial.Authority))
            {
                Proxy = proxy
            };
            RestClient = new RestClient(options);
        }


        /// <summary>
        /// Retrieves access token from LWA
        /// </summary>
        /// <param name="lwaAccessTokenRequestMeta">LWA AccessTokenRequest metadata</param>
        /// <returns>LWA Access Token</returns>
        public virtual async Task<TokenResponse> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        {
            LWAAccessTokenRequestMeta lwaAccessTokenRequestMeta = LWAAccessTokenRequestMetaBuilder.Build(LWAAuthorizationCredentials);
            var accessTokenRequest = new RestRequest(LWAAuthorizationCredentials.Endpoint.AbsolutePath, RestSharp.Method.Post);

            string jsonRequestBody = JsonConvert.SerializeObject(lwaAccessTokenRequestMeta);

            //accessTokenRequest.AddParameter(JsonMediaType, jsonRequestBody, ParameterType.RequestBody);
            accessTokenRequest.AddJsonBody(jsonRequestBody);

            try
            {
                var response = await RestClient.ExecuteAsync(accessTokenRequest, cancellationToken).ConfigureAwait(false);

                if (!IsSuccessful(response))
                {
                    var message = string.IsNullOrEmpty(response.ErrorMessage)
                        ? $"Unsuccessful LWA token exchange: {response.Content}"
                        : $"Unsuccessful LWA token exchange: {response.ErrorMessage}";
                    throw new IOException(message);
                }

                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(response.Content);
                return tokenResponse;
            }
            catch (Exception e)
            {
                //Debug.WriteLine(e.Message + Environment.NewLine + e.InnerException?.Message);
                throw new SystemException("Error getting LWA Access Token!", e);
            }
        }

        private bool IsSuccessful(RestResponse response)
        {
            int statusCode = (int)response.StatusCode;
            return statusCode >= 200 && statusCode <= 299 && response.ResponseStatus == ResponseStatus.Completed;
        }
    }
}
