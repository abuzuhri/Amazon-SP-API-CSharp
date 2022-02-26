using FikaAmazonAPI.AmazonSpApiSDK.Models.Finances;
using FikaAmazonAPI.Parameter.Finance;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class FinancialService : RequestService
    {
        public FinancialService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public IList<FinancialEventGroup> ListFinancialEventGroups(ParameterListFinancialEventGroup parameterListFinancialEventGroup) =>
            Task.Run(() => ListFinancialEventGroupsAsync(parameterListFinancialEventGroup)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<FinancialEventGroup>> ListFinancialEventGroupsAsync(ParameterListFinancialEventGroup parameterListFinancialEventGroup)
        {
            List<FinancialEventGroup> list = new List<FinancialEventGroup>();

            var parameter = parameterListFinancialEventGroup.getParameters();

            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventGroups, RestSharp.Method.GET, parameter);
            var response = await ExecuteRequestAsync<ListFinancialEventGroupsResponse>(RateLimitType.Financial_ListFinancialEventGroups);

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

        public ListFinancialEventGroupsPayload GetFinancialEventGroupListByNextToken(string nextToken) =>
            Task.Run(() => GetFinancialEventGroupListByNextTokenAsync(nextToken)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ListFinancialEventGroupsPayload> GetFinancialEventGroupListByNextTokenAsync(string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventGroups, RestSharp.Method.GET, queryParameters);
            var response = await ExecuteRequestAsync<ListFinancialEventGroupsResponse>(RateLimitType.Financial_ListFinancialEventGroups);
            return response.Payload;
        }


        public FinancialEvents ListFinancialEventsByGroupId(string eventGroupId) =>
                Task.Run(() => ListFinancialEventsByGroupIdAsync(eventGroupId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<FinancialEvents> ListFinancialEventsByGroupIdAsync(string eventGroupId)
        {
            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventsByGroupId(eventGroupId), RestSharp.Method.GET);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEventsByGroupId);
            return response.Payload.FinancialEvents;
        }

        public FinancialEvents ListFinancialEventsByOrderId(string orderId) =>
            Task.Run(() => ListFinancialEventsByOrderIdAsync(orderId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FinancialEvents> ListFinancialEventsByOrderIdAsync(string orderId)
        {
            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventsByOrderId(orderId), RestSharp.Method.GET);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEventsByOrderId);
            return response.Payload.FinancialEvents;
        }

        public FinancialEvents ListFinancialEvents() =>
            Task.Run(() => ListFinancialEventsAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FinancialEvents> ListFinancialEventsAsync()
        {
            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.GET);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents);
            return response.Payload.FinancialEvents;
        }

        public IList<FinancialEvents> ListFinancialEvents(ParameterListFinancialEvents parameterListFinancials) =>
            Task.Run(() => ListFinancialEventsAsync(parameterListFinancials)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<FinancialEvents>> ListFinancialEventsAsync(ParameterListFinancialEvents parameterListFinancials)
        {
            List<FinancialEvents> list = new List<FinancialEvents>();

            var parameter = parameterListFinancials.getParameters();

            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.GET, parameter);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents);

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

        private ListFinancialEventsPayload GetFinancialEventsByNextToken(string nextToken) =>
            Task.Run(() => GetFinancialEventsByNextTokenAsync(nextToken)).ConfigureAwait(false).GetAwaiter().GetResult();

        private async Task<ListFinancialEventsPayload> GetFinancialEventsByNextTokenAsync(string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.GET, queryParameters);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents);
            return response.Payload;
        }


    }
}
