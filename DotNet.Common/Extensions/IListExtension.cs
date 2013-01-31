using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Common.Extensions
{
    public static class IListExtension
    {
        public static IList<T> Merge<T>(this IList<T> first, IList<T> second)
        {
            IList<T> list = new List<T>();
            if (first != null && first.Count > 0)
            {
                foreach (var item in first)
                {
                    list.Add(item);
                }
            }
            if (first != null && first.Count > 0)
            {
                foreach (var item in second)
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
