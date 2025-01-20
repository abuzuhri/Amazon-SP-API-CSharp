using FikaAmazonAPI.ConstructFeed.JsonMessages;
using FikaAmazonAPI.ConstructFeed.Messages;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.ConstructFeed
{
    public class ConstructJSONFeedService
    {
        JsonMessagesData jsonMessagesData = new JsonMessagesData();
        public ConstructJSONFeedService(string sellerId, string version = "2.0", string issueLocale = "en_US")
        {
            jsonMessagesData.header = new HeaderData()
            {
                issueLocale = issueLocale,
                sellerId = sellerId,
                version = version
            };

        }


        public void AddPriceMessage(IList<PriceMessage> messages)
        {
            int index = jsonMessagesData.messages.Count;
            foreach (var itm in messages)
            {
                var patcheValueData = new PatcheValueData()
                {
                    currency = itm.StandardPrice.currency,
                    our_price = new List<PriceData>()
                    {
                        new PriceData(){ schedule = new List<SchedulePriceData>(){ new SchedulePriceData() { value_with_tax= itm.StandardPrice.Value }  } }
                    },
                };

                if (itm.MinimumSellerAllowedPrice != null)
                {
                    patcheValueData.minimum_seller_allowed_price = new List<PriceData>()
                    {
                        new PriceData(){ schedule = new List<SchedulePriceData>(){ new SchedulePriceData() { value_with_tax= itm.MinimumSellerAllowedPrice.Value }  } }
                    };
                }

                if (itm.MaximumSellerAllowedPrice != null)
                {
                    patcheValueData.maximum_seller_allowed_price = new List<PriceData>()
                    {
                        new PriceData(){ schedule = new List<SchedulePriceData>(){ new SchedulePriceData() { value_with_tax= itm.MaximumSellerAllowedPrice.Value }  } }
                    };
                }

                var msg = new MessagesData()
                {
                    messageId = ++index,
                    sku = itm.SKU,
                    operationType = "PATCH",
                    productType = "PRODUCT",
                    patches = new List<PatcheData>{
                        new PatcheData()
                        {
                            op = "replace",
                            path = "/attributes/purchasable_offer",
                            value =new List<PatcheValueData>{ patcheValueData }
                        }
                    }
                };

                jsonMessagesData.messages.Add(msg);
            }
        }

        public string GetJSON()
        {
            string jsonString = JsonConvert.SerializeObject(jsonMessagesData, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return jsonString;
        }
    }
}
