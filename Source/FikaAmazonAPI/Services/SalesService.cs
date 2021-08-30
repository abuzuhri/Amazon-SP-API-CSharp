using AmazonSpApiSDK.Models.Sales;
using AmazonSpApiSDK.Models.Sellers;
using FikaAmazonAPI.Parameter.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class SalesService : RequestService
    {
        public SalesService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public List<OrderMetricsInterval> GetOrderMetrics(ParameterGetOrderMetrics parameterGetOrderMetrics)
        {
            var param = parameterGetOrderMetrics.getParameters();
            CreateAuthorizedRequest(SalesApiUrls.GetOrderMetrics, RestSharp.Method.GET, param);
            var response = ExecuteRequest<GetOrderMetricsResponse>();
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
