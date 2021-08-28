using FikaAmazonAPI.Parameter.Report;
using FikaAmazonAPI.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Test
{
    [TestClass]
    public class Reports
    {
        AmazonConnection amazonConnection;
        public Reports()
        {
            amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
                SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
                RoleArn = Environment.GetEnvironmentVariable("RoleArn"),
                ClientId = Environment.GetEnvironmentVariable("ClientId"),
                ClientSecret = Environment.GetEnvironmentVariable("ClientSecret"),
                RefreshToken = Environment.GetEnvironmentVariable("RefreshToken"),
                MarketPlace = MarketPlace.UnitedArabEmirates

            });

        }

        [TestMethod]
        public void GetReports()
        {
            var parameters = new ParameterReportList();
            parameters.pageSize = 100;
            parameters.reportTypes = new List<ReportTypes>();
            parameters.reportTypes.Add(ReportTypes.GET_AFN_INVENTORY_DATA);
            parameters.marketplaceIds = new List<string>();
            parameters.marketplaceIds.Add(MarketPlace.UnitedArabEmirates.ID);
            amazonConnection.Reports.GetReports(parameters);
        }

        [TestMethod]
        public void CreateReport()
        {

            var parameters = new ParameterCreateReportSpecification();
            parameters.reportType = ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL;
            parameters.dataStartTime = DateTime.UtcNow.AddDays(-30);
            parameters.dataEndTime = DateTime.UtcNow.AddDays(-10);

            parameters.marketplaceIds = new MarketplaceIds();
            parameters.marketplaceIds.Add(MarketPlace.UnitedArabEmirates.ID);

            parameters.reportOptions = new AmazonSpApiSDK.Models.Reports.ReportOptions();

            var reportId= amazonConnection.Reports.CreateReport(parameters);
        }

        [TestMethod]
        public void GetReport()
        {

            amazonConnection.Reports.GetReport("192841018867");
        }

        [TestMethod]
        public void CancelReport()
        {

            amazonConnection.Reports.CancelReport("192841018867");
        }

        [TestMethod]
        public void GetReportSchedules()
        {

            var parameters = new ParameterReportSchedules();
            parameters.reportTypes.Add(ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL);

            var result = amazonConnection.Reports.GetReportSchedules(parameters);
        }

        [TestMethod]
        public void CreateReportScheduleSpecification()
        {

            var parameters = new ParameterCreateReportScheduleSpecification();
            parameters.reportType = ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL;
            parameters.period = AmazonSpApiSDK.Models.Reports.CreateReportScheduleSpecification.PeriodEnum.PT30M;

            parameters.marketplaceIds = new MarketplaceIds();
            parameters.marketplaceIds.Add(MarketPlace.UnitedArabEmirates.ID);

            parameters.reportOptions = new AmazonSpApiSDK.Models.Reports.ReportOptions();

            var result = amazonConnection.Reports.CreateReportSchedule(parameters);


        }

        [TestMethod]
        public void GetReportSchedule()
        {

            var data = amazonConnection.Reports.GetReportSchedule("50039018867");


        }
        [TestMethod]
        public void CancelReportSchedule()
        {

            var data = amazonConnection.Reports.CancelReportSchedule("50039018867");


        }
        [TestMethod]
        public void GetReportDocument()
        {

            var data = amazonConnection.Reports.GetReportDocument("50039018867");

        }
        
        [TestMethod]
        public void GetReportFile()
        {

            var data = amazonConnection.Reports.GetReport("192841018867");


            var filePath = amazonConnection.Reports.GetReportFile(data.ReportDocumentId);

        }




    }
}
