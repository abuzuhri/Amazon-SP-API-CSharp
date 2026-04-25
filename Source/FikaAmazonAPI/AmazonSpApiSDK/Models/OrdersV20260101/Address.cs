using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Address
    /// </summary>
    [DataContract]
    public partial class Address : IEquatable<Address>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address" /> class.
        /// </summary>
        public Address() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address" /> class.
        /// </summary>
        /// <param name="name">The full name of the person who will receive the delivery at this address.</param>
        /// <param name="companyName">The name of the business or organization at this address.</param>
        /// <param name="addressLine1">The primary street address.</param>
        /// <param name="addressLine2">Additional address information.</param>
        /// <param name="addressLine3">Additional address information.</param>
        /// <param name="city">The city of the address.</param>
        /// <param name="districtOrCounty">The district or county of the address.</param>
        /// <param name="stateOrRegion">The state, province, or region of the address.</param>
        /// <param name="municipality">The municipality of the address.</param>
        /// <param name="postalCode">The postal code, ZIP code, or equivalent mailing code of the address.</param>
        /// <param name="countryCode">The two-letter country code identifying the country of the address, in ISO 3166-1 format.</param>
        /// <param name="phone">The contact phone number for delivery coordination and customer communication.</param>
        /// <param name="extendedFields">Additional address components that provide more detailed location information, helping with precise delivery routing.</param>
        /// <param name="addressType">The type of location.</param>
        public Address(string name,
                       string companyName,
                       string addressLine1,
                       string addressLine2,
                       string addressLine3,
                       string city,
                       string districtOrCounty,
                       string stateOrRegion,
                       string municipality,
                       string postalCode,
                       string countryCode,
                       string phone,
                       AddressExtendedFields extendedFields,
                       AddressTypeEnum? addressType)
        {
            this.Name = name;
            this.CompanyName = companyName;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.AddressLine3 = addressLine3;
            this.City = city;
            this.DistrictOrCounty = districtOrCounty;
            this.StateOrRegion = stateOrRegion;
            this.Municipality = municipality;
            this.PostalCode = postalCode;
            this.CountryCode = countryCode;
            this.Phone = phone;
            this.ExtendedFields = extendedFields;
            this.AddressType = addressType;
        }

        /// <summary>
        /// The full name of the person who will receive the delivery at this address.
        /// </summary>
        /// <value>The full name of the person who will receive the delivery at this address.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// The name of the business or organization at this address.
        /// </summary>
        /// <value>The name of the business or organization at this address.</value>
        [DataMember(Name = "companyName", EmitDefaultValue = false)]
        public string CompanyName { get; set; }

        /// <summary>
        /// The primary street address.
        /// </summary>
        /// <value>The primary street address.</value>
        [DataMember(Name = "addressLine1", EmitDefaultValue = false)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Additional address information.
        /// </summary>
        /// <value>Additional address information.</value>
        [DataMember(Name = "addressLine2", EmitDefaultValue = false)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Additional address information.
        /// </summary>
        /// <value>Additional address information.</value>
        [DataMember(Name = "addressLine3", EmitDefaultValue = false)]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// The city of the address.
        /// </summary>
        /// <value>The city of the address. </value>
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        /// <summary>
        /// The district or county of the address.
        /// </summary>
        /// <value>The district or county of the address.</value>
        [DataMember(Name = "districtOrCounty", EmitDefaultValue = false)]
        public string DistrictOrCounty { get; set; }

        /// <summary>
        /// The state, province, or region of the address.
        /// </summary>
        /// <value>The state, province, or region of the address.</value>
        [DataMember(Name = "stateOrRegion", EmitDefaultValue = false)]
        public string StateOrRegion { get; set; }

        /// <summary>
        /// The municipality of the address.
        /// </summary>
        /// <value>The municipality of the address.</value>
        [DataMember(Name = "municipality", EmitDefaultValue = false)]
        public string Municipality { get; set; }

        /// <summary>
        /// The postal code, ZIP code, or equivalent mailing code of the address.
        /// </summary>
        /// <value>The postal code, ZIP code, or equivalent mailing code of the address.</value>
        [DataMember(Name = "postalCode", EmitDefaultValue = false)]
        public string PostalCode { get; set; }

        /// <summary>
        /// The two-letter country code identifying the country of the address, in ISO 3166-1 format.
        /// </summary>
        /// <value>The two-letter country code identifying the country of the address, in ISO 3166-1 format.</value>
        [DataMember(Name = "countryCode", EmitDefaultValue = false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// The contact phone number for delivery coordination and customer communication.
        /// </summary>
        /// <value>The contact phone number for delivery coordination and customer communication.</value>
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        public string Phone { get; set; }

        /// <summary>
        /// Additional address components that provide more detailed location information, helping with precise delivery routing.
        /// </summary>
        /// <value>Additional address components that provide more detailed location information, helping with precise delivery routing.</value>
        [DataMember(Name = "extendedFields", EmitDefaultValue = false)]
        public AddressExtendedFields ExtendedFields { get; set; }

        /// <summary>
        /// The type of location. Possible values: RESIDENTIAL, COMMERCIAL, PICKUP_POINT
        /// </summary>
        /// <value>The type of location. Possible values: RESIDENTIAL, COMMERCIAL, PICKUP_POINT</value>
        [DataMember(Name = "addressType", EmitDefaultValue = false)]
        public AddressTypeEnum? AddressType { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Address {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  CompanyName: ").Append(CompanyName).Append("\n");
            sb.Append("  AddressLine1: ").Append(AddressLine1).Append("\n");
            sb.Append("  AddressLine2: ").Append(AddressLine2).Append("\n");
            sb.Append("  AddressLine3: ").Append(AddressLine3).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  DistrictOrCounty: ").Append(DistrictOrCounty).Append("\n");
            sb.Append("  StateOrRegion: ").Append(StateOrRegion).Append("\n");
            sb.Append("  Municipality: ").Append(Municipality).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  CountryCode: ").Append(CountryCode).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  ExtendedFields: ").Append(ExtendedFields).Append("\n");
            sb.Append("  AddressType: ").Append(AddressType).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Address);
        }

        /// <summary>
        /// Returns true if Address instances are equal
        /// </summary>
        /// <param name="input">Instance of Address to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Address input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.CompanyName == input.CompanyName ||
                    (this.CompanyName != null &&
                    this.CompanyName.Equals(input.CompanyName))
                ) &&
                (
                    this.AddressLine1 == input.AddressLine1 ||
                    (this.AddressLine1 != null &&
                    this.AddressLine1.Equals(input.AddressLine1))
                ) &&
                (
                    this.AddressLine2 == input.AddressLine2 ||
                    (this.AddressLine2 != null &&
                    this.AddressLine2.Equals(input.AddressLine2))
                ) &&
                (
                    this.AddressLine3 == input.AddressLine3 ||
                    (this.AddressLine3 != null &&
                    this.AddressLine3.Equals(input.AddressLine3))
                ) &&
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) &&
                (
                    this.DistrictOrCounty == input.DistrictOrCounty ||
                    (this.DistrictOrCounty != null &&
                    this.DistrictOrCounty.Equals(input.DistrictOrCounty))
                ) &&
                (
                    this.StateOrRegion == input.StateOrRegion ||
                    (this.StateOrRegion != null &&
                    this.StateOrRegion.Equals(input.StateOrRegion))
                ) &&
                (
                    this.Municipality == input.Municipality ||
                    (this.Municipality != null &&
                    this.Municipality.Equals(input.Municipality))
                ) &&
                (
                    this.PostalCode == input.PostalCode ||
                    (this.PostalCode != null &&
                    this.PostalCode.Equals(input.PostalCode))
                ) &&
                (
                    this.CountryCode == input.CountryCode ||
                    (this.CountryCode != null &&
                    this.CountryCode.Equals(input.CountryCode))
                ) &&
                (
                    this.Phone == input.Phone ||
                    (this.Phone != null &&
                    this.Phone.Equals(input.Phone))
                ) &&
                (
                    this.ExtendedFields == input.ExtendedFields ||
                    (this.ExtendedFields != null &&
                    this.ExtendedFields.Equals(input.ExtendedFields))
                ) &&
                (
                    this.AddressType == input.AddressType ||
                    (this.AddressType != null &&
                    this.AddressType.Equals(input.AddressType))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.CompanyName != null)
                    hashCode = hashCode * 59 + this.CompanyName.GetHashCode();
                if (this.AddressLine1 != null)
                    hashCode = hashCode * 59 + this.AddressLine1.GetHashCode();
                if (this.AddressLine2 != null)
                    hashCode = hashCode * 59 + this.AddressLine2.GetHashCode();
                if (this.AddressLine3 != null)
                    hashCode = hashCode * 59 + this.AddressLine3.GetHashCode();
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
                if (this.DistrictOrCounty != null)
                    hashCode = hashCode * 59 + this.DistrictOrCounty.GetHashCode();
                if (this.StateOrRegion != null)
                    hashCode = hashCode * 59 + this.StateOrRegion.GetHashCode();
                if (this.Municipality != null)
                    hashCode = hashCode * 59 + this.Municipality.GetHashCode();
                if (this.PostalCode != null)
                    hashCode = hashCode * 59 + this.PostalCode.GetHashCode();
                if (this.CountryCode != null)
                    hashCode = hashCode * 59 + this.CountryCode.GetHashCode();
                if (this.Phone != null)
                    hashCode = hashCode * 59 + this.Phone.GetHashCode();
                if (this.ExtendedFields != null)
                    hashCode = hashCode * 59 + this.ExtendedFields.GetHashCode();
                if (this.AddressType != null)
                    hashCode = hashCode * 59 + this.AddressType.GetHashCode();
                return hashCode;
            }
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