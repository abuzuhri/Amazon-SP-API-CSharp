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
        /// The identifier name to filter by. Only FINANCIAL_EVENT_GROUP_ID has filtering capability at the moment;
        /// other values appear in response payloads but cannot be used as query filters.
        /// </summary>
        public RelatedIdentifierNameEnum? relatedIdentifierName { get; set; }
        public string? relatedIdentifierValue { get; set; }
        public string nextToken { get; set; }
        public int? MaxNumberOfPages { get; set; }
    }
}
