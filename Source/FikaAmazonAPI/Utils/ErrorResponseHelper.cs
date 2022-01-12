using Newtonsoft.Json;
using System;
using System.Net;

namespace FikaAmazonAPI.Utils
{
    public static class ErrorResponseHelper
    {
        public static ErrorResponse ConvertToErrorResponse(this string response)
        {
            if (String.IsNullOrEmpty(response)) return null;

            try
            {
                return JsonConvert.DeserializeObject<ErrorResponse>(response);
            }
            catch
            {
                return null;
            }
        }
    }


    public class ErrorResponse
    {
        [JsonProperty("errors")]
        public ErrorResponseItem[] Errors;
    }

    public class ErrorResponseItem
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("code")]
        public HttpStatusCode Code { get; set; }
        [JsonProperty("details")]
        public string Details { get; set; }
    }
}
