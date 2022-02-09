using Amazon;

namespace FikaAmazonAPI.Parameter.Notification
{
    public class ParameterMessageReceiver
    {
        public string awsAccessKeyId { get; set; }
        public string awsSecretAccessKey { get; set; }
        public string SQS_URL { get; set; }
        public RegionEndpoint RegionEndpoint { get; set; }
        public ParameterMessageReceiver(string awsAccessKeyId, string awsSecretAccessKey,string SQS_URL, RegionEndpoint RegionEndpoint)
        {
            this.awsAccessKeyId = awsAccessKeyId;
            this.awsSecretAccessKey = awsSecretAccessKey;
            this.SQS_URL = SQS_URL;
            this.RegionEndpoint = RegionEndpoint;
        }

    }
}
