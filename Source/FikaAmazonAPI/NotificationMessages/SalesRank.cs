using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class SalesRank
    {
        /// <summary>
        /// Required. The product category identifier of the item.
        /// </summary>
        [JsonProperty("ProductCategoryId")]
        public string ProductCategoryId { get; set; }

        /// <summary>
        /// Required. The sales rank of the item in the given product category.
        /// </summary>
        [JsonProperty("Rank")]
        public long Rank { get; set; }
    }
}
