using FikaAmazonAPI.AmazonSpApiSDK.Models;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Solicitations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class SolicitationService : RequestService
    {
        public SolicitationService(AmazonCredential amazonCredential) : base(amazonCredential)
        {
            
        }


        public GetSolicitationActionsForOrderResponseEmbedded GetSolicitationActionsForOrder(string orderId, List<KeyValuePair<string, string>> queryParameters = null)
        {
            CreateAuthorizedRequest(SolicitationsApiUrls.GetSolicitationActionsForOrder(orderId), RestSharp.Method.GET, queryParameters);
            var response = ExecuteRequest<GetSolicitationActionsForOrderResponse>();
            return response.Embedded;
        }
        public GetSolicitationActionsForOrderResponseEmbedded CreateProductReviewAndSellerFeedbackSolicitation(string orderId, List<KeyValuePair<string, string>> queryParameters = null)
        {
            CreateAuthorizedRequest(SolicitationsApiUrls.CreateProductReviewAndSellerFeedbackSolicitation(orderId), RestSharp.Method.POST, queryParameters);
            var response = ExecuteRequest<GetSolicitationActionsForOrderResponse>();
            return response.Embedded;
        }
    }
}
