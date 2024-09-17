using FikaAmazonAPI.AmazonSpApiSDK.Models.Exceptions;
using FikaAmazonAPI.Services;
using FikaAmazonAPI.Utils;
using System;
using System.Globalization;
using System.Threading;

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
        public EasyShip20220323Service EasyShip20220323 => this._EasyShip20220323 ?? throw _NoCredentials;
        public FbaInboundService FbaInbound => this._FbaInbound ?? throw _NoCredentials;
        public FbaInventoryService FbaInventory => this._FbaInventory ?? throw _NoCredentials;
        public FbaOutboundService FbaOutbound => this._FbaOutbound ?? throw _NoCredentials;
        public FbaSmallandLightService FbaSmallandLight => this._FbaSmallandLight ?? throw _NoCredentials;
        public FeedService Feed => this._Feed ?? throw _NoCredentials;
        public ListingsItemService ListingsItem => this._ListingsItem ?? throw _NoCredentials;
        public RestrictionService Restrictions => this._Restrictions ?? throw _NoCredentials;
        public MerchantFulfillmentService MerchantFulfillment => this._MerchantFulfillment ?? throw _NoCredentials;
        public MessagingService Messaging => this._Messaging ?? throw _NoCredentials;
        public NotificationService Notification => this._Notification ?? throw _NoCredentials;
        public ProductFeeService ProductFee => this._ProductFee ?? throw _NoCredentials;
        public ProductTypeService ProductType => this._ProductType ?? throw _NoCredentials;
        public SalesService Sales => this._Sales ?? throw _NoCredentials;
        public SellerService Seller => this._Seller ?? throw _NoCredentials;
        public ServicesService Services => this._Services ?? throw _NoCredentials;
        public ShipmentInvoicingService ShipmentInvoicing => this._ShipmentInvoicing ?? throw _NoCredentials;
        public ShippingService Shipping => this._Shipping ?? throw _NoCredentials;
        public ShippingServiceV2 ShippingV2 => this._ShippingV2 ?? throw _NoCredentials;
        public UploadService Upload => this._Upload ?? throw _NoCredentials;
        public TokenService Tokens => this._Tokens ?? throw _NoCredentials;
        public FulFillmentInboundService FulFillmentInbound => this._FulFillmentInbound ?? throw _NoCredentials;
        public FulFillmentInboundServicev20240320 FulFillmentInboundv20240320 => this._FulFillmentInboundv20240320 ?? throw _NoCredentials;
        public FulFillmentOutboundService FulFillmentOutbound => this._FulFillmentOutbound ?? throw _NoCredentials;
        public VendorDirectFulfillmentOrderService VendorDirectFulfillmentOrders => this._VendorDirectFulfillmentOrders ?? throw _NoCredentials;
        public VendorOrderService VendorOrders => this._VendorOrders ?? throw _NoCredentials;

        public VendorTransactionStatusService VendorTransactionStatus => this._VendorTransactionStatus ?? throw _NoCredentials;

        private OrderService _Orders { get; set; }
        private ReportService _Reports { get; set; }
        private SolicitationService _Solicitations { get; set; }
        private FinancialService _Financials { get; set; }
        private CatalogItemService _CatalogItems { get; set; }
        private ProductPricingService _ProductPricing { get; set; }
        private AuthorizationService _Authorization { get; set; }
        private AplusContentService _AplusContent { get; set; }
        private FbaInboundEligibilityService _FbaInboundEligibility { get; set; }
        private EasyShip20220323Service _EasyShip20220323 { get; set; }
        private FbaInboundService _FbaInbound { get; set; }
        private FbaInventoryService _FbaInventory { get; set; }
        private FbaOutboundService _FbaOutbound { get; set; }
        private FbaSmallandLightService _FbaSmallandLight { get; set; }
        private FeedService _Feed { get; set; }
        private ListingsItemService _ListingsItem { get; set; }
        private RestrictionService _Restrictions { get; set; }
        private MerchantFulfillmentService _MerchantFulfillment { get; set; }
        private MessagingService _Messaging { get; set; }
        private NotificationService _Notification { get; set; }
        private ProductFeeService _ProductFee { get; set; }
        private ProductTypeService _ProductType { get; set; }
        private SalesService _Sales { get; set; }
        private SellerService _Seller { get; set; }
        private ServicesService _Services { get; set; }
        private ShipmentInvoicingService _ShipmentInvoicing { get; set; }
        private ShippingService _Shipping { get; set; }
        private ShippingServiceV2 _ShippingV2 { get; set; }
        private UploadService _Upload { get; set; }
        private TokenService _Tokens { get; set; }
        private FulFillmentInboundService _FulFillmentInbound { get; set; }
        private FulFillmentInboundServicev20240320 _FulFillmentInboundv20240320 { get; set; }
        private FulFillmentOutboundService _FulFillmentOutbound { get; set; }
        private VendorDirectFulfillmentOrderService _VendorDirectFulfillmentOrders { get; set; }
        private VendorOrderService _VendorOrders { get; set; }
        private VendorTransactionStatusService _VendorTransactionStatus { get; set; }

        private UnauthorizedAccessException _NoCredentials = new UnauthorizedAccessException($"Error, you cannot make calls to Amazon without credentials!");

        public string RefNumber { get; set; }
        public AmazonConnection(AmazonCredential Credentials, string RefNumber = null, CultureInfo? cultureInfo = null)
        {
            this.Authenticate(Credentials);
            this.RefNumber = RefNumber;
            Thread.CurrentThread.CurrentCulture = cultureInfo ?? CultureInfo.CurrentCulture;
        }

        private void Authenticate(AmazonCredential Credentials)
        {
            if (this.Credentials == default(AmazonCredential))
                Init(Credentials);
            else
                throw new InvalidOperationException("Error, you are already authenticated to amazon in this AmazonConnection, dispose of this connection and create a new one to connect to a different account.");
        }

        private void Init(AmazonCredential Credentials)
        {
            ValidateCredentials(Credentials);

            this.Credentials = Credentials;

            this._Authorization = new AuthorizationService(this.Credentials);
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
            this._FbaInboundEligibility = new FbaInboundEligibilityService(this.Credentials);
            this._EasyShip20220323 = new EasyShip20220323Service(this.Credentials);
            this._AplusContent = new AplusContentService(this.Credentials);
            this._Feed = new FeedService(this.Credentials);
            this._ListingsItem = new ListingsItemService(this.Credentials);
            this._Restrictions = new RestrictionService(this.Credentials);
            this._MerchantFulfillment = new MerchantFulfillmentService(this.Credentials);
            this._Messaging = new MessagingService(this.Credentials);
            this._Notification = new NotificationService(this.Credentials);
            this._ProductFee = new ProductFeeService(this.Credentials);
            this._ProductType = new ProductTypeService(this.Credentials);
            this._Sales = new SalesService(this.Credentials);
            this._Seller = new SellerService(this.Credentials);
            this._Services = new ServicesService(this.Credentials);
            this._ShipmentInvoicing = new ShipmentInvoicingService(this.Credentials);
            this._Shipping = new ShippingService(this.Credentials);
            this._ShippingV2 = new ShippingServiceV2(this.Credentials);
            this._Upload = new UploadService(this.Credentials);
            this._Tokens = new TokenService(this.Credentials);
            this._FulFillmentInbound = new FulFillmentInboundService(this.Credentials);
            this._FulFillmentInboundv20240320 = new FulFillmentInboundServicev20240320(this.Credentials);
            this._FulFillmentOutbound = new FulFillmentOutboundService(this.Credentials);
            this._VendorDirectFulfillmentOrders = new VendorDirectFulfillmentOrderService(this.Credentials);
            this._VendorOrders = new VendorOrderService(this.Credentials);
            this._VendorTransactionStatus = new VendorTransactionStatusService(this.Credentials);

            AmazonCredential.DebugMode = this.Credentials.IsDebugMode;
        }
        private void ValidateCredentials(AmazonCredential Credentials)
        {
            if (Credentials == null)
                throw new AmazonUnauthorizedException($"Error, you cannot make calls to Amazon without credentials!");
            //Remove AWS authorization
            //else if (string.IsNullOrEmpty(Credentials.AccessKey))
            //    throw new AmazonInvalidInputException($"InvalidInput, AccessKey cannot be empty!");
            //else if (string.IsNullOrEmpty(Credentials.SecretKey))
            //    throw new AmazonInvalidInputException($"InvalidInput, SecretKey  cannot be empty!");
            //else if (string.IsNullOrEmpty(Credentials.RoleArn))
            //    throw new AmazonInvalidInputException($"InvalidInput, RoleArn cannot be empty!");
            else if (string.IsNullOrEmpty(Credentials.ClientId))
                throw new AmazonInvalidInputException($"InvalidInput, ClientId cannot be empty!");
            else if (string.IsNullOrEmpty(Credentials.ClientSecret))
                throw new AmazonInvalidInputException($"InvalidInput, ClientSecret  cannot be empty!");
            else if (string.IsNullOrEmpty(Credentials.RefreshToken))
                throw new AmazonInvalidInputException($"InvalidInput, RefreshToken cannot be empty!");
            else if (Credentials.MarketPlace == null)
            {
                if (string.IsNullOrEmpty(Credentials.MarketPlaceID))
                {
                    throw new AmazonInvalidInputException($"InvalidInput, MarketPlace or MarketPlaceID cannot be null for both!");
                }
                else
                {
                    Credentials.MarketPlace = MarketPlace.GetMarketPlaceByID(Credentials.MarketPlaceID);
                }
            }

        }
        public MarketPlace GetCurrentMarketplace { get { return Credentials.MarketPlace; } }
        public string GetCurrentSellerID { get { return Credentials.SellerID; } }
    }
}
