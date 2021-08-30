using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;
using System.Text;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Parameter.Notification
{
    public class ParameterCreateSubscription : ParameterBased
    {
        public string payloadVersion { get; set; }
        public string destinationId { get; set; }
        public NotificationType notificationType { get; set; }

    }
}
