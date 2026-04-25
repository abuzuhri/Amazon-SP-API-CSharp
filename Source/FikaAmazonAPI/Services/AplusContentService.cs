using FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    /// <summary>
    /// A+ Content API v2020-11-01 — manage A+ Content documents on product detail pages.
    /// All operations share a rate limit of 10 req/s, burst 10. The list / search operations
    /// auto-page internally and return flat lists.
    /// </summary>
    public class AplusContentService : RequestService
    {
        public AplusContentService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {
        }

        // -- searchContentDocuments ---------------------------------------------------

        public IList<ContentMetadataRecord> SearchContentDocuments(string marketplaceId = null) =>
            Task.Run(() => SearchContentDocumentsAsync(marketplaceId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<ContentMetadataRecord>> SearchContentDocumentsAsync(string marketplaceId = null, CancellationToken cancellationToken = default)
        {
            var marketplace = string.IsNullOrEmpty(marketplaceId) ? AmazonCredential.MarketPlace.ID : marketplaceId;
            var records = new List<ContentMetadataRecord>();
            string nextToken = null;

            do
            {
                var query = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("marketplaceId", marketplace),
                };
                if (!string.IsNullOrEmpty(nextToken))
                    query.Add(new KeyValuePair<string, string>("pageToken", nextToken));

                await CreateAuthorizedRequestAsync(AplusContentApiUrls.SearchContentDocuments, RestSharp.Method.Get, query, cancellationToken: cancellationToken);
                var response = await ExecuteRequestAsync<SearchContentDocumentsResponse>(RateLimitType.AplusContent_SearchContentDocuments, cancellationToken);
                if (response?.ContentMetadataRecords != null) records.AddRange(response.ContentMetadataRecords);
                nextToken = response?.NextPageToken;
            } while (!string.IsNullOrEmpty(nextToken));

            return records;
        }

        // -- createContentDocument ----------------------------------------------------

        public PostContentDocumentResponse CreateContentDocument(PostContentDocumentRequest request, string marketplaceId = null) =>
            Task.Run(() => CreateContentDocumentAsync(request, marketplaceId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<PostContentDocumentResponse> CreateContentDocumentAsync(PostContentDocumentRequest request, string marketplaceId = null, CancellationToken cancellationToken = default)
        {
            if (request?.ContentDocument == null)
                throw new InvalidDataException("request.ContentDocument is required");

            var query = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("marketplaceId", string.IsNullOrEmpty(marketplaceId) ? AmazonCredential.MarketPlace.ID : marketplaceId),
            };
            await CreateAuthorizedRequestAsync(AplusContentApiUrls.CreateContentDocument, RestSharp.Method.Post, query, postJsonObj: request, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<PostContentDocumentResponse>(RateLimitType.AplusContent_CreateContentDocument, cancellationToken);
        }

        // -- getContentDocument -------------------------------------------------------

        public GetContentDocumentResponse GetContentDocument(string contentReferenceKey, IList<AplusIncludedDataType> includedDataSet, string marketplaceId = null) =>
            Task.Run(() => GetContentDocumentAsync(contentReferenceKey, includedDataSet, marketplaceId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetContentDocumentResponse> GetContentDocumentAsync(string contentReferenceKey, IList<AplusIncludedDataType> includedDataSet, string marketplaceId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(contentReferenceKey))
                throw new InvalidDataException("contentReferenceKey is required");
            if (includedDataSet == null || includedDataSet.Count == 0)
                throw new InvalidDataException("includedDataSet is required (at least one of CONTENTS, METADATA)");

            var query = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("marketplaceId", string.IsNullOrEmpty(marketplaceId) ? AmazonCredential.MarketPlace.ID : marketplaceId),
                new KeyValuePair<string, string>("includedDataSet", string.Join(",", includedDataSet)),
            };
            await CreateAuthorizedRequestAsync(AplusContentApiUrls.GetContentDocument(contentReferenceKey), RestSharp.Method.Get, query, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GetContentDocumentResponse>(RateLimitType.AplusContent_GetContentDocument, cancellationToken);
        }

        // -- updateContentDocument ----------------------------------------------------

        public PostContentDocumentResponse UpdateContentDocument(string contentReferenceKey, PostContentDocumentRequest request, string marketplaceId = null) =>
            Task.Run(() => UpdateContentDocumentAsync(contentReferenceKey, request, marketplaceId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<PostContentDocumentResponse> UpdateContentDocumentAsync(string contentReferenceKey, PostContentDocumentRequest request, string marketplaceId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(contentReferenceKey))
                throw new InvalidDataException("contentReferenceKey is required");
            if (request?.ContentDocument == null)
                throw new InvalidDataException("request.ContentDocument is required");

            var query = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("marketplaceId", string.IsNullOrEmpty(marketplaceId) ? AmazonCredential.MarketPlace.ID : marketplaceId),
            };
            await CreateAuthorizedRequestAsync(AplusContentApiUrls.UpdateContentDocument(contentReferenceKey), RestSharp.Method.Post, query, postJsonObj: request, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<PostContentDocumentResponse>(RateLimitType.AplusContent_UpdateContentDocument, cancellationToken);
        }

        // -- listContentDocumentAsinRelations ----------------------------------------

        public IList<AsinMetadata> ListContentDocumentAsinRelations(string contentReferenceKey, IList<AplusIncludedDataType> includedDataSet = null, IList<string> asins = null, string marketplaceId = null) =>
            Task.Run(() => ListContentDocumentAsinRelationsAsync(contentReferenceKey, includedDataSet, asins, marketplaceId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<AsinMetadata>> ListContentDocumentAsinRelationsAsync(string contentReferenceKey, IList<AplusIncludedDataType> includedDataSet = null, IList<string> asins = null, string marketplaceId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(contentReferenceKey))
                throw new InvalidDataException("contentReferenceKey is required");

            var marketplace = string.IsNullOrEmpty(marketplaceId) ? AmazonCredential.MarketPlace.ID : marketplaceId;
            var results = new List<AsinMetadata>();
            string nextToken = null;

            do
            {
                var query = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("marketplaceId", marketplace),
                };
                if (includedDataSet != null && includedDataSet.Count > 0)
                    query.Add(new KeyValuePair<string, string>("includedDataSet", string.Join(",", includedDataSet)));
                if (asins != null && asins.Count > 0)
                    query.Add(new KeyValuePair<string, string>("asinSet", string.Join(",", asins)));
                if (!string.IsNullOrEmpty(nextToken))
                    query.Add(new KeyValuePair<string, string>("pageToken", nextToken));

                await CreateAuthorizedRequestAsync(AplusContentApiUrls.ListContentDocumentAsinRelations(contentReferenceKey), RestSharp.Method.Get, query, cancellationToken: cancellationToken);
                var response = await ExecuteRequestAsync<ListContentDocumentAsinRelationsResponse>(RateLimitType.AplusContent_ListContentDocumentAsinRelations, cancellationToken);
                if (response?.AsinMetadataSet != null) results.AddRange(response.AsinMetadataSet);
                nextToken = response?.NextPageToken;
            } while (!string.IsNullOrEmpty(nextToken));

            return results;
        }

        // -- postContentDocumentAsinRelations -----------------------------------------

        public PostContentDocumentAsinRelationsResponse PostContentDocumentAsinRelations(string contentReferenceKey, PostContentDocumentAsinRelationsRequest request, string marketplaceId = null) =>
            Task.Run(() => PostContentDocumentAsinRelationsAsync(contentReferenceKey, request, marketplaceId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<PostContentDocumentAsinRelationsResponse> PostContentDocumentAsinRelationsAsync(string contentReferenceKey, PostContentDocumentAsinRelationsRequest request, string marketplaceId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(contentReferenceKey))
                throw new InvalidDataException("contentReferenceKey is required");
            if (request?.AsinSet == null || request.AsinSet.Count == 0)
                throw new InvalidDataException("request.AsinSet must contain at least one ASIN");

            var query = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("marketplaceId", string.IsNullOrEmpty(marketplaceId) ? AmazonCredential.MarketPlace.ID : marketplaceId),
            };
            await CreateAuthorizedRequestAsync(AplusContentApiUrls.PostContentDocumentAsinRelations(contentReferenceKey), RestSharp.Method.Post, query, postJsonObj: request, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<PostContentDocumentAsinRelationsResponse>(RateLimitType.AplusContent_PostContentDocumentAsinRelations, cancellationToken);
        }

        // -- validateContentDocumentAsinRelations -------------------------------------

        public ValidateContentDocumentAsinRelationsResponse ValidateContentDocumentAsinRelations(PostContentDocumentRequest request, IList<string> asins = null, string marketplaceId = null) =>
            Task.Run(() => ValidateContentDocumentAsinRelationsAsync(request, asins, marketplaceId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ValidateContentDocumentAsinRelationsResponse> ValidateContentDocumentAsinRelationsAsync(PostContentDocumentRequest request, IList<string> asins = null, string marketplaceId = null, CancellationToken cancellationToken = default)
        {
            if (request?.ContentDocument == null)
                throw new InvalidDataException("request.ContentDocument is required");

            var query = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("marketplaceId", string.IsNullOrEmpty(marketplaceId) ? AmazonCredential.MarketPlace.ID : marketplaceId),
            };
            if (asins != null && asins.Count > 0)
                query.Add(new KeyValuePair<string, string>("asinSet", string.Join(",", asins)));

            await CreateAuthorizedRequestAsync(AplusContentApiUrls.ValidateContentDocumentAsinRelations, RestSharp.Method.Post, query, postJsonObj: request, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ValidateContentDocumentAsinRelationsResponse>(RateLimitType.AplusContent_ValidateContentDocumentAsinRelations, cancellationToken);
        }

        // -- searchContentPublishRecords ----------------------------------------------

        public IList<PublishRecord> SearchContentPublishRecords(string asin, string marketplaceId = null) =>
            Task.Run(() => SearchContentPublishRecordsAsync(asin, marketplaceId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<PublishRecord>> SearchContentPublishRecordsAsync(string asin, string marketplaceId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(asin))
                throw new InvalidDataException("asin is required");

            var marketplace = string.IsNullOrEmpty(marketplaceId) ? AmazonCredential.MarketPlace.ID : marketplaceId;
            var records = new List<PublishRecord>();
            string nextToken = null;

            do
            {
                var query = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("marketplaceId", marketplace),
                    new KeyValuePair<string, string>("asin", asin),
                };
                if (!string.IsNullOrEmpty(nextToken))
                    query.Add(new KeyValuePair<string, string>("pageToken", nextToken));

                await CreateAuthorizedRequestAsync(AplusContentApiUrls.SearchContentPublishRecords, RestSharp.Method.Get, query, cancellationToken: cancellationToken);
                var response = await ExecuteRequestAsync<SearchContentPublishRecordsResponse>(RateLimitType.AplusContent_SearchContentPublishRecords, cancellationToken);
                if (response?.PublishRecordList != null) records.AddRange(response.PublishRecordList);
                nextToken = response?.NextPageToken;
            } while (!string.IsNullOrEmpty(nextToken));

            return records;
        }

        // -- postContentDocumentApprovalSubmission ------------------------------------

        public PostContentDocumentApprovalSubmissionResponse PostContentDocumentApprovalSubmission(string contentReferenceKey, string marketplaceId = null) =>
            Task.Run(() => PostContentDocumentApprovalSubmissionAsync(contentReferenceKey, marketplaceId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<PostContentDocumentApprovalSubmissionResponse> PostContentDocumentApprovalSubmissionAsync(string contentReferenceKey, string marketplaceId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(contentReferenceKey))
                throw new InvalidDataException("contentReferenceKey is required");

            var query = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("marketplaceId", string.IsNullOrEmpty(marketplaceId) ? AmazonCredential.MarketPlace.ID : marketplaceId),
            };
            await CreateAuthorizedRequestAsync(AplusContentApiUrls.PostContentDocumentApprovalSubmission(contentReferenceKey), RestSharp.Method.Post, query, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<PostContentDocumentApprovalSubmissionResponse>(RateLimitType.AplusContent_PostContentDocumentApprovalSubmission, cancellationToken);
        }

        // -- postContentDocumentSuspendSubmission -------------------------------------

        public PostContentDocumentSuspendSubmissionResponse PostContentDocumentSuspendSubmission(string contentReferenceKey, string marketplaceId = null) =>
            Task.Run(() => PostContentDocumentSuspendSubmissionAsync(contentReferenceKey, marketplaceId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<PostContentDocumentSuspendSubmissionResponse> PostContentDocumentSuspendSubmissionAsync(string contentReferenceKey, string marketplaceId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(contentReferenceKey))
                throw new InvalidDataException("contentReferenceKey is required");

            var query = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("marketplaceId", string.IsNullOrEmpty(marketplaceId) ? AmazonCredential.MarketPlace.ID : marketplaceId),
            };
            await CreateAuthorizedRequestAsync(AplusContentApiUrls.PostContentDocumentSuspendSubmission(contentReferenceKey), RestSharp.Method.Post, query, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<PostContentDocumentSuspendSubmissionResponse>(RateLimitType.AplusContent_PostContentDocumentSuspendSubmission, cancellationToken);
        }
    }
}
