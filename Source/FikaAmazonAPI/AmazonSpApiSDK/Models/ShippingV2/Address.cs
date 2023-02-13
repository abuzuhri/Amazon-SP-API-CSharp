using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// The address.
  /// </summary>
  [DataContract]
  public class Address {
    /// <summary>
    /// The name of the person, business or institution at the address.
    /// </summary>
    /// <value>The name of the person, business or institution at the address.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// The first line of the address.
    /// </summary>
    /// <value>The first line of the address.</value>
    [DataMember(Name="addressLine1", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "addressLine1")]
    public string AddressLine1 { get; set; }

    /// <summary>
    /// Additional address information, if required.
    /// </summary>
    /// <value>Additional address information, if required.</value>
    [DataMember(Name="addressLine2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "addressLine2", DefaultValueHandling = DefaultValueHandling.Ignore )]
    public string AddressLine2 { get; set; }

    /// <summary>
    /// Additional address information, if required.
    /// </summary>
    /// <value>Additional address information, if required.</value>
    [DataMember(Name="addressLine3", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "addressLine3", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string AddressLine3 { get; set; }

    /// <summary>
    /// The name of the business or institution associated with the address.
    /// </summary>
    /// <value>The name of the business or institution associated with the address.</value>
    [DataMember(Name="companyName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "companyName", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string CompanyName { get; set; }

    /// <summary>
    /// Gets or Sets StateOrRegion
    /// </summary>
    [DataMember(Name = "stateOrRegion", EmitDefaultValue = false)]
    [JsonProperty(PropertyName = "stateOrRegion")]
    public string StateOrRegion { get; set; } = string.Empty;

    /// <summary>
    /// Gets or Sets City
    /// </summary>
    [DataMember(Name="city", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "city")]
    public string City { get; set; }

    /// <summary>
    /// Gets or Sets CountryCode
    /// </summary>
    [DataMember(Name="countryCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "countryCode")]
    public string CountryCode { get; set; }

    /// <summary>
    /// Gets or Sets PostalCode
    /// </summary>
    [DataMember(Name="postalCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postalCode")]
    public string PostalCode { get; set; }

    /// <summary>
    /// The email address of the contact associated with the address.
    /// </summary>
    /// <value>The email address of the contact associated with the address.</value>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Email { get; set; }

    /// <summary>
    /// The phone number of the person, business or institution located at that address, including the country calling code.
    /// </summary>
    /// <value>The phone number of the person, business or institution located at that address, including the country calling code.</value>
    [DataMember(Name="phoneNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phoneNumber", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string PhoneNumber { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Address {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  AddressLine1: ").Append(AddressLine1).Append("\n");
      sb.Append("  AddressLine2: ").Append(AddressLine2).Append("\n");
      sb.Append("  AddressLine3: ").Append(AddressLine3).Append("\n");
      sb.Append("  CompanyName: ").Append(CompanyName).Append("\n");
      sb.Append("  StateOrRegion: ").Append(StateOrRegion).Append("\n");
      sb.Append("  City: ").Append(City).Append("\n");
      sb.Append("  CountryCode: ").Append(CountryCode).Append("\n");
      sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
