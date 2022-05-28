using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductPricing
{
    [DataContract]
    public class ItemOffersResponse
    {
        /// <summary>
        /// A mapping of additional HTTP headers to send/receive for the individual batch request.
        /// </summary>
        [DataMember(Name = "headers", EmitDefaultValue = false)]
        public HttpResponseHeaders Headers { get; set; }

        /// <summary>
        /// The HTTP status line associated with the response.For more information, consult RFC 2616.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public GetOffersHttpStatusLine Status { get; set; }

        /// <summary>
        /// The response schema for the getListingOffers and getItemOffers operations.
        /// </summary>
        [DataMember(Name = "body", EmitDefaultValue = false)]
        public GetOffersResponse Body { get; set; }
    }
}
