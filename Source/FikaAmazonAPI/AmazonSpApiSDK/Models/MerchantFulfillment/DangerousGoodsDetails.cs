using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.MerchantFulfillment
{
    [DataContract]
    public partial class DangerousGoodsDetails : IEquatable<DangerousGoodsDetails>, IValidatableObject
    {
        [DataMember(Name = "UnitedNationsRegulatoryId", EmitDefaultValue = false)]
        public string UnitedNationsRegulatoryId { get; set; }
        [DataMember(Name = "TransportationRegulatoryClass", EmitDefaultValue = false)]
        public string TransportationRegulatoryClass { get; set; }

        [DataMember(Name = "PackingGroup", EmitDefaultValue = false)]
        public PackingGroup? PackingGroup { get; set; }

        [DataMember(Name = "PackingInstruction", EmitDefaultValue = false)]
        public PackingInstruction? PackingInstruction { get; set; }

        [JsonConstructorAttribute]
        public DangerousGoodsDetails() { }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DangerousGoodsDetails {\n");
            sb.Append("  UnitedNationsRegulatoryId: ").Append(UnitedNationsRegulatoryId).Append("\n");
            sb.Append("  TransportationRegulatoryClass: ").Append(TransportationRegulatoryClass).Append("\n");
            sb.Append("  PackingGroup: ").Append(PackingGroup).Append("\n");
            sb.Append("  PackingInstruction: ").Append(PackingInstruction).Append("\n");            
            sb.Append("}\n");
            return sb.ToString();
        }
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public override bool Equals(object input)
        {
            return this.Equals(input as DangerousGoodsDetails);
        }

        public bool Equals(DangerousGoodsDetails input)
        {
            if (input == null)
                return false;

            return
                (
                    this.UnitedNationsRegulatoryId == input.UnitedNationsRegulatoryId ||
                    (this.UnitedNationsRegulatoryId != null &&
                    this.UnitedNationsRegulatoryId.Equals(input.UnitedNationsRegulatoryId))
                ) &&
                (
                    this.TransportationRegulatoryClass == input.TransportationRegulatoryClass ||
                    (this.TransportationRegulatoryClass != null &&
                    this.TransportationRegulatoryClass.Equals(input.TransportationRegulatoryClass))
                ) &&
                (
                    this.PackingGroup == input.PackingGroup ||
                    (this.PackingGroup != null &&
                    this.PackingGroup.Equals(input.PackingGroup))
                ) &&
                (
                    this.PackingInstruction == input.PackingInstruction ||
                    (this.PackingInstruction != null &&
                    this.PackingInstruction.Equals(input.PackingInstruction))
                );
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.UnitedNationsRegulatoryId != null)
                    hashCode = hashCode * 59 + this.UnitedNationsRegulatoryId.GetHashCode();
                if (this.TransportationRegulatoryClass != null)
                    hashCode = hashCode * 59 + this.TransportationRegulatoryClass.GetHashCode();
                if (this.PackingGroup != null)
                    hashCode = hashCode * 59 + this.PackingGroup.GetHashCode();
                if (this.PackingInstruction != null)
                    hashCode = hashCode * 59 + this.PackingInstruction.GetHashCode();                
                return hashCode;
            }
        }

        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PackingGroup
    {
        [EnumMember(Value = "I")]
        I = 1,

        [EnumMember(Value = "II")]
        II = 2,

        [EnumMember(Value = "III")]
        III = 3
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PackingInstruction
    {
        [EnumMember(Value = "PI965_SECTION_IA")]
        PI965_SECTION_IA = 1,

        [EnumMember(Value = "PI965_SECTION_IB")]
        PI965_SECTION_IB = 2,

        [EnumMember(Value = "PI965_SECTION_II")]
        PI965_SECTION_II = 3,

        [EnumMember(Value = "PI966_SECTION_I")]
        PI966_SECTION_I = 4,

        [EnumMember(Value = "PI966_SECTION_II")]
        PI966_SECTION_II = 5,

        [EnumMember(Value = "PI967_SECTION_I")]
        PI967_SECTION_I = 6,

        [EnumMember(Value = "PI967_SECTION_II")]
        PI967_SECTION_II = 7,

        [EnumMember(Value = "PI968_SECTION_IA")]
        PI968_SECTION_IA = 8,

        [EnumMember(Value = "PI968_SECTION_IB")]
        PI968_SECTION_IB = 9,

        [EnumMember(Value = "PI969_SECTION_I")]
        PI969_SECTION_I = 10,

        [EnumMember(Value = "PI969_SECTION_II")]
        PI969_SECTION_II = 11,

        [EnumMember(Value = "PI970_SECTION_I")]
        PI970_SECTION_I = 12,

        [EnumMember(Value = "PI970_SECTION_II")]
        PI970_SECTION_II = 13
    }
}
