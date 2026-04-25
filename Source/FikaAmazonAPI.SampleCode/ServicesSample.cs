using FikaAmazonAPI.AmazonSpApiSDK.Models.Services;
using FikaAmazonAPI.Parameter.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
    public class ServicesSample
    {
        AmazonConnection amazonConnection;
        public ServicesSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public ServiceJob GetServiceJobByServiceJobId(string serviceJobId)
        {
            return amazonConnection.Services.GetServiceJobByServiceJobId(serviceJobId);
        }

        public async Task<ServiceJob> GetServiceJobByServiceJobIdAsync(string serviceJobId)
        {
            return await amazonConnection.Services.GetServiceJobByServiceJobIdAsync(serviceJobId);
        }

        /// <summary>
        /// Demonstrates reading the payments[] array Amazon added to getServiceJobByServiceJobId
        /// in the April 2026 release. Returns the total of all payments.
        /// </summary>
        public decimal? GetTotalPaymentsForServiceJob(string serviceJobId)
        {
            var job = amazonConnection.Services.GetServiceJobByServiceJobId(serviceJobId);
            if (job?.Payments == null)
                return null;

            return job.Payments
                .Where(p => p.Amount?.Value != null)
                .Sum(p => p.Amount.Value);
        }

        /// <summary>
        /// List service jobs scheduled in the next 14 days. The SDK pages the call internally
        /// and returns a flat <see cref="IList{ServiceJob}"/>.
        /// </summary>
        public IList<ServiceJob> GetUpcomingServiceJobs()
        {
            var parameter = new ParameterGetServiceJobs
            {
                scheduleStartDate = DateTime.UtcNow,
                scheduleEndDate = DateTime.UtcNow.AddDays(14),
                serviceJobStatus = new List<string> { "SCHEDULED", "PENDING_SCHEDULE" },
                pageSize = 50,
                sortField = "JOB_DATE",
                sortOrder = "ASC",
            };
            return amazonConnection.Services.GetServiceJobs(parameter);
        }

        public bool CancelServiceJob(string serviceJobId, string cancellationReasonCode)
        {
            return amazonConnection.Services.CancelServiceJobByServiceJobId(serviceJobId, cancellationReasonCode);
        }

        public bool CompleteServiceJob(string serviceJobId)
        {
            return amazonConnection.Services.CompleteServiceJobByServiceJobId(serviceJobId);
        }
    }
}
