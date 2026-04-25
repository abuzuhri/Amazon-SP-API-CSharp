using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>A list of rich-text content typically presented in a text box.</summary>
    public class ParagraphComponent
    {
        [JsonProperty("textList")]
        public List<TextComponent> TextList { get; set; }
    }
}
