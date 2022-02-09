using FikaAmazonAPI.Parameter.ListingItem;
using FikaAmazonAPI.Parameter.Order;
using FikaAmazonAPI.Search;
using System.Collections.Generic;

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
                    });
                }
                else if (testCase.Equals(Constants.TestCase400))
                {
                    queryParameters.Add(Constants.TestCase400, new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("marketplaceIds", string.Join(",", parameterGetListingsItem.marketplaceIds))
                    });
                }
            }
            else if (instance is ParameterPutListingItem parameterPutListingsItem)
            {
                if (testCase.Equals(Constants.TestCase200))
                {
                    queryParameters.Add(Constants.TestCase200, new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("marketplaceIds", string.Join(",", parameterPutListingsItem.marketplaceIds)),
                    });
                }
                else if (testCase.Equals(Constants.TestCase400))
                {
                    queryParameters.Add(Constants.TestCase400, new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("marketplaceIds", string.Join(",", parameterPutListingsItem.marketplaceIds))
                    });
                }
            }
            else if (instance is ParameterDeleteListingItem parameterDeleteListingsItem)
            {
                if (testCase.Equals(Constants.TestCase200))
                {
                    queryParameters.Add(Constants.TestCase200, new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("marketplaceIds", string.Join(",", parameterDeleteListingsItem.marketplaceIds)),
                    });
                }
                else if (testCase.Equals(Constants.TestCase400))
                {
                    queryParameters.Add(Constants.TestCase400, new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("marketplaceIds", string.Join(",", parameterDeleteListingsItem.marketplaceIds))
                    });
                }
            }
            else if (instance is ParameterPatchListingItem parameterPatchListingItem)
            {
                if (testCase.Equals(Constants.TestCase200))
                {
                    queryParameters.Add(Constants.TestCase200, new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("marketplaceIds", string.Join(",", parameterPatchListingItem.marketplaceIds)),
                    });
                }
                else if (testCase.Equals(Constants.TestCase400))
                {
                    queryParameters.Add(Constants.TestCase400, new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("marketplaceIds", string.Join(",", parameterPatchListingItem.marketplaceIds))
                    });
                }
            }

            return queryParameters;
        }
    }
}
