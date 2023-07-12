using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound;
namespace FikaAmazonAPI.Utils
{
    class SellerFreightClassConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string sellerFreightClassString = reader.Value.ToString();
            if (sellerFreightClassString.Substring(sellerFreightClassString.Length - 2) == ".0")
                sellerFreightClassString = sellerFreightClassString.Substring(0, sellerFreightClassString.Length - 2);
            return (SellerFreightClass)Enum.Parse(typeof(SellerFreightClass), sellerFreightClassString, true);
        }
    }
}
