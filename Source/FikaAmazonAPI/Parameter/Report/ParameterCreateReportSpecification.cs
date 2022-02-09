using FikaAmazonAPI.AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using System;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.Report
{
    public class ParameterCreateReportSpecification : ParameterBased
    {
        public ReportOptions reportOptions { get; set; }
        public ReportTypes reportType { get; set; }
        public DateTime? dataStartTime { get; set; }
        public DateTime? dataEndTime { get; set; }
        public MarketplaceIds marketplaceIds { get; set; }
    }
}
