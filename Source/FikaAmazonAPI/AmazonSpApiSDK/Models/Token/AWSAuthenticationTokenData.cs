using System;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Token
{
    public class AWSAuthenticationTokenData
    {
        //public AWSAuthenticationCredentials AWSAuthenticationCredential { get; set; }
        public string SessionToken { get; set; }
        public DateTime Expiration { get; set; }


    }
}
