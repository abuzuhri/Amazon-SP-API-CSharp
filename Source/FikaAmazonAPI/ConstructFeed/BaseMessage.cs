using FikaAmazonAPI.ConstructFeed.Messages;
using System.Xml.Serialization;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.ConstructFeed
{
    public class BaseMessage
    {
        public int MessageID { get; set; }

        public OperationType OperationType { get; set; }

        public PriceMessage Price { get; set; }

        public InventoryMessage Inventory { get; set; }
        public ProductMessage Product { get; set; }


        public AmazonAppMessage AmazonApp { get; set; }
        public CatPILMessage CatPIL { get; set; }
        public AutoPartsItemMessage AutoPartsItem { get; set; }
        public CharacterDataMessage CharacterData { get; set; }
        public CustomerMessage Customer { get; set; }
        public CustomerReportMessage CustomerReport { get; set; }
        public EnhancedContentMessage EnhancedContent { get; set; }
        public ExternalCustomerMessage ExternalCustomer { get; set; }
        public ExternalOrderMessage ExternalOrder { get; set; }
        public FulfillmentCenterMessage FulfillmentCenter { get; set; }
        public FulfillmentOrderRequestMessage FulfillmentOrderRequest { get; set; }
        public FulfillmentOrderCancellationRequestMessage FulfillmentOrderCancellationRequest { get; set; }
        public CartonContentsRequest CartonContentsRequest { get; set; }
        public ImageMessage Image { get; set; }
        public LocalMessage Local { get; set; }
        public InvoiceConfirmationMessage InvoiceConfirmation { get; set; }
        public ItemMessage Item { get; set; }
        public MSVatMessage MSVat { get; set; }
        public LoyaltyMessage Loyalty { get; set; }
        public MultiChannelOrderReportMessage MultiChannelOrderReport { get; set; }
        public NavigationReportMessage NavigationReport { get; set; }
        public OfferMessage Offer { get; set; }
        public OrderAcknowledgementMessage OrderAcknowledgement { get; set; }
        public OrderAdjustmentMessage OrderAdjustment { get; set; }
        public OrderFulfillmentMessage OrderFulfillment { get; set; }
        public OrderSourcingOnDemandMessage OrderSourcingOnDemand { get; set; }
        public OrderNotificationReportMessage OrderNotificationReport { get; set; }
        public OrderReportMessage OrderReport { get; set; }
        public OverrideMessage Override { get; set; }
        public PointOfSaleMessage PointOfSale { get; set; }
        public TradeInPriceMessage TradeInPrice { get; set; }
        public ProcessingReportMessage ProcessingReport { get; set; }
        public ProductImageMessage ProductImage { get; set; }
        public PromotionRequestMessage PromotionRequest { get; set; }
        public RelationshipMessage Relationship { get; set; }
        public ReverseItemMessage ReverseItem { get; set; }
        public RichContentMessage RichContent { get; set; }
        public SettlementReportMessage SettlementReport { get; set; }
        public SalesHistoryMessage SalesHistory { get; set; }
        public StandardProductMessage StandardProduct { get; set; }
        public TestOrderRequestMessage TestOrderRequest { get; set; }
        public StoreMessage Store { get; set; }
        public StoreStockMovementMessage StoreStockMovement { get; set; }
        public WebstoreItemMessage WebstoreItem { get; set; }
        public PendingOrderReportMessage PendingOrderReport { get; set; }
        public PurchaseConfirmationMessage PurchaseConfirmation { get; set; }
        public SalesAdjustmentMessage SalesAdjustment { get; set; }
        public EasyShipDocumentMessage EasyShipDocument { get; set; }


        [XmlIgnore]
        public bool InventorySpecified { get { return Inventory != null; } }
        [XmlIgnore]
        public bool PriceSpecified { get { return Price != null; } }

        [XmlIgnore] public bool AmazonAppSpecified { get { return AmazonApp != null; } }
        [XmlIgnore] public bool CatPILSpecified { get { return CatPIL != null; } }
        [XmlIgnore] public bool AutoPartsItemSpecified { get { return AutoPartsItem != null; } }
        [XmlIgnore] public bool CharacterDataSpecified { get { return CharacterData != null; } }
        [XmlIgnore] public bool CustomerSpecified { get { return Customer != null; } }
        [XmlIgnore] public bool CustomerReportSpecified { get { return CustomerReport != null; } }
        [XmlIgnore] public bool EnhancedContentSpecified { get { return EnhancedContent != null; } }
        [XmlIgnore] public bool ExternalCustomerSpecified { get { return ExternalCustomer != null; } }
        [XmlIgnore] public bool ExternalOrderSpecified { get { return ExternalOrder != null; } }
        [XmlIgnore] public bool FulfillmentCenterSpecified { get { return FulfillmentCenter != null; } }
        [XmlIgnore] public bool FulfillmentOrderRequestSpecified { get { return FulfillmentOrderRequest != null; } }
        [XmlIgnore] public bool FulfillmentOrderCancellationRequestSpecified { get { return FulfillmentOrderCancellationRequest != null; } }
        [XmlIgnore] public bool CartonContentsRequestSpecified { get { return CartonContentsRequest != null; } }
        [XmlIgnore] public bool ImageSpecified { get { return Image != null; } }
        [XmlIgnore] public bool LocalSpecified { get { return Local != null; } }
        [XmlIgnore] public bool InvoiceConfirmationSpecified { get { return InvoiceConfirmation != null; } }
        [XmlIgnore] public bool ItemSpecified { get { return Item != null; } }
        [XmlIgnore] public bool MSVatSpecified { get { return MSVat != null; } }
        [XmlIgnore] public bool LoyaltySpecified { get { return Loyalty != null; } }
        [XmlIgnore] public bool MultiChannelOrderReportSpecified { get { return MultiChannelOrderReport != null; } }
        [XmlIgnore] public bool NavigationReportSpecified { get { return NavigationReport != null; } }
        [XmlIgnore] public bool OfferSpecified { get { return Offer != null; } }
        [XmlIgnore] public bool OrderAcknowledgementSpecified { get { return OrderAcknowledgement != null; } }
        [XmlIgnore] public bool OrderAdjustmentSpecified { get { return OrderAdjustment != null; } }
        [XmlIgnore] public bool OrderFulfillmentSpecified { get { return OrderFulfillment != null; } }
        [XmlIgnore] public bool OrderSourcingOnDemandSpecified { get { return OrderSourcingOnDemand != null; } }
        [XmlIgnore] public bool OrderNotificationReportSpecified { get { return OrderNotificationReport != null; } }
        [XmlIgnore] public bool OrderReportSpecified { get { return OrderReport != null; } }
        [XmlIgnore] public bool OverrideSpecified { get { return Override != null; } }
        [XmlIgnore] public bool PointOfSaleSpecified { get { return PointOfSale != null; } }
        [XmlIgnore] public bool TradeInPriceSpecified { get { return TradeInPrice != null; } }
        [XmlIgnore] public bool ProcessingReportSpecified { get { return ProcessingReport != null; } }
        [XmlIgnore] public bool ProductSpecified { get { return Product != null; } }
        [XmlIgnore] public bool ProductImageSpecified { get { return ProductImage != null; } }
        [XmlIgnore] public bool PromotionRequestSpecified { get { return PromotionRequest != null; } }
        [XmlIgnore] public bool RelationshipSpecified { get { return Relationship != null; } }
        [XmlIgnore] public bool ReverseItemSpecified { get { return ReverseItem != null; } }
        [XmlIgnore] public bool RichContentSpecified { get { return RichContent != null; } }
        [XmlIgnore] public bool SettlementReportSpecified { get { return SettlementReport != null; } }
        [XmlIgnore] public bool SalesHistorySpecified { get { return SalesHistory != null; } }
        [XmlIgnore] public bool StandardProductSpecified { get { return StandardProduct != null; } }
        [XmlIgnore] public bool TestOrderRequestSpecified { get { return TestOrderRequest != null; } }
        [XmlIgnore] public bool StoreSpecified { get { return Store != null; } }
        [XmlIgnore] public bool StoreStockMovementSpecified { get { return StoreStockMovement != null; } }
        [XmlIgnore] public bool WebstoreItemSpecified { get { return WebstoreItem != null; } }
        [XmlIgnore] public bool PendingOrderReportSpecified { get { return PendingOrderReport != null; } }
        [XmlIgnore] public bool PurchaseConfirmationSpecified { get { return PurchaseConfirmation != null; } }
        [XmlIgnore] public bool SalesAdjustmentSpecified { get { return SalesAdjustment != null; } }
        [XmlIgnore] public bool EasyShipDocumentSpecified { get { return EasyShipDocument != null; } }



    }
}
