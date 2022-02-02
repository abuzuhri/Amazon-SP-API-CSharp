using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Parameter.ListingsItems
{
    public class ParameterGetListingsItem : ParameterBased
    {
        public ParameterGetListingsItem()
        {
        }

        /// <summary>
        /// A list of MarketplaceId values. Used to select orders that were placed in the specified marketplaces. Max count : 50
        /// </summary>
        public IList<string> marketplaceIds { get; set; }

        /// <summary>
        /// A locale for localization of issues. When not provided, the default language code of the first marketplace is used. Examples: "en_US", "fr_CA", "fr_FR". Localized messages default to "en_US" when a localization is not available in the specified locale.
        /// </summary>
        public string issueLocale { get; set; } = "en_US";

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        /// <summary>
        /// A comma-delimited list of data sets to include in the response. Default: summaries.
        /// </summary>
        public IList<Constants.ListingsIncludedData> includedData { get; set; }
    }
}
