using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.NotificationMessages
{
    public class FeedProcessingFinishedNotification
    {

        public string sellerId { get; set; }
        public string feedId { get; set; }
        public string feedType { get; set; }
        public string processingStatus { get; set; }
        public string resultFeedDocumentId { get; set; }
    }
}