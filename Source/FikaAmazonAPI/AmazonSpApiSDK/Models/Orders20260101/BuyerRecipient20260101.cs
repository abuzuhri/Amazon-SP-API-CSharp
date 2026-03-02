using Newtonsoft.Json;

/// <summary>
/// Code Generated then Edited from:
/// https://github.com/amzn/selling-partner-api-models/blob/main/models/orders-api-model/orders_2026-01-01.json
/// </summary>

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101
{
    /// <summary>
    /// Buyer information. Requires includedData=BUYER.
    /// </summary>
    public class Buyer
    {
        [JsonProperty("buyerEmail")]
        public string BuyerEmail { get; set; }

        [JsonProperty("buyerName")]
        public string BuyerName { get; set; }

        [JsonProperty("buyerCompanyName")]
        public string BuyerCompanyName { get; set; }

        [JsonProperty("buyerPurchaseOrderNumber")]
        public string BuyerPurchaseOrderNumber { get; set; }
    }

    /// <summary>
    /// Recipient/delivery address information. Requires includedData=RECIPIENT.
    /// </summary>
    public class Recipient
    {
        [JsonProperty("deliveryAddress")]
        public DeliveryAddress DeliveryAddress { get; set; }

        [JsonProperty("deliveryPreference")]
        public object DeliveryPreference { get; set; }
    }

    public class DeliveryAddress
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("addressLine3")]
        public string AddressLine3 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("stateOrRegion")]
        public string StateOrRegion { get; set; }

        [JsonProperty("municipality")]
        public string Municipality { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("addressType")]
        public string AddressType { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }
    }
}
