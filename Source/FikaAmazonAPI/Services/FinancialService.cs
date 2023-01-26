using FikaAmazonAPI.AmazonSpApiSDK.Models.Finances;
using FikaAmazonAPI.Parameter.Finance;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading;
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

        public async Task<IList<FinancialEventGroup>> ListFinancialEventGroupsAsync(ParameterListFinancialEventGroup parameterListFinancialEventGroup, CancellationToken cancellationToken = default)
        {
            List<FinancialEventGroup> list = new List<FinancialEventGroup>();

            var parameter = parameterListFinancialEventGroup.getParameters();

            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventGroups, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventGroupsResponse>(RateLimitType.Financial_ListFinancialEventGroups, cancellationToken);

            list.AddRange(response.Payload.FinancialEventGroupList);
            var nextToken = response.Payload.NextToken;

            while (!string.IsNullOrEmpty(nextToken))
            {
                var data = await GetFinancialEventGroupListByNextTokenAsync(nextToken, cancellationToken);
                list.AddRange(data.FinancialEventGroupList);
                nextToken = data.NextToken;
            }

            return list;
        }

        public ListFinancialEventGroupsPayload GetFinancialEventGroupListByNextToken(string nextToken) =>
            Task.Run(() => GetFinancialEventGroupListByNextTokenAsync(nextToken)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ListFinancialEventGroupsPayload> GetFinancialEventGroupListByNextTokenAsync(string nextToken, CancellationToken cancellationToken = default)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventGroups, RestSharp.Method.Get, queryParameters, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventGroupsResponse>(RateLimitType.Financial_ListFinancialEventGroups, cancellationToken);
            return response.Payload;
        }


        public List<FinancialEvents> ListFinancialEventsByGroupId(string eventGroupId) =>
                Task.Run(() => ListFinancialEventsByGroupIdAsync(eventGroupId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<FinancialEvents>> ListFinancialEventsByGroupIdAsync(string eventGroupId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventsByGroupId(eventGroupId), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEventsByGroupId, cancellationToken);

            var nextToken = response.Payload.NextToken;

            var list = new List<FinancialEvents>();
            list.Add(response.Payload.FinancialEvents);

            while (!string.IsNullOrEmpty(nextToken))
            {
                var data = await ListFinancialEventsByGroupIdByNextTokenAsync(eventGroupId, nextToken, cancellationToken);
                if (data.Payload != null && data.Payload.FinancialEvents != null)
                {
                    list.Add(data.Payload.FinancialEvents);
                }
                nextToken = data.Payload.NextToken;
            }

            return list;
        }
        private async Task<ListFinancialEventsResponse> ListFinancialEventsByGroupIdByNextTokenAsync(string eventGroupId, string nextToken, CancellationToken cancellationToken = default)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventsByGroupId(eventGroupId), RestSharp.Method.Get, queryParameters, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEventsByGroupId, cancellationToken);
        }

        public FinancialEvents ListFinancialEventsByOrderId(string orderId) =>
            Task.Run(() => ListFinancialEventsByOrderIdAsync(orderId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FinancialEvents> ListFinancialEventsByOrderIdAsync(string orderId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEventsByOrderId(orderId), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEventsByOrderId, cancellationToken);
            return response.Payload.FinancialEvents;
        }

        public FinancialEvents ListFinancialEvents() =>
            Task.Run(() => ListFinancialEventsAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FinancialEvents> ListFinancialEventsAsync(CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents, cancellationToken);
            return response.Payload.FinancialEvents;
        }

        public IList<FinancialEvents> ListFinancialEvents(ParameterListFinancialEvents parameterListFinancials) =>
            Task.Run(() => ListFinancialEventsAsync(parameterListFinancials)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<FinancialEvents>> ListFinancialEventsAsync(ParameterListFinancialEvents parameterListFinancials, CancellationToken cancellationToken = default)
        {
            List<FinancialEvents> list = new List<FinancialEvents>();

            var parameter = parameterListFinancials.getParameters();

            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents, cancellationToken);

            list.Add(response.Payload.FinancialEvents);
            var nextToken = response.Payload.NextToken;
            int countPages = 1;
            while (!string.IsNullOrEmpty(nextToken) &&
                        ((!parameterListFinancials.MaxNumberOfPages.HasValue)
                            || (parameterListFinancials.MaxNumberOfPages.HasValue && parameterListFinancials.MaxNumberOfPages > countPages)))
            {
                var data = await GetFinancialEventsByNextTokenAsync(nextToken, cancellationToken);
                list.Add(data.FinancialEvents);
                nextToken = data.NextToken;
                countPages++;
            }

            return list;
        }

        private ListFinancialEventsPayload GetFinancialEventsByNextToken(string nextToken) =>
            Task.Run(() => GetFinancialEventsByNextTokenAsync(nextToken)).ConfigureAwait(false).GetAwaiter().GetResult();

        private async Task<ListFinancialEventsPayload> GetFinancialEventsByNextTokenAsync(string nextToken, CancellationToken cancellationToken = default)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));


            await CreateAuthorizedRequestAsync(FinanceApiUrls.ListFinancialEvents, RestSharp.Method.Get, queryParameters, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListFinancialEventsResponse>(RateLimitType.Financial_ListFinancialEvents, cancellationToken);
            return response.Payload;
        }


    }
}
