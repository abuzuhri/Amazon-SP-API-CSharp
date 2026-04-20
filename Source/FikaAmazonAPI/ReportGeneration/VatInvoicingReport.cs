using FikaAmazonAPI.ReportGeneration.ReportDataTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FikaAmazonAPI.ReportGeneration
{
    public class VatInvoicingReport
    {
        public List<VatInvoicingReportRow> Data { get; set; } = new List<VatInvoicingReportRow>();
        public VatInvoicingReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var table = Table.ConvertFromCSV(path);

            List<VatInvoicingReportRow> values = new List<VatInvoicingReportRow>();
            foreach (var row in table.Rows)
            {
                values.Add(VatInvoicingReportRow.FromRow(row, refNumber));
            }
            Data = values;
        }
    }


    public class VatInvoicingReportRow
    {
        public string MarketplaceId { get; set; }
        public string AmazonOrderId { get; set; }
        public string OrderItemId { get; set; }
        public string ShippingId { get; set; }
        public string TransactionId { get; set; }
        public string TransactionType { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceStatus { get; set; }
        public string InvoiceStatusDescription { get; set; }
        public string IsAmazonInvoiced { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string BuyerVatNumber { get; set; }
        public string SellerVatNumber { get; set; }
        public string ASIN { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public decimal? QuantityPurchased { get; set; }
        public string Currency { get; set; }
        public decimal? ItemVatInclAmount { get; set; }
        public decimal? ItemVatAmount { get; set; }
        public decimal? ItemVatExclAmount { get; set; }
        public decimal? ItemVatRate { get; set; }
        public decimal? ItemPromoVatInclAmount { get; set; }
        public decimal? ItemPromoVatExclAmount { get; set; }
        public decimal? ItemPromoVatAmount { get; set; }
        public decimal? ItemPromoVatRate { get; set; }
        public string ItemPromotionId { get; set; }
        public decimal? GiftWrapVatInclAmount { get; set; }
        public decimal? GiftWrapVatAmount { get; set; }
        public decimal? GiftWrapVatExclAmount { get; set; }
        public decimal? GiftWrapVatRate { get; set; }
        public decimal? GiftPromoVatInclAmount { get; set; }
        public decimal? GiftPromoVatExclAmount { get; set; }
        public decimal? GiftPromoVatAmount { get; set; }
        public decimal? GiftPromoVatRate { get; set; }
        public string GiftPromotionId { get; set; }
        public decimal? ShippingVatInclAmount { get; set; }
        public decimal? ShippingVatAmount { get; set; }
        public decimal? ShippingVatExclAmount { get; set; }
        public decimal? ShippingVatRate { get; set; }
        public decimal? ShippingPromoVatInclAmount { get; set; }
        public decimal? ShippingPromoVatExclAmount { get; set; }
        public decimal? ShippingPromoVatAmount { get; set; }
        public decimal? ShippingPromoVatRate { get; set; }
        public string ShipPromotionId { get; set; }
        public string IsBusinessOrder { get; set; }
        public string PriceDesignation { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string RecipientName { get; set; }
        public string ShipServiceLevel { get; set; }
        public string FulfilledBy { get; set; }
        public string ShipAddress1 { get; set; }
        public string ShipAddress2 { get; set; }
        public string ShipAddress3 { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPhoneNumber { get; set; }
        public string ShipFromCountry { get; set; }
        public string ShipFromState { get; set; }
        public string ShipFromCity { get; set; }
        public string ShipFromPostalCode { get; set; }
        public string BillingName { get; set; }
        public string BillAddress1 { get; set; }
        public string BillAddress2 { get; set; }
        public string BillAddress3 { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillPostalCode { get; set; }
        public string BillCountry { get; set; }
        public string BillingPhoneNumber { get; set; }
        public string BuyerName { get; set; }
        public string BuyerCompanyName { get; set; }
        public string LegacyCustomerOrderItemId { get; set; }
        public string RecommendedInvoiceFormat { get; set; }
        public string BuyerTaxRegistrationType { get; set; }
        public string BuyerEInvoiceAccountId { get; set; }
        public string IsBuyerPhysicallyPresent { get; set; }
        public string IsSellerPhysicallyPresent { get; set; }
        public string CitationEs { get; set; }
        public string CitationIt { get; set; }
        public string CitationFr { get; set; }
        public string CitationDe { get; set; }
        public string CitationEn { get; set; }
        public string ExportOutsideEu { get; set; }
        public string IsInvoiceCorrected { get; set; }
        public string OriginalVatInvoiceNumber { get; set; }
        public string InvoiceCorrectionDetails { get; set; }

        public string refNumber { get; set; }

        public VatInvoicingReportRow()
        {

        }

        public static VatInvoicingReportRow FromRow(TableRow rowData, string refNumber)
        {
            var row = new VatInvoicingReportRow();
            row.MarketplaceId = rowData.GetString("marketplace-id");
            row.AmazonOrderId = rowData.GetString("order-id");
            row.OrderItemId = rowData.GetString("order-item-id");
            row.ShippingId = rowData.GetString("shipping-id");
            row.TransactionId = rowData.GetString("transaction-id");
            row.TransactionType = rowData.GetString("transaction-type");
            row.InvoiceNumber = rowData.GetString("invoice-number");
            row.InvoiceStatus = rowData.GetString("invoice-status");
            row.InvoiceStatusDescription = rowData.GetString("invoice-status-description");
            row.IsAmazonInvoiced = rowData.GetString("is-amazon-invoiced");
            row.OrderDate = DataConverter.GetDate(rowData.GetString("order-date"), DataConverter.DateTimeFormat.DATETIME_K_FORMAT);
            row.ShipmentDate = DataConverter.GetDate(rowData.GetString("shipment-date"), DataConverter.DateTimeFormat.DATETIME_K_FORMAT);
            row.BuyerVatNumber = rowData.GetString("buyer-vat-number");
            row.SellerVatNumber = rowData.GetString("seller-vat-number");
            row.ASIN = rowData.GetString("asin");
            row.SKU = rowData.GetString("sku");
            row.ProductName = rowData.GetString("product-name");
            row.QuantityPurchased = rowData.GetDecimal("quantity-purchased");
            row.Currency = rowData.GetString("currency");
            row.ItemVatInclAmount = rowData.GetDecimal("item-vat-incl-amount");
            row.ItemVatAmount = rowData.GetDecimal("item-vat-amount");
            row.ItemVatExclAmount = rowData.GetDecimal("item-vat-excl-amount");
            row.ItemVatRate = rowData.GetDecimal("item-vat-rate");
            row.ItemPromoVatInclAmount = rowData.GetDecimal("item-promo-vat-incl-amount");
            row.ItemPromoVatExclAmount = rowData.GetDecimal("item-promo-vat-excl-amount");
            row.ItemPromoVatAmount = rowData.GetDecimal("item-promo-vat-amount");
            row.ItemPromoVatRate = rowData.GetDecimal("item-promo-vat-rate");
            row.ItemPromotionId = rowData.GetString("item-promotion-id");
            row.GiftWrapVatInclAmount = rowData.GetDecimal("gift-wrap-vat-incl-amount");
            row.GiftWrapVatAmount = rowData.GetDecimal("gift-wrap-vat-amount");
            row.GiftWrapVatExclAmount = rowData.GetDecimal("gift-wrap-vat-excl-amount");
            row.GiftWrapVatRate = rowData.GetDecimal("gift-wrap-vat-rate");
            row.GiftPromoVatInclAmount = rowData.GetDecimal("gift-promo-vat-incl-amount");
            row.GiftPromoVatExclAmount = rowData.GetDecimal("gift-promo-vat-excl-amount");
            row.GiftPromoVatAmount = rowData.GetDecimal("gift-promo-vat-amount");
            row.GiftPromoVatRate = rowData.GetDecimal("gift-promo-vat-rate");
            row.GiftPromotionId = rowData.GetString("gift-promotion-id");
            row.ShippingVatInclAmount = rowData.GetDecimal("shipping-vat-incl-amount");
            row.ShippingVatAmount = rowData.GetDecimal("shipping-vat-amount");
            row.ShippingVatExclAmount = rowData.GetDecimal("shipping-vat-excl-amount");
            row.ShippingVatRate = rowData.GetDecimal("shipping-vat-rate");
            row.ShippingPromoVatInclAmount = rowData.GetDecimal("shipping-promo-vat-incl-amount");
            row.ShippingPromoVatExclAmount = rowData.GetDecimal("shipping-promo-vat-excl-amount");
            row.ShippingPromoVatAmount = rowData.GetDecimal("shipping-promo-vat-amount");
            row.ShippingPromoVatRate = rowData.GetDecimal("shipping-promo-vat-rate");
            row.ShipPromotionId = rowData.GetString("ship-promotion-id");
            row.IsBusinessOrder = rowData.GetString("is-business-order");
            row.PriceDesignation = rowData.GetString("price-designation");
            row.PurchaseOrderNumber = rowData.GetString("purchase-order-number");
            row.RecipientName = rowData.GetString("recipient-name");
            row.ShipServiceLevel = rowData.GetString("ship-service-level");
            row.FulfilledBy = rowData.GetString("fulfilled-by");
            row.ShipAddress1 = rowData.GetString("ship-address-1");
            row.ShipAddress2 = rowData.GetString("ship-address-2");
            row.ShipAddress3 = rowData.GetString("ship-address-3");
            row.ShipCity = rowData.GetString("ship-city");
            row.ShipState = rowData.GetString("ship-state");
            row.ShipPostalCode = rowData.GetString("ship-postal-code");
            row.ShipCountry = rowData.GetString("ship-country");
            row.ShipPhoneNumber = rowData.GetString("ship-phone-number");
            row.ShipFromCountry = rowData.GetString("ship-from-country");
            row.ShipFromState = rowData.GetString("ship-from-state");
            row.ShipFromCity = rowData.GetString("ship-from-city");
            row.ShipFromPostalCode = rowData.GetString("ship-from-postal-code");
            row.BillingName = rowData.GetString("billing-name");
            row.BillAddress1 = rowData.GetString("bill-address-1");
            row.BillAddress2 = rowData.GetString("bill-address-2");
            row.BillAddress3 = rowData.GetString("bill-address-3");
            row.BillCity = rowData.GetString("bill-city");
            row.BillState = rowData.GetString("bill-state");
            row.BillPostalCode = rowData.GetString("bill-postal-code");
            row.BillCountry = rowData.GetString("bill-country");
            row.BillingPhoneNumber = rowData.GetString("billing-phone-number");
            row.BuyerName = rowData.GetString("buyer-name");
            row.BuyerCompanyName = rowData.GetString("buyer-company-name");
            row.LegacyCustomerOrderItemId = rowData.GetString("legacy-customer-order-item-id");
            row.RecommendedInvoiceFormat = rowData.GetString("recommended-invoice-format");
            row.BuyerTaxRegistrationType = rowData.GetString("buyer-tax-registration-type");
            row.BuyerEInvoiceAccountId = rowData.GetString("buyer-e-invoice-account-id");
            row.IsBuyerPhysicallyPresent = rowData.GetString("is-buyer-physically-present");
            row.IsSellerPhysicallyPresent = rowData.GetString("is-seller-physically-present");
            row.CitationEs = rowData.GetString("citation-es");
            row.CitationIt = rowData.GetString("citation-it");
            row.CitationFr = rowData.GetString("citation-fr");
            row.CitationDe = rowData.GetString("citation-de");
            row.CitationEn = rowData.GetString("citation-en");
            row.ExportOutsideEu = rowData.GetString("export-outside-eu");
            row.IsInvoiceCorrected = rowData.GetString("is-invoice-corrected");
            row.OriginalVatInvoiceNumber = rowData.GetString("original-vat-invoice-number");
            row.InvoiceCorrectionDetails = rowData.GetString("invoice-correction-details");

            row.refNumber = refNumber;
            return row;

            return row;
        }
    }
}
