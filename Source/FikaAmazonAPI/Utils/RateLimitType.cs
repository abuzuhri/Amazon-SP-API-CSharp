﻿namespace FikaAmazonAPI.Utils
{
    public enum RateLimitType
    {
        UNSET,

        Order_GetOrders,
        Order_GetOrder,
        Order_GetOrderBuyerInfo,
        Order_GetOrderAddress,
        Order_GetOrderItems,
        Order_GetOrderItemsBuyerInfo,
        Order_UpdateShipmentStatus,

        Report_GetReports,
        Report_GetReport,
        Report_CreateReport,
        Report_CancelReport,
        Report_GetReportSchedules,
        Report_CreateReportSchedule,
        Report_GetReportSchedule,
        Report_CancelReportSchedule,
        Report_GetReportDocument,

        Financial_ListFinancialEventGroups,
        Financial_ListFinancialEventsByGroupId,
        Financial_ListFinancialEventsByOrderId,
        Financial_ListFinancialEvents,

        Feed_GetFeeds,
        Feed_CreateFeed,
        Feed_GetFeed,
        Feed_CancelFeed,
        Feed_CreateFeedDocument,
        Feed_GetFeedDocument,

        ListingsItem_GetListingsItem,
        ListingsItem_PutListingsItem,
        ListingsItem_DeleteListingsItem,
        ListingsItem_PatchListingsItem,

        Upload_CreateUploadDestinationForResource,

        ShipmentInvoicing_GetShipmentDetails,
        ShipmentInvoicing_SubmitInvoice,
        ShipmentInvoicing_GetInvoiceStatus,

        Shipping_CreateShipment,
        Shipping_GetShipment,
        Shipping_CancelShipment,
        Shipping_PurchaseLabels,
        Shipping_RetrieveShippingLabel,
        Shipping_PurchaseShipment,
        Shipping_GetRates,
        Shipping_GetAccount,
        Shipping_GetTrackingInformation,

        CatalogItems_ListCatalogItems,
        CatalogItems_GetCatalogItem,
        CatalogItems_ListCatalogCategories,
        CatalogItems20220401_GetCatalogItem,
        CatalogItems20220401_SearchCatalogItems,

        FbaInventory_GetInventorySummaries,

        Authorization_GetAuthorizationCode,

        ProductTypes_SearchDefinitionsProductTypes,
        ProductTypes_GetDefinitionsProductType,

        Restrictions_GetListingsRestrictions,

        FbaSmallandLight_GetSmallAndLightEnrollmentBySellerSKU,
        FbaSmallandLight_PutSmallAndLightEnrollmentBySellerSKU,
        FbaSmallandLight_DeleteSmallAndLightEnrollmentBySellerSKU,
        FbaSmallandLight_GetSmallAndLightEligibilityBySellerSKU,
        FbaSmallandLight_GetSmallAndLightFeePreview,


        FBAInboundEligibility_GetItemEligibilityPreview,

        FulFillmentInbound_GetInboundGuidance,
        FulFillmentInbound_CreateInboundShipmentPlan,
        FulFillmentInbound_UpdateInboundShipment,
        FulFillmentInbound_CreateInboundShipment,
        FulFillmentInbound_GetPreorderInfo,
        FulFillmentInbound_ConfirmPreorder,
        FulFillmentInbound_GetPrepInstructions,
        FulFillmentInbound_GetTransportDetails,
        FulFillmentInbound_PutTransportDetails,
        FulFillmentInbound_VoidTransport,
        FulFillmentInbound_EstimateTransport,
        FulFillmentInbound_ConfirmTransport,
        FulFillmentInbound_GetLabels,
        FulFillmentInbound_GetBillOfLading,
        FulFillmentInbound_GetShipments,
        FulFillmentInbound_GetShipmentItemsByShipmentId,
        FulFillmentInbound_GetShipmentItems,

        FulFillmentOutbound_GetFulfillmentPreview,
        FulFillmentOutbound_ListAllFulfillmentOrders,
        FulFillmentOutbound_CreateFulfillmentOrder,
        FulFillmentOutbound_GetPackageTrackingDetails,
        FulFillmentOutbound_ListReturnReasonCodes,
        FulFillmentOutbound_CreateFulfillmentReturn,
        FulFillmentOutbound_GetFulfillmentOrder,
        FulFillmentOutbound_UpdateFulfillmentOrder,
        FulFillmentOutbound_CancelFulfillmentOrder,
        FulFillmentOutbound_GetFeatures,
        FulFillmentOutbound_GetFeatureInventory,
        FulFillmentOutbound_GetFeatureSKU,

        MerchantFulFillment_GetEligibleShipmentServicesOld,
        MerchantFulFillment_GetEligibleShipmentServices,
        MerchantFulFillment_GetShipment,
        MerchantFulFillment_CancelShipment,
        MerchantFulFillment_CancelShipmentOld,
        MerchantFulFillment_CreateShipment,
        MerchantFulFillment_GetAdditionalSellerInputsOld,
        MerchantFulFillment_GetAdditionalSellerInputs,

        Messaging_GetMessagingActionsForOrder,
        Messaging_ConfirmCustomizationDetails,
        Messaging_CreateConfirmDeliveryDetails,
        Messaging_CreateLegalDisclosure,
        Messaging_CreateNegativeFeedbackRemoval,
        Messaging_CreateConfirmOrderDetails,
        Messaging_CreateConfirmServiceDetails,
        Messaging_CreateAmazonMotors,
        Messaging_CreateWarranty,
        Messaging_GetAttributes,
        Messaging_CreateDigitalAccessKey,
        Messaging_CreateUnexpectedProblem,

        Notifications_GetSubscription,
        Notifications_CreateSubscription,
        Notifications_GetSubscriptionById,
        Notifications_DeleteSubscriptionById,
        Notifications_GetDestinations,
        Notifications_CreateDestination,
        Notifications_GetDestination,
        Notifications_DeleteDestination,

        ProductFees_GetMyFeesEstimateForSKU,
        ProductFees_GetMyFeesEstimateForASIN,
        ProductFees_GetMyFeesEstimate,

        ProductPricing_GetPricing,
        ProductPricing_GetCompetitivePricing,
        ProductPricing_GetListingOffers,
        ProductPricing_GetItemOffers,
        ProductPricing_GetItemOffersBatch,
        ProductPricing_GetListingOffersBatch,

        Sales_GetOrderMetrics,


        EasyShip_ListHandoverSlots,
        EasyShip_GetScheduledPackage,
        EasyShip_CreateScheduledPackage,
        EasyShip_UpdateScheduledPackages,


        Sellers_GetMarketplaceParticipations,

        Solicitations_GetSolicitationActionsForOrder,
        Solicitations_CreateProductReviewAndSellerFeedbackSolicitation,

        Token_CreateRestrictedDataToken,

        VendorDirectFulfillmentOrdersV1_GetOrders,
        VendorDirectFulfillmentOrdersV1_GetOrder,
        VendorDirectFulfillmentOrdersV1_SubmitAcknowledgement,

        ShippingV2_GetShipmentDocument,
        ShippingV2_CancelShipment,
        ShippingV2_PurchaseShipment,
        ShippingV2_GetRates,
        ShippingV2_DirectPurchaseShipment,
        ShippingV2_GetTracking,
        ShippingV2_GetAdditionalInputs,

        VendorOrdersV1_GetPurchaseOrders,
        VendorOrdersV1_GetPurchaseOrder,
        VendorOrdersV1_SubmitAcknowledgement,
        VendorOrdersV1_GetPurchaseOrdersStatus,

    }
}
