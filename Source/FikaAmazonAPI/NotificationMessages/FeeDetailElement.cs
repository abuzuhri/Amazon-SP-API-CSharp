using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class FeeDetailElement
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public MoneyType FeeAmount { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public MoneyType FeePromotion { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string FeeType { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public MoneyType FinalFee { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public List<IncludedFeeElement> IncludedFees { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public MoneyType TaxAmount { get; set; }
    }
}
