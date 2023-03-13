using FikaAmazonAPI.AmazonSpApiSDK.Models.Restrictions;
using FikaAmazonAPI.Search;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.Restrictions
{
    public class ParameterGetListingsRestrictions : ParameterBased
    {
        /// <summary>
        /// The Amazon Standard Identification Number (ASIN) of the item.
        /// </summary>
        public string asin { get; set; }
        /// <summary>
        /// The condition used to filter restrictions.
        /// </summary>
        public ConditionType conditionType { get; set; }
        /// <summary>
        /// A selling partner identifier, such as a merchant account.
        /// </summary>
        public string sellerId { get; set; }
        /// <summary>
        /// A comma-delimited list of Amazon marketplace identifiers for the request.
        /// </summary>
        public ICollection<string> marketplaceIds { get; set; } = new List<string>();
        /// <summary>
        /// A locale for reason text localization. When not provided, the default language code of the first marketplace is used. Examples: "en_US", "fr_CA", "fr_FR". Localized messages default to "en_US" when a localization is not available in the specified locale.
        /// </summary>
        public string reasonLocale { get; set; }
    }
}
