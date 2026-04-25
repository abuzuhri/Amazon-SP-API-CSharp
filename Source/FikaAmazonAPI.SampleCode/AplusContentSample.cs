using FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
    public class AplusContentSample
    {
        AmazonConnection amazonConnection;
        public AplusContentSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        /// <summary>List every A+ Content document on the seller account (auto-paged).</summary>
        public async Task<IList<ContentMetadataRecord>> ListAllDocumentsAsync()
        {
            return await amazonConnection.AplusContent.SearchContentDocumentsAsync();
        }

        /// <summary>Fetch one document with full content + metadata.</summary>
        public async Task<GetContentDocumentResponse> GetDocumentAsync(string contentReferenceKey)
        {
            return await amazonConnection.AplusContent.GetContentDocumentAsync(
                contentReferenceKey,
                new List<AplusIncludedDataType> { AplusIncludedDataType.CONTENTS, AplusIncludedDataType.METADATA });
        }

        /// <summary>
        /// Create a minimal A+ Content document with a single STANDARD_TEXT module.
        /// </summary>
        public async Task<string> CreateMinimalDocumentAsync(string name, string locale = "en-US")
        {
            var request = new PostContentDocumentRequest
            {
                ContentDocument = new ContentDocument
                {
                    Name        = name,
                    ContentType = ContentType.EBC,
                    Locale      = locale,
                    ContentModuleList = new List<ContentModule>
                    {
                        new ContentModule
                        {
                            ContentModuleType = ContentModuleType.STANDARD_TEXT,
                            StandardText = new StandardTextModule
                            {
                                Headline = new TextComponent { Value = "About this product" },
                                Body     = new ParagraphComponent
                                {
                                    TextList = new List<TextComponent>
                                    {
                                        new TextComponent { Value = "Replace with your product story." }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var response = await amazonConnection.AplusContent.CreateContentDocumentAsync(request);
            return response.ContentReferenceKey;
        }

        /// <summary>Attach a list of ASINs to a content document.</summary>
        public async Task LinkAsinsAsync(string contentReferenceKey, IList<string> asins)
        {
            await amazonConnection.AplusContent.PostContentDocumentAsinRelationsAsync(
                contentReferenceKey,
                new PostContentDocumentAsinRelationsRequest { AsinSet = asins.ToList() });
        }

        /// <summary>List ASINs related to a document, with metadata (badges, title, image).</summary>
        public async Task<IList<AsinMetadata>> ListAsinsForDocumentAsync(string contentReferenceKey)
        {
            return await amazonConnection.AplusContent.ListContentDocumentAsinRelationsAsync(
                contentReferenceKey,
                includedDataSet: new List<AplusIncludedDataType> { AplusIncludedDataType.METADATA });
        }

        /// <summary>Submit a draft for Amazon's approval.</summary>
        public Task SubmitForApprovalAsync(string contentReferenceKey) =>
            amazonConnection.AplusContent.PostContentDocumentApprovalSubmissionAsync(contentReferenceKey);

        /// <summary>Withdraw a previously-submitted document.</summary>
        public Task WithdrawSubmissionAsync(string contentReferenceKey) =>
            amazonConnection.AplusContent.PostContentDocumentSuspendSubmissionAsync(contentReferenceKey);

        /// <summary>List the publish records for an ASIN — what content is currently live where.</summary>
        public async Task<IList<PublishRecord>> ListPublishRecordsForAsinAsync(string asin)
        {
            return await amazonConnection.AplusContent.SearchContentPublishRecordsAsync(asin);
        }
    }
}
