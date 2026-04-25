using FikaAmazonAPI.AmazonSpApiSDK.Models.Finances;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Finances.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
    public class FinancialSample
    {
        AmazonConnection amazonConnection;
        public FinancialSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public IList<FinancialEventGroup> ListFinancialEventGroups()
        {
            return amazonConnection.Financial.ListFinancialEventGroups(new Parameter.Finance.ParameterListFinancialEventGroup()
            {
                FinancialEventGroupStartedAfter = DateTime.UtcNow.AddDays(-10),
                FinancialEventGroupStartedBefore = DateTime.UtcNow.AddDays(-1),
                MaxResultsPerPage = 55
            });
        }

        public List<FinancialEvents> ListFinancialEventsByGroupId(string financialGroupId)
        {
            var financialEventsWithoutParams = amazonConnection.Financial.ListFinancialEventsByGroupId(financialGroupId);
            var financialEventsWithParams = amazonConnection.Financial.ListFinancialEventsByGroupId(financialGroupId,
                new Parameter.Finance.ParameterListFinancialEventsByGroupId()
                {
                    PostedAfter = DateTime.UtcNow.AddDays(-170),
                    PostedBefore = DateTime.UtcNow.AddMinutes(-60),
                    MaxResultsPerPage = 55
                });
            return financialEventsWithParams;
        }

        public IList<Transaction> ListFinancialTransactions20240619()
        {
            return amazonConnection.Financial.ListFinancialTransactions20240619(
                new Parameter.Finance.ParameterListFinancialTransactions20240619()
                {
                    postedAfter = DateTime.UtcNow.AddDays(-30),
                    postedBefore = DateTime.UtcNow.AddMinutes(-60),
                });
        }

        public IList<Transaction> ListFinancialTransactions20240619_DeferredReleased()
        {
            return amazonConnection.Financial.ListFinancialTransactions20240619(
                new Parameter.Finance.ParameterListFinancialTransactions20240619()
                {
                    postedAfter = DateTime.UtcNow.AddDays(-30),
                    transactionStatus = "DEFERRED_RELEASED",
                });
        }

        public IList<Transaction> ListFinancialTransactions20240619_ByEventGroup(string financialEventGroupId)
        {
            return amazonConnection.Financial.ListFinancialTransactions20240619(
                new Parameter.Finance.ParameterListFinancialTransactions20240619()
                {
                    postedAfter = DateTime.UtcNow.AddDays(-30),
                    relatedIdentifierName = "FINANCIAL_EVENT_GROUP_ID",
                    relatedIdentifierValue = financialEventGroupId,
                });
        }
    }
}
