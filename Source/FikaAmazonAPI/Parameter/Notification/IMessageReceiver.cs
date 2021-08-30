using Amazon.SQS.Model;
using FikaAmazonAPI.NotificationMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Parameter.Notification
{
    public interface IMessageReceiver
    {
        void NewMessageRevicedTriger(NotificationMessageResponce message);
        void ErrorCatch(Exception ex);
    }
}
