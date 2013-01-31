/*
 * Created by hx
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DotNet.Common.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 把指定对象的是拷贝到目标对象，src的类型必须能转换为dest类型(src类型为dest类型或派生类)
        /// </summary>
        /// <param name="src">源对象</param>
        /// <param name="dest">目标对象</param>
        public static void CopyTo(this object src, object dest)
        {
            if (src == null || dest == null)
            {
                return;
            }

            Type srcType = src.GetType();
            Type destType = dest.GetType();
            PropertyInfo[] srcProperties = srcType.GetProperties();
            for (int i = 0; i < srcProperties.Length; ++i)
            {
                System.Object value = srcProperties[i].GetValue(src, null);

                PropertyInfo destPropery = destType.GetProperty(srcProperties[i].Name);
                if (null != destPropery && destPropery.CanWrite)
                {
                    destPropery.SetValue(dest, value, null);
                }
            }
        }

        /// <summary>
        /// 把指定的对象转换为T类型
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="src">源数据</param>
        /// <returns>转换后的数据对象</returns>
        /// <remarks>
        /// src的类型必须能转换为T类型(src类型为T类型或派生类)
        /// </remarks>
        public static T ConvertTo<T>(this object src) where T: new()
        {
            T result = new T();
            src.CopyTo(result);

            return result;
        }

        public static String ToJson(this object obj)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(obj);
        }

        public static T FromJson<T>(this String text)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Deserialize<T>(text);
        }

        /// <summary>
        /// 克隆对象
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static object Clone(this object source)
        {
            Type type = source.GetType();
            object[] attributes = type.GetCustomAttributes(typeof(SerializableAttribute), false);
            if (attributes.Length <= 0)
            {
                throw new Exception("source类型必须有SerializableAttribute才能Clone");
            }

            System.IO.MemoryStream memStream = new System.IO.MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memStream, source);

            memStream.Position = 0;
            return formatter.Deserialize(memStream);
        }
    }
}
