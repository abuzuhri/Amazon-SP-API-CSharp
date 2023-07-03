using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.AmazonSpApiSDK.Runtime
{
    public class LWAClient
    {
        public const string AccessTokenKey = "access_token";
        public const string JsonMediaType = "application/json";

        public RestClient RestClient { get; set; }
        public LWAAccessTokenRequestMetaBuilder LWAAccessTokenRequestMetaBuilder { get; set; }
        public LWAAuthorizationCredentials LWAAuthorizationCredentials { get; private set; }


        public LWAClient(LWAAuthorizationCredentials lwaAuthorizationCredentials, string proxyAddress = null)
        {

            LWAAuthorizationCredentials = lwaAuthorizationCredentials;
            LWAAccessTokenRequestMetaBuilder = new LWAAccessTokenRequestMetaBuilder();
            // RestClient = new RestClient(LWAAuthorizationCredentials.Endpoint.GetLeftPart(UriPartial.Authority));
            if (string.IsNullOrWhiteSpace(proxyAddress))
            {
                RestClient = new RestClient(LWAAuthorizationCredentials.Endpoint.GetLeftPart(UriPartial.Authority));
            }else
            {
                var options = new RestClientOptions(LWAAuthorizationCredentials.Endpoint.GetLeftPart(UriPartial.Authority))
                {
                    Proxy = new System.Net.WebProxy()
                    {
                        Address = new Uri(proxyAddress)
                    }
                };

                RestClient = new RestClient(options);
            }
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
                    throw new IOException("Unsuccessful LWA token exchange", response.ErrorException);
                }

                TokenResponse tokenService = new TokenResponse();

                var tokenRespoce = JsonConvert.DeserializeObject<TokenResponse>(response.Content);
                return tokenRespoce;
            }
            catch (Exception e)
            {
                throw new SystemException("Error getting LWA Access Token", e);
            }
        }

        private bool IsSuccessful(RestResponse response)
        {
            int statusCode = (int)response.StatusCode;
            return statusCode >= 200 && statusCode <= 299 && response.ResponseStatus == ResponseStatus.Completed;
        }
    }
}
