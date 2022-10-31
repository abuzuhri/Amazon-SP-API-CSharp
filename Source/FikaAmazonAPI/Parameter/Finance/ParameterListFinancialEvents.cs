using FikaAmazonAPI.Search;
using System;

namespace FikaAmazonAPI.Parameter.Finance
{
    public class ParameterListFinancialEvents : ParameterBased
    {
        public int? MaxResultsPerPage { get; set; } = 100;
        public DateTime? PostedAfter { get; set; }
        public DateTime? PostedBefore { get; set; }
        public string NextToken { get; set; }
        public int? MaxNumberOfPages { get; set; }
    }
}
