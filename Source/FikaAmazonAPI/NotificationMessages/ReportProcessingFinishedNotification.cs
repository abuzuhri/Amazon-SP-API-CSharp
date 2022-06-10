namespace FikaAmazonAPI.NotificationMessages
{
    public class ReportProcessingFinishedNotification
    {

        public string sellerId { get; set; }
        public string reportId { get; set; }
        public string reportType { get; set; }
        public string processingStatus { get; set; }
        public string reportDocumentId { get; set; }
    }
}