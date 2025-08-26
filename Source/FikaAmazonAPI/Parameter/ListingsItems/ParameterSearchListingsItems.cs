using FikaAmazonAPI.AmazonSpApiSDK.Models.ListingsItems;
using System;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.ListingItem
{
    public class ParameterSearchListingsItems : PaginationParameter
    {
        [PathParameter]
        public string sellerId { get; set; }
        public ICollection<string> marketplaceIds { get; set; } = new List<string>();
        public string issueLocale { get; set; } = "en_US";
        public ICollection<ListingsIncludedData> includedData { get; set; }
        public ICollection<string> identifiers { get; set; }
        public IdentifiersType? identifiersType { get; set; }
        public string variationParentSku { get; set; }
        public string packageHierarchySku { get; set; }
        public DateTime? createdAfter { get; set; }
        public DateTime? createdBefore { get; set; }
        public DateTime? lastUpdatedAfter { get; set; }
        public DateTime? lastUpdatedBefore { get; set; }
        public ICollection<Issue.SeverityEnum> withIssueSeverity { get; set; }
        public ICollection<ItemSummaryByMarketplace.StatusEnum> withStatus { get; set; }
        public ICollection<ItemSummaryByMarketplace.StatusEnum> withoutStatus { get; set; }
        public SortBy? sortBy { get; set; }
        public SortOrderEnum? sortOrder { get; set; }
        public string pageToken { get; set; }
    }
}
