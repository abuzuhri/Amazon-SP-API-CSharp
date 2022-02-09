namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class PromotionInformationElement
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public MoneyType FeeDiscountMonetaryAmount { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string FeeDiscountType { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public double FeeDiscountValue { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public FeesEstimate FeesEstimate { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string FeeType { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public MoneyType PriceThreshold { get; set; }
    }
}
