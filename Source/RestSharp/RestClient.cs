using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FikaAmazonAPI.RestSharp
{
    public class RestClient
    {
        public RestClientOptions Options { get; }
        private readonly HttpClient _httpClient;
        private static readonly HttpMethod PatchMethod = new HttpMethod("PATCH");

        public RestClient(RestClientOptions options, Action<RestClient> configureSerialization = null)
        {
            Options = options;
            var handler = new HttpClientHandler();
            if (options.Proxy != null)
            {
                handler.Proxy = options.Proxy;
                handler.UseProxy = true;
            }
            _httpClient = new HttpClient(handler) { BaseAddress = options.BaseUrl };
            configureSerialization?.Invoke(this);
        }

        public RestClient(HttpClient httpClient, RestClientOptions options, Action<RestClient> configureSerialization = null)
        {
            Options = options;
            _httpClient = httpClient;
            if (Options.BaseUrl != null)
                _httpClient.BaseAddress = Options.BaseUrl;
            configureSerialization?.Invoke(this);
        }

        private HttpMethod ToHttpMethod(Method method)
        {
            return method switch
            {
                Method.Get => HttpMethod.Get,
                Method.Post => HttpMethod.Post,
                Method.Put => HttpMethod.Put,
                Method.Delete => HttpMethod.Delete,
                Method.Patch => PatchMethod,
                _ => HttpMethod.Get
            };
        }

        private HttpRequestMessage BuildRequest(RestRequest request)
        {
            var uriBuilder = new UriBuilder(new Uri(Options.BaseUrl, request.Resource));
            var queryParams = request.Parameters
                .Where(p => p.Type == ParameterType.QueryString)
                .Select(p => $"{Uri.EscapeDataString(p.Name)}={Uri.EscapeDataString(p.Value.ToString())}");
            var query = string.Join("&", queryParams);
            if (!string.IsNullOrEmpty(query))
            {
                if (string.IsNullOrEmpty(uriBuilder.Query))
                    uriBuilder.Query = query;
                else
                    uriBuilder.Query = $"{uriBuilder.Query.TrimStart('?')}&{query}";
            }
            var message = new HttpRequestMessage(ToHttpMethod(request.Method), uriBuilder.Uri);

            foreach (var header in request.Parameters.Where(p => p.Type == ParameterType.HttpHeader))
            {
                message.Headers.TryAddWithoutValidation(header.Name, header.Value.ToString());
            }

            if (request.JsonBody != null)
            {
                message.Content = new StringContent(request.JsonBody, Encoding.UTF8, "application/json");
            }

            return message;
        }

        private RestResponse CreateRestResponse(HttpResponseMessage httpResponse, string content)
        {
            var response = new RestResponse
            {
                StatusCode = httpResponse.StatusCode,
                Content = content,
                ResponseStatus = ResponseStatus.Completed,
                ResponseUri = httpResponse.RequestMessage?.RequestUri
            };

            foreach (var header in httpResponse.Headers)
            {
                foreach (var val in header.Value)
                {
                    response.Headers.Add(new HeaderParameter { Name = header.Key, Value = val });
                }
            }
            foreach (var header in httpResponse.Content.Headers)
            {
                foreach (var val in header.Value)
                {
                    response.Headers.Add(new HeaderParameter { Name = header.Key, Value = val });
                }
            }

            return response;
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest request, CancellationToken cancellationToken = default)
        {
            var message = BuildRequest(request);
            using var httpResponse = await _httpClient.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            return CreateRestResponse(httpResponse, content);
        }

        public async Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request, CancellationToken cancellationToken = default)
        {
            var baseResponse = await ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
            var data = default(T);
            if (!string.IsNullOrEmpty(baseResponse.Content))
            {
                try
                {
                    data = JsonConvert.DeserializeObject<T>(baseResponse.Content);
                }
                catch
                {
                    // ignore deserialization errors
                }
            }
            return new RestResponse<T>
            {
                StatusCode = baseResponse.StatusCode,
                Content = baseResponse.Content,
                ResponseStatus = baseResponse.ResponseStatus,
                ResponseUri = baseResponse.ResponseUri,
                Headers = baseResponse.Headers,
                ErrorMessage = baseResponse.ErrorMessage,
                Data = data
            };
        }
    }
}
