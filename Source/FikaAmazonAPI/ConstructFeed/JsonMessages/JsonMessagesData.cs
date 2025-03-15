using System.Collections.Generic;

namespace FikaAmazonAPI.ConstructFeed.JsonMessages
{
    public class JsonMessagesData
    {
        public HeaderData header { get; set; }
        public IList<MessagesData> messages { get; set; } = new List<MessagesData>();
    }
}
