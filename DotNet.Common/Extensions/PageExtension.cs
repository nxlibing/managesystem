using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Web.UI
{
    public static class PageExtension
    {
        /// <summary>
        /// 检测页面上是否包含指定的js文件
        /// </summary>
        /// <param name="page"></param>
        /// <param name="jsFile">js文件名</param>
        /// <returns></returns>
        public static bool ContaintJSFile(this Page page, String jsFile)
        {
            var literas = page.Header.Controls.OfType<System.Web.UI.LiteralControl>();
            var scriptTags = from litera in literas where litera.Text.ToLower().Contains("script") select litera;
            List<String> scirptSrcs = new List<string>();
            foreach (var scriptTag in scriptTags)
            {
                Match match = Regex.Match(scriptTag.Text, "src\\s*=\"(.*)\"\\s");
                if (match.Success && match.Groups.Count > 1)
                {
                    String src = Regex.Replace(match.Groups[1].Value, ".*?/", "");
                    scirptSrcs.Add(src.Substring(0, src.IndexOf(".")));
                }
            }

            var js = from script in scirptSrcs
                     where jsFile.ToLower().Contains(script.ToLower())
                     select script;

            return js.Count() > 0;
        }
    }
}
