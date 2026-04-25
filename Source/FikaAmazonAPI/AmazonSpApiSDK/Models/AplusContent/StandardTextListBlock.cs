using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard fixed-length list of text — usually rendered as bullets.</summary>
    public class StandardTextListBlock
    {
        [JsonProperty("textList")]
        public List<TextItem> TextList { get; set; }
    }
}
