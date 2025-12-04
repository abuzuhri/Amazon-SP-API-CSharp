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

    public class CustomMessageRecieverWithResult : IMessageReceiverWithResult
    {
        public void ErrorCatch(Exception ex)
        {
            //Your code here
        }

        public bool NewMessageRevicedTriger(NotificationMessageResponce message)
        {
            Console.Write(".");
            //Your Code here

            // Return true to acknowledge and delete the message from queue, false to leave it in the queue.
            return false;
        }
    }
}
