using FikaAmazonAPI.AmazonSpApiSDK.Models.ProductFees;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Parameter.ProductFee
{
    public class FeesEstimateByIdRequest
    {
        public string IdValue { get; set; }
        public IdTypeEnum IdType { get; set; }
        public FeesEstimateRequest FeesEstimateRequest { get; set; }
    }
}
