using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter
{
    public class PaginationParameter : ParameterBased
    {
        public int? pageSize { get; set; } = 20;
        [IgnoreToAddParameterAttribute]
        public int? maxPages { get; set; } = 20;
    }
}
