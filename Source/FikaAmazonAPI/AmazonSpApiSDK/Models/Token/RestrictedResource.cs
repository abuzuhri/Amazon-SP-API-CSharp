using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Token
{
    public class RestrictedResource
    {

        public string method { get; set; }
        public string path { get; set; }
        public IList<string> dataElements { get; set; }

        
    }
    public enum Method
    {
        GET,
        PUT,
        POST,
        DELETE
    }

}
