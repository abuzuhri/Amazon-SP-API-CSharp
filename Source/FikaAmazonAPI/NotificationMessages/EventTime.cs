using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    public partial class EventTime
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Default { get; set; }
        public List<string> Examples { get; set; }
    }
}
