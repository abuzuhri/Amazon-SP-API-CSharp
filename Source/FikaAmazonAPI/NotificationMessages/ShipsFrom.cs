using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class ShipsFrom
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("Country")]
        public string Country { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("State")]
        public string State { get; set; }
    }
}
