using System;
using System.Collections.Generic;
using System.Text;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Search.Report
{
    public class ParameterCreateReportSpecification : ParameterBased
    {
        public int reportOptions { get; set; }
        public ReportTypes reportType { get; set; }
        public DateTime? dataStartTime { get; set; }
        public DateTime? dataEndTime { get; set; }
        public IList<string> marketplaceIds { get; set; }
    }
}
