using FikaAmazonAPI.AmazonSpApiSDK.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Token
{
    public class AWSAuthenticationTokenData
    {
        public AWSAuthenticationCredentials AWSAuthenticationCredential { get; set; }
        public string SessionToken { get; set; }
        public DateTime Expiration { get; set; }


    }
}
