using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DotNet.Common
{
    public static class Domain
    {
        /// <summary>
        /// 获取当前域名,包括虚拟目录、端口，最后包含了反斜杠"/"
        /// 例如虚拟目录：http://www.aaa.com/Web/
        /// 例如网站：http://www.aaa.com/
        /// 最后有/
        /// </summary>
        public static string domain = "http://"
                + HttpContext.Current.Request.Url.Host
                + (HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port)
                + (HttpContext.Current.Request.ApplicationPath == "/" ? "/" : HttpContext.Current.Request.ApplicationPath + "/");


        /// <summary>
        /// 获取当前Web物理盘主路径，最后包含了反斜杠"/"
        /// 例如Web所在的主路径 C:/wwwroot/
        /// </summary>
        public static string appdomain = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

    }
}
