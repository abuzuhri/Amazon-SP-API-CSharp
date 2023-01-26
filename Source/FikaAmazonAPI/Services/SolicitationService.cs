using FikaAmazonAPI.AmazonSpApiSDK.Models.Solicitations;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class SolicitationService : RequestService
    {
        public SolicitationService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public GetSolicitationActionsForOrderResponseEmbedded GetSolicitationActionsForOrder(string orderId, List<KeyValuePair<string, string>> queryParameters = null) =>
            Task.Run(() => GetSolicitationActionsForOrderAsync(orderId, queryParameters)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetSolicitationActionsForOrderResponseEmbedded> GetSolicitationActionsForOrderAsync(string orderId, List<KeyValuePair<string, string>> queryParameters = null, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(SolicitationsApiUrls.GetSolicitationActionsForOrder(orderId), RestSharp.Method.Get, queryParameters, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetSolicitationActionsForOrderResponse>(RateLimitType.Solicitations_GetSolicitationActionsForOrder, cancellationToken);
            return response.Embedded;
        }

        public GetSolicitationActionsForOrderResponseEmbedded CreateProductReviewAndSellerFeedbackSolicitation(string orderId, List<KeyValuePair<string, string>> queryParameters = null) =>
            Task.Run(() => CreateProductReviewAndSellerFeedbackSolicitationAsync(orderId, queryParameters)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetSolicitationActionsForOrderResponseEmbedded> CreateProductReviewAndSellerFeedbackSolicitationAsync(string orderId, List<KeyValuePair<string, string>> queryParameters = null, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(SolicitationsApiUrls.CreateProductReviewAndSellerFeedbackSolicitation(orderId), RestSharp.Method.Post, queryParameters, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetSolicitationActionsForOrderResponse>(RateLimitType.Solicitations_CreateProductReviewAndSellerFeedbackSolicitation, cancellationToken);
            return response.Embedded;
        }
    }
}
