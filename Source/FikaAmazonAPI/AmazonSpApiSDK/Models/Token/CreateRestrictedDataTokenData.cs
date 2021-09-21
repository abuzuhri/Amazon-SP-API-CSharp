using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Token
{
    public class CreateRestrictedDataTokenData
    {
        public string RestrictedDataToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
