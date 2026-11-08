using FikaAmazonAPI.AmazonSpApiSDK.Models.Support;
using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.Support
{
    /// <summary>
    /// Parameters for listCases. The operation is a POST, so these values are sent as the
    /// <see cref="ListCasesRequest"/> body rather than as query parameters.
    /// </summary>
    public class ParameterListCases : ParameterBased
    {
        /// <summary>
        /// Optional filters to narrow the returned collection. When absent, the operation returns all cases for the requesting identity.
        /// </summary>
        public CaseFilters CaseFilters { get; set; }

        /// <summary>
        /// The sort direction. Defaults to DESC when absent.
        /// </summary>
        public ListCasesRequest.SortOrderEnum? SortOrder { get; set; }

        /// <summary>
        /// The maximum number of results to include in each page. The value must be between 1 and 50. Defaults to 10.
        /// </summary>
        public int? MaxResults { get; set; }

        /// <summary>
        /// A token to retrieve the next page of results. The response includes nextToken when there are multiple pages of results.
        /// </summary>
        public string NextToken { get; set; }

        /// <summary>
        /// Maximum number of pages to return. When null, all pages are fetched.
        /// </summary>
        [IgnoreToAddParameter]
        public int? MaxNumberOfPages { get; set; }

        internal ListCasesRequest ToRequest() =>
            new ListCasesRequest(caseFilters: CaseFilters, sortOrder: SortOrder, maxResults: MaxResults, nextToken: NextToken);
    }
}
