using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNet.Common.Extensions
{
    public class DateTimeExtension
    {
        /// <summary>
        /// 将日期数字格式转化为中文小写
        /// </summary>
        /// <param name="strDate">格式为2011-10-10   日期中间分隔符可以为(-)(/)   </param>
        /// <returns></returns>
        public static string ToChinese(string strDate)
        {
            DateToChinese a = new DateToChinese();
            string result = a.ToChinese(strDate);
            return result;
        }

        class DateToChinese
        {
            private char[] strChinese;

            public DateToChinese()
            {
                strChinese = new char[] { '〇', '一', '二', '三', '四', '五', '六', '七', '八', '九', '十' };
            }

            /// <summary>
            /// 将日期数字格式转化为中文小写
            /// </summary>
            /// <param name="strDate"></param>
            /// <returns></returns>
            public string ToChinese(string strDate)
            {
                StringBuilder result = new StringBuilder();

                // 依据正则表达式判断参数是否正确
                Regex theReg = new Regex(@"(\d{2}|\d{4})(\/|-)(\d{1,2})(\/|-)(\d{1,2})");
                if (theReg.Match(strDate).Length != 0)
                {
                    // 将数字日期的年月日存到字符数组str中
                    string[] str = null;
                    if (strDate.Contains("-"))
                    {
                        str = strDate.Split('-');
                    }
                    else if (strDate.Contains("/"))
                    {
                        str = strDate.Split('/');
                    }

                    // str[0]中为年，将其各个字符转换为相应的汉字
                    for (int i = 0; i < str[0].Length; i++)
                    {
                        result.Append(strChinese[int.Parse(str[0][i].ToString())]);
                    }
                    result.Append("_");

                    // 转换月
                    int month = int.Parse(str[1]);
                    int MN1 = month / 10;
                    int MN2 = month % 10;

                    if (MN1 > 1)
                    {
                        result.Append(strChinese[MN1]);
                    }
                    if (MN1 > 0)
                    {
                        result.Append(strChinese[10]);
                    }
                    if (MN2 != 0)
                    {
                        result.Append(strChinese[MN2]);
                    }
                    result.Append("_");

                    // 转换日
                    int day = int.Parse(str[2]);
                    int DN1 = day / 10;
                    int DN2 = day % 10;

                    if (DN1 > 1)
                    {
                        result.Append(strChinese[DN1]);
                    }
                    if (DN1 > 0)
                    {
                        result.Append(strChinese[10]);
                    }
                    if (DN2 != 0)
                    {
                        result.Append(strChinese[DN2]);
                    }
                    result.Append("_");
                }
                return result.ToString();
            }
        }

    }
}
