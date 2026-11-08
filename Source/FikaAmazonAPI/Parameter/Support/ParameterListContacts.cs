using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.Support
{
    [CamelCase]
    public class ParameterListContacts : ParameterBased
    {
        /// <summary>
        /// The maximum number of results to include in each page. The value must be between 1 and 50. Defaults to 10.
        /// </summary>
        public int? MaxResults { get; set; }

        /// <summary>
        /// A token to retrieve the next page of results. The response includes nextToken when there are multiple pages of results.
        /// </summary>
        public string NextToken { get; set; }

        /// <summary>
        /// Sort the returned contacts by createdDate in either ascending or descending order. Defaults to DESC.
        /// </summary>
        public SupportSortOrder? SortOrder { get; set; }

        /// <summary>
        /// Maximum number of pages to return. When null, all pages are fetched.
        /// </summary>
        [IgnoreToAddParameter]
        public int? MaxNumberOfPages { get; set; }
    }
}
