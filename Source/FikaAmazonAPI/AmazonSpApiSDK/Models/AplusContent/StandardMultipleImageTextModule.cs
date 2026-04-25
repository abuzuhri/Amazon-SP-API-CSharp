using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Image+text blocks shown one at a time via thumbnail clicks.</summary>
    public class StandardMultipleImageTextModule
    {
        [JsonProperty("blocks")]
        public List<StandardImageTextCaptionBlock> Blocks { get; set; }
    }
}
