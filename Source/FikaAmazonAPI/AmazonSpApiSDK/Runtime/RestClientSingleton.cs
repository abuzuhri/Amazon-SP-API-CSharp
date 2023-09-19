using System;
using System.Net.Http;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace FikaAmazonAPI.AmazonSpApiSDK.Runtime
{
    /// <summary>
    /// Get Singleton HttpClient
    /// to fixed: RestClient not properly disposed causes memory / socket leaks
    /// <see cref="https://github.com/abuzuhri/Amazon-SP-API-CSharp/issues/523"/>
    /// </summary>
    public static class RestClientSingleton
    {
        private static readonly HttpClient _httpClient = null;

        static RestClientSingleton()
        {
            _httpClient = new HttpClient(new StandardSocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(1)
            });
        }

        /// <summary>
        /// Get RestClient By Singleton HttpClient
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static RestClient GetRestClient(string baseUrl)
        {
            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var baseUri))
            {
                throw new ArgumentException($"argument of {baseUrl} is illegal");
            }

            var restClientOption = new RestClientOptions
            {
                BaseUrl = baseUri,
            };
            return new RestClient(_httpClient, restClientOption,
                configureSerialization: s => s.UseNewtonsoftJson());
        }
    }
}