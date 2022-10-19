using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders;
using FikaAmazonAPI.Parameter.VendorOrders;
using System.Data;
using Constants = FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders.Constants;

namespace FikaAmazonAPI.SampleCode
{
    public class VendorOrdersSample
    {
        AmazonConnection amazonConnection;

        public VendorOrdersSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        public void LoadNewPurchaseOrders()
        {
            // Load all new purchase orders not yet acknowledged.
            ParameterVendorOrdersGetPurchaseOrders filter = new ParameterVendorOrdersGetPurchaseOrders();
            filter.purchaseOrderState = Constants.PurchaseOrderState.New;
            LoadPurchaseOrders(filter);
        }

        public void LoadPurchaseOrdersChangedAfter(DateTime changedAfter)
        {
            // Load all purchase orders changed after a certain date.
            ParameterVendorOrdersGetPurchaseOrders filter = new ParameterVendorOrdersGetPurchaseOrders();
            filter.changedAfter = changedAfter;
            LoadPurchaseOrders(filter);
        }

        void LoadAcknowledgedPurchaseOrders()
        {
            // Load all purchase orders acknowledged but not closed.
            ParameterVendorOrdersGetPurchaseOrders filter = new ParameterVendorOrdersGetPurchaseOrders();
            filter.limit = 100;
            filter.purchaseOrderState = Constants.PurchaseOrderState.Acknowledged;
            LoadPurchaseOrders(filter);
        }

        private void LoadPurchaseOrders(ParameterVendorOrdersGetPurchaseOrders filter)
        {
            var orders = amazonConnection.VendorOrders.GetPurchaseOrders(filter);
            foreach (var order in orders)
            {
                OrderDetails details = order.OrderDetails;
                /* _log.LogInformation("PO {0}, {1}, date {2}, changed = {3}, stateChanged = {4}, buyer {5}, seller {6}, shipTo {7}, billTo {8}, shipStart {9}, shipEnd = {10}",
                    order.PurchaseOrderNumber, order.PurchaseOrderState, details.PurchaseOrderDate, details.PurchaseOrderChangedDate, details.PurchaseOrderStateChangedDate,
                    details.BuyingParty.PartyId, details.SellingParty.PartyId, details.ShipToParty.PartyId, details.BillToParty.PartyId, details.ShipWindow.StartDate, details.ShipWindow.EndDate); */
            }
        }

        public void LoadPurchaseOrdersWithStatusUpdates(DateTime? updatedAfter)
        {
            ParameterVendorOrdersGetPurchaseOrdersStatus filter = new ParameterVendorOrdersGetPurchaseOrdersStatus();
            filter.purchaseOrderStatus = Constants.PurchaseOrderStatus.OPEN;
            if (updatedAfter.HasValue)
            {
                filter.updatedAfter = updatedAfter;
            }
            var ordersStatus = amazonConnection.VendorOrders.GetPurchaseOrdersStatus(filter);
            foreach (OrderStatus orderStatus in ordersStatus)
            {
                /* _log.LogInformation("PO {0}, status {1}, poDate {2}, lastUpdatedDate {3}, seller {4}, shipTo {5}",
                    orderStatus.PurchaseOrderNumber, orderStatus.PurchaseOrderStatus, orderStatus.PurchaseOrderDate, orderStatus.LastUpdatedDate, orderStatus.SellingParty.PartyId, orderStatus.ShipToParty.PartyId); */
                List<OrderItemStatus> items = orderStatus.ItemStatus;
                foreach (OrderItemStatus item in items)
                {
                    foreach(OrderedQuantityDetails oqd in item.OrderedQuantity.OrderedQuantityDetails)
                    {
                    }
                    if (item.AcknowledgementStatus.AcknowledgementStatusDetails != null)
                    {
                        foreach (AcknowledgementStatusDetails asd in item.AcknowledgementStatus.AcknowledgementStatusDetails)
                        {
                        }
                    }
                    /* _log.LogDebug("{0}: ASIN {1}, Sku {2}, cost {3}, list {4}, ordered {5} {6}, status {7}, accepted {8}, rejected {9} {10}, receiveStatus {11}, receivedQuantity {12}, lastReceive {13}",
                        item.ItemSequenceNumber, item.BuyerProductIdentifier, item.VendorProductIdentifier, item.NetCost.Amount, item.ListPrice.Amount,
                        item.OrderedQuantity.OrderedQuantity.Amount, details.ToString(),
                        item.AcknowledgementStatus.ConfirmationStatus, 
                        item.AcknowledgementStatus.AcceptedQuantity != null ? item.AcknowledgementStatus.AcceptedQuantity.Amount : 0, 
                        item.AcknowledgementStatus.RejectedQuantity != null ? item.AcknowledgementStatus.RejectedQuantity.Amount : 0, ackDetails.ToString(),
                        item.ReceivingStatus.ReceiveStatus, item.ReceivingStatus.ReceivedQuantity != null ? item.ReceivingStatus.ReceivedQuantity.Amount : 0, 
                        item.ReceivingStatus.LastReceiveDate); */
                }
            }
        }

        public void LoadPurchaseOrder(string poNumber)
        {
            var order = amazonConnection.VendorOrders.GetPurchaseOrder(poNumber);
        }

        public void AcknowledgePo(string poNumber, NewPo newPo)
        {
            // Acknowledge PO specified. Assumes details of which items to accept and which to reject have already been constructed in the NewPo object.
            SubmitAcknowledgementRequest request = new SubmitAcknowledgementRequest();
            request.Acknowledgements = new List<OrderAcknowledgement>();
            OrderAcknowledgement acknowledgement = new OrderAcknowledgement();
            acknowledgement.PurchaseOrderNumber = poNumber;
            PartyIdentification sellingParty = new PartyIdentification();
            sellingParty.PartyId = "XXXX";
            acknowledgement.SellingParty = sellingParty;
            acknowledgement.AcknowledgementDate = DateTime.UtcNow;
            acknowledgement.Items = new List<OrderAcknowledgementItem>();
            foreach (KeyValuePair<string, PoItem> kvp in newPo.PoItems)
            {
                string sku = kvp.Key;
                PoItem poItem = kvp.Value;
                bool obsolete = poItem.Obsolete;
                OrderAcknowledgementItem item = new OrderAcknowledgementItem();
                item.ItemAcknowledgements = new List<OrderItemAcknowledgement>();
                item.ItemSequenceNumber = "";
                item.AmazonProductIdentifier = poItem.AmazonAsin;
                item.VendorProductIdentifier = sku;
                item.NetCost = new FikaAmazonAPI.AmazonSpApiSDK.Models.ListingsItems.Money("USD", poItem.AcceptedPrice.ToString());
                item.ListPrice = new FikaAmazonAPI.AmazonSpApiSDK.Models.ListingsItems.Money("USD", poItem.ListPrice.ToString());
                item.DiscountMultiplier = "";
                ItemQuantity orderedQuantity = new ItemQuantity();
                orderedQuantity.Amount = poItem.QuantityOrdered;
                orderedQuantity.UnitOfMeasure = ItemQuantity.UnitOfMeasureEnum.Eaches;
                item.OrderedQuantity = orderedQuantity;
                OrderItemAcknowledgement itemAcknowledgement = new OrderItemAcknowledgement();
                itemAcknowledgement.AcknowledgementCode = poItem.QuantityConfirmed > 0 ? AcknowledgementCode.Accepted : AcknowledgementCode.Rejected;
                ItemQuantity acknowledgeQuantity = new ItemQuantity();
                acknowledgeQuantity.Amount = poItem.QuantityConfirmed;
                acknowledgeQuantity.UnitOfMeasure = ItemQuantity.UnitOfMeasureEnum.Eaches;
                itemAcknowledgement.AcknowledgedQuantity = acknowledgeQuantity;
                if (poItem.QuantityConfirmed == 0)
                {
                    itemAcknowledgement.RejectionReason = obsolete ? RejectionReason.ObsoleteProduct : RejectionReason.TemporarilyUnavailable;
                }
                item.ItemAcknowledgements.Add(itemAcknowledgement);
                acknowledgement.Items.Add(item);
            }
            request.Acknowledgements.Add(acknowledgement);
            var transactionId = amazonConnection.VendorOrders.SubmitAcknowledgement(request);
        }



        public class NewPo
        {
            public NewPo(DateTime orderDate, DateOnly shipWindowStartDate, DateOnly shipWindowEndDate, string fulfillmentCenter, bool fcKnown)
            {
                OrderDate = orderDate;
                ShipWindowStartDate = shipWindowStartDate;
                ShipWindowEndDate = shipWindowEndDate;
                FulfillmentCenter = fulfillmentCenter;
                FcKnown = fcKnown;
                PoItems = new Dictionary<string, PoItem>();
            }
            public DateTime OrderDate { get; set; }
            public DateOnly ShipWindowStartDate { get; set; }
            public DateOnly ShipWindowEndDate { get; set; }
            public string FulfillmentCenter { get; set; }
            public bool FcKnown { get; set; }
            public Dictionary<string, PoItem> PoItems { get; set; }
            public bool IsFutureOrder
            {
                get
                {
                    bool isFutureOrder = false;
                    if (ShipWindowStartDate >= DateOnly.FromDateTime(DateTime.UtcNow.AddDays(7)))
                    {
                        isFutureOrder = true;
                    }
                    return isFutureOrder;
                }
            }
        }

        public class PoItem
        {
            public PoItem(string amazonAsin, int quantityOrdered, decimal acceptedPrice, decimal listPrice)
            {
                AmazonAsin = amazonAsin;
                QuantityOrdered = quantityOrdered;
                AcceptedPrice = acceptedPrice;
                ListPrice = listPrice;
            }
            public string AmazonAsin { get; set; }
            public int QuantityOrdered { get; set; }
            public decimal AcceptedPrice { get; set; }
            public decimal ListPrice { get; set; }
            public int QuantityConfirmed { get; set; }
            public bool Obsolete { get; set; }          // Is this item obsolete (i.e. we don't sell it to Vendor Central anymore)?
        }



    }
}
