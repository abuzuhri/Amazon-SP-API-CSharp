using FikaAmazonAPI.AmazonSpApiSDK.Models.FbaInventory;
using FikaAmazonAPI.Parameter.FbaInventory;
using System;
using System.Collections.Generic;
using System.Text;

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
                    var getInventorySummaries = GetInventorySummariesByNextToken(nextToken);
                    list.Add(getInventorySummaries.Payload.InventorySummaries);
                    nextToken = getInventorySummaries.Pagination?.NextToken;
                }
            }
            return list;
        }

        private GetInventorySummariesResponse GetInventorySummariesByNextToken(string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            CreateAuthorizedRequest(FinanceApiUrls.ListFinancialEventGroups, RestSharp.Method.GET, queryParameters);
            var response = ExecuteRequest<GetInventorySummariesResponse>();
            return response;
        }
    }
}
