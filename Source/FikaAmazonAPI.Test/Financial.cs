using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Test
{
    [TestClass]
    public class Financial
    {
        AmazonConnection amazonConnection;
        public Financial()
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
        public void ListFinancialEventGroups()
        {
            amazonConnection.Financial.ListFinancialEventGroups(new Parameter.Finance.ParameterListFinancialEventGroup()
            {
                FinancialEventGroupStartedAfter = DateTime.UtcNow.AddDays(-10),
                FinancialEventGroupStartedBefore = DateTime.UtcNow.AddDays(-1),
                MaxResultsPerPage = 55
            });

        }

    }
}
