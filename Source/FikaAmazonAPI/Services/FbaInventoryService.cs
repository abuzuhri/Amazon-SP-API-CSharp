using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaInventory;
using FikaAmazonAPI.Parameter.FbaInventory;
using System.Collections.Generic;

namespace FikaAmazonAPI.Services
{
    public class FbaInventoryService : RequestService
    {

        public FbaInventoryService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public List<InventorySummaries> GetInventorySummaries(ParameterGetInventorySummaries ParameterGetInventorySummaries)
        {
            var list = new List<InventorySummaries>();
            var param = ParameterGetInventorySummaries.getParameters();

            CreateAuthorizedRequest(FbaInventoriesApiUrls.GetInventorySummaries, RestSharp.Method.GET, param);
            var response = ExecuteRequest<GetInventorySummariesResponse>();
            list.Add(response.Payload.InventorySummaries);
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken))
                {
                    var getInventorySummaries = GetInventorySummariesByNextToken(nextToken, ParameterGetInventorySummaries);
                    list.Add(getInventorySummaries.Payload.InventorySummaries);
                    nextToken = getInventorySummaries.Pagination?.NextToken;
                }
            }
            return list;
        }

        private GetInventorySummariesResponse GetInventorySummariesByNextToken(string nextToken,ParameterGetInventorySummaries parameterGetInventorySummaries)
        {
            parameterGetInventorySummaries.nextToken = nextToken;
            var param = parameterGetInventorySummaries.getParameters();

            CreateAuthorizedRequest(FbaInventoriesApiUrls.GetInventorySummaries, RestSharp.Method.GET, param);
            var response = ExecuteRequest<GetInventorySummariesResponse>();

            return response;
        }
    }
}
