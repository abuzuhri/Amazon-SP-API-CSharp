using FikaAmazonAPI.Parameter;
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
        public virtual List<KeyValuePair<string, string>> getParameters(bool isSandbox = false)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            Type t = this.GetType(); // Where obj is object whose properties you need.
            if (isSandbox)
            {
                if (typeof(IHasParameterizedTestCase).IsAssignableFrom(t))
                {
                    var queryParametersProperties = t.GetInterfaces().FirstOrDefault(x => x == typeof(IHasParameterizedTestCase)).GetProperties();
                    var testCasePropertyValue = queryParametersProperties.FirstOrDefault(x => x.Name == nameof(IHasParameterizedTestCase.TestCase))?.GetValue(this);
                    if (testCasePropertyValue != null && testCasePropertyValue is string testCase)
                    {
                        var sandboxQueryParametersPropertyValue = queryParametersProperties.FirstOrDefault(x => x.Name == nameof(IHasParameterizedTestCase.SandboxQueryParameters))?.GetValue(this);
                        if (sandboxQueryParametersPropertyValue != null && sandboxQueryParametersPropertyValue is Dictionary<string, List<KeyValuePair<string, string>>> sandboxQueryParameters)
                        {
                            if (sandboxQueryParameters.ContainsKey(testCase))
                                return sandboxQueryParameters[testCase];
                        }

                    }
                }
            }
            PropertyInfo[] pi = t.GetProperties();
            foreach (PropertyInfo p in pi)
            {

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
                    else if(p.PropertyType.IsEnum || IsNullableEnum(p.PropertyType))
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
