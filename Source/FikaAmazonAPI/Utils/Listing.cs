using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FikaAmazonAPI.Utils
{
    public static class Listing
    {
        public static IList<IList<T>> Slice<T>(IList<T> list, int number)
        {
            IList<IList<T>> objListList = new List<IList<T>>();
            int num = list.Count / number;
            if ((uint)(list.Count % number) > 0U)
                ++num;
            for (int index = 0; index <= num - 1; ++index)
            {
                IList<T> list1 = list.Skip<T>(index * number).Take<T>(number).ToList<T>();
                objListList.Add(list1);
            }
            return objListList;
        }

        public static string GetElementAtIndexOrDefault(this object[] array, int index)
        {
            if (index >= 0 && index < array.Length)
            {
                return array[index].ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
