using FikaAmazonAPI.Search;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Finances.Model.RelatedIdentifier;

namespace FikaAmazonAPI.Parameter.Finance
{
    public class ParameterListFinancialTransactions20240619 : ParameterBased
    {
        public DateTime postedAfter { get; set; }
        public DateTime? postedBefore { get; set; }
        public string? marketplaceId { get; set; }
        /// <summary>
        /// The status of the transaction.Possible values:
        /// `DEFERRED`: the transaction is currently deferred.
        /// `RELEASED`: the transaction is currently released. 
        /// `DEFERRED_RELEASED`: the transaction was deferred in the past, but is now released. The status of a deferred transaction is updated to `DEFERRED_RELEASED` when the transaction is released.
        /// </summary>
        public string? transactionStatus { get; set; }
        /// <summary>
        /// Possible values:`FINANCIAL_EVENT_GROUP_ID`: the financial event group ID associated with the transaction.
        ///*Note: FINANCIAL_EVENT_GROUP_ID is the only `relatedIdentifier` with filtering capabilities at the moment. While other `relatedIdentifier` values will be included in the response when available, they cannot be used for filtering purposes.
        /// </summary>
        public string? relatedIdentifierName { get; set; }
        public string? relatedIdentifierValue { get; set; }
        public string nextToken { get; set; }
        public int? MaxNumberOfPages { get; set; }
    }
}
