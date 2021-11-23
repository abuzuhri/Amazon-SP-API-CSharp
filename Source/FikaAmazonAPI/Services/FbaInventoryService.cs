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
            var nextToken = response.Pagination?.NextToken;// Pagination is Null at last page
            list.Add(response.Payload.InventorySummaries);
            while (!string.IsNullOrEmpty(nextToken))
            {
                var nextresponse = GetInventorySummariesByNextToken(nextToken,ParameterGetInventorySummaries);
                list.Add(nextresponse.Payload.InventorySummaries);
                nextToken = nextresponse.Pagination?.NextToken;
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
