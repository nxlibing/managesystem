using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Web.Admin
{
    public partial class Main : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (null != User)
                {
                    username.InnerHtml = User.Realname + "&nbsp;&nbsp;(" + User.Username + ")";
                    username.Attributes.Add("p", User.Password);
                }
                else
                {
                    RedirectLogin();
                }
            }
          //  Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type=\"text/javascript\">LockScreen();</script>");
        }

        protected void DotNet_Exit_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            RedirectLogin();
            System.Web.Security.FormsAuthentication.RedirectToLoginPage();
        }

        private void RedirectLogin()
        {
            Response.Redirect("../Login.aspx");
        }
    }
}