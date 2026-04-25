using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>A list of error responses returned when a request is unsuccessful.</summary>
    public class ErrorList
    {
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }
}
