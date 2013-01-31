using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace DotNet.Common.Extensions
{
    public static class DataTableExtionsion
    {
        /// <summary>
        /// 把制定的DataTable转换为T类型的列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="datatable">数据表</param>
        /// <returns>实体列表</returns>
        public static IList<T> ToEntity<T>(this DataTable datatable) where T : new()
        { 
            IList<T> results = new List<T>();

            PropertyInfo[] properyInfos = typeof(T).GetProperties();

            //CBNX
            if (null == datatable)
            {
                return results;
            }

            foreach (DataRow row in datatable.Rows)
            {
                T r = new T();
                for (int i = 0; i < properyInfos.Length; ++i)
                { 
                    PropertyInfo propery = properyInfos[i];
                    if (!datatable.Columns.Contains(propery.Name))
                    {
                        continue;
                    }

                    object value = row[propery.Name];
                    if(value == DBNull.Value)
                    {
                        continue;
                    }

                    propery.SetValue(r, GetValue(value, propery.PropertyType), null);
                }

                results.Add(r);
            }

            return results;
        }

        private static object GetValue(object obj, Type targetType)
        { 

            if(targetType.IsAssignableFrom(typeof(int)))
            {
                return int.Parse(obj.ToString());
            }
            else if (targetType.IsAssignableFrom(typeof(double)))
            {
                return double.Parse(obj.ToString());
            }

            return obj;
        }
    }
}
