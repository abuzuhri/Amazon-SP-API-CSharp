using FikaAmazonAPI.AmazonSpApiSDK.Models.Services;
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
    }
}
