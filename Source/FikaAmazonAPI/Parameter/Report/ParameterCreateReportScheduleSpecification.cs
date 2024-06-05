using FikaAmazonAPI.AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Reports.CreateReportScheduleSpecification;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.Report
{
    public class ParameterCreateReportScheduleSpecification : ParameterBased
    {
        public ReportOptions reportOptions { get; set; }
        public ReportTypes reportType { get; set; }
        public List<string> marketplaceIds { get; set; }
        public PeriodEnum period { get; set; }
        public DateTime? nextReportCreationTime { get; set; }

    }
}
