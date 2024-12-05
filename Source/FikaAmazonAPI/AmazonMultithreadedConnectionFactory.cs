using FikaAmazonAPI.Utils;
using System;
using System.Globalization;

namespace FikaAmazonAPI
{
    public class AmazonMultithreadedConnectionFactory
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly string _roleArn;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _refreshToken;
        private readonly string _proxyAddress;

        private readonly IRateLimitingHandler _rateLimitingHandler;

        public AmazonMultithreadedConnectionFactory(
            string ClientId,
            string ClientSecret,
            string RefreshToken,
            string AccessKey = null,
            string SecretKey = null,
            string RoleArn = null,
            string ProxyAddress = null,
            IRateLimitingHandler rateLimitingHandler = null)
        {
            _accessKey = AccessKey;
            _secretKey = SecretKey;
            _roleArn = RoleArn;
            _clientId = ClientId;
            _clientSecret = ClientSecret;
            _refreshToken = RefreshToken;
            _proxyAddress = ProxyAddress;

            _rateLimitingHandler = rateLimitingHandler ?? new RateLimitingHandler();
        }

        public AmazonConnection RequestScopedConnection(
            string marketPlaceId = null,
            string sellerId = null,
            string refCode = null,
            Action<AmazonCredential> credentialConfiguration = null,
            CultureInfo cultureInfo = null)
        {
            // need to create distinct credential/connection here so that token caching in credential is predicably kept within scope
            var credential = new AmazonCredential(_accessKey, _secretKey, _roleArn, _clientId, _clientSecret, _refreshToken, _proxyAddress) 
            {
                MarketPlaceID = marketPlaceId,
                SellerID = sellerId,
            };
            credentialConfiguration?.Invoke(credential);

            return new AmazonConnection(credential, _rateLimitingHandler, refCode, cultureInfo);
        }
    }
}
