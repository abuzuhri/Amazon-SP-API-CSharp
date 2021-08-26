using AmazonSpApiSDK.Models;
using AmazonSpApiSDK.Models.CatalogItems;
using AmazonSpApiSDK.Models.Exceptions;
using AmazonSpApiSDK.Models.Filters;
using AmazonSpApiSDK.Models.Orders;
using AmazonSpApiSDK.Services;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using RestSharp.Serializers;

namespace FikaAmazonAPI.Services
{
    public class RequestService : ApiUrls
    {
        protected RestClient RequestClient { get; set; }
        protected IRestRequest Request { get; set; }
        protected AmazonCredential AmazonCredential { get; set; }
        protected MarketPlaceParamEnum MarketPlaceParam { get; set; } = MarketPlaceParamEnum.MarketplaceId;
        protected MarketPlace MarketPlace { get; set; }
        protected string AmazonSandboxUrl { get; set; }
        protected string AmazonProductionUrl { get; set; }
        protected string AccessToken { get; set; }
        protected string ApiBaseUrl
        {
            get
            {
                return EnvironemntManager.Environemnt == EnvironemntManager.Environments.Sandbox ? AmazonSandboxUrl : AmazonProductionUrl;
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

        /// <summary>
        /// Checks if token is refreshed after creating the sevice instance
        /// </summary>
        /// <param name="lastUpdated">last time the tokken was updated</param>
        /// <returns></returns>
        public bool IsAccessTokenRefreshed(DateTime lastUpdated)
        {
            return true; //; lastUpdated != ClientToken.LastUpdated;
        }

        private void CreateRequest(string url, Method method)
        {
            RequestClient = new RestClient(ApiBaseUrl);
            Request = new RestRequest(url, method);
        }

        protected void CreateAuthorizedRequest(string url, Method method, List<KeyValuePair<string, string>> queryParameters = null)
        {
            RefreshToken();
            CreateRequest(url, method);
            //AddMarketPlaceId();
            AddQueryParameters(queryParameters);
            AddAccessToken();
        }

        protected void CreateAuthorizedPagedRequest(AmazonFilter filter, string url, Method method)
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
            Request = TokenService.SignWithSTSKeysAndSecurityToken(Request, RequestClient.BaseUrl.Host, AmazonCredential.RoleArn, AmazonCredential.AccessKey, AmazonCredential.SecretKey);
            var response = RequestClient.Execute<T>(Request);
            //response.Headers
            ///TODO
            ///x-amzn-RateLimit-Limit
            ///https://github.com/gilyas/selling-partner-api-bootstrap/blob/2f075c1690882bdc3b1e8e916f67ec88f14b36d1/lambda/src/main/java/cn/amazon/aws/rp/spapi/lambda/requestlimiter/ApiProxy.java#L147

            ParseResponse(response);
            if (response.StatusCode==HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content) && response.Data == null)
            {
                response.Data = JsonConvert.DeserializeObject<T>(response.Content);
            }
            return response.Data;
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
            if (response.StatusCode == HttpStatusCode.OK)
                return;
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new NotFoundException("Resource that you are looking for is not found", response);
            else
                throw new AmazonException("Amazon Api didn't respond with Okay, see exception for more details", response);
        }

        protected void AddMarketPlaceId()
        {
            Request.AddQueryParameter(MarketPlaceParam.ToString(), MarketPlace.ID);
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

        protected void AddAccessToken()
        {
            Request.AddHeader("x-amz-access-token", AccessToken);
        }

        protected void RefreshToken()
        {
            AccessToken = TokenService.RefreshAccessToken(AmazonCredential);
        }

    }

}
