using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class IdentifierElement
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string IdentifierType { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public List<IdentifierValueElement> IdentifierValues { get; set; }
    }
}
