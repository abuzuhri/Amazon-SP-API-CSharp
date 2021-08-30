using FikaAmazonAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI
{
    public class AmazonConnection
    {
        private AmazonCredential Credentials { get; set; }

        

        public OrderService Orders => this._Orders ?? throw _NoCredentials;
        public ReportService Reports => this._Reports ?? throw _NoCredentials;
        public SolicitationService Solicitations => this._Solicitations ?? throw _NoCredentials;
        public FinancialService Financial => this._Financials ?? throw _NoCredentials;
        public CatalogItemService CatalogItem => this._CatalogItems ?? throw _NoCredentials;
        public ProductPricingService ProductPricing => this._ProductPricing ?? throw _NoCredentials;
        public AuthorizationService Authorization => this._Authorization ?? throw _NoCredentials;
        public AplusContentService AplusContent => this._AplusContent ?? throw _NoCredentials;
        public FbaInboundEligibilityService FbaInboundEligibility => this._FbaInboundEligibility ?? throw _NoCredentials;
        public FbaInboundService FbaInbound => this._FbaInbound ?? throw _NoCredentials;
        public FbaInventoryService FbaInventory => this._FbaInventory ?? throw _NoCredentials;
        public FbaOutboundService FbaOutbound => this._FbaOutbound ?? throw _NoCredentials;
        public FbaSmallandLightService FbaSmallandLight => this._FbaSmallandLight ?? throw _NoCredentials;
        public FeedService Feed => this._Feed ?? throw _NoCredentials;
        public ListingsItemService ListingsItem => this._ListingsItem ?? throw _NoCredentials;
        public MerchantFulfillmentService MerchantFulfillment => this._MerchantFulfillment ?? throw _NoCredentials;
        public MessagingService Messaging => this._Messaging ?? throw _NoCredentials;
        public NotificationService Notification => this._Notification ?? throw _NoCredentials;
        public ProductFeeService ProductFee => this._ProductFee ?? throw _NoCredentials;
        public SalesService Sales => this._Sales ?? throw _NoCredentials;
        public SellerService Seller => this._Seller ?? throw _NoCredentials;
        public ServicesService Services => this._Services ?? throw _NoCredentials;
        public ShipmentInvoicingService ShipmentInvoicing => this._ShipmentInvoicing ?? throw _NoCredentials;
        public ShippingService Shipping => this._Shipping ?? throw _NoCredentials;
        public UploadService Upload => this._Upload ?? throw _NoCredentials;


        private OrderService _Orders { get; set; }
        private ReportService _Reports { get; set; }
        private SolicitationService _Solicitations { get; set; }
        private FinancialService _Financials { get; set; }
        private CatalogItemService _CatalogItems { get; set; }
        private ProductPricingService _ProductPricing { get; set; }
        private AuthorizationService _Authorization { get; set; }
        private AplusContentService _AplusContent { get; set; }
        private FbaInboundEligibilityService _FbaInboundEligibility { get; set; }
        private FbaInboundService _FbaInbound { get; set; }
        private FbaInventoryService _FbaInventory { get; set; }
        private FbaOutboundService _FbaOutbound { get; set; }
        private FbaSmallandLightService _FbaSmallandLight { get; set; }
        private FeedService _Feed { get; set; }
        private ListingsItemService _ListingsItem { get; set; }
        private MerchantFulfillmentService _MerchantFulfillment { get; set; }
        private MessagingService _Messaging { get; set; }
        private NotificationService _Notification { get; set; }
        private ProductFeeService _ProductFee { get; set; }
        private SalesService _Sales { get; set; }
        private SellerService _Seller { get; set; }
        private ServicesService _Services { get; set; }
        private ShipmentInvoicingService _ShipmentInvoicing { get; set; }
        private ShippingService _Shipping { get; set; }
        private UploadService _Upload { get; set; }



        private UnauthorizedAccessException _NoCredentials = new UnauthorizedAccessException($"Error, you cannot make calls to Amazon without credentials!");


        public AmazonConnection(AmazonCredential Credentials)
        {
            this.Authenticate(Credentials);
        }

        public void Authenticate(AmazonCredential Credentials)
        {
            if (this.Credentials == default(AmazonCredential))
                Init(Credentials);
            else
                throw new InvalidOperationException("Error, you are already authenticated to amazon in this AmazonConnection, dispose of this connection and create a new one to connect to a different account.");
        }

        private void Init(AmazonCredential Credentials)
        {
            this.Credentials = Credentials;

            this._Orders = new OrderService(this.Credentials);
            this._Reports = new ReportService(this.Credentials);
            this._Solicitations = new SolicitationService(this.Credentials);
            this._Financials = new FinancialService(this.Credentials);
            this._CatalogItems = new CatalogItemService(this.Credentials);
            this._ProductPricing = new ProductPricingService(this.Credentials);

            this._FbaInbound = new FbaInboundService(this.Credentials);
            this._FbaInventory = new FbaInventoryService(this.Credentials);
            this._FbaOutbound = new FbaOutboundService(this.Credentials);
            this._FbaSmallandLight = new FbaSmallandLightService(this.Credentials);
            this._Feed = new FeedService(this.Credentials);
            this._ListingsItem = new ListingsItemService(this.Credentials);
            this._MerchantFulfillment = new MerchantFulfillmentService(this.Credentials);
            this._Messaging= new MessagingService(this.Credentials);
            this._Notification= new NotificationService(this.Credentials);
            this._ProductFee= new ProductFeeService(this.Credentials);
            this._Sales= new SalesService(this.Credentials);
            this._Seller= new SellerService(this.Credentials);
            this._Services= new ServicesService(this.Credentials);
            this._ShipmentInvoicing= new ShipmentInvoicingService(this.Credentials);
            this._Shipping= new ShippingService(this.Credentials);
            this._Upload= new UploadService(this.Credentials);
        }
    }
}
