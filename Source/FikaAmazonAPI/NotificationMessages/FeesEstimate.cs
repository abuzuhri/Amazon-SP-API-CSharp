using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class FeesEstimate
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public List<FeeDetailElement> FeeDetails { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string TimeOfFeesEstimated { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public MoneyType TotalFeesEstimate { get; set; }
    }
}
