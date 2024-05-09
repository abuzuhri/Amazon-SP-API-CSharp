using System;

namespace FikaAmazonAPI.Utils
{
    public static class StringHelper
    {
        public static string FirstCharToLower(this string str)
        {
            return Char.ToLower(str[0]) + str.Substring(1);
        }
    }
}
