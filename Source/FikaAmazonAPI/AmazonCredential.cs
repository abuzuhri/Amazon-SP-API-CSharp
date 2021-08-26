using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Text;

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

        public AmazonCredential()
        {
        }
        public AmazonCredential(string AccessKey, string SecretKey, string RoleArn, string ClientId, string ClientSecret)
        {
            this.AccessKey = AccessKey;
            this.SecretKey = SecretKey;
            this.RoleArn = RoleArn;
            this.ClientId = ClientId;
            this.ClientSecret = ClientSecret;
            this.RefreshToken = RefreshToken;
        }
    }
}
