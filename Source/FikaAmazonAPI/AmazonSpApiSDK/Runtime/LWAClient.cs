using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;

namespace FikaAmazonAPI.AmazonSpApiSDK.Runtime
{
    public class LWAClient
    {
        public const string AccessTokenKey = "access_token";
        public const string JsonMediaType = "application/json; charset=utf-8";

        public IRestClient RestClient { get; set; }
        public LWAAccessTokenRequestMetaBuilder LWAAccessTokenRequestMetaBuilder { get; set; }
        public LWAAuthorizationCredentials LWAAuthorizationCredentials { get; private set; }


        public LWAClient(LWAAuthorizationCredentials lwaAuthorizationCredentials)
        {

            LWAAuthorizationCredentials = lwaAuthorizationCredentials;
            LWAAccessTokenRequestMetaBuilder = new LWAAccessTokenRequestMetaBuilder();
            RestClient = new RestClient(LWAAuthorizationCredentials.Endpoint.GetLeftPart(UriPartial.Authority));
        }

        /// <summary>
        /// Retrieves access token from LWA
        /// </summary>
        /// <param name="lwaAccessTokenRequestMeta">LWA AccessTokenRequest metadata</param>
        /// <returns>LWA Access Token</returns>
        public virtual TokenResponse GetAccessToken()
        {
            LWAAccessTokenRequestMeta lwaAccessTokenRequestMeta = LWAAccessTokenRequestMetaBuilder.Build(LWAAuthorizationCredentials);
            var accessTokenRequest = new RestRequest(LWAAuthorizationCredentials.Endpoint.AbsolutePath,RestSharp.Method.POST);

            string jsonRequestBody = JsonConvert.SerializeObject(lwaAccessTokenRequestMeta);

            accessTokenRequest.AddParameter(JsonMediaType, jsonRequestBody, ParameterType.RequestBody);

            try
            {
                var response = RestClient.Execute(accessTokenRequest);

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

        private bool IsSuccessful(IRestResponse response)
        {
            int statusCode = (int)response.StatusCode;
            return statusCode >= 200 && statusCode <= 299 && response.ResponseStatus == ResponseStatus.Completed;
        }
    }
}
