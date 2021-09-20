using FikaAmazonAPI.AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using System;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Reports.CreateReportScheduleSpecification;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.Report
{
    public class ParameterCreateReportScheduleSpecification : ParameterBased
    {
        public ReportOptions reportOptions { get; set; }
        public ReportTypes reportType { get; set; }
        public MarketplaceIds marketplaceIds { get; set; }
        public PeriodEnum period { get; set; }
        public DateTime? nextReportCreationTime { get; set; }

    }
}
