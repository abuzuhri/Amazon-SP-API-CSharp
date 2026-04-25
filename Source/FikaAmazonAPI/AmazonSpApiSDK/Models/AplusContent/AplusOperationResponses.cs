using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    public class GetContentDocumentResponse : AplusResponse
    {
        [JsonProperty("contentRecord")]
        public ContentRecord ContentRecord { get; set; }
    }

    public class PostContentDocumentResponse : AplusResponse
    {
        [JsonProperty("contentReferenceKey")]
        public string ContentReferenceKey { get; set; }
    }

    public class PostContentDocumentApprovalSubmissionResponse : AplusResponse { }

    public class PostContentDocumentSuspendSubmissionResponse : AplusResponse { }

    public class PostContentDocumentAsinRelationsResponse : AplusResponse { }

    /// <summary>
    /// Per the spec, validateContentDocumentAsinRelations returns AplusResponse + ErrorList,
    /// so this carries both the warning list (from AplusResponse) and a separate errors list.
    /// </summary>
    public class ValidateContentDocumentAsinRelationsResponse : AplusResponse
    {
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }

    public class SearchContentDocumentsResponse : AplusPaginatedResponse
    {
        [JsonProperty("contentMetadataRecords")]
        public List<ContentMetadataRecord> ContentMetadataRecords { get; set; }
    }

    public class SearchContentPublishRecordsResponse : AplusPaginatedResponse
    {
        [JsonProperty("publishRecordList")]
        public List<PublishRecord> PublishRecordList { get; set; }
    }

    public class ListContentDocumentAsinRelationsResponse : AplusPaginatedResponse
    {
        [JsonProperty("asinMetadataSet")]
        public List<AsinMetadata> AsinMetadataSet { get; set; }
    }
}
