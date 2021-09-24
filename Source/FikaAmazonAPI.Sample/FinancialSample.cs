using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Sample
{
    public class FinancialSample
    {
        AmazonConnection amazonConnection;
        public FinancialSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

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
