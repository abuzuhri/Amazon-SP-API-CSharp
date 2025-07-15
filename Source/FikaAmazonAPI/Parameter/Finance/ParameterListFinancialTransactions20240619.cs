using FikaAmazonAPI.Search;
using System;

namespace FikaAmazonAPI.Parameter.Finance
{
    public class ParameterListFinancialTransactions20240619 : ParameterBased
    {
        public DateTime postedAfter { get; set; }
        public DateTime? postedBefore { get; set; }
        public string? marketplaceId { get; set; }
        public string nextToken { get; set; }
        public int? MaxNumberOfPages { get; set; }
    }

}
