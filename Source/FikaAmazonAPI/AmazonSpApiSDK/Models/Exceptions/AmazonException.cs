using RestSharp;
using System;
using System.Net;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Exceptions
{
    public class AmazonException : Exception
    {
        public ExceptionResponse Response { get; set; }

        public AmazonException(string msg, IRestResponse response = null) : base(msg)
        {
            if (response != null)
            {
                Response = new ExceptionResponse();
                Response.Content = response.Content;
                Response.ResponseCode = response.StatusCode;
            }
        }

    }

    public class AmazonNotFoundException : AmazonException
    {
        public AmazonNotFoundException(string msg, IRestResponse response = null) : base(msg, response)
        {

        }
    }

    public class AmazonUnauthorizedException : AmazonException
    {
        public AmazonUnauthorizedException(string msg, IRestResponse response = null) : base(msg, response)
        {

        }
    }

    public class ExceptionResponse
    {
        public string Content { get; set; }
        public HttpStatusCode? ResponseCode { get; set; }
    }
}
