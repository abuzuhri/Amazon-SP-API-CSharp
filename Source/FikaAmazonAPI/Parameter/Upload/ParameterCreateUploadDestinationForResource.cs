using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Parameter.Upload
{
    public class ParametercreateUploadDestinationForResource
    {
        public IList<string> marketplaceIds { get; set; }
        public string contentMD5 { get; set; }
        public string resource { get; set; }
        public string contentType { get; set; }

    }

}
