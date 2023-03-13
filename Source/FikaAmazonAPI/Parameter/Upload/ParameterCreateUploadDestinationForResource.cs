using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.Upload
{
    public class ParameterCreateUploadDestinationForResource : ParameterBased
    {
        public ICollection<string> marketplaceIds { get; set; } = new List<string>();
        public string contentMD5 { get; set; }
        public string resource { get; set; }
        public string contentType { get; set; }

    }

}
