using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FikaAmazonAPI.Search
{
    public class ParameterBased
    {
        [IgnoreToAddParameter]
        [JsonIgnore]
        public string TestCase { get; set; }

        [IgnoreToAddParameter]
        internal Dictionary<string, List<KeyValuePair<string, string>>> SandboxQueryParameters { get; private set; }

        public virtual List<KeyValuePair<string, string>> getParameters()
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrEmpty(TestCase))
            {
                SandboxQueryParameters = Sandbox.SandboxQueryParameters(this, TestCase);
                return SandboxQueryParameters[TestCase];
            }
            PropertyInfo[] pi = this.GetType().GetProperties();
            foreach (PropertyInfo p in pi)
            {
                if (p.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoreToAddParameterAttribute))) continue;
                if (p.CustomAttributes.Any(x => x.AttributeType == typeof(PathParameterAttribute))) continue;
                if (p.CustomAttributes.Any(x => x.AttributeType == typeof(BodyParameterAttribute))) continue;
                var value = p.GetValue(this);
                if (value != null)
                {
                    var PropertyType = p.PropertyType;
                    var propTypeName = p.PropertyType.Name;

                    if (propTypeName == "IsNeedRestrictedDataToken" || propTypeName == "RestrictedDataTokenRequest")
                        continue;

                    string output = "";
                    if (PropertyType == typeof(DateTime) || PropertyType == typeof(Nullable<DateTime>))
                    {
                        output = ((DateTime)value).ToString(Constants.DateISO8601Format);
                    }
                    else if (propTypeName == typeof(String).Name)
                    {
                        output = value.ToString();
                    }
                    else if (p.PropertyType.IsEnum || IsNullableEnum(p.PropertyType))
                    {
                        output = value.ToString();
                    }
                    else if (IsEnumerableOfEnum(p.PropertyType) || IsEnumerable(p.PropertyType))
                    {
                        var data = ((ICollection)value).Cast<object>().Select(a => a.ToString());
                        if (data.Count() > 0)
                        {
                            var result = data.ToArray();
                            output = string.Join(",", result);
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

        private static bool IsNullableEnum(Type t)
        {
            Type u = Nullable.GetUnderlyingType(t);
            return (u != null) && u.IsEnum;
        }
        private static bool IsEnumerableOfEnum(Type type)
        {
            return GetEnumerableTypes(type).Any(t => t.IsEnum);
        }

        private static bool IsEnumerable(Type type)
        {
            if (type.IsInterface)
            {
                if (type.IsGenericType
                    && (type.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                        || type.GetGenericTypeDefinition() == typeof(ICollection<>)
                        || type.GetGenericTypeDefinition() == typeof(IList<>)
                        || type.GetGenericTypeDefinition() == typeof(List<>)))
                {
                    return true;
                }
            }

            return false;
        }
        private static IEnumerable<Type> GetEnumerableTypes(Type type)
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
