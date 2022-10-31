using FikaAmazonAPI.AmazonSpApiSDK.Models.Sales;
using FikaAmazonAPI.Parameter.Sales;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class SalesService : RequestService
    {
        public SalesService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public List<OrderMetricsInterval> GetOrderMetrics(ParameterGetOrderMetrics parameterGetOrderMetrics) =>
            Task.Run(() => GetOrderMetricsAsync(parameterGetOrderMetrics)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<OrderMetricsInterval>> GetOrderMetricsAsync(ParameterGetOrderMetrics parameterGetOrderMetrics)
        {
            var param = parameterGetOrderMetrics.getParameters();
            await CreateAuthorizedRequestAsync(SalesApiUrls.GetOrderMetrics, RestSharp.Method.Get, param);
            var response = await ExecuteRequestAsync<GetOrderMetricsResponse>(Utils.RateLimitType.Sales_GetOrderMetrics);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
