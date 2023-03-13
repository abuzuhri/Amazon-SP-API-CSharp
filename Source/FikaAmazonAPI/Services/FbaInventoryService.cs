using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaInventory;
using FikaAmazonAPI.Parameter.FbaInventory;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class FbaInventoryService : RequestService
    {

        public FbaInventoryService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public List<InventorySummaries> GetInventorySummaries(ParameterGetInventorySummaries parameter) =>
            Task.Run(() => GetInventorySummariesAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<InventorySummaries>> GetInventorySummariesAsync(ParameterGetInventorySummaries parameter, CancellationToken cancellationToken = default)
        {
            if (parameter.marketplaceIds == null || parameter.marketplaceIds.Count == 0)
            {
                parameter.marketplaceIds = new List<string>();
                parameter.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);
            }

            var list = new List<InventorySummaries>();
            var param = parameter.getParameters();

            await CreateAuthorizedRequestAsync(FbaInventoriesApiUrls.GetInventorySummaries, RestSharp.Method.Get, param, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetInventorySummariesResponse>(RateLimitType.FbaInventory_GetInventorySummaries, cancellationToken);
            list.Add(response.Payload.InventorySummaries);
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken))
                {
					var getInventorySummaries = await GetInventorySummariesByNextTokenAsync(nextToken, parameter, cancellationToken);
                    list.Add(getInventorySummaries.Payload.InventorySummaries);
                    nextToken = getInventorySummaries.Pagination?.NextToken;
                }
            }
            return list;
        }

        public GetInventorySummariesResponse GetInventorySummariesByNextToken(string nextToken, ParameterGetInventorySummaries parameterGetInventorySummaries) =>
            Task.Run(() => GetInventorySummariesByNextTokenAsync(nextToken, parameterGetInventorySummaries)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetInventorySummariesResponse> GetInventorySummariesByNextTokenAsync(string nextToken, ParameterGetInventorySummaries parameterGetInventorySummaries, CancellationToken cancellationToken = default)
        {
            parameterGetInventorySummaries.nextToken = nextToken;
            var param = parameterGetInventorySummaries.getParameters();

            await CreateAuthorizedRequestAsync(FbaInventoriesApiUrls.GetInventorySummaries, RestSharp.Method.Get, param, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetInventorySummariesResponse>(RateLimitType.FbaInventory_GetInventorySummaries, cancellationToken);

            return response;
        }
    }
}
