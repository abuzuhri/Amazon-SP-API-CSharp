using FikaAmazonAPI.AmazonSpApiSDK.Models.Finances;
using FikaAmazonAPI.Parameter.Finance;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;

namespace FikaAmazonAPI.Services
{
    public class FinancialService : RequestService
    {
        public FinancialService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public IList<FinancialEventGroup> ListFinancialEventGroups(ParameterListFinancialEventGroup  parameterListFinancialEventGroup)
        {
            List<FinancialEventGroup> list = new List<FinancialEventGroup>();

            var parameter = parameterListFinancialEventGroup.getParameters();

            CreateAuthorizedRequest(FinanceApiUrls.ListFinancialEventGroups , RestSharp.Method.GET, parameter);
            var response = ExecuteRequest<ListFinancialEventGroupsResponse>(RateLimitType.Financial_ListFinancialEventGroups);

            list.AddRange(response.Payload.FinancialEventGroupList);
            var nextToken = response.Payload.NextToken;
            
            while (!string.IsNullOrEmpty(nextToken))
            {
                var data = GetFinancialEventGroupListByNextToken(nextToken);
                list.AddRange(data.FinancialEventGroupList);
                nextToken = data.NextToken;
            }

            return list;
        }

        public ListFinancialEventGroupsPayload GetFinancialEventGroupListByNextToken(string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            CreateAuthorizedRequest(FinanceApiUrls.ListFinancialEventGroups, RestSharp.Method.GET, queryParameters);
            var response = ExecuteRequest<ListFinancialEventGroupsResponse>(RateLimitType.Financial_ListFinancialEventGroups);
            return response.Payload;
        }


        public FinancialEvents ListFinancialEventsByGroupId(string eventGroupId)
        {
            CreateAuthorizedRequest(FinanceApiUrls.ListFinancialEventsByGroupId(eventGroupId), RestSharp.Method.GET);
            var response = ExecuteRequest<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEventsByGroupId);
            return response.Payload.FinancialEvents;
        }

        public FinancialEvents ListFinancialEventsByOrderId(string orderId)
        {
            CreateAuthorizedRequest(FinanceApiUrls.ListFinancialEventsByOrderId(orderId), RestSharp.Method.GET);
            var response = ExecuteRequest<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEventsByOrderId);
            return response.Payload.FinancialEvents;
        }

        public FinancialEvents ListFinancialEvents()
        {
            CreateAuthorizedRequest(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.GET);
            var response = ExecuteRequest<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents);
            return response.Payload.FinancialEvents;
        }

        public IList<FinancialEvents> ListFinancialEvents(ParameterListFinancialEvents parameterListFinancials)
        {
            List<FinancialEvents> list = new List<FinancialEvents>();

            var parameter = parameterListFinancials.getParameters();

            CreateAuthorizedRequest(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.GET, parameter);
            var response = ExecuteRequest<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents);

            list.Add(response.Payload.FinancialEvents);
            var nextToken = response.Payload.NextToken;

            while (!string.IsNullOrEmpty(nextToken))
            {
                var data = GetFinancialEventsByNextToken(nextToken);
                list.Add(data.FinancialEvents);
                nextToken = data.NextToken;
            }

            return list;
        }

        private ListFinancialEventsPayload GetFinancialEventsByNextToken(string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            CreateAuthorizedRequest(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.GET, queryParameters);
            var response = ExecuteRequest<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents);
            return response.Payload;
        }


    }
}
