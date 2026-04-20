using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public class MerchantShippingGroupMessage
    {
        /// A dictionary containing all the possible Merchant Shipping Groups. 
        /// The dict keys = the merchant_shipping_group_name. The dict values = merchant_shipping_group enum id key.
        /// This is meant to be set once (in the beginning) and it will reuse it every time.
        public static Dictionary<string, string> MerchantShippingGroupNamesKeys { get; set; }

        public string SKU { get; set; }

        public string MerchantShippingGroupId { get; set; }

        private string merchant_shipping_group_name;
        public string MerchantShippingGroupName
        {
            get => merchant_shipping_group_name;
            set
            {
                merchant_shipping_group_name = value;

                if (MerchantShippingGroupNamesKeys?.ContainsKey(value) == true)
                {
                    MerchantShippingGroupId = MerchantShippingGroupNamesKeys[value];
                }
                else if (MerchantShippingGroupNamesKeys?.Count > 0)
                {
                    MerchantShippingGroupId = null;
                    throw new Exception($"Merchant Shipping Group Id not found for '{MerchantShippingGroupName}'!");
                }
            } 
        
        }
    }
}
