using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.CacheTokenData;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI
{
    public class AmazonCredential
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string RoleArn { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RefreshToken { get; set; }
        public MarketPlace MarketPlace { get; set; }
        private CacheTokenData CacheTokenData { get; set; }
        public bool IsActiveLimitRate { get; set; } = true;
        public Environments Environment { get; set; } = Environments.Production;
        public int MaxThrottledRetryCount { get; set; } = 3;
        public ShippingBusiness? ShippingBusiness { get; set; }
        public bool IsDebugMode { get; set; }
        public string MarketPlaceID { get; set; }
        public string SellerID { get; set; }

        public AmazonCredential()
        {
            CacheTokenData = new CacheTokenData();
        }
        public AmazonCredential(string AccessKey, string SecretKey, string RoleArn, string ClientId, string ClientSecret, string RefreshToken)
        {
            this.AccessKey = AccessKey;
            this.SecretKey = SecretKey;
            this.RoleArn = RoleArn;
            this.ClientId = ClientId;
            this.ClientSecret = ClientSecret;
            this.RefreshToken = RefreshToken;
            CacheTokenData = new CacheTokenData();
        }

        public TokenResponse GetToken(TokenDataType tokenDataType)
        {
            return CacheTokenData.GetToken(tokenDataType);
        }
        public void SetToken(TokenDataType tokenDataType, TokenResponse token)
        {
            CacheTokenData.SetToken(tokenDataType, token);
        }
        public AWSAuthenticationTokenData GetAWSAuthenticationTokenData()
        {
            return CacheTokenData.GetAWSAuthenticationTokenData();
        }
        public void SetAWSAuthenticationTokenData(AWSAuthenticationTokenData tokenData)
        {
            CacheTokenData.SetAWSAuthenticationTokenData(tokenData);
        }
        internal Dictionary<RateLimitType, RateLimits> UsagePlansTimings { get; set; } = RateLimitsDefinitions.RateLimitsTime();

    }
}
