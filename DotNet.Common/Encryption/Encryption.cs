using System;
using System.Security.Cryptography;
using System.Text;

namespace DotNet.Common
{
    /// <summary>
    /// 字符串加密相关算法
    /// </summary>
    public static class Encryption
    {
        /// <summary>
        /// 字符串MD5加密
        /// </summary>
        /// <param name="encryptingString"></param>
        /// <returns></returns>
        public static string EncryptMD5(string encryptingString)
        {
            byte[] result = Encoding.Default.GetBytes(encryptingString);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
        /// <summary>  
        /// 分析用户请求是否正常  
        /// </summary>  
        /// <param name="Str">传入用户提交数据</param>  
        /// <returns>返回是否含有SQL注入式攻击代码</returns>
        public static bool SqlFilter(string stringInText)
        {
            bool ReturnValue = true;
            try
            {
                if (stringInText != "" && stringInText != null)
                {
                    string SqlStr = "";
                    if (SqlStr == "" || SqlStr == null)
                    {
                        SqlStr = "'|exec|insert|select|delete|update|count|*|chr|mid|master|truncate|char|declare";
                    }
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (stringInText.IndexOf(ss) >= 0)
                        {
                            ReturnValue = false;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }
    }
}
