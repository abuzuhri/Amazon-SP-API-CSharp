using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard company-logo image module.</summary>
    public class StandardCompanyLogoModule
    {
        [JsonProperty("companyLogo")]
        public ImageComponent CompanyLogo { get; set; }
    }
}
