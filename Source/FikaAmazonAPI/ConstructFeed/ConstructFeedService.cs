using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;

namespace FikaAmazonAPI.ConstructFeed
{



    public class ConstructFeedService
    {

        private FeedAmazonEnvelope envelope = new FeedAmazonEnvelope();
        public ConstructFeedService(string sellerId, string documentVersion, bool? purgeAndReplace = null)
        {
            envelope.Header = new FeedHeader()
            {
                MerchantIdentifier = sellerId,
                DocumentVersion = documentVersion,
            };
            envelope.PurgeAndReplace = purgeAndReplace;
        }

        public void AddPriceMessage(IList<PriceMessage> messages)
        {
            var msgs = new List<BaseMessage>();
            int index = 1;
            foreach (var itm in messages)
            {
                msgs.Add(new BaseMessage()
                {
                    MessageID = index++,
                    Price = itm,
                    OperationType = Utils.Constants.OperationType.Update
                });
            }
            envelope.Message = msgs;
            envelope.MessageType = Utils.Constants.FeedMessageType.Price;
        }
        public void AddOfferMessage(IList<OfferMessage> messages, Constants.OperationType operationType = Constants.OperationType.Update)
        {
            var msgs = new List<BaseMessage>();
            int index = 1;
            foreach (var itm in messages)
            {
                msgs.Add(new BaseMessage()
                {
                    MessageID = index++,
                    Offer = itm,
                    OperationType = operationType
                });
            }
            envelope.Message = msgs;
            envelope.MessageType = Utils.Constants.FeedMessageType.Product;

        }

        public void AddInventoryMessage(IList<InventoryMessage> messages)
        {
            var msgs = new List<BaseMessage>();
            int index = 1;
            foreach (var itm in messages)
            {
                msgs.Add(new BaseMessage()
                {
                    MessageID = index++,
                    Inventory = itm,
                    OperationType = Utils.Constants.OperationType.Update
                });
            }
            envelope.Message = msgs;
            envelope.MessageType = Utils.Constants.FeedMessageType.Inventory;

        }

        public void AddProductMessage(IList<ProductMessage> messages, Constants.OperationType operationType = Constants.OperationType.Update)
        {
            var msgs = new List<BaseMessage>();
            int index = 1;
            foreach (var itm in messages)
            {
                msgs.Add(new BaseMessage()
                {
                    MessageID = index++,
                    Product = itm,
                    OperationType = operationType
                });
            }
            envelope.Message = msgs;
            envelope.MessageType = Utils.Constants.FeedMessageType.Product;
        }

        public void AddCartonContentsRequest(IList<CartonContentsRequest> shipments)
        {
            var msgs = new List<BaseMessage>();
            int index = 1;
            foreach (var itm in shipments)
            {
                msgs.Add(new BaseMessage()
                {
                    MessageID = index++,
                    CartonContentsRequest = itm
                });
            }
            envelope.Message = msgs;
            envelope.MessageType = Utils.Constants.FeedMessageType.CartonContentsRequest;
        }
        public void AddOrderFulfillmentMessage(IList<OrderFulfillmentMessage> messages, Constants.OperationType operationType = Constants.OperationType.Update)
        {
            var msgs = new List<BaseMessage>();
            int index = 1;
            foreach (var itm in messages)
            {
                msgs.Add(new BaseMessage()
                {
                    MessageID = index++,
                    OrderFulfillment = itm,
                    OperationType = operationType
                });
            }
            envelope.Message = msgs;
            envelope.MessageType = Utils.Constants.FeedMessageType.OrderFulfillment;
        }

        public void AddOrderAcknowledgementMessage(IList<OrderAcknowledgementMessage> messages, Constants.OperationType operationType = Constants.OperationType.Update)
        {
            var msgs = new List<BaseMessage>();
            int index = 1;
            foreach (var itm in messages)
            {
                msgs.Add(new BaseMessage()
                {
                    MessageID = index++,
                    OrderAcknowledgement = itm,
                    OperationType = operationType
                });
            }
            envelope.Message = msgs;
            envelope.MessageType = Utils.Constants.FeedMessageType.OrderAcknowledgement;
        }

        public void AddOrderAdjustmentMessage(IList<OrderAdjustmentMessage> messages, Constants.OperationType operationType = Constants.OperationType.Update)
        {
            var msgs = new List<BaseMessage>();
            int index = 1;
            foreach (var itm in messages)
            {
                msgs.Add(new BaseMessage()
                {
                    MessageID = index++,
                    OrderAdjustment = itm,
                    OperationType = operationType
                });
            }
            envelope.Message = msgs;
            envelope.MessageType = Utils.Constants.FeedMessageType.OrderAdjustment;
        }

        public void AddProductImageMessage(IList<ProductImageMessage> messages, Constants.OperationType operationType = Constants.OperationType.Update)
        {
            var msgs = new List<BaseMessage>();
            int index = 1;
            foreach (var itm in messages)
            {
                msgs.Add(new BaseMessage()
                {
                    MessageID = index++,
                    ProductImage = itm,
                    OperationType = operationType
                });
            }
            envelope.Message = msgs;
            envelope.MessageType = Utils.Constants.FeedMessageType.ProductImage;
        }

        public void AddEasyShipDocumentMessage(IList<EasyShipDocumentMessage> messages, Constants.OperationType operationType = Constants.OperationType.Update)
        {
            var msgs = new List<BaseMessage>();
            int index = 1;
            foreach (var itm in messages)
            {
                msgs.Add(new BaseMessage()
                {
                    MessageID = index++,
                    EasyShipDocument = itm,
                    OperationType = operationType
                });
            }
            envelope.Message = msgs;
            envelope.MessageType = Utils.Constants.FeedMessageType.EasyShipDocument;
        }

        public string GetXML()
        {
            return LinqHelper.SerializeObject(envelope);
        }

    }
}
