using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing
{
    public class GetBatchOffersResponse
    {

        [DataMember(Name = "responses", EmitDefaultValue = false)]
        public ItemOffersResponse[] Responses { get; set; }

    }

}
