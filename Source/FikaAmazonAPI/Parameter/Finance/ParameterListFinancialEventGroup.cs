using FikaAmazonAPI.Search;
using System;

namespace FikaAmazonAPI.Parameter.Finance
{
    public class ParameterListFinancialEventGroup : ParameterBased
    {
        public int? MaxResultsPerPage { get; set; } = 100;
        public DateTime? FinancialEventGroupStartedBefore { get; set; }
        public DateTime? FinancialEventGroupStartedAfter { get; set; }
        public string NextToken { get; set; }
    }
}
