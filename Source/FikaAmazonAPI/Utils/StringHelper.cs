using System;

namespace FikaAmazonAPI.Utils
{
    public static class StringHelper
    {
        public static string ToCamelCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            string[] words = str.Split(new char[] { '_', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string camelCase = words[0].ToLower();

            for (int i = 1; i < words.Length; i++)
            {
                camelCase += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
            }

            return camelCase;
        }
    }
}
