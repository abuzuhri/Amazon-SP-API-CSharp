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
                        new PriceData()
                        {
                            schedule = new List<SchedulePriceData>()
                                {
                                    new SchedulePriceData()
                                    {
                                        value_with_tax= itm.StandardPrice.Value
                                    }
                                }
                        }
                    },
                };

                if (itm.MinimumSellerAllowedPrice != null)
                {
                    patcheValueData.minimum_seller_allowed_price = new List<PriceData>
                    {
                        new PriceData
                        {
                            schedule = new List<SchedulePriceData>
                            {
                                new SchedulePriceData
                                {
                                    value_with_tax = itm.MinimumSellerAllowedPrice.Value,
                                    start_at = itm.MinimumSellerAllowedPrice.start_at,
                                    end_at = itm.MinimumSellerAllowedPrice.end_at
                                }
                            }
                        }
                    };
                }

                if (itm.MaximumSellerAllowedPrice != null)
                {
                    patcheValueData.maximum_seller_allowed_price = new List<PriceData>
                    {
                        new PriceData
                        {
                            schedule = new List<SchedulePriceData>
                            {
                                new SchedulePriceData
                                {
                                    value_with_tax = itm.MaximumSellerAllowedPrice.Value,
                                    start_at = itm.MaximumSellerAllowedPrice.start_at,
                                    end_at = itm.MaximumSellerAllowedPrice.end_at
                                }
                            }
                        }
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

        public void AddInventoryMessage(IList<InventoryMessage> messages)
        {
            int index = jsonMessagesData.messages.Count;
            foreach (var itm in messages)
            {
                var patcheValueData = new PatcheValueData()
                {
                    fulfillment_channel_code = "DEFAULT"
                };

                if (itm.QuantitySpecified)
                {
                    patcheValueData.quantity = itm.Quantity;
                }

                if (itm.FulfillmentLatencySpecified)
                {
                    patcheValueData.lead_time_to_ship_max_days = System.Convert.ToInt32(itm.FulfillmentLatency);
                }

                if (itm.RestockDateSpecified)
                {
                    patcheValueData.restock_date = itm.RestockDate;
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
                            path = "/attributes/fulfillment_availability",
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
