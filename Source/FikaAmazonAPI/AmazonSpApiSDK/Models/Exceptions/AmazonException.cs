﻿using RestSharp;
using System;
using System.Net;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Exceptions
{
    public class AmazonException : Exception
    {
        public ExceptionResponse Response { get; set; }

        public AmazonException(string msg, RestResponse response = null) : base(msg)
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
        public AmazonNotFoundException(string msg, RestResponse response = null) : base(msg, response)
        {

        }
    }

    public class AmazonUnauthorizedException : AmazonException
    {
        public AmazonUnauthorizedException(string msg, RestResponse response = null) : base(msg, response)
        {

        }
    }

    public class AmazonInvalidInputException : AmazonException
    {
        public AmazonInvalidInputException(string msg, RestResponse response = null) : base(msg, response)
        {

        }
    }
    public class AmazonQuotaExceededException : AmazonException
    {
        public AmazonQuotaExceededException(string msg, RestResponse response = null) : base(msg, response)
        {

        }
    }

    public class AmazonInvalidSignatureException : AmazonException
    {
        public AmazonInvalidSignatureException(string msg, RestResponse response = null) : base(msg, response)
        {

        }
    }

    public class AmazonProcessingReportDeserializeException : AmazonException
    {
        public string ReportContent { get; set; }
        public AmazonProcessingReportDeserializeException(string msg, string reportContent, RestResponse response = null) : base(msg, response)
        {
            ReportContent = reportContent;
        }
    }

    public class ExceptionResponse
    {
        public string Content { get; set; }
        public HttpStatusCode? ResponseCode { get; set; }
    }
}
