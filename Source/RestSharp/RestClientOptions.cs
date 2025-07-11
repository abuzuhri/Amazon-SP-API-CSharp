using System;
using System.Net;

namespace RestSharp
{
    public class RestClientOptions
    {
        public RestClientOptions() { }

        public RestClientOptions(string baseUrl)
        {
            BaseUrl = new Uri(baseUrl);
        }

        public Uri BaseUrl { get; set; }
        public IWebProxy Proxy { get; set; }
    }
}
