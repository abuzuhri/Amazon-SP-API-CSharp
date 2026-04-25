using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>
    /// Base for every A+ Content response. <see cref="Warnings"/> is populated on partial success.
    /// </summary>
    public class AplusResponse
    {
        [JsonProperty("warnings")]
        public List<Error> Warnings { get; set; }
    }

    /// <summary>
    /// Base for paged A+ Content responses. Pass <see cref="NextPageToken"/> back into the
    /// next call to fetch more results; iterate until the token is null.
    /// </summary>
    public class AplusPaginatedResponse : AplusResponse
    {
        [JsonProperty("nextPageToken")]
        public string NextPageToken { get; set; }
    }
}
