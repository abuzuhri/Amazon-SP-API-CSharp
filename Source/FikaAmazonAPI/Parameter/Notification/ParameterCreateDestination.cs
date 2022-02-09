using FikaAmazonAPI.Search;

namespace FikaAmazonAPI.Parameter.Notification
{
    public class ParameterCreateDestination : ParameterBased
    {
        public DestinationResourceSpecification resourceSpecification { get; set; }
        public string name { get; set; }
    }
    public class DestinationResourceSpecification
    {
        public SqsResource sqs { get; set; }
        public EventBridgeResourceSpecification eventBridge { get; set; }
    }
    public class SqsResource
    {
        public string arn { get; set; }
    }
    public class EventBridgeResourceSpecification
    {
        public string region { get; set; }
        public string accountId { get; set; }
    }
}
