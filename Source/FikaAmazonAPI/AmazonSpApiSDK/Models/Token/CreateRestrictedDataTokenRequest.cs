using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Token
{
    public class CreateRestrictedDataTokenRequest
    {
        public IList<RestrictedResource> restrictedResources { get; set; }

        public string targetApplication { get; set; }

    }
}
