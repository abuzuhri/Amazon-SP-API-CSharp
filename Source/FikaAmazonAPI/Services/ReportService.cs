using AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.Search.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class ReportService : RequestService
    {
        public ReportService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }
        #region GetReport
        public List<Report> GetReport(ParameterReportList parameterReportList)
        {
            var list = new List<Report>();

            var parameters = parameterReportList.getParameters();

            CreateAuthorizedRequest(ReportApiUrls.GetReports, RestSharp.Method.GET, parameters);
            var response = ExecuteRequest<GetReportsResponse>();
            var nextToken = response.NextToken;
            list = response.Payload;
            list.AddRange(list);

            while (!string.IsNullOrEmpty(nextToken))
            {
                var nextTokenResponse = GetOrdersByNextToken(nextToken);
                list.AddRange(nextTokenResponse.Payload);
                nextToken = nextTokenResponse.NextToken;
            }
            return list;
        }


        public GetReportsResponse GetOrdersByNextToken(string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("NextToken", nextToken));

            CreateAuthorizedRequest(ReportApiUrls.GetReports, RestSharp.Method.GET, queryParameters);
            var response = ExecuteRequest<GetReportsResponse>();
            return response;
        }
        #endregion
    }
}
