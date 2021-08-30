using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class IncludedFeeElement
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public AmountValue FeeAmount { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public AmountValue FeePromotion { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string FeeType { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public AmountValue FinalFee { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public AmountValue TaxAmount { get; set; }
    }

}
