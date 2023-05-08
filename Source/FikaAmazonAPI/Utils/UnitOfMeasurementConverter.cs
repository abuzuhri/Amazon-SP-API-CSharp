using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound;

namespace FikaAmazonAPI.Utils
{
    class UnitOfMeasurementConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string unitOfMeasurementString = reader.Value.ToString();
            if (unitOfMeasurementString.Equals("in", StringComparison.OrdinalIgnoreCase))
                return UnitOfMeasurement.Inches;
            else
                return (UnitOfMeasurement)Enum.Parse(typeof(UnitOfMeasurement), unitOfMeasurementString, true);
        }
    }
}
