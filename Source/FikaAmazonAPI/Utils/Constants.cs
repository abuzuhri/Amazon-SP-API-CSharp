using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.Utils
{
    public class Constants
    {
        public readonly static string AmazonTokenEndPoint = "https://api.amazon.com/auth/o2/token";
        public readonly static string DateISO8601Format = "yyyy-MM-ddTHH:mm:ss.fffZ";
        public readonly static string TestCase200 = "TEST_CASE_200";
        public readonly static string TestCase400 = "TEST_CASE_400";

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Environments
        {
            Sandbox, Production
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum GranularityEnum
        {
            Hour,
            Day,
            Week,
            Month,
            Year,
            Total
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OperationType
        {
            Update,
            Delete,
            PartialUpdate,
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ShipmentStatusList
        {
            WORKING,
            SHIPPED,
            RECEIVING,
            CANCELLED,
            DELETED,
            CLOSED,
            ERROR,
            IN_TRANSIT,
            DELIVERED,
            CHECKED_IN,
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum IncludedData
        {
            attributes,
            dimensions,
            identifiers,
            images,
            productTypes,
            relationships,
            salesRanks,
            summaries,
            vendorDetails
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum QueryType
        {
            SHIPMENT,
            DATE_RANGE,
            NEXT_TOKEN
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PageType
        {
            PackageLabel_Letter_2,
            PackageLabel_Letter_4,
            PackageLabel_Letter_6,
            PackageLabel_Letter_6_CarrierLeft,
            PackageLabel_A4_2,
            PackageLabel_A4_4,
            PackageLabel_Plain_Paper,
            PackageLabel_Plain_Paper_CarrierBottom,
            PackageLabel_Thermal,
            PackageLabel_Thermal_Unified,
            PackageLabel_Thermal_NonPCP,
            PackageLabel_Thermal_No_Carrier_Rotation
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LabelType
        {
            BARCODE_2D,
            UNIQUE,
            PALLET,
            SELLER_LABEL
        }
        /// <summary>
        /// List of all FeedType https://github.com/amzn/selling-partner-api-docs/blob/main/references/feeds-api/feedtype-values.md
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FeedType
        {
            JSON_LISTINGS_FEED,
            POST_PRODUCT_DATA,
            POST_INVENTORY_AVAILABILITY_DATA,
            POST_PRODUCT_OVERRIDES_DATA,
            POST_PRODUCT_PRICING_DATA,
            POST_PRODUCT_IMAGE_DATA,
            POST_PRODUCT_RELATIONSHIP_DATA,
            POST_FLAT_FILE_INVLOADER_DATA,
            POST_FLAT_FILE_LISTINGS_DATA,
            POST_FLAT_FILE_BOOKLOADER_DATA,
            POST_FLAT_FILE_CONVERGENCE_LISTINGS_DATA,
            POST_FLAT_FILE_PRICEANDQUANTITYONLY_UPDATE_DATA,
            POST_UIEE_BOOKLOADER_DATA,
            POST_STD_ACES_DATA,
            POST_ORDER_ACKNOWLEDGEMENT_DATA,
            POST_PAYMENT_ADJUSTMENT_DATA,
            POST_ORDER_FULFILLMENT_DATA,
            POST_INVOICE_CONFIRMATION_DATA,
            POST_EXPECTED_SHIP_DATE_SOD,
            POST_FLAT_FILE_ORDER_ACKNOWLEDGEMENT_DATA,
            POST_FLAT_FILE_PAYMENT_ADJUSTMENT_DATA,
            POST_FLAT_FILE_FULFILLMENT_DATA,
            POST_EXPECTED_SHIP_DATE_SOD_FLAT_FILE,
            POST_FULFILLMENT_ORDER_REQUEST_DATA,
            POST_FULFILLMENT_ORDER_CANCELLATION_REQUEST_DATA,
            POST_FBA_INBOUND_CARTON_CONTENTS,
            POST_FLAT_FILE_FULFILLMENT_ORDER_REQUEST_DATA,
            POST_FLAT_FILE_FULFILLMENT_ORDER_CANCELLATION_REQUEST_DATA,
            POST_FLAT_FILE_FBA_CREATE_INBOUND_PLAN,
            POST_FLAT_FILE_FBA_UPDATE_INBOUND_PLAN,
            POST_FLAT_FILE_FBA_CREATE_REMOVAL,
            RFQ_UPLOAD_FEED,
            POST_EASYSHIP_DOCUMENTS,


            UPLOAD_VAT_INVOICE




        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FirstDayOfWeek
        {
            monday,
            sunday
        }

        [JsonConverter(typeof(StringEnumConverter))]
        /// <summary>
        /// A list of NotificationType
        /// </summary>
        public enum NotificationType
        {
            ANY_OFFER_CHANGED,
            FEED_PROCESSING_FINISHED,
            FBA_OUTBOUND_SHIPMENT_STATUS,
            FEE_PROMOTION,
            FULFILLMENT_ORDER_STATUS,
            REPORT_PROCESSING_FINISHED,
            BRANDED_ITEM_CONTENT_CHANGE,
            ITEM_PRODUCT_TYPE_CHANGE,
            ITEM_INVENTORY_EVENT_CHANGE,
            ITEM_SALES_EVENT_CHANGE,
            LISTINGS_ITEM_STATUS_CHANGE,
            LISTINGS_ITEM_ISSUES_CHANGE,
            LISTINGS_ITEM_MFN_QUANTITY_CHANGE,
            DETAIL_PAGE_TRAFFIC_EVENT,
            MFN_ORDER_STATUS_CHANGE,
            B2B_ANY_OFFER_CHANGED,
            ACCOUNT_STATUS_CHANGED,
            EXTERNAL_FULFILLMENT_SHIPMENT_STATUS_CHANGE,
            PRODUCT_TYPE_DEFINITIONS_CHANGE,
            ORDER_STATUS_CHANGE,
            ORDER_CHANGE,
            PRICING_HEALTH,
            FBA_INVENTORY_AVAILABILITY_CHANGES
        }

        /// <summary>
        /// SortOrder
        /// </summary>
        /// <value>Current Sort Order.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SortOrderEnum
        {

            /// <summary>
            /// Enum ASC for value: ASC
            /// </summary>
            [EnumMember(Value = "ASC")]
            ASC = 1,

            /// <summary>
            /// Enum DESC for value: DESC
            /// </summary>
            [EnumMember(Value = "DESC")]
            DESC = 2
        }

        [JsonConverter(typeof(StringEnumConverter))]
        /// <summary>
        /// A list of OrderStatus values
        /// </summary>
        public enum OrderStatuses
        {
            /// <summary>
            /// This status is available for pre-orders only. The order has been placed, payment has not been authorized, and the release date of the item is in the future.
            /// </summary>
            PendingAvailability,
            /// <summary>
            /// The order has been placed but payment has not been authorized
            /// </summary>
            Pending,
            /// <summary>
            /// Payment has been authorized and the order is ready for shipment, but no items in the order have been shipped
            /// </summary>
            Unshipped,
            /// <summary>
            /// One or more, but not all, items in the order have been shipped
            /// </summary>
            PartiallyShipped,
            /// <summary>
            /// All items in the order have been shipped
            /// </summary>
            Shipped,
            /// <summary>
            /// All items in the order have been shipped. The seller has not yet given confirmation to Amazon that the invoice has been shipped to the buyer
            /// </summary>
            InvoiceUnconfirmed,
            /// <summary>
            /// The order has been canceled
            /// </summary>
            Canceled,
            /// <summary>
            /// The order cannot be fulfilled. This state applies only to Multi-Channel Fulfillment orders
            /// </summary>
            Unfulfillable
        }

        [JsonConverter(typeof(StringEnumConverter))]
        /// <summary>
        /// A list of payment method
        /// </summary>
        public enum PaymentMethods
        {
            /// <summary>
            /// Cash on delivery
            /// </summary>
            COD,
            /// <summary>
            /// Convenience store payment
            /// </summary>
            CVS,
            /// <summary>
            /// Any payment method other than COD or CVS
            /// </summary>
            Other
        }

        [JsonConverter(typeof(StringEnumConverter))]
        /// <summary>
        /// A list of EasyShipShipmentStatus , Used to select Easy Ship orders with statuses that match the specified values
        /// </summary>
        public enum EasyShipShipmentStatuses
        {
            PendingPickUp,
            LabelCanceled,
            PickedUp,
            OutForDelivery,
            Damaged,
            Delivered,
            RejectedByBuyer,
            Undeliverable,
            ReturnedToSeller,
            ReturningToSeller
        }

        [JsonConverter(typeof(StringEnumConverter))]
        /// <summary>
        /// A list that indicates how an order was fulfilled
        /// </summary>
        public enum FulfillmentChannels
        {
            /// <summary>
            /// Fulfillment by Amazon
            /// </summary>
            [EnumMember(Value = "AFN")]
            AFN,
            /// <summary>
            /// Fulfilled by the seller
            /// </summary>
            [EnumMember(Value = "MFN")]
            MFN
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ProcessingStatuses
        {
            /// <summary>
            /// The report was cancelled. There are two ways a report can be cancelled: an explicit cancellation request before the report starts processing, or an automatic cancellation if there is no data to return.
            /// </summary>
            CANCELLED,
            /// <summary>
            /// The report has completed processing.
            /// </summary>
            DONE,
            /// <summary>
            /// The report was aborted due to a fatal error.
            /// </summary>
            FATAL,
            /// <summary>
            /// The report is being processed.
            /// </summary>
            IN_PROGRESS,
            /// <summary>
            /// The report has not yet started processing. It may be waiting for another IN_PROGRESS report.
            /// </summary>
            IN_QUEUE
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ItemType
        {
            Asin,
            Sku
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum IdentifiersType
        {
            ASIN,
            EAN,
            GTIN,
            ISBN,
            JAN,
            MINSAN,
            SKU,
            UPC
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum CustomerType
        {
            Consumer,
            Business
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ItemCondition
        {
            New,
            Used,
            Collectible,
            Refurbished,
            Club
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OfferTypeEnum
        {
            /// <summary>
            /// Enum B2C for value: B2C
            /// </summary>
            [EnumMember(Value = "B2C")]
            B2C,
            /// <summary>
            /// Enum B2B for value: B2B
            /// </summary>
            [EnumMember(Value = "B2B")]
            B2B
        }

        [JsonConverter(typeof(StringEnumConverter))]

        public enum QuantityDiscountType
        {

            /// <summary>
            /// Enum QUANTITYDISCOUNT for value: QUANTITY_DISCOUNT
            /// </summary>
            [EnumMember(Value = "QUANTITY_DISCOUNT")]
            QUANTITYDISCOUNT = 1
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum BuyerType
        {
            B2C,
            B2B
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RestrictedReportTypes
        {
            GET_AMAZON_FULFILLED_SHIPMENTS_DATA_INVOICING,
            GET_AMAZON_FULFILLED_SHIPMENTS_DATA_TAX,
            GET_FLAT_FILE_ACTIONABLE_ORDER_DATA_SHIPPING,
            GET_FLAT_FILE_ORDER_REPORT_DATA_SHIPPING,
            GET_FLAT_FILE_ORDER_REPORT_DATA_INVOICING,
            GET_FLAT_FILE_ORDER_REPORT_DATA_TAX,
            GET_FLAT_FILE_ORDERS_RECONCILIATION_DATA_TAX,
            GET_FLAT_FILE_ORDERS_RECONCILIATION_DATA_INVOICING,
            GET_FLAT_FILE_ORDERS_RECONCILIATION_DATA_SHIPPING,
            GET_ORDER_REPORT_DATA_INVOICING,
            GET_ORDER_REPORT_DATA_TAX,
            GET_ORDER_REPORT_DATA_SHIPPING,
            GET_EASYSHIP_DOCUMENTS,
            GET_GST_MTR_B2B_CUSTOM,
            GET_VAT_TRANSACTION_DATA,
            SC_VAT_TAX_REPORT
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ReportTypes
        {
            GET_VENDOR_SALES_DIAGNOSTIC_REPORT,
            GET_VENDOR_SALES_REPORT,
            GET_VENDOR_TRAFFIC_REPORT,
            GET_VENDOR_FORECASTING_REPORT,
            GET_VENDOR_INVENTORY_HEALTH_AND_PLANNING_REPORT,
            GET_VENDOR_DEMAND_FORECAST_REPORT,
            GET_VENDOR_INVENTORY_REPORT,
            GET_VENDOR_NET_PURE_PRODUCT_MARGIN_REPORT,
            GET_PROMOTION_PERFORMANCE_REPORT,
            GET_MERCHANTS_LISTINGS_FYP_REPORT,
            GET_FBA_SNS_FORECAST_DATA,
            GET_FBA_SNS_PERFORMANCE_DATA,
            GET_COUPON_PERFORMANCE_REPORT,
            GET_FLAT_FILE_OPEN_LISTINGS_DATA,
            GET_MERCHANT_LISTINGS_ALL_DATA,
            GET_MERCHANT_LISTINGS_DATA,
            GET_MERCHANT_LISTINGS_INACTIVE_DATA,
            GET_MERCHANT_LISTINGS_DATA_BACK_COMPAT,
            GET_MERCHANT_LISTINGS_DATA_LITE,
            GET_MERCHANT_LISTINGS_DATA_LITER,
            GET_MERCHANT_CANCELLED_LISTINGS_DATA,
            GET_MERCHANT_LISTINGS_DEFECT_DATA,
            GET_PAN_EU_OFFER_STATUS,
            GET_MFN_PAN_EU_OFFER_STATUS,
            GET_REFERRAL_FEE_PREVIEW_REPORT,
            GET_FLAT_FILE_ACTIONABLE_ORDER_DATA_SHIPPING,
            GET_ORDER_REPORT_DATA_INVOICING,
            GET_ORDER_REPORT_DATA_TAX,
            GET_ORDER_REPORT_DATA_SHIPPING,
            GET_FLAT_FILE_ORDER_REPORT_DATA_INVOICING,
            GET_FLAT_FILE_ORDER_REPORT_DATA_SHIPPING,
            GET_FLAT_FILE_ORDER_REPORT_DATA_TAX,
            GET_FLAT_FILE_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL,
            GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL,
            GET_FLAT_FILE_ARCHIVED_ORDERS_DATA_BY_ORDER_DATE,
            GET_XML_ALL_ORDERS_DATA_BY_LAST_UPDATE_GENERAL,
            GET_XML_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL,
            GET_FLAT_FILE_PENDING_ORDERS_DATA,
            GET_PENDING_ORDERS_DATA,
            GET_CONVERGED_FLAT_FILE_PENDING_ORDERS_DATA,
            GET_XML_RETURNS_DATA_BY_RETURN_DATE,
            GET_FLAT_FILE_RETURNS_DATA_BY_RETURN_DATE,
            GET_XML_MFN_PRIME_RETURNS_REPORT,
            GET_CSV_MFN_PRIME_RETURNS_REPORT,
            GET_XML_MFN_SKU_RETURN_ATTRIBUTES_REPORT,
            GET_FLAT_FILE_MFN_SKU_RETURN_ATTRIBUTES_REPORT,
            GET_SELLER_FEEDBACK_DATA,
            GET_V1_SELLER_PERFORMANCE_REPORT,
            GET_V2_SELLER_PERFORMANCE_REPORT,
            GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE,
            GET_V2_SETTLEMENT_REPORT_DATA_XML,
            GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2,
            GET_AMAZON_FULFILLED_SHIPMENTS_DATA_GENERAL,
            GET_AMAZON_FULFILLED_SHIPMENTS_DATA_INVOICING,
            GET_AMAZON_FULFILLED_SHIPMENTS_DATA_TAX,
            GET_FBA_FULFILLMENT_CUSTOMER_SHIPMENT_SALES_DATA,
            GET_FBA_FULFILLMENT_CUSTOMER_SHIPMENT_PROMOTION_DATA,
            GET_FBA_FULFILLMENT_CUSTOMER_TAXES_DATA,
            GET_REMOTE_FULFILLMENT_ELIGIBILITY,
            GET_AFN_INVENTORY_DATA,
            GET_AFN_INVENTORY_DATA_BY_COUNTRY,
            GET_LEDGER_SUMMARY_VIEW_DATA,
            GET_LEDGER_DETAIL_VIEW_DATA,
            GET_FBA_FULFILLMENT_CURRENT_INVENTORY_DATA,
            GET_FBA_FULFILLMENT_MONTHLY_INVENTORY_DATA,
            GET_FBA_FULFILLMENT_INVENTORY_RECEIPTS_DATA,
            GET_RESERVED_INVENTORY_DATA,
            GET_FBA_FULFILLMENT_INVENTORY_SUMMARY_DATA,
            GET_FBA_FULFILLMENT_INVENTORY_ADJUSTMENTS_DATA,
            GET_FBA_FULFILLMENT_INVENTORY_HEALTH_DATA,
            GET_FBA_MYI_UNSUPPRESSED_INVENTORY_DATA,
            GET_FBA_MYI_ALL_INVENTORY_DATA,
            GET_RESTOCK_INVENTORY_RECOMMENDATIONS_REPORT,
            GET_FBA_FULFILLMENT_INBOUND_NONCOMPLIANCE_DATA,
            GET_STRANDED_INVENTORY_UI_DATA,
            GET_STRANDED_INVENTORY_LOADER_DATA,
            GET_FBA_INVENTORY_AGED_DATA,
            GET_EXCESS_INVENTORY_DATA,
            GET_FBA_STORAGE_FEE_CHARGES_DATA,
            GET_PRODUCT_EXCHANGE_DATA,
            GET_FBA_ESTIMATED_FBA_FEES_TXT_DATA,
            GET_FBA_REIMBURSEMENTS_DATA,
            GET_FBA_FULFILLMENT_LONGTERM_STORAGE_FEE_CHARGES_DATA,
            GET_FBA_FULFILLMENT_CUSTOMER_RETURNS_DATA,
            GET_FBA_FULFILLMENT_CUSTOMER_SHIPMENT_REPLACEMENT_DATA,
            GET_FBA_RECOMMENDED_REMOVAL_DATA,
            GET_FBA_FULFILLMENT_REMOVAL_ORDER_DETAIL_DATA,
            GET_FBA_FULFILLMENT_REMOVAL_SHIPMENT_DETAIL_DATA,
            GET_FBA_UNO_INVENTORY_DATA,
            GET_FLAT_FILE_SALES_TAX_DATA,
            SC_VAT_TAX_REPORT,
            GET_VAT_TRANSACTION_DATA,
            GET_GST_MTR_B2B_CUSTOM,
            GET_GST_MTR_B2C_CUSTOM,
            GET_XML_BROWSE_TREE_DATA,
            GET_EASYSHIP_DOCUMENTS,
            GET_EASYSHIP_PICKEDUP,
            GET_EASYSHIP_WAITING_FOR_PICKUP,
            RFQD_BULK_DOWNLOAD,
            FEE_DISCOUNTS_REPORT,
            GET_FLAT_FILE_OFFAMAZONPAYMENTS_SANDBOX_SETTLEMENT_DATA,
            GET_B2B_PRODUCT_OPPORTUNITIES_RECOMMENDED_FOR_YOU,
            GET_B2B_PRODUCT_OPPORTUNITIES_NOT_YET_ON_AMAZON,
            GET_BRAND_ANALYTICS_MARKET_BASKET_REPORT,
            GET_BRAND_ANALYTICS_SEARCH_TERMS_REPORT,
            GET_BRAND_ANALYTICS_REPEAT_PURCHASE_REPORT,
            GET_BRAND_ANALYTICS_ALTERNATE_PURCHASE_REPORT,
            GET_BRAND_ANALYTICS_ITEM_COMPARISON_REPORT,
            GET_SALES_AND_TRAFFIC_REPORT,
            GET_GST_STR_ADHOC,
            GET_FLAT_FILE_VAT_INVOICE_DATA_REPORT,
            GET_XML_VAT_INVOICE_DATA_REPORT,
            GET_FLAT_FILE_GEO_OPPORTUNITIES,
            GET_DATE_RANGE_FINANCIAL_TRANSACTION_DATA,
            GET_FBA_INVENTORY_PLANNING_DATA,
            GET_MFN_PANEU_OFFER_STATUS,
            GET_FBA_RECONCILIATION_REPORT_DATA,
            GET_FBA_OVERAGE_FEE_CHARGES_DATA,
            GET_EPR_MONTHLY_REPORTS,
            GET_EPR_QUARTERLY_REPORTS,
            GET_EPR_ANNUAL_REPORTS


        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ContentType
        {
            [EnumMember(Value = "text/xml; charset=UTF-8")]
            XML,
            [EnumMember(Value = "application/json; charset=UTF-8")]
            JSON,
            [EnumMember(Value = "application/pdf; charset=UTF-8")]
            PDF,
            [EnumMember(Value = "text/tab-separated-values; charset=UTF-8")]
            TXT,
        }

        public enum ContentFormate
        {
            AutoDetect,
            File,
            Text
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum FeedMessageType
        {
            CatPIL,
            CharacterData,
            Customer,
            CustomerReport,
            EnhancedContent,
            ExternalCustomer,
            ExternalOrder,
            FulfillmentCenter,
            FulfillmentOrderRequest,
            FulfillmentOrderCancellationRequest,
            Image,
            Inventory,
            InvoiceConfirmation,
            Item,
            MSVat,
            Local,
            Loyalty,
            MultiChannelOrderReport,
            NavigationReport,
            Offer,
            OrderAcknowledgement,
            OrderAdjustment,
            OrderFulfillment,
            OrderSourcingOnDemand,
            OrderNotificationReport,
            OrderReport,
            Override,
            PendingOrderReport,
            PointOfSale,
            Price,
            TradeInPrice,
            ProcessingReport,
            Product,
            ProductImage,
            Promotion,
            PurchaseConfirmation,
            ACES,
            PIES,
            Relationship,
            ReverseItem,
            RichContent,
            SalesHistory,
            SalesAdjustment,
            SettlementReport,
            StandardProduct,
            TestOrderRequest,
            Store,
            StoreStockMovement,
            WebstoreItem,
            CartonContentsRequest,
            EasyShipDocument,
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ListingsIncludedData
        {
            Summaries,
            Attributes,
            Issues,
            Offers,
            FulfillmentAvailability,
            Procurement
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum OptionalFulfillmentProgram
        {
            FBA_CORE,
            FBA_SNL,
            FBA_EFN
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ShippingBusiness
        {
            [EnumMember(Value = "AmazonShipping_US")]
            AmazonShipping_US,
            [EnumMember(Value = "AmazonShipping_IN")]
            AmazonShipping_IN,
            [EnumMember(Value = "AmazonShipping_UK")]
            AmazonShipping_UK,
            [EnumMember(Value = "AmazonShipping_UAE")]
            AmazonShipping_UAE,
            [EnumMember(Value = "AmazonShipping_SA")]
            AmazonShipping_SA,
            [EnumMember(Value = "AmazonShipping_EG")]
            AmazonShipping_EG,
            [EnumMember(Value = "AmazonShipping_IT")]
            AmazonShipping_IT
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ShippingChannelType
        {
            [EnumMember(Value = "AMAZON")]
            AMAZON,
            [EnumMember(Value = "EXTERNAL")]
            EXTERNAL
        }

        ///// <summary>
        ///// One of a set of predefined ISO 8601 periods that specifies how often a report should be created.
        ///// </summary>
        //public enum Period
        //{
        //    /// <summary>
        //    /// 5 minutes
        //    /// </summary>
        //    PT5M,
        //    /// <summary>
        //    /// 15 minutes
        //    /// </summary>
        //    PT15M,
        //    /// <summary>
        //    /// 30 minutes
        //    /// </summary>
        //    PT30M,
        //    /// <summary>
        //    /// 1 hour
        //    /// </summary>
        //    PT1H,
        //    /// <summary>
        //    /// 2 hours
        //    /// </summary>
        //    PT2H,
        //    /// <summary>
        //    /// 4 hours
        //    /// </summary>
        //    PT4H,
        //    /// <summary>
        //    /// 8 hours
        //    /// </summary>
        //    PT8H,
        //    /// <summary>
        //    /// 12 hours
        //    /// </summary>
        //    PT12H,
        //    /// <summary>
        //    /// 1 day
        //    /// </summary>
        //    P1D,
        //    /// <summary>
        //    /// 2 days
        //    /// </summary>
        //    P2D,
        //    /// <summary>
        //    /// 3 days
        //    /// </summary>
        //    P3D,
        //    /// <summary>
        //    /// 84 hours
        //    /// </summary>
        //    PT84H,
        //    /// <summary>
        //    /// 7 days
        //    /// </summary>
        //    P7D,
        //    /// <summary>
        //    /// 14 days
        //    /// </summary>
        //    P14D,
        //    /// <summary>
        //    /// 15 days
        //    /// </summary>
        //    P15D,
        //    /// <summary>
        //    /// 18 days
        //    /// </summary>
        //    P18D,
        //    /// <summary>
        //    /// 30 days
        //    /// </summary>
        //    P30D,
        //    /// <summary>
        //    /// 1 month
        //    /// </summary>
        //    P1M
        //}

    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FullFillmentInboundPlanStatus
    {
        [EnumMember(Value = "ACTIVE")]
        ACTIVE = 0,

        [EnumMember(Value = "VOIDED")]
        VOIDED = 1,

        [EnumMember(Value = "SHIPPED")]
        SHIPPED = 2,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FullFillmentInboundSortBy
    {
        [EnumMember(Value = "LAST_UPDATED_TIME")]
        LAST_UPDATED_TIME = 0,

        [EnumMember(Value = "CREATION_TIME")]
        CREATION_TIME = 1,

    }
}
