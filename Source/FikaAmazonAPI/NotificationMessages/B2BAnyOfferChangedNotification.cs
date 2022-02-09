using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    public partial class B2BAnyOfferChangedNotification
    {
        public string SellerId { get; set; }
        public OfferChangeTrigger OfferChangeTrigger { get; set; }
        public Summary Summary { get; set; }
        public List<Offer> Offers { get; set; }
    }

}
