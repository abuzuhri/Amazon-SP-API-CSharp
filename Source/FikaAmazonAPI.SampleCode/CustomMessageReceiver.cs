using Amazon;
using FikaAmazonAPI.NotificationMessages;
using FikaAmazonAPI.Parameter.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Your Code here
        }
    }
}
