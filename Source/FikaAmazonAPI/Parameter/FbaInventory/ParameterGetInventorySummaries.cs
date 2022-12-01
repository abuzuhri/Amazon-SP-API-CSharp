using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.FbaInventory.Granularity;

namespace FikaAmazonAPI.Parameter.FbaInventory
{
    public class ParameterGetInventorySummaries : ParameterBased
    {
        public bool? details { get; set; }
        public string granularityId { get; set; }
        public DateTime? startDateTime { get; set; }
        public ICollection<string> sellerSkus { get; set; }
        public string nextToken { get; set; }
        public ICollection<string> marketplaceIds { get; set; }
        public GranularityTypeEnum granularityType { get; set; }
    }
}
