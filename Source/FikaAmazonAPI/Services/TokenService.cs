using Amazon;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using FikaAmazonAPI.AmazonSpApiSDK.Models;
using FikaAmazonAPI.AmazonSpApiSDK.Runtime;
using FikaAmazonAPI.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FikaAmazonAPI.Services
{
    public static class TokenService
    {
        public static bool IsTokenExpired(int? expiresIn, DateTime? lastUpdated, DateTime? dateCreated)
        {
            if (expiresIn == null)
                throw new Exception("Channel token expires in not defined");
            if (lastUpdated == null)
                if (dateCreated == null)
                    throw new Exception("Expires in or Last update date is null");
                else
                    return DateTime.UtcNow.Subtract((DateTime)dateCreated).TotalSeconds > expiresIn;
            else
                return DateTime.UtcNow.Subtract((DateTime)lastUpdated).TotalSeconds > expiresIn;
        }

        public static string RefreshAccessToken(AmazonCredential credentials,bool isGrantless=false)
        {
            var lwaCredentials = new LWAAuthorizationCredentials()
            {
                ClientId = credentials.ClientId,
                ClientSecret = credentials.ClientSecret,
                Endpoint = new Uri(Constants.AmazonToeknEndPoint),
                RefreshToken = credentials.RefreshToken,
                Scopes=null
            };
            if (isGrantless)
                lwaCredentials.Scopes = new List<string>() { ScopeConstants.ScopeMigrationAPI, ScopeConstants.ScopeNotificationsAPI };

            var Client = new LWAClient(lwaCredentials);
            var accessToken = Client.GetAccessToken();

            return accessToken.access_token;
        }


        public static IRestRequest SignWithSTSKeysAndSecurityToken(IRestRequest restRequest, string host, string roleARN, string accessKey, string secretKey,string region)
        {
            AssumeRoleResponse response1 = null;
            using (var STSClient = new AmazonSecurityTokenServiceClient(accessKey, secretKey)) //, RegionEndpoint.USEast1
            {
                var req = new AssumeRoleRequest()
                {
                    RoleArn = roleARN,
                    DurationSeconds = 950, //put anything you want here
                    RoleSessionName = Guid.NewGuid().ToString()
                };

                response1 = STSClient.AssumeRoleAsync(req, new CancellationToken()).Result;
            }

            //auth step 3
            var awsAuthenticationCredentials = new AWSAuthenticationCredentials
            {
                AccessKeyId = response1.Credentials.AccessKeyId,
                SecretKey = response1.Credentials.SecretAccessKey,
                Region = region
            };

            restRequest.AddHeader("x-amz-security-token", response1.Credentials.SessionToken);

            return new AWSSigV4Signer(awsAuthenticationCredentials)
                            .Sign(restRequest, host);
        }
    }
}
