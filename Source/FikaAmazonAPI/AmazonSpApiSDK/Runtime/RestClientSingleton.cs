using System;
using System.Net.Http;
using RestSharp;

namespace FikaAmazonAPI.AmazonSpApiSDK.Runtime
{
    public class RestClientSingleton
    {
        private static readonly HttpClient _httpClient = new HttpClient(new StandardSocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(15)
        });

        static RestClientSingleton()
        {
        }

        private RestClientSingleton()
        {
        }

        public static RestClient RestClient => new RestClient(_httpClient);
    }
}