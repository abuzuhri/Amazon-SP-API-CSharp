using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FikaAmazonAPI.Utils
{
    public class DoubleJsonConverter : JsonConverter<double>
    {
        public override double ReadJson(JsonReader reader, Type objectType,
            double existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer,
            double value, JsonSerializer serializer)
        {
            // Customise how you want the decimal value to be output in here
            // for example, you may want to consider culture
            if (value % 1 != 0)
            {
                writer.WriteRawValue(value.ToString());
            }
            else
            {
                writer.WriteRawValue(((double)value).ToString("F0", CultureInfo.InvariantCulture));
            }
        }
    }
}
