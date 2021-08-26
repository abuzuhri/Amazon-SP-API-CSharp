using AmazonSpApiSDK.Models;
using AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.Parameter.Report;
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
            var parameters = parameterReportList.getParameters();

            CreateAuthorizedRequest(ReportApiUrls.GetReports, RestSharp.Method.GET, parameters);
            var response = ExecuteRequest<GetReportsResponse>();
            parameterReportList.nextToken = response.NextToken;
            var list = response.Payload;
            list.AddRange(list);

            while (!string.IsNullOrEmpty(parameterReportList.nextToken))
            {
                var nextTokenResponse = GetOrdersByNextToken(parameterReportList);
                list.AddRange(nextTokenResponse.Payload);
                parameterReportList.nextToken = nextTokenResponse.NextToken;
            }
            return list;
        }


        public GetReportsResponse GetOrdersByNextToken(ParameterReportList parameterReportList)
        {
            var parameterReportListNew = new ParameterReportList();
            parameterReportListNew.nextToken = parameterReportList.nextToken;
            //parameterReportListNew.reportTypes= parameterReportList.reportTypes;
            var parameters = parameterReportListNew.getParameters();

            CreateAuthorizedRequest(ReportApiUrls.GetReports, RestSharp.Method.GET, parameters);
            var response = ExecuteRequest<GetReportsResponse>();
            return response;
        }
        #endregion
    }
}
