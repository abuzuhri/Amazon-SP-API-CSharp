using System.Collections.Generic;

namespace FikaAmazonAPI.Utils
{
    internal static class RateLimitsDefinitions
    {
        internal static Dictionary<RateLimitType, RateLimits> RateLimitsTime()
        {
            //This has to create a new list for each connection, so that rate limits are per seller, not overall.
            return new Dictionary<RateLimitType, RateLimits>()
            {
              { RateLimitType.Order_GetOrders,                            new RateLimits(0.0167M, 20) },
              { RateLimitType.Order_GetOrder,                             new RateLimits(0.0167M, 20) },
              { RateLimitType.Order_GetOrderBuyerInfo,                    new RateLimits(0.0167M, 20) },
              { RateLimitType.Order_GetOrderAddress,                      new RateLimits(0.0167M, 20) },
              { RateLimitType.Order_GetOrderItems,                        new RateLimits(0.5M, 20) },
              { RateLimitType.Order_GetOrderItemsBuyerInfo,               new RateLimits(0.5M, 30) },
              { RateLimitType.Order_UpdateShipmentStatus,                 new RateLimits(5M, 15) },
              { RateLimitType.Order_GetOrderRegulatedInfo,                new RateLimits(0.5M, 15) },
              { RateLimitType.Order_UpdateVerificationStatus,             new RateLimits(0.5M, 30) },
              { RateLimitType.Order_UpdateOrderItemsApprovals,            new RateLimits(5M, 15) },
              { RateLimitType.Order_ShipmentConfirmation,                 new RateLimits(2M, 10) },

              { RateLimitType.Report_GetReports,                          new RateLimits(0.0222M, 10) },
              { RateLimitType.Report_GetReport,                           new RateLimits(2.0M, 15) },
              { RateLimitType.Report_CreateReport,                        new RateLimits(0.0167M, 15) },
              { RateLimitType.Report_CancelReport,                        new RateLimits(0.0222M, 10) },
              { RateLimitType.Report_GetReportSchedules,                  new RateLimits(0.0222M, 10) },
              { RateLimitType.Report_CreateReportSchedule,                new RateLimits(0.0222M, 10) },
              { RateLimitType.Report_GetReportSchedule,                   new RateLimits(0.0222M, 10) },
              { RateLimitType.Report_CancelReportSchedule,                new RateLimits(0.0222M, 10) },
              { RateLimitType.Report_GetReportDocument,                   new RateLimits(0.0167M, 15) },

              { RateLimitType.Financial_ListFinancialEventGroups,         new RateLimits(0.5M, 30) },
              { RateLimitType.Financial_ListFinancialEventsByGroupId,     new RateLimits(0.5M, 30) },
              { RateLimitType.Financial_ListFinancialEventsByOrderId,     new RateLimits(0.5M, 30) },
              { RateLimitType.Financial_ListFinancialEvents,              new RateLimits(0.5M, 30) },

              { RateLimitType.Feed_GetFeeds,                              new RateLimits(0.0222M, 10) },
              { RateLimitType.Feed_CreateFeed,                            new RateLimits(0.0083M, 15) },
              { RateLimitType.Feed_GetFeed,                               new RateLimits(2.0M, 15) },
              { RateLimitType.Feed_CancelFeed,                            new RateLimits(0.0222M, 10) },
              { RateLimitType.Feed_CreateFeedDocument,                    new RateLimits(0.0083M, 15) },
              { RateLimitType.Feed_GetFeedDocument,                       new RateLimits(0.0222M, 10) },

              { RateLimitType.ListingsItem_GetListingsItem,               new RateLimits(5.0M, 10) },
              { RateLimitType.ListingsItem_PutListingsItem,               new RateLimits(5.0M, 10) },
              { RateLimitType.ListingsItem_DeleteListingsItem,            new RateLimits(5.0M, 10) },
              { RateLimitType.ListingsItem_PatchListingsItem,             new RateLimits(5.0M, 10) },

              { RateLimitType.Upload_CreateUploadDestinationForResource,  new RateLimits(0.1M, 5) },

              { RateLimitType.ShipmentInvoicing_GetShipmentDetails,       new RateLimits(1.133M, 25) },
              { RateLimitType.ShipmentInvoicing_SubmitInvoice,            new RateLimits(1.133M, 25) },
              { RateLimitType.ShipmentInvoicing_GetInvoiceStatus,         new RateLimits(1.133M, 25) },

              { RateLimitType.Shipping_CreateShipment,                    new RateLimits(5.0M, 15) },
              { RateLimitType.Shipping_GetShipment,                       new RateLimits(5.0M, 15) },
              { RateLimitType.Shipping_CancelShipment,                    new RateLimits(5.0M, 15) },
              { RateLimitType.Shipping_PurchaseLabels,                    new RateLimits(5.0M, 15) },
              { RateLimitType.Shipping_RetrieveShippingLabel,             new RateLimits(5.0M, 15) },
              { RateLimitType.Shipping_PurchaseShipment,                  new RateLimits(5.0M, 15) },
              { RateLimitType.Shipping_GetRates,                          new RateLimits(5.0M, 15) },
              { RateLimitType.Shipping_GetAccount,                        new RateLimits(5.0M, 15) },
              { RateLimitType.Shipping_GetTrackingInformation,            new RateLimits(1.0M, 1) },

              { RateLimitType.ShippingV2_CancelShipment,                    new RateLimits(80.0M, 100) },
              { RateLimitType.ShippingV2_DirectPurchaseShipment,            new RateLimits(80.0M, 100) },
              { RateLimitType.ShippingV2_GetAdditionalInputs,               new RateLimits(80.0M, 100) },
              { RateLimitType.ShippingV2_GetRates,                          new RateLimits(80.0M, 100) },
              { RateLimitType.ShippingV2_GetShipmentDocument,               new RateLimits(80.0M, 100) },
              { RateLimitType.ShippingV2_GetTracking,                       new RateLimits(80.0M, 100) },
              { RateLimitType.ShippingV2_PurchaseShipment,                  new RateLimits(80.0M, 100) },

              { RateLimitType.CatalogItems_ListCatalogItems,              new RateLimits(6.0M, 40) },
              { RateLimitType.CatalogItems_GetCatalogItem,                new RateLimits(2.0M, 20) },
              { RateLimitType.CatalogItems_ListCatalogCategories,         new RateLimits(1.0M, 40) },
              { RateLimitType.CatalogItems20220401_GetCatalogItem,        new RateLimits(2.0M, 2) },
              { RateLimitType.CatalogItems20220401_SearchCatalogItems,    new RateLimits(2.0M, 2) },

              { RateLimitType.FbaInventory_GetInventorySummaries,         new RateLimits(2.0M, 2) },

              { RateLimitType.Authorization_GetAuthorizationCode,         new RateLimits(1.0M, 5) },

              { RateLimitType.FbaSmallandLight_GetSmallAndLightEnrollmentBySellerSKU,         new RateLimits(2.0M, 10) },
              { RateLimitType.FbaSmallandLight_PutSmallAndLightEnrollmentBySellerSKU,         new RateLimits(2.0M, 5) },
              { RateLimitType.FbaSmallandLight_DeleteSmallAndLightEnrollmentBySellerSKU,      new RateLimits(2.0M, 5) },
              { RateLimitType.FbaSmallandLight_GetSmallAndLightEligibilityBySellerSKU,        new RateLimits(2.0M, 10) },
              { RateLimitType.FbaSmallandLight_GetSmallAndLightFeePreview,                    new RateLimits(1.0M, 3) },

              { RateLimitType.Restrictions_GetListingsRestrictions,                new RateLimits(5.0M, 10) },

              { RateLimitType.ProductTypes_GetDefinitionsProductType,                new RateLimits(5.0M, 10) },
              { RateLimitType.ProductTypes_SearchDefinitionsProductTypes,                new RateLimits(5.0M, 10) },

              { RateLimitType.FBAInboundEligibility_GetItemEligibilityPreview,                new RateLimits(1.0M, 1) },


              { RateLimitType.EasyShip_CreateScheduledPackage,                new RateLimits(1.0M, 5) },
              { RateLimitType.EasyShip_GetScheduledPackage,                   new RateLimits(1.0M, 5) },
              { RateLimitType.EasyShip_ListHandoverSlots,                     new RateLimits(1.0M, 5) },
              { RateLimitType.EasyShip_UpdateScheduledPackages,               new RateLimits(1.0M, 5) },

              { RateLimitType.FulFillmentInbound_GetInboundGuidance,          new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_CreateInboundShipmentPlan,   new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_UpdateInboundShipment,       new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_CreateInboundShipment,       new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_GetPreorderInfo,             new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_ConfirmPreorder,             new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_GetPrepInstructions,         new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_GetTransportDetails,         new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_PutTransportDetails,         new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_VoidTransport,               new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_EstimateTransport,           new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_ConfirmTransport,            new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_GetLabels,                   new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_GetBillOfLading,             new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_GetShipments,                new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_GetShipmentItemsByShipmentId,new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentInbound_GetShipmentItems,            new RateLimits(2.0M, 30) },

              { RateLimitType.FulFillmentInboundV20240320_GetListInboundPlans,               new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_CreateInboundPlan,                 new RateLimits(0.05M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_GetInboundPlan,                    new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ListInboundPlanBoxes,              new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_CancelInboundPlan,                 new RateLimits(0.05M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ListInboundPlanItems,              new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_SetPackingInformation,             new RateLimits(0.05M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ListPackingOptions,                new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_GeneratePackingOptions,            new RateLimits(0.05M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ConfirmPackingOption,              new RateLimits(0.05M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ListPackingGroupItems,             new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ListInboundPlanPallets,            new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ListPlacementOptions,              new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_GeneratePlacementOptions,          new RateLimits(0.05M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ConfirmPlacementOption,            new RateLimits(0.05M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_GetShipment,                       new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_GetDeliveryChallanDocument,        new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_UpdateShipmentDeliveryWindow,      new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_GetSelfShipAppointmentSlots,       new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_GenerateSelfShipAppointmentSlots,  new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_CancelSelfShipAppointment,         new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ScheduleSelfShipAppointment,       new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_UpdateShipmentTrackingDetails,     new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ListTransportationOptions,         new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_GenerateTransportationOptions,     new RateLimits(0.05M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ConfirmTransportationOptions,      new RateLimits(0.05M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_ListItemComplianceDetails,         new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_UpdateItemComplianceDetails,       new RateLimits(1.0M, 1) },
              { RateLimitType.FulFillmentInboundV20240320_GetInboundOperationStatus,         new RateLimits(1.0M, 1) },

              { RateLimitType.FulFillmentOutbound_GetFulfillmentPreview,      new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentOutbound_ListAllFulfillmentOrders,   new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentOutbound_CreateFulfillmentOrder,     new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentOutbound_GetPackageTrackingDetails,  new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentOutbound_ListReturnReasonCodes,      new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentOutbound_CreateFulfillmentReturn,    new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentOutbound_GetFulfillmentOrder,        new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentOutbound_UpdateFulfillmentOrder,     new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentOutbound_CancelFulfillmentOrder,     new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentOutbound_GetFeatures,                new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentOutbound_GetFeatureInventory,        new RateLimits(2.0M, 30) },
              { RateLimitType.FulFillmentOutbound_GetFeatureSKU,              new RateLimits(2.0M, 30) },

              { RateLimitType.MerchantFulFillment_GetEligibleShipmentServicesOld,new RateLimits(1.0M, 1) },
              { RateLimitType.MerchantFulFillment_GetEligibleShipmentServices,new RateLimits(5.0M, 10) },
              { RateLimitType.MerchantFulFillment_GetShipment,                new RateLimits(1.0M, 1) },
              { RateLimitType.MerchantFulFillment_CancelShipment,             new RateLimits(1.0M, 1) },
              { RateLimitType.MerchantFulFillment_CancelShipmentOld,          new RateLimits(1.0M, 1) },
              { RateLimitType.MerchantFulFillment_CreateShipment,             new RateLimits(1.0M, 1) },
              { RateLimitType.MerchantFulFillment_GetAdditionalSellerInputsOld,new RateLimits(1.0M, 1) },
              { RateLimitType.MerchantFulFillment_GetAdditionalSellerInputs,  new RateLimits(1.0M, 1) },

              { RateLimitType.Messaging_GetMessagingActionsForOrder,          new RateLimits(1.0M, 5) },
              { RateLimitType.Messaging_ConfirmCustomizationDetails,          new RateLimits(1.0M, 5) },
              { RateLimitType.Messaging_CreateConfirmDeliveryDetails,         new RateLimits(1.0M, 5) },
              { RateLimitType.Messaging_CreateLegalDisclosure,                new RateLimits(1.0M, 5) },
              { RateLimitType.Messaging_CreateNegativeFeedbackRemoval,        new RateLimits(1.0M, 5) },
              { RateLimitType.Messaging_CreateConfirmOrderDetails,            new RateLimits(1.0M, 5) },
              { RateLimitType.Messaging_CreateConfirmServiceDetails,          new RateLimits(1.0M, 5) },
              { RateLimitType.Messaging_CreateAmazonMotors,                   new RateLimits(1.0M, 5) },
              { RateLimitType.Messaging_CreateWarranty,                       new RateLimits(1.0M, 5) },
              { RateLimitType.Messaging_GetAttributes,                        new RateLimits(1.0M, 5) },
              { RateLimitType.Messaging_CreateDigitalAccessKey,               new RateLimits(1.0M, 5) },
              { RateLimitType.Messaging_CreateUnexpectedProblem,              new RateLimits(1.0M, 5) },

              { RateLimitType.Notifications_GetSubscription,                  new RateLimits(1.0M, 5) },
              { RateLimitType.Notifications_CreateSubscription,               new RateLimits(1.0M, 5) },
              { RateLimitType.Notifications_GetSubscriptionById,              new RateLimits(1.0M, 5) },
              { RateLimitType.Notifications_DeleteSubscriptionById,           new RateLimits(1.0M, 5) },
              { RateLimitType.Notifications_GetDestinations,                  new RateLimits(1.0M, 5) },
              { RateLimitType.Notifications_CreateDestination,                new RateLimits(1.0M, 5) },
              { RateLimitType.Notifications_GetDestination,                   new RateLimits(1.0M, 5) },
              { RateLimitType.Notifications_DeleteDestination,                new RateLimits(1.0M, 5) },

              { RateLimitType.ProductFees_GetMyFeesEstimateForSKU,            new RateLimits(1M, 2) },
              { RateLimitType.ProductFees_GetMyFeesEstimateForASIN,           new RateLimits(1M, 2) },
              { RateLimitType.ProductFees_GetMyFeesEstimate,                  new RateLimits(0.5M, 1) },

              { RateLimitType.ProductPricing_GetPricing,                      new RateLimits(0.5M, 1) },
              { RateLimitType.ProductPricing_GetCompetitivePricing,           new RateLimits(0.5M, 1) },
              { RateLimitType.ProductPricing_GetListingOffers,                new RateLimits(1M, 2) },
              { RateLimitType.ProductPricing_GetItemOffers,                   new RateLimits(0.5M, 1) },

              { RateLimitType.ProductPricing_GetItemOffersBatch,                   new RateLimits(0.1M, 1) },
              { RateLimitType.ProductPricing_GetListingOffersBatch,                   new RateLimits(0.5M, 1) },

              { RateLimitType.Sales_GetOrderMetrics,                          new RateLimits(0.5M, 15) },

              { RateLimitType.Sellers_GetMarketplaceParticipations,           new RateLimits(0.016M, 15) },

              { RateLimitType.Solicitations_GetSolicitationActionsForOrder,                   new RateLimits(1.0M, 5) },
              { RateLimitType.Solicitations_CreateProductReviewAndSellerFeedbackSolicitation, new RateLimits(1.0M, 5) },

              { RateLimitType.Token_CreateRestrictedDataToken, new RateLimits(1.0M, 10) },

              { RateLimitType.VendorDirectFulfillmentOrdersV1_GetOrders,      new RateLimits(10.0M, 10) },
              { RateLimitType.VendorDirectFulfillmentOrdersV1_GetOrder,       new RateLimits(10.0M, 10) },
              { RateLimitType.VendorDirectFulfillmentOrdersV1_SubmitAcknowledgement, new RateLimits(10.0M, 10) },

              { RateLimitType.VendorOrdersV1_GetPurchaseOrders,         new RateLimits(10.0M, 10) },
              { RateLimitType.VendorOrdersV1_GetPurchaseOrder,          new RateLimits(10.0M, 10) },
              { RateLimitType.VendorOrdersV1_SubmitAcknowledgement,     new RateLimits(10.0M, 10) },
              { RateLimitType.VendorOrdersV1_GetPurchaseOrdersStatus,   new RateLimits(10.0M, 10) },

              { RateLimitType.VendorTransactionStatus_GetTransaction,     new RateLimits(10.0M, 10) },
            };
        }
    }
}
