using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ApplicationManagement
{
    /// <summary>
    /// Response wrapper for rotateApplicationClientSecret. Note: per the OpenAPI spec, the
    /// 200 response has no body — Amazon delivers the rotated secret asynchronously to a
    /// developer-registered SQS queue subscribed to the APPLICATION_OAUTH_CLIENT_NEW_SECRET
    /// notification. Only the Errors field is populated for non-2xx responses.
    /// </summary>
    public class RotateApplicationClientSecretResponse
    {
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }
}
