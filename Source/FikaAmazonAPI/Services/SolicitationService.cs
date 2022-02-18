using FikaAmazonAPI.AmazonSpApiSDK.Models.Solicitations;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class SolicitationService : RequestService
    {
        public SolicitationService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public GetSolicitationActionsForOrderResponseEmbedded GetSolicitationActionsForOrder(string orderId, List<KeyValuePair<string, string>> queryParameters = null) =>
            GetSolicitationActionsForOrderAsync(orderId, queryParameters).GetAwaiter().GetResult();
        public async Task<GetSolicitationActionsForOrderResponseEmbedded> GetSolicitationActionsForOrderAsync(string orderId, List<KeyValuePair<string, string>> queryParameters = null)
        {
            await CreateAuthorizedRequestAsync(SolicitationsApiUrls.GetSolicitationActionsForOrder(orderId), RestSharp.Method.GET, queryParameters);
            var response = await ExecuteRequestAsync<GetSolicitationActionsForOrderResponse>(RateLimitType.Solicitations_GetSolicitationActionsForOrder);
            return response.Embedded;
        }

        public GetSolicitationActionsForOrderResponseEmbedded CreateProductReviewAndSellerFeedbackSolicitation(string orderId, List<KeyValuePair<string, string>> queryParameters = null) =>
            CreateProductReviewAndSellerFeedbackSolicitationAsync(orderId, queryParameters).GetAwaiter().GetResult();
        public async Task<GetSolicitationActionsForOrderResponseEmbedded> CreateProductReviewAndSellerFeedbackSolicitationAsync(string orderId, List<KeyValuePair<string, string>> queryParameters = null)
        {
            await CreateAuthorizedRequestAsync(SolicitationsApiUrls.CreateProductReviewAndSellerFeedbackSolicitation(orderId), RestSharp.Method.POST, queryParameters);
            var response = await ExecuteRequestAsync<GetSolicitationActionsForOrderResponse>(RateLimitType.Solicitations_CreateProductReviewAndSellerFeedbackSolicitation);
            return response.Embedded;
        }
    }
}
