using Newtonsoft.Json;
using System;

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
        public ErrorResponseElement[] Errors;
    }

    public class ErrorResponseElement
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("details")]
        public string Details { get; set; }
    }
}
