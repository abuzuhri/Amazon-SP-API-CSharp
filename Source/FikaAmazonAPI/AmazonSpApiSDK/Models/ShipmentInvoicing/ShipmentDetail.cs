using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShipmentInvoicing
{
    public class ShipmentDetail : IEquatable<ShipmentDetail>, IValidatableObject
    {
        public ShipmentDetail()
        {

        }

        public string WarehouseId { get; set; }
        public string AmazonOrderId { get; set; }
        public string AmazonShipmentId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Address ShippingAddress { get; set; }
        public IList<string> PaymentMethodDetails { get; set; }
        public string MarketplaceId { get; set; }
        public string SellerId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerCounty { get; set; }
        public BuyerTaxInfo BuyerTaxInfo { get; set; }
        public string SellerDisplayName { get; set; }
        public IList<ShipmentItem> ShipmentItems { get; set; }


        public override bool Equals(object input)
        {
            return this.Equals(input as GetShipmentDetailsResponse);
        }
        public bool Equals(ShipmentDetail input)
        {
            if (input == null)
                return false;

            return
                (
                    this.WarehouseId == input.WarehouseId ||
                    (this.WarehouseId != null &&
                    this.WarehouseId.Equals(input.WarehouseId))
                );
        }


        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }


  
    }
}
