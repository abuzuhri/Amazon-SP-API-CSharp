using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Token
{
    public class CreateRestrictedDataTokenResponse
    {
        public string RestrictedDataToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
