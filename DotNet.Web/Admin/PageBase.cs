using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Text;
using DotNet.Common;

namespace DotNet.Web.Admin
{
    public class PageBase : System.Web.UI.Page
    {
        public Business.Security.Domain.User User
        {
            get
            {

                // if (Session["UserInfor"] != null)
                //{
                return Session["userAccount"] as Business.Security.Domain.User;
                //}
            }
        }
        #region 页面初始化
        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
            if (bool.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["IECompatible"]) == true)
            {
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "X-UA-Compatible";
                meta.Content = "IE=8";
                this.Header.Controls.AddAt(0, meta);
            }
            LiteralControl include = new LiteralControl(getHeaderInfo());
            this.Header.Controls.AddAt(0, include);
        }

        private string getHeaderInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\" src=\"" + AppInfo.Domain + "Admin/Style/Js/jquery-1.8.3.min.js\"></script>\n");
            sb.Append("<script type=\"text/javascript\" src=\"" + AppInfo.Domain + "Admin/Style/artDialog4.1.6/artDialog.source.js?skin=default\"></script>\n");
            sb.Append("<script type=\"text/javascript\" src=\"" + AppInfo.Domain + "Admin/Style/artDialog4.1.6/plugins/iframeTools.source.js\"></script>\n");
            sb.Append("<script type=\"text/javascript\" src=\"" + AppInfo.Domain + "Admin/Style/Js/Common.js\"></script>\n");
            sb.Append("<script type=\"text/javascript\" src=\"" + AppInfo.Domain + "Admin/Style/Js/JSON.js\"></script>\n");
            // sb.Append("<link href=\"" + Dcqtech.Common.Domain.domain + "Style/Css/master.css\" rel=\"stylesheet\" type=\"text/css\" />\n");
            sb.Append("<link href=\"" + AppInfo.Domain + "Admin/Style/Css/page.css\" rel=\"stylesheet\" type=\"text/css\" />\n");
            return sb.ToString();
        }
        #endregion
    }
}