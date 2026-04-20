using FikaAmazonAPI.NotificationMessages;
using System;

namespace FikaAmazonAPI.Parameter.Notification
{
    public interface IMessageReceiverWithResult
    {
        bool NewMessageRevicedTriger(NotificationMessageResponce message);
        void ErrorCatch(Exception ex);
    }
}
