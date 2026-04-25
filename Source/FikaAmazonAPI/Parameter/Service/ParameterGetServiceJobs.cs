using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.Service
{
    public class ParameterGetServiceJobs : ParameterBased
    {
        /// <summary>
        /// Required. List of marketplace IDs the call applies to.
        /// </summary>
        public ICollection<string> marketplaceIds { get; set; }

        public ICollection<string> serviceOrderIds { get; set; }

        /// <summary>
        /// Possible values: NOT_SERVICED, NOT_SCHEDULED, SCHEDULED, COMPLETED, CANCELLED, PENDING_SCHEDULE, etc.
        /// </summary>
        public ICollection<string> serviceJobStatus { get; set; }

        public string pageToken { get; set; }
        public int? pageSize { get; set; }

        /// <summary>
        /// Possible values: JOB_DATE, JOB_STATUS.
        /// </summary>
        public string sortField { get; set; }

        /// <summary>
        /// Possible values: ASC, DESC.
        /// </summary>
        public string sortOrder { get; set; }

        public DateTime? createdAfter { get; set; }
        public DateTime? createdBefore { get; set; }
        public DateTime? lastUpdatedAfter { get; set; }
        public DateTime? lastUpdatedBefore { get; set; }
        public DateTime? scheduleStartDate { get; set; }
        public DateTime? scheduleEndDate { get; set; }

        public ICollection<string> asins { get; set; }
        public ICollection<string> requiredSkills { get; set; }
        public ICollection<string> storeIds { get; set; }
    }
}
