using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    public class FulfillmentInventorybyMarketplaceNotification : List<FulfillmentInventorybyMarketplace>
    {
    }

    public class FulfillmentInventorybyMarketplace
    {
        public string MarketplaceId { get; set; }
        public string ItemName { get; set; }
        public FulfillmentInventory FulfillmentInventory { get; set; }
        public List<string> Stores { get; set; }
    }

    public class FulfillmentInventory
    {
        public InboundQuantityBreakdown InboundQuantityBreakdown { get; set; }
        public int Fulfillable { get; set; }
        public int Unfulfillable { get; set; }
        public int Researching { get; set; }
        public ReservedQuantityBreakdown ReservedQuantityBreakdown { get; set; }
        public int FutureSupplyBuyable { get; set; }
        public int PendingCustomerOrderInTransit { get; set; }
    }

    public class InboundQuantityBreakdown
    {
        public int Working { get; set; }
        public int Shipped { get; set; }
        public int Receiving { get; set; }
    }

    public class ReservedQuantityBreakdown
    {
        public int WarehouseProcessing { get; set; }       
        public int WarehouseTransfer { get; set; } 
        public int PendingCustomerOrder { get; set; }
    }
}
