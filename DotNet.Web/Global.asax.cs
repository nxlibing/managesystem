using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using DotNet.Common.IOC;
using DotNet.Common;

namespace DotNet.Web
{
    public class Global : System.Web.HttpApplication, IUnityContainerAccessor
    {

        public override void Init()
        {
            base.Init();

            Log.InitLog();

            this.BeginRequest += new EventHandler(OnBeginRequest);
        }

        void OnBeginRequest(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo myCI = new System.Globalization.CultureInfo("zh-CN", true);
            myCI.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            System.Threading.Thread.CurrentThread.CurrentCulture = myCI;
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            DotNet.Common.AppInfo.ApplicationStartPath = System.AppDomain.CurrentDomain.BaseDirectory;
            DotNet.Common.Ioc.InitUntiy(System.IO.Path.Combine(DotNet.Common.AppInfo.ApplicationStartPath, "config\\unity.config"));
            String nfConfig = System.IO.Path.Combine(DotNet.Common.AppInfo.ApplicationStartPath, "config\\hibernate.cfg.config");
            XNamespace ns = "urn:nhibernate-configuration-2.2";
            var t = from ele in XElement.Load(nfConfig).Element(ns + "session-factory").Elements(ns + "property")
                    where ele.Attribute("name").Value.Equals("connection.connection_string")
                    select ele.Value;
            DotNet.Common.AppInfo.ConnectString = t.First();
            DotNet.Entitity.BusinesBase.Init(nfConfig);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            try
            {
                string session_param_name = "ASPSESSID";
                string session_cookie_name = "ASP.NET_SESSIONID";

                if (HttpContext.Current.Request.Form[session_param_name] != null)
                {
                    UpdateCookie(session_cookie_name, HttpContext.Current.Request.Form[session_param_name]);
                }
                else if (HttpContext.Current.Request.QueryString[session_param_name] != null)
                {
                    UpdateCookie(session_cookie_name, HttpContext.Current.Request.QueryString[session_param_name]);
                }
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                Response.Write("Error Initializing Session");
            }

            try
            {
                string auth_param_name = "AUTHID";
                string auth_cookie_name = FormsAuthentication.FormsCookieName;

                if (HttpContext.Current.Request.Form[auth_param_name] != null)
                {
                    UpdateCookie(auth_cookie_name, HttpContext.Current.Request.Form[auth_param_name]);
                }
                else if (HttpContext.Current.Request.QueryString[auth_param_name] != null)
                {
                    UpdateCookie(auth_cookie_name, HttpContext.Current.Request.QueryString[auth_param_name]);
                }

            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                Response.Write("Error Initializing Forms Authentication");
            }
        }
        void UpdateCookie(string cookie_name, string cookie_value)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookie_name);
            if (cookie == null)
            {
                cookie = new HttpCookie(cookie_name);
                HttpContext.Current.Request.Cookies.Add(cookie);
            }
            cookie.Value = cookie_value;
            HttpContext.Current.Request.Cookies.Set(cookie);
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.StatusCode = 404;
            //Response.Write("<html xmlns=\"http://www.w3.org/1999/xhtml/\" ><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><title>页面没有找到</title><meta http-equiv=\"refresh\" CONTENT=\"0; url=/\"></head><body><div>" + "<div style=\"display:none;\">页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到页面没有找到</div></div></body></html>");
            //Response.End();
        }


        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }


        #region IUnityContainerAccessor 成员

        public Microsoft.Practices.Unity.IUnityContainer Contanier
        {
            get
            {
                return Ioc.Container;
            }
        }

        #endregion
    }
}