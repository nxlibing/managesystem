﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace DotNet.Web
{
    public partial class Loginout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginOut();
        }

        private void LoginOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("Login.aspx");

            FormsAuthentication.RedirectToLoginPage();
        }
    }
}