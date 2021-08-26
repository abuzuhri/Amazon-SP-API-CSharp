using Amazon;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using AmazonSpApiSDK.Models;
using AmazonSpApiSDK.Runtime;
using FikaAmazonAPI.Utils;
using RestSharp;
using System;
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

        public static string RefreshAccessToken(AmazonCredential credentials)
        {
            var lwaCredentials = new LWAAuthorizationCredentials()
            {
                ClientId = credentials.ClientId,
                ClientSecret = credentials.ClientSecret,
                Endpoint = new Uri(Constants.AmazonToeknEndPoint),
                RefreshToken = credentials.RefreshToken,
            };

            var Client = new LWAClient(lwaCredentials);
            var accessToken = Client.GetAccessToken();

            return accessToken;
        }

        public static IRestRequest SignWithAccessToken(IRestRequest restRequest, string clientId, string clientSecret, string refreshToken)
        {
            var lwaAuthorizationCredentials = new LWAAuthorizationCredentials
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                Endpoint = new Uri("https://api.amazon.com/auth/o2/token"),
                RefreshToken = refreshToken,
            };

            return new LWAAuthorizationSigner(lwaAuthorizationCredentials).Sign(restRequest);
        }

        public static IRestRequest SignWithSTSKeysAndSecurityToken(IRestRequest restRequest, string host, string roleARN, string accessKey, string secretKey)
        {
            AssumeRoleResponse response1 = null;
            using (var STSClient = new AmazonSecurityTokenServiceClient(accessKey, secretKey, RegionEndpoint.USEast1))
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
                Region = "eu-west-1"
            };

            restRequest.AddHeader("x-amz-security-token", response1.Credentials.SessionToken);

            return new AWSSigV4Signer(awsAuthenticationCredentials)
                            .Sign(restRequest, host);
        }
    }
}
