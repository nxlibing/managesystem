using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System
{
    public static class StringExtension
    {
        public static string ToString2(this object value)
        {
            string r = "";
            if (null == value)
            {
                return r;
            }
            return value.ToString();
        }

        public static bool ToBool(this string value, bool defaultValue)
        {
            bool r;
            if (bool.TryParse(value, out r))
            {
                return r;
            }
            return defaultValue;
        }

        public static int ToInt(this string value, int defaultValue)
        {
            int r;
            if (int.TryParse(value, out r))
            {
                return r;
            }
            return defaultValue;
        }

        public static double ToDouble(this string value, double defaultValue)
        {
            double r;
            if (double.TryParse(value, out r))
            {
                return r;
            }
            return defaultValue;
        }

        /// <summary>
        /// 把十六进制字符串转为数值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int HexToInt(this String obj, int defaultValue)
        {
            int r;
            if (int.TryParse(obj, System.Globalization.NumberStyles.AllowHexSpecifier, System.Globalization.NumberFormatInfo.CurrentInfo, out r))
            {
                return r;
            }
            return defaultValue;
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String Capitalize(this String obj)
        {
            if (String.IsNullOrEmpty(obj))
            {
                return obj;
            }

            String ret = obj[0].ToString().ToUpper() + obj.Substring(1);

            return ret;
        }
    }
}
