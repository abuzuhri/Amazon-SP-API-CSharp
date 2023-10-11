using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.ListingItem
{
    public class ParameterGetListingsItem : ParameterBased
    {
        public ParameterGetListingsItem()
        {
        }

        public bool Check()
        {
            if (TestCase == TestCase400)
                sku = "BadSKU";
            if (string.IsNullOrWhiteSpace(sellerId))
            {
                throw new InvalidDataException("SellerId is a required property for ParameterGetListingsItem and cannot be null");
            }
            if (string.IsNullOrWhiteSpace(sku))
            {
                throw new InvalidDataException("Sku is a required property for ParameterGetListingsItem and cannot be null");
            }
            if (marketplaceIds == null || !marketplaceIds.Any())
            {
                throw new InvalidDataException("MarketplaceIds is a required property for ParameterGetListingsItem and cannot be null");
            }
            if (includedData is null)
            {
                includedData = new List<ListingsIncludedData>();
                includedData.Add(ListingsIncludedData.Summaries);
            }
            if (includedData.Count == 0)
                includedData.Add(ListingsIncludedData.Summaries);
            return true;
        }

        public string sellerId { get; set; }

        public string sku { get; set; }

        /// <summary>
        /// A list of MarketplaceId values. Used to select orders that were placed in the specified marketplaces. Max count : 50
        /// </summary>
        public ICollection<string> marketplaceIds { get; set; }

        /// <summary>
        /// A locale for localization of issues. When not provided, the default language code of the first marketplace is used. Examples: "en_US", "fr_CA", "fr_FR". Localized messages default to "en_US" when a localization is not available in the specified locale.
        /// </summary>
        public string issueLocale { get; set; } = "en_US";

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        /// <summary>
        /// A comma-delimited list of data sets to include in the response. Default: summaries.
        /// </summary>
        public ICollection<Constants.ListingsIncludedData> includedData { get; set; }
    }
}
