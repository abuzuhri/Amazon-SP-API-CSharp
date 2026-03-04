using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Reflection;

namespace FikaAmazonAPI.Parameter.Order
{
    [Obsolete("This class is deprecated. Please use ParameterGetOrder20260101 instead.")]
    public class ParameterGetOrder : ParameterBased, IParameterBasedPII
    {
        public string OrderId { get; set; }
        public bool IsNeedRestrictedDataToken { get; set; }
        public CreateRestrictedDataTokenRequest RestrictedDataTokenRequest { get; set; }
    }

    /// <summary>
    /// Parameters for the getOrder endpoint (Orders API v2026-01-01).
    /// Replaces ParameterGetOrder from v0.
    /// 
    /// Key differences from v0:
    /// - No RDT required: PII access is role-based.
    /// - includedData parameter replaces separate GetOrderBuyerInfo/GetOrderAddress/GetOrderItems calls.
    /// - Order items are always included in the response.
    /// 
    /// </summary>
    [CamelCase]
    public class ParameterGetOrder20260101 : ParameterBased
    {
        /// <summary>
        /// The Amazon order identifier (path parameter).
        /// </summary>
        [PathParameter]
        public string OrderId { get; set; }

        /// <summary>
        /// Specifies which additional data to include in the response.
        /// Values: BUYER, RECIPIENT, FULFILLMENT, PROCEEDS, EXPENSE, PROMOTION, CANCELLATION, PACKAGES.
        /// Order items are always included regardless of this parameter.
        /// </summary>
        [IgnoreToAddParameter]
        public ICollection<IncludedData20260101> IncludedData { get; set; }


        public List<KeyValuePair<string,string>> getParameters()
        {
            var parameter = new List<KeyValuePair<string,string>>();

            if (string.IsNullOrEmpty(OrderId))
                throw new ArgumentException("OrderID needs to be set for a getOrder call to Work... i mean what Order do you try to get?");

            parameter.Add(new KeyValuePair<string, string>("orderID", OrderId));

            if(IncludedData != null && IncludedData.Count > 0)
            {
                parameter.Add(new KeyValuePair<string, string>("includedData",JoinEnums(IncludedData)));
            }

            return parameter;
        }


        // Helpers
        private static string JoinEnums<T>(ICollection<T> values) where T : Enum
        {
            return string.Join(",", values.Select(GetEnumMemberValue));
        }

        private static string GetEnumMemberValue<T>(T enumValue) where T : Enum
        {
            var member = typeof(T).GetMember(enumValue.ToString()).FirstOrDefault();
            var attr = member?.GetCustomAttribute<EnumMemberAttribute>();
            return attr?.Value ?? enumValue.ToString();
        }
    }
}
