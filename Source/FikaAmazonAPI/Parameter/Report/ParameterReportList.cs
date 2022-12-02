using FikaAmazonAPI.AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.Report
{
    public class ParameterReportList : ParameterBased
    {
        public ParameterReportList()
        {
            reportOptions = new ReportOptions();
        }
        /// <summary>
        /// A list of report types used to filter reports. When reportTypes is provided, the other filter parameters (processingStatuses, marketplaceIds, createdSince, createdUntil) and pageSize may also be provided. Either reportTypes or nextToken is required.         Min count : 1 Max count : 10
        /// </summary>
        public ICollection<ReportTypes> reportTypes { get; set; } = new List<ReportTypes>();
        /// <summary>
        /// A list of processing statuses used to filter reports.
        /// </summary>
        public ICollection<ProcessingStatuses> processingStatuses { get; set; }
        /// <summary>
        /// A list of marketplace identifiers used to filter reports. The reports returned will match at least one of the marketplaces that you specify. Minimum : 1 Maximum : 10
        /// </summary>
        public ICollection<string> marketplaceIds { get; set; } = new List<string>();
        /// <summary>
        /// The maximum number of reports to return in a single call. Minimum : 1 Maximum : 100	
        /// </summary>
        public int? pageSize { get; set; }
        /// <summary>
        /// The earliest report creation date and time for reports to include in the response, in ISO 8601 date time format. The default is 90 days ago. Reports are retained for a maximum of 90 days.	
        /// </summary>
        public DateTime? createdSince { get; set; }
        /// <summary>
        /// The latest report creation date and time for reports to include in the response, in ISO 8601 date time format. The default is now.	
        /// </summary>
        public DateTime? createdUntil { get; set; }
        /// <summary>
        /// A string token returned in the response to your previous request. nextToken is returned when the number of results exceeds the specified pageSize value. To get the next page of results, call the getReports operation and include this token as the only parameter. Specifying nextToken with any other parameters will cause the request to fail.	
        /// </summary>
        public string nextToken { get; set; }
        public ReportOptions reportOptions { get; set; }

    }
}
