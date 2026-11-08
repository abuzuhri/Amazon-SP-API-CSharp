using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using FikaAmazonAPI.AmazonSpApiSDK.Models.Support;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Parameter.Support;
using FikaAmazonAPI.Utils;

using Microsoft.Extensions.Logging;

using Method = FikaAmazonAPI.RestSharp.Method;

namespace FikaAmazonAPI.Services
{
    /// <summary>
    /// Selling Partner API for Support v2025-02-01. Retrieves support cases and their contact history.
    /// Requires the Selling Partner Support (Restricted) role.
    /// </summary>
    public class SupportService : RequestService
    {
        public SupportService(AmazonCredential amazonCredential, ILoggerFactory loggerFactory) : base(amazonCredential, loggerFactory)
        {
        }

        #region ListCases

        public List<Case> ListCases(ParameterListCases parameterListCases) =>
            Task.Run(() => ListCasesAsync(parameterListCases)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Case>> ListCasesAsync(ParameterListCases parameterListCases, CancellationToken ct = default)
        {
            ValidateListCases(parameterListCases);

            List<Case> list = new List<Case>();

            var response = await ListCasesByNextTokenAsync(parameterListCases, ct);
            if (response?.Cases != null)
                list.AddRange(response.Cases);

            // Surface the token on the parameter object so callers can continue manually
            // via ListCasesByNextToken, even when MaxNumberOfPages stops the loop below.
            parameterListCases.NextToken = response?.NextToken;

            var totalPages = 1;
            while (!string.IsNullOrEmpty(parameterListCases.NextToken) &&
                (!parameterListCases.MaxNumberOfPages.HasValue || totalPages < parameterListCases.MaxNumberOfPages.Value))
            {
                var listCasesNextPage = await ListCasesByNextTokenAsync(parameterListCases, ct);
                if (listCasesNextPage?.Cases != null)
                    list.AddRange(listCasesNextPage.Cases);
                parameterListCases.NextToken = listCasesNextPage?.NextToken;
                totalPages++;
            }

            return list;
        }

        public ListCasesResult ListCasesByNextToken(ParameterListCases parameterListCases) =>
            Task.Run(() => ListCasesByNextTokenAsync(parameterListCases)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ListCasesResult> ListCasesByNextTokenAsync(ParameterListCases parameterListCases, CancellationToken ct = default)
        {
            ValidateListCases(parameterListCases);

            await CreateAuthorizedRequestAsync(SupportApiUrls.Cases, Method.Post, null, parameterListCases.ToRequest(), CacheTokenData.TokenDataType.Normal, null, ct);
            return await ExecuteRequestAsync<ListCasesResult>(RateLimitType.Support_ListCases, ct);
        }

        #endregion

        public Case GetCase(string caseId) =>
            Task.Run(() => GetCaseAsync(caseId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Case> GetCaseAsync(string caseId, CancellationToken ct = default)
        {
            ValidateCaseId(caseId);

            await CreateAuthorizedRequestAsync(SupportApiUrls.Case(caseId), Method.Get, null, null, CacheTokenData.TokenDataType.Normal, null, ct);
            return await ExecuteRequestAsync<Case>(RateLimitType.Support_GetCase, ct);
        }

        #region ListContacts

        public List<Contact> ListContacts(string caseId, ParameterListContacts parameterListContacts = null) =>
            Task.Run(() => ListContactsAsync(caseId, parameterListContacts)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Contact>> ListContactsAsync(string caseId, ParameterListContacts parameterListContacts = null, CancellationToken ct = default)
        {
            parameterListContacts ??= new ParameterListContacts();
            ValidateListContacts(caseId, parameterListContacts);

            List<Contact> list = new List<Contact>();

            var response = await ListContactsByNextTokenAsync(caseId, parameterListContacts, ct);
            if (response?.Contacts != null)
                list.AddRange(response.Contacts);

            // Surface the token on the parameter object so callers can continue manually
            // via ListContactsByNextToken, even when MaxNumberOfPages stops the loop below.
            parameterListContacts.NextToken = response?.NextToken;

            var totalPages = 1;
            while (!string.IsNullOrEmpty(parameterListContacts.NextToken) &&
                (!parameterListContacts.MaxNumberOfPages.HasValue || totalPages < parameterListContacts.MaxNumberOfPages.Value))
            {
                var listContactsNextPage = await ListContactsByNextTokenAsync(caseId, parameterListContacts, ct);
                if (listContactsNextPage?.Contacts != null)
                    list.AddRange(listContactsNextPage.Contacts);
                parameterListContacts.NextToken = listContactsNextPage?.NextToken;
                totalPages++;
            }

            return list;
        }

        public ListContactsResult ListContactsByNextToken(string caseId, ParameterListContacts parameterListContacts) =>
            Task.Run(() => ListContactsByNextTokenAsync(caseId, parameterListContacts)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ListContactsResult> ListContactsByNextTokenAsync(string caseId, ParameterListContacts parameterListContacts, CancellationToken ct = default)
        {
            ValidateListContacts(caseId, parameterListContacts);

            var parameter = parameterListContacts.getParameters();
            await CreateAuthorizedRequestAsync(SupportApiUrls.Contacts(caseId), Method.Get, parameter, null, CacheTokenData.TokenDataType.Normal, null, ct);
            return await ExecuteRequestAsync<ListContactsResult>(RateLimitType.Support_ListContacts, ct);
        }

        #endregion

        internal static void ValidateListCases(ParameterListCases parameterListCases)
        {
            if (parameterListCases == null)
                throw new InvalidDataException("parameterListCases is required");

            ValidateMaxResults(parameterListCases.MaxResults);

            var subjectKeywords = parameterListCases.CaseFilters?.SubjectKeywords;
            if (subjectKeywords != null && (subjectKeywords.Length < 1 || subjectKeywords.Length > 200))
                throw new InvalidDataException("CaseFilters.SubjectKeywords must be between 1 and 200 characters");
        }

        internal static void ValidateListContacts(string caseId, ParameterListContacts parameterListContacts)
        {
            ValidateCaseId(caseId);

            if (parameterListContacts == null)
                throw new InvalidDataException("parameterListContacts is required");

            ValidateMaxResults(parameterListContacts.MaxResults);
        }

        private static void ValidateCaseId(string caseId)
        {
            if (string.IsNullOrWhiteSpace(caseId))
                throw new InvalidDataException("caseId is required");
        }

        private static void ValidateMaxResults(int? maxResults)
        {
            if (maxResults.HasValue && (maxResults.Value < 1 || maxResults.Value > 50))
                throw new InvalidDataException("MaxResults must be between 1 and 50");
        }
    }
}
