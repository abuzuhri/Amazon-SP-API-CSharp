using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.Feed
{
    public class ParameterGetFeed : ParameterBased
    {
        public IList<FeedType> feedTypes { get; set; }
        public IList<string> marketplaceIds { get; set; }
        public int? pageSize { get; set; }
        public ProcessingStatuses? processingStatuses { get; set; }
        public DateTime? createdSince { get; set; }
        public DateTime? createdUntil { get; set; }
        public string nextToken { get; set; }

    }
}
