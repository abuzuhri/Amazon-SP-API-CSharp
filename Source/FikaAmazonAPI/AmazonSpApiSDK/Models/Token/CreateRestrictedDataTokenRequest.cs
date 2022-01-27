using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Token
{
    public class CreateRestrictedDataTokenRequest
    {
        public IList<RestrictedResource> restrictedResources { get; set; }

        public string targetApplication { get; set; }

    }
}
