using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    public class PostContentDocumentAsinRelationsRequest
    {
        [JsonProperty("asinSet")]
        public List<string> AsinSet { get; set; }
    }
}
