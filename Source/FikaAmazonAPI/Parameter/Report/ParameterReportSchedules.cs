using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using System.Text;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.Report
{
    public class ParameterReportSchedules : ParameterBased
    {
        public ParameterReportSchedules()
        {
            reportTypes = new List<ReportTypes>();
        }
        public IList<ReportTypes> reportTypes { get; set; }
    }
}
