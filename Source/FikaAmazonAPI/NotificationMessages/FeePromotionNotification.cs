using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class FeePromotionNotification
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string FeePromotionType { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string FeePromotionTypeDescription { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public List<IdentifierElement> Identifiers { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string MarketplaceId { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public PromotionActiveTimeRange PromotionActiveTimeRange { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public List<PromotionInformationElement> PromotionInformation { get; set; }
    }
}
