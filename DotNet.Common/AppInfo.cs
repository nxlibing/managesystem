using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DotNet.Common
{
    public class AppInfo
    {
        private static string _applicationStartPath;

        private static string _mainAssemblyName;

        /// <summary>
        /// 应用程序启动路径
        /// </summary>
        public static string ApplicationStartPath
        {
            get { return _applicationStartPath; }
            set { _applicationStartPath = value; }
        }

        /// <summary>
        /// 主程序集名(启动的程序集)
        /// </summary>
        public static string MainAssemblyName
        {
            get { return AppInfo._mainAssemblyName; }
            set { AppInfo._mainAssemblyName = value; }
        }

        private static String _connectString;

        /// <summary>
        /// 连接字符串
        /// </summary>
        public static String ConnectString
        {
            get { return AppInfo._connectString; }
            set { AppInfo._connectString = value; }
        }

        /// <summary>
        /// 当前域名
        /// </summary>
        public static string Domain
        {
            get
            {
                //针对公司端口映射
                int port = 7777;
                if (HttpContext.Current.Request.Url.Host != "222.177.19.233")
                {
                    port = HttpContext.Current.Request.Url.Port;
                }
                //return "http://"
                //       + HttpContext.Current.Request.Url.Host
                //       + (HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port)
                //       + (HttpContext.Current.Request.ApplicationPath == "/" ? "/" : HttpContext.Current.Request.ApplicationPath + "/");
                return "http://"
                                    + HttpContext.Current.Request.Url.Host
                                    + (port == 80 ? "" : ":" + port)
                                    + (HttpContext.Current.Request.ApplicationPath == "/" ? "/" : HttpContext.Current.Request.ApplicationPath + "/");

            }
        }

    }
}
