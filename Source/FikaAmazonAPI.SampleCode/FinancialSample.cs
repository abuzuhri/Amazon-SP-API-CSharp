using FikaAmazonAPI.AmazonSpApiSDK.Models.Finances;
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
    }
}
