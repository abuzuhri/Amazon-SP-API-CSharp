using FikaAmazonAPI.NotificationMessages;
using FikaAmazonAPI.Parameter.Notification;

namespace FikaAmazonAPI.SampleCode
{
    public class CustomMessageReceiver : IMessageReceiver
    {

        public void ErrorCatch(Exception ex)
        {
            //Your code here
        }

        public void NewMessageRevicedTriger(NotificationMessageResponce message)
        {
            Console.Write(".");
            //Your Code here
        }
    }
}
