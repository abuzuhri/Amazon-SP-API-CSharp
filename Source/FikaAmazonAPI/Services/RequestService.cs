using FikaAmazonAPI.AmazonSpApiSDK.Models.Exceptions;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Filters;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.AmazonSpApiSDK.Runtime;
using FikaAmazonAPI.AmazonSpApiSDK.Services;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.CacheTokenData;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    public class RequestService : ApiUrls
    {
        public static readonly string AccessTokenHeaderName = "x-amz-access-token";
        public static readonly string SecurityTokenHeaderName = "x-amz-security-token";
        private readonly string RateLimitLimitHeaderName = "x-amzn-RateLimit-Limit";
        protected RestClient RequestClient { get; set; }
        protected IRestRequest Request { get; set; }
        protected AmazonCredential AmazonCredential { get; set; }
        protected string AmazonSandboxUrl { get; set; }
        protected string AmazonProductionUrl { get; set; }
        protected string AccessToken { get; set; }

        protected string ApiBaseUrl
        {
            get
            {
                return AmazonCredential.Environment == Environments.Sandbox ? AmazonSandboxUrl : AmazonProductionUrl;
            }
        }

        /// <summary>
        /// Creates request base service
        /// </summary>
        /// <param name="awsCredentials">Contains api clients information</param>
        /// <param name="clientToken">Contains current user's account api keys</param>
        public RequestService(AmazonCredential amazonCredential)
        {
            AmazonCredential = amazonCredential;
            AmazonSandboxUrl = amazonCredential.MarketPlace.Region.SandboxHostUrl;
            AmazonProductionUrl = amazonCredential.MarketPlace.Region.HostUrl;
        }


        private void CreateRequest(string url, RestSharp.Method method)
        {
            RequestClient = new RestClient(ApiBaseUrl);
            Request = new RestRequest(url, method);
        }
        protected async Task CreateUnAuthorizedRequestAsync(string url, RestSharp.Method method, List<KeyValuePair<string, string>> queryParameters = null, object postJsonObj = null)
        {
            CreateRequest(url, method);
            if (postJsonObj != null)
                AddJsonBody(postJsonObj);
            if (queryParameters != null)
                AddQueryParameters(queryParameters);
        }

        protected async Task CreateAuthorizedRequestAsync(string url, RestSharp.Method method, List<KeyValuePair<string, string>> queryParameters = null, object postJsonObj = null, TokenDataType tokenDataType = TokenDataType.Normal, object parameter = null)
        {
            var PiiObject = parameter as IParameterBasedPII;
            if (PiiObject != null && PiiObject.IsNeedRestrictedDataToken)
            {
                await RefreshTokenAsync(TokenDataType.PII, PiiObject.RestrictedDataTokenRequest);
            }
            else await RefreshTokenAsync(tokenDataType);
            CreateRequest(url, method);
            if (postJsonObj != null)
                AddJsonBody(postJsonObj);
            if (queryParameters != null)
                AddQueryParameters(queryParameters);
        }

        protected void CreateAuthorizedPagedRequest(AmazonFilter filter, string url, RestSharp.Method method)
        {
            RefreshToken();
            if (filter.NextPage != null)
                CreateRequest(filter.NextPage, method);
            else
            {
                CreateRequest(url, method);
                AddLimitHeader(filter.Limit);
            }
            AddAccessToken();
        }


        /// <summary>
        /// Executes the request
        /// </summary>
        /// <typeparam name="T">Type to parse response to</typeparam>
        /// <returns>Returns data of T type</returns>
        protected async Task<T> ExecuteRequestTry<T>(RateLimitType rateLimitType = RateLimitType.UNSET) where T : new()
        {
            RestHeader();
            AddAccessToken();
            Request = await TokenGeneration.SignWithSTSKeysAndSecurityTokenAsync(Request, RequestClient.BaseUrl.Host, AmazonCredential);
            var response = await RequestClient.ExecuteAsync<T>(Request);
            SleepForRateLimit(response.Headers, rateLimitType);
            ParseResponse(response);

            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content) && response.Data == null)
            {
                response.Data = JsonConvert.DeserializeObject<T>(response.Content);
            }
            return response.Data;
        }
        private void RestHeader()
        {
            Request.Parameters.RemoveAll(parameter => ParameterType.HttpHeader.Equals(parameter.Type)
                                                          && parameter.Name == AWSSignerHelper.XAmzDateHeaderName);
            Request.Parameters.RemoveAll(parameter => ParameterType.HttpHeader.Equals(parameter.Type)
                                                          && parameter.Name == AWSSignerHelper.AuthorizationHeaderName);
            Request.Parameters.RemoveAll(parameter => ParameterType.HttpHeader.Equals(parameter.Type)
                                                          && parameter.Name == AccessTokenHeaderName);
            Request.Parameters.RemoveAll(parameter => ParameterType.HttpHeader.Equals(parameter.Type)
                                                          && parameter.Name == SecurityTokenHeaderName);
        }

        //public T ExecuteRequest<T>(RateLimitType rateLimitType = RateLimitType.UNSET) where T : new()
        //{
        //    return this.ExecuteRequestAsync<T>(rateLimitType)).ConfigureAwait(false).GetAwaiter().GetResult();
        //}

        public async Task<T> ExecuteRequestAsync<T>(RateLimitType rateLimitType = RateLimitType.UNSET) where T : new()
        {
            var tryCount = 0;
            while (true)
            {
                try
                {
                    return await ExecuteRequestTry<T>(rateLimitType);
                }
                catch (AmazonQuotaExceededException ex)
                {
                    if (tryCount >= AmazonCredential.MaxThrottledRetryCount)
                    {
#if DEBUG
                        Console.WriteLine("Throttle max try count reached");
#endif
                        throw;
                    }

                    AmazonCredential.UsagePlansTimings[rateLimitType].Delay();
                    tryCount++;
                }
            }
        }

        private void SleepForRateLimit(IList<RestSharp.Parameter> headers, RateLimitType rateLimitType = RateLimitType.UNSET)
        {
            try
            {
                decimal rate = 0;
                var limitHeader = headers.Where(a => a.Name == RateLimitLimitHeaderName).FirstOrDefault();
                if (limitHeader != null)
                {
                    var RateLimitValue = limitHeader.Value.ToString();
                    decimal.TryParse(RateLimitValue, NumberStyles.Any, CultureInfo.InvariantCulture, out rate);
                }

                if (AmazonCredential.IsActiveLimitRate)
                {
                    if (rateLimitType == RateLimitType.UNSET)
                    {
                        if (rate > 0)
                        {
                            int sleepTime = (int)(1 / rate * 1000);
                            Task.Delay(sleepTime).Wait();
                        }
                    }
                    else
                    {
                        if (rate > 0)
                        {
                            AmazonCredential.UsagePlansTimings[rateLimitType].SetRateLimit(rate);
                        }
                        var time = AmazonCredential.UsagePlansTimings[rateLimitType].NextRate(rateLimitType);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }


        protected async Task<T> ExecuteUnAuthorizedRequest<T>() where T : new()
        {
            var response = await RequestClient.ExecuteAsync<T>(Request);
            ParseResponse(response);

            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content) && response.Data == null)
            {
                response.Data = JsonConvert.DeserializeObject<T>(response.Content);
            }
            return response.Data;
        }

        protected void ParseResponse(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.Created)
                return;
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new AmazonNotFoundException("Resource that you are looking for is not found", response);
            }
            else
            {
                Console.WriteLine("Amazon Api didn't respond with Okay, see exception for more details" + response.Content);

                var errorResponse = response.Content.ConvertToErrorResponse();
                if (errorResponse != null)
                {
                    var error = errorResponse.Errors.FirstOrDefault();

                    switch (error.Code)
                    {
                        case "Unauthorized":
                            throw new AmazonUnauthorizedException(error.Message, response);
                        case "InvalidSignature":
                            throw new AmazonInvalidSignatureException(error.Message, response);
                        case "InvalidInput":
                            throw new AmazonInvalidInputException(error.Message, response);
                        case "QuotaExceeded":
                            throw new AmazonQuotaExceededException(error.Message, response);
                    }

                }
            }

            throw new AmazonException("Amazon Api didn't respond with Okay, see exception for more details", response);
        }

        protected void AddQueryParameters(List<KeyValuePair<string, string>> queryParameters)
        {
            if (queryParameters != null)
                queryParameters.ForEach(qp => Request.AddQueryParameter(qp.Key, qp.Value));
        }

        protected void AddLimitHeader(int limit)
        {
            Request.AddQueryParameter("limit", limit.ToString());
        }
        protected void AddJsonBody(object jsonData)
        {
            var json = JsonConvert.SerializeObject(jsonData);
            Request.AddJsonBody(json);
        }
        protected void AddAccessToken()
        {
            Request.AddOrUpdateHeader(AccessTokenHeaderName, AccessToken);
        }

        protected async void RefreshToken(TokenDataType tokenDataType = TokenDataType.Normal, CreateRestrictedDataTokenRequest requestPII = null)
        {
            var token = AmazonCredential.GetToken(tokenDataType);
            if (token == null)
            {
                if (tokenDataType == TokenDataType.PII)
                {
                    var pii = CreateRestrictedDataToken(requestPII);
                    if (pii != null)
                    {
                        token = new TokenResponse()
                        {
                            access_token = pii.RestrictedDataToken,
                            expires_in = pii.ExpiresIn
                        };
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(pii));
                    }
                }
                else
                {
                    token = await TokenGeneration.RefreshAccessTokenAsync(AmazonCredential, tokenDataType);
                }

                AmazonCredential.SetToken(tokenDataType, token);
            }


            AccessToken = token.access_token;
        }

        protected async Task RefreshTokenAsync(TokenDataType tokenDataType = TokenDataType.Normal, CreateRestrictedDataTokenRequest requestPII = null)
        {
            var token = AmazonCredential.GetToken(tokenDataType);
            if (token == null)
            {
                if (tokenDataType == TokenDataType.PII)
                {
                    var pii = await CreateRestrictedDataTokenAsync(requestPII);
                    if (pii != null)
                    {
                        token = new TokenResponse()
                        {
                            access_token = pii.RestrictedDataToken,
                            expires_in = pii.ExpiresIn
                        };
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(pii));
                    }
                }
                else
                {
                    token = await TokenGeneration.RefreshAccessTokenAsync(AmazonCredential, tokenDataType);
                }

                AmazonCredential.SetToken(tokenDataType, token);
            }


            AccessToken = token.access_token;
        }

        public CreateRestrictedDataTokenResponse CreateRestrictedDataToken(CreateRestrictedDataTokenRequest createRestrictedDataTokenRequest)
        {
            return Task.Run(() => CreateRestrictedDataTokenAsync(createRestrictedDataTokenRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task<CreateRestrictedDataTokenResponse> CreateRestrictedDataTokenAsync(CreateRestrictedDataTokenRequest createRestrictedDataTokenRequest)
        {
            await CreateAuthorizedRequestAsync(TokenApiUrls.RestrictedDataToken, RestSharp.Method.POST, postJsonObj: createRestrictedDataTokenRequest);
            var response = await ExecuteRequestAsync<CreateRestrictedDataTokenResponse>();
            return response;
        }
    }

}