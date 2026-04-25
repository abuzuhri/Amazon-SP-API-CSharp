using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Rich-text content — a string plus optional decorators.</summary>
    public class TextComponent
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("decoratorSet")]
        public List<Decorator> DecoratorSet { get; set; }
    }
}
