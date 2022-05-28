using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing
{
    /// <summary>
    /// The HTTP status line associated with the response. For more information, consult RFC 2616.
    /// </summary>
    [DataContract]
    public class GetOffersHttpStatusLine
    {
        /// <summary>
        /// The HTTP response Status Code.
        /// Minimum value : 100
        /// Maximum value : 599
        /// </summary>
        [DataMember(Name = "statusCode", EmitDefaultValue = false)]
        public int StatusCode { get; set; }

        /// <summary>
        /// The HTTP response Reason-Phase.
        /// </summary>
        [DataMember(Name = "reasonPhrase", EmitDefaultValue = false)]
        public string ReasonPhrase { get; set; }
    }
}
