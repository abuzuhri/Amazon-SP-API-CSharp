using System;

namespace FikaAmazonAPI.Parameter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class CamelCaseAttribute : Attribute
    {
    }

}
