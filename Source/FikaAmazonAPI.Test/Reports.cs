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
        public void GetOrders()
        {
            var parameters = new ParameterReportList();
            parameters.pageSize = 100;
            parameters.reportTypes = new List<ReportTypes>();
            parameters.reportTypes.Add(ReportTypes.GET_AFN_INVENTORY_DATA);

            parameters.marketplaceIds = new List<string>();
            parameters.marketplaceIds.Add(MarketPlace.UnitedArabEmirates.ID);

            amazonConnection.Reports.GetReport(parameters);
        }
    }
}
