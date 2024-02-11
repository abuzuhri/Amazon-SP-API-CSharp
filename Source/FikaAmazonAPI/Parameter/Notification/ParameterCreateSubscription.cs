using FikaAmazonAPI.Search;
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
