using FikaAmazonAPI.NotificationMessages;
using System;

namespace FikaAmazonAPI.Parameter.Notification
{
    public interface IMessageReceiver
    {
        void NewMessageRevicedTriger(NotificationMessageResponce message);
        void ErrorCatch(Exception ex);
    }
}
