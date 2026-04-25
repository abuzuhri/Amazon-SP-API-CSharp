using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard product description text.</summary>
    public class StandardProductDescriptionModule
    {
        [JsonProperty("body")]
        public ParagraphComponent Body { get; set; }
    }
}
