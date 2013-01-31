using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace System
{
    public static class JsonHelper
    {
        /// <summary>
        /// 将对象序列化为json字符串
        /// </summary>
        /// <param name="obj">序列对象</param>
        /// <returns>json字符串</returns>
        public static string ToJson(this object obj)
        {
            if (obj == null)
            {
                return "";
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = int.MaxValue;

            String json = serializer.Serialize(obj);

            //Regex regex = new Regex(@"\\/Date\((\d+)\)\\/", RegexOptions.Compiled);

            //Match match = regex.Match(json);
            //if (match.Success)
            //{
            //    json = regex.Replace(json, "$1");
            //}

            return json;
        }

        /// <summary>
        /// 将对象按照指定的递归深度序列化为json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="recursionLimit">递归深度</param>
        /// <returns>json字符串</returns>
        public static string ToJson(this object obj, int recursionLimit)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionLimit;
            return serializer.Serialize(obj);
        }

        public static T FromJson<T>(this string obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(obj);
        }
    }
}
