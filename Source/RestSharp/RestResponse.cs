using System;
using System.Collections.Generic;
using System.Net;

namespace FikaAmazonAPI.RestSharp
{
    public enum ResponseStatus
    {
        Completed,
        Error
    }

    public class RestResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public Uri ResponseUri { get; set; }
        public List<HeaderParameter> Headers { get; set; } = new List<HeaderParameter>();
        public string ErrorMessage { get; set; }
    }

    public class RestResponse<T> : RestResponse
    {
        public T Data { get; set; }
    }
}
