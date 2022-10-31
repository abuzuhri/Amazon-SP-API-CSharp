﻿using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.AmazonSpApiSDK.Runtime;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.CacheTokenData;

namespace FikaAmazonAPI.Services
{
    public static class TokenGeneration
    {

        public static async Task<TokenResponse> RefreshAccessTokenAsync(AmazonCredential credentials, TokenDataType tokenDataType = TokenDataType.Normal)
        {
            var lwaCredentials = new LWAAuthorizationCredentials()
            {
                ClientId = credentials.ClientId,
                ClientSecret = credentials.ClientSecret,
                Endpoint = new Uri(Constants.AmazonToeknEndPoint),
                RefreshToken = credentials.RefreshToken,
                Scopes = null
            };
            if (tokenDataType == TokenDataType.Grantless)
                lwaCredentials.Scopes = new List<string>() { ScopeConstants.ScopeMigrationAPI, ScopeConstants.ScopeNotificationsAPI };

            var Client = new LWAClient(lwaCredentials);
            var accessToken = await Client.GetAccessTokenAsync();

            return accessToken;
        }

        public static async Task<TokenResponse> GetAccessTokenFromCodeAsync(string ClientId, string ClientSecret, string code, string appRedirectUri, string grant_type = "client_credentials")
        {
            string data = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.amazon.com");
                var byteArray = Encoding.ASCII.GetBytes($"{ClientId}:{ClientSecret}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                Dictionary<string, string> items = new Dictionary<string, string>();
                items.Add("grant_type", grant_type);
                items.Add("scope", ScopeConstants.ScopeMigrationAPI);
                items.Add("client_id", ClientId);
                items.Add("client_secret", ClientSecret);
                items.Add("code", code);
                items.Add("redirect_uri", appRedirectUri);

                FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(items);
                var rs = client.PostAsync("/auth/o2/token", formUrlEncodedContent).Result;
                data = await rs.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<TokenResponse>(data);
        }

        public static async Task<RestRequest> SignWithSTSKeysAndSecurityTokenAsync(RestRequest restRequest, string host, AmazonCredential amazonCredential)
        {
            var dataToken = amazonCredential.GetAWSAuthenticationTokenData();
            if (dataToken == null)
            {
                AssumeRoleResponse response1 = null;
                using (var STSClient = new AmazonSecurityTokenServiceClient(amazonCredential.AccessKey, amazonCredential.SecretKey))
                {
                    var req = new AssumeRoleRequest()
                    {
                        RoleArn = amazonCredential.RoleArn,
                        DurationSeconds = 3600,
                        RoleSessionName = Guid.NewGuid().ToString()
                    };

                    response1 = await STSClient.AssumeRoleAsync(req, new CancellationToken());
                }

                //auth step 3
                var awsAuthenticationCredentials = new AWSAuthenticationCredentials
                {
                    AccessKeyId = response1.Credentials.AccessKeyId,
                    SecretKey = response1.Credentials.SecretAccessKey,
                    Region = amazonCredential.MarketPlace.Region.RegionName
                };

                amazonCredential.SetAWSAuthenticationTokenData(new AWSAuthenticationTokenData()
                {
                    AWSAuthenticationCredential = awsAuthenticationCredentials,
                    SessionToken = response1.Credentials.SessionToken,
                    Expiration = response1.Credentials.Expiration
                });
                dataToken = amazonCredential.GetAWSAuthenticationTokenData();
            }

            lock (restRequest)
            {
                restRequest.AddOrUpdateHeader(RequestService.SecurityTokenHeaderName, dataToken.SessionToken);
            }
            return new AWSSigV4Signer(dataToken.AWSAuthenticationCredential)
                            .Sign(restRequest, host);

        }
    }
}
