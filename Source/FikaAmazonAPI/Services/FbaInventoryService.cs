using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaInventory;
using FikaAmazonAPI.Parameter.FbaInventory;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;

namespace FikaAmazonAPI.Services
{
    public class FbaInventoryService : RequestService
    {

        public FbaInventoryService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public List<InventorySummaries> GetInventorySummaries(ParameterGetInventorySummaries parameter)
        {
            if (parameter.marketplaceIds == null || parameter.marketplaceIds.Count == 0)
            {
                parameter.marketplaceIds = new List<string>();
                parameter.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);
            }

            var list = new List<InventorySummaries>();
            var param = parameter.getParameters();

            CreateAuthorizedRequest(FbaInventoriesApiUrls.GetInventorySummaries, RestSharp.Method.GET, param);
            var response = ExecuteRequest<GetInventorySummariesResponse>(RateLimitType.FbaInventory_GetInventorySummaries);
            list.Add(response.Payload.InventorySummaries);
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken))
                {
                    var getInventorySummaries = GetInventorySummariesByNextToken(nextToken, parameter);
                    list.Add(getInventorySummaries.Payload.InventorySummaries);
                    nextToken = getInventorySummaries.Pagination?.NextToken;
                }
            }
            return list;
        }

        private GetInventorySummariesResponse GetInventorySummariesByNextToken(string nextToken, ParameterGetInventorySummaries parameterGetInventorySummaries)
        {
            parameterGetInventorySummaries.nextToken = nextToken;
            var param = parameterGetInventorySummaries.getParameters();

            CreateAuthorizedRequest(FbaInventoriesApiUrls.GetInventorySummaries, RestSharp.Method.GET, param);
            var response = ExecuteRequest<GetInventorySummariesResponse>(RateLimitType.FbaInventory_GetInventorySummaries);

            return response;
        }
    }
}
