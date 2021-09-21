using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Parameter.Order
{
    public class ParameterGetOrder : ParameterBased, IParameterBasedPII
    {
        public string OrderId { get; set; }
        public bool IsNeedRestrictedDataToken { get; set; }
        public CreateRestrictedDataTokenRequest RestrictedDataTokenRequest { get; set; }
    }
}
