using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Parameter.ListingsItems;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Utils
{
    internal static class Sandbox
    {
        public static Dictionary<string, List<KeyValuePair<string, string>>> SandboxQueryParameters<T>(T instance, string testCase) where T : ParameterBased
        {
            var queryParameters = new Dictionary<string, List<KeyValuePair<string, string>>>();
            if (instance is ParameterOrderList parameterOrderList)
            {
                if (testCase.Equals(Constants.TestCase200))
                {
                    queryParameters.Add(Constants.TestCase200, new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("CreatedAfter", Constants.TestCase200),
                        new KeyValuePair<string, string>("MarketplaceIds", MarketPlace.US.ID)
                    });
                }
            }
            else if (instance is ParameterGetListingsItem parameterGetListingsItem)
            {
                if (testCase.Equals(Constants.TestCase200))
                {
                    queryParameters.Add(Constants.TestCase200, new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("marketplaceIds", string.Join(",", parameterGetListingsItem.marketplaceIds)),
                        //new KeyValuePair<string, string>("issueLocale", "en_US"),
                        //new KeyValuePair<string, string>("includedData", "Summaries"),
                    });
                }
            }

            return queryParameters;
        }
    }
}
