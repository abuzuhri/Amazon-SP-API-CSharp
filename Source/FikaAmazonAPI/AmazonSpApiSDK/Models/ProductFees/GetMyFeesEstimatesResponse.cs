using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductFees
{
    [DataContract]
    public class GetMyFeesEstimatesResponse: List<FeesEstimateResult>
    {
    }
}
