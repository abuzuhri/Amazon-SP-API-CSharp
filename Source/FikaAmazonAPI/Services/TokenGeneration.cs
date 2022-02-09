using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.AmazonSpApiSDK.Runtime;
using FikaAmazonAPI.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.CacheTokenData;

namespace FikaAmazonAPI.Services
{
    public static class TokenGeneration
    {


        public static TokenResponse RefreshAccessToken(AmazonCredential credentials, TokenDataType tokenDataType = TokenDataType.Normal)
        {
            var lwaCredentials = new LWAAuthorizationCredentials()
            {
                ClientId = credentials.ClientId,
                ClientSecret = credentials.ClientSecret,
                Endpoint = new Uri(Constants.AmazonToeknEndPoint),
                RefreshToken = credentials.RefreshToken,
                Scopes=null
            };
            if (tokenDataType== TokenDataType.Grantless)
                lwaCredentials.Scopes = new List<string>() { ScopeConstants.ScopeMigrationAPI, ScopeConstants.ScopeNotificationsAPI };

            var Client = new LWAClient(lwaCredentials);
            var accessToken = Client.GetAccessToken();

            return accessToken;
        }


        public static IRestRequest SignWithSTSKeysAndSecurityToken(IRestRequest restRequest, string host, AmazonCredential amazonCredential)
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

                    response1 = STSClient.AssumeRoleAsync(req, new CancellationToken()).Result;
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
                    AWSAuthenticationCredential= awsAuthenticationCredentials,
                    SessionToken= response1.Credentials.SessionToken,
                    Expiration= response1.Credentials.Expiration
                });
                dataToken = amazonCredential.GetAWSAuthenticationTokenData();
            }
            
            
            restRequest.AddHeader("x-amz-security-token", dataToken.SessionToken);

            return new AWSSigV4Signer(dataToken.AWSAuthenticationCredential)
                            .Sign(restRequest, host);
        }
    }
}
