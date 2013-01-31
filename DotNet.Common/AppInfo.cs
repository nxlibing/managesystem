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
        /// Ӧ�ó�������·��
        /// </summary>
        public static string ApplicationStartPath
        {
            get { return _applicationStartPath; }
            set { _applicationStartPath = value; }
        }

        /// <summary>
        /// ��������(�����ĳ���)
        /// </summary>
        public static string MainAssemblyName
        {
            get { return AppInfo._mainAssemblyName; }
            set { AppInfo._mainAssemblyName = value; }
        }

        private static String _connectString;

        /// <summary>
        /// �����ַ���
        /// </summary>
        public static String ConnectString
        {
            get { return AppInfo._connectString; }
            set { AppInfo._connectString = value; }
        }

        /// <summary>
        /// ��ǰ����
        /// </summary>
        public static string Domain
        {
            get
            {
                //��Թ�˾�˿�ӳ��
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
