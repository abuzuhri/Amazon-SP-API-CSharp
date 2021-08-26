using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FikaAmazonAPI.Search
{
    public class ParameterBased
    {
        public List<KeyValuePair<string, string>> getParameters()
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            Type t = this.GetType(); // Where obj is object whose properties you need.
            PropertyInfo[] pi = t.GetProperties();
            foreach (PropertyInfo p in pi)
            {

                var value = p.GetValue(this);
                if (value != null)
                {
                    var PropertyType = p.PropertyType;
                    var propTypeName = p.PropertyType.Name;

                    string output = "";
                    if (PropertyType == typeof(DateTime) || PropertyType == typeof(Nullable<DateTime>))
                    {
                        output = ((DateTime)value).ToString(Constants.DateISO8601Format);
                    }
                    else if (propTypeName == typeof(String).Name)
                    {
                        output = value.ToString();
                    }
                    else if(p.PropertyType.IsEnum)
                    {
                        output = value.ToString();
                    }
                    else if (IsEnumerableOfEnum(p.PropertyType) || IsEnumerable(p.PropertyType))
                    {
                        var data = ((IEnumerable)value).Cast<object>().Select(a => a.ToString());
                        if (data.Count() > 0)
                        {
                            var result = data.ToArray();
                            output = String.Join(",", result);
                        }
                        else continue;
                        
                    }
                    else
                    {
                        output = JsonConvert.SerializeObject(value);
                    }
                    

                    var propName = p.Name;

                    queryParameters.Add(new KeyValuePair<string, string>(propName, output));
                }
                
            }

            return queryParameters;
        }

        public static bool IsEnumerableOfEnum(Type type)
        {
            return GetEnumerableTypes(type).Any(t => t.IsEnum);
        }
        
        public static bool IsEnumerable(Type type)
        {
            if (type.IsInterface)
            {
                if (type.IsGenericType
                    && (type.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                        || type.GetGenericTypeDefinition() == typeof(IList<>)
                        || type.GetGenericTypeDefinition() == typeof(List<>)))
                {
                    return true;
                }
            }

            return false;
        }
        public static IEnumerable<Type> GetEnumerableTypes(Type type)
        {
            if (type.IsInterface)
            {
                if (type.IsGenericType
                    && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    yield return type.GetGenericArguments()[0];
                }
            }
            foreach (Type intType in type.GetInterfaces())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    yield return intType.GetGenericArguments()[0];
                }
            }
        }

    }
}
