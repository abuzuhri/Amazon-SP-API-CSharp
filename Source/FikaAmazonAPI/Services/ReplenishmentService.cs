using FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    /// <summary>
    /// Replenishment API v2022-11-07 — Subscribe and Save program data.
    /// Operations: listOffers, listOfferMetrics, getSellingPartnerMetrics. Each is rate-limited
    /// to 1 req/s, burst 1.
    /// </summary>
    public class ReplenishmentService : RequestService
    {
        public ReplenishmentService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {
        }

        public ListOffersResponse ListOffers(ListOffersRequest request) =>
            Task.Run(() => ListOffersAsync(request)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ListOffersResponse> ListOffersAsync(ListOffersRequest request, CancellationToken cancellationToken = default)
        {
            ValidateListOffersRequest(request);
            await CreateAuthorizedRequestAsync(ReplenishmentApiUrls.ListOffers, RestSharp.Method.Post, postJsonObj: request, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListOffersResponse>(RateLimitType.Replenishment_ListOffers, cancellationToken);
        }

        public ListOfferMetricsResponse ListOfferMetrics(ListOfferMetricsRequest request) =>
            Task.Run(() => ListOfferMetricsAsync(request)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ListOfferMetricsResponse> ListOfferMetricsAsync(ListOfferMetricsRequest request, CancellationToken cancellationToken = default)
        {
            ValidateListOfferMetricsRequest(request);
            await CreateAuthorizedRequestAsync(ReplenishmentApiUrls.ListOfferMetrics, RestSharp.Method.Post, postJsonObj: request, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListOfferMetricsResponse>(RateLimitType.Replenishment_ListOfferMetrics, cancellationToken);
        }

        public GetSellingPartnerMetricsResponse GetSellingPartnerMetrics(GetSellingPartnerMetricsRequest request) =>
            Task.Run(() => GetSellingPartnerMetricsAsync(request)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetSellingPartnerMetricsResponse> GetSellingPartnerMetricsAsync(GetSellingPartnerMetricsRequest request, CancellationToken cancellationToken = default)
        {
            ValidateGetSellingPartnerMetricsRequest(request);
            await CreateAuthorizedRequestAsync(ReplenishmentApiUrls.GetSellingPartnerMetrics, RestSharp.Method.Post, postJsonObj: request, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GetSellingPartnerMetricsResponse>(RateLimitType.Replenishment_GetSellingPartnerMetrics, cancellationToken);
        }

        private static void ValidateListOffersRequest(ListOffersRequest request)
        {
            if (request == null)
                throw new InvalidDataException("request is required");
            if (request.Pagination == null)
                throw new InvalidDataException("request.Pagination is required");
            if (request.Filters == null)
                throw new InvalidDataException("request.Filters is required");
            if (string.IsNullOrEmpty(request.Filters.MarketplaceId))
                throw new InvalidDataException("request.Filters.MarketplaceId is required");
            if (request.Filters.ProgramTypes == null || request.Filters.ProgramTypes.Count == 0)
                throw new InvalidDataException("request.Filters.ProgramTypes must contain at least one ProgramType");
        }

        private static void ValidateListOfferMetricsRequest(ListOfferMetricsRequest request)
        {
            if (request == null)
                throw new InvalidDataException("request is required");
            if (request.Pagination == null)
                throw new InvalidDataException("request.Pagination is required");
            if (request.Filters == null)
                throw new InvalidDataException("request.Filters is required");
            if (request.Filters.TimeInterval == null)
                throw new InvalidDataException("request.Filters.TimeInterval is required");
            if (string.IsNullOrEmpty(request.Filters.MarketplaceId))
                throw new InvalidDataException("request.Filters.MarketplaceId is required");
            if (request.Filters.ProgramTypes == null || request.Filters.ProgramTypes.Count == 0)
                throw new InvalidDataException("request.Filters.ProgramTypes must contain at least one ProgramType");
        }

        private static void ValidateGetSellingPartnerMetricsRequest(GetSellingPartnerMetricsRequest request)
        {
            if (request == null)
                throw new InvalidDataException("request is required");
            if (request.TimeInterval == null)
                throw new InvalidDataException("request.TimeInterval is required");
            if (string.IsNullOrEmpty(request.MarketplaceId))
                throw new InvalidDataException("request.MarketplaceId is required");
            if (request.ProgramTypes == null || request.ProgramTypes.Count == 0)
                throw new InvalidDataException("request.ProgramTypes must contain at least one ProgramType");
        }
    }
}
