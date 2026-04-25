using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    public class ErrorList
    {
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }
}
