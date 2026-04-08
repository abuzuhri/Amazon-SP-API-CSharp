using FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101;
using FikaAmazonAPI.Search;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.Order.V20260101
{
    [CamelCase]
    public class ParameterGetOrder : ParameterBased
    {
        public ParameterGetOrder()
        {
        }

        [PathParameter]
        /// <summary>
        /// An Amazon-defined order identifier.
        /// </summary>
        public string OrderId { get; set; }

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        /// <summary>
        /// A list of datasets to include in the response.
        /// </summary>
        public ICollection<IncludedDataEnum> IncludedData { get; set; }
    }
}
