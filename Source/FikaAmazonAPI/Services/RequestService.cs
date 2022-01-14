using FikaAmazonAPI.AmazonSpApiSDK.Models;
using FikaAmazonAPI.AmazonSpApiSDK.Models.CatalogItems;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Exceptions;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Filters;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders;
using FikaAmazonAPI.AmazonSpApiSDK.Services;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using RestSharp.Serializers;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.CacheTokenData;
using FikaAmazonAPI.Search;
using System.Linq;
using System.Threading;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    public class RequestService : ApiUrls
    {
        private readonly string AccessTokenHeaderName = "x-amz-access-token";
        private readonly string RateLimitLimitHeaderName = "x-amzn-RateLimit-Limit";
        protected RestClient RequestClient { get; set; }
        protected IRestRequest Request { get; set; }
        protected AmazonCredential AmazonCredential { get; set; }
        protected MarketPlace MarketPlace { get; set; }
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

            MarketPlace = amazonCredential.MarketPlace;
            
        }


        private void CreateRequest(string url, RestSharp.Method method)
        {
            RequestClient = new RestClient(ApiBaseUrl);
            Request = new RestRequest(url, method);
        }



        protected void CreateAuthorizedRequest(string url, RestSharp.Method method, List<KeyValuePair<string, string>> queryParameters = null,object postJsonObj=null, TokenDataType tokenDataType=TokenDataType.Normal,object parameter=null)
        {
            var PiiObject = parameter as IParameterBasedPII;
            if (PiiObject != null && PiiObject.IsNeedRestrictedDataToken)
            {
                RefreshToken(TokenDataType.PII, PiiObject.RestrictedDataTokenRequest);
            }
            else RefreshToken(tokenDataType);
            CreateRequest(url, method);
            if (postJsonObj != null)
                AddJsonBody(postJsonObj);
            if (queryParameters!=null)
                AddQueryParameters(queryParameters);

            AddAccessToken();
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
        protected T ExecuteRequest<T>() where T : new()
        {
            Request = TokenGeneration.SignWithSTSKeysAndSecurityToken(Request, RequestClient.BaseUrl.Host, AmazonCredential);
            var response = RequestClient.Execute<T>(Request);
            SleepForRateLimit(response.Headers);
            ParseResponse(response);
            
            if (response.StatusCode==HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content) && response.Data == null)
            {
                response.Data = JsonConvert.DeserializeObject<T>(response.Content);
            }
            return response.Data;
        }

        private void SleepForRateLimit(IList<RestSharp.Parameter> headers)
        {
            try
            {
                if (AmazonCredential.IsActiveLimitRate)
                {
                    var limitHeader = headers.Where(a => a.Name == RateLimitLimitHeaderName).FirstOrDefault();
                    if (limitHeader != null)
                    {
                        var RateLimitValue = limitHeader.Value.ToString();
                        float rate = 0;
                        if(float.TryParse(RateLimitValue,out rate))
                        {
                            if (rate > 0)
                            {
                                int sleepTime = (int)(1 / rate*1000);
                                Thread.Sleep(sleepTime);
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {

            }
        }

        /// <summary>
        /// Executes the request 
        /// </summary>
        /// <typeparam name="T">Type to parse response to</typeparam>
        /// <returns>Returns raw response</returns>
        protected IRestResponse ExecuteRequest()
        {
            var response = RequestClient.Execute(Request);
            ParseResponse(response);
            return response;
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
                var errorResponse = response.Content.ConvertToErrorResponse();
                if(errorResponse != null)
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
                    }
                    
                }
            }
           
            Console.WriteLine("Amazon Api didn't respond with Okay, see exception for more details" + response.Content);
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
            //Request.JsonSerializer = new JsonNetSerializer();
            var json = JsonConvert.SerializeObject(jsonData);
            Request.AddJsonBody(json);
        }
        protected void AddAccessToken()
        {
            Request.AddHeader(AccessTokenHeaderName, AccessToken);
        }

        protected void RefreshToken(TokenDataType tokenDataType=TokenDataType.Normal, CreateRestrictedDataTokenRequest requestPII = null)
        {
            var token = AmazonCredential.GetToken(tokenDataType);
            if(token==null)
            {
                if(tokenDataType== TokenDataType.PII)
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
                    token = TokenGeneration.RefreshAccessToken(AmazonCredential, tokenDataType);
                }

                AmazonCredential.SetToken(tokenDataType, token);
            }
                

            AccessToken = token.access_token;
        }

        public CreateRestrictedDataTokenResponse CreateRestrictedDataToken(CreateRestrictedDataTokenRequest createRestrictedDataTokenRequest)
        {
            CreateAuthorizedRequest(TokenApiUrls.RestrictedDataToken, RestSharp.Method.POST, postJsonObj: createRestrictedDataTokenRequest);
            var response = ExecuteRequest<CreateRestrictedDataTokenResponse>();
            return response;
        }
    }

}