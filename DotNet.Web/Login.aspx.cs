using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Presenter.Admin.Security;

namespace DotNet.Web
{
    public partial class Login : System.Web.UI.Page, AuthenticationIView
    {
        public string Username { get; set; }
        public string Password { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.Log.Error("a");
        }

        protected void btn_Ok_Click(object sender, EventArgs e)
        {
            ctlTip.Text = "";
            if (string.IsNullOrEmpty(ctlUsername.Text))
            {
                ctlTip.Text = "请输入用户名";
                return;
            }
            if (string.IsNullOrEmpty(ctlPassword.Text))
            {
                ctlTip.Text = "请输入密码";
                return;
            }
            string checkcode = Session["CheckCode"].ToString2();
            if (checkcode.ToLower() != ctlCheckCode.Text.ToLower())
            {
                ctlTip.Text = "验证码出错";
                return;
            }
            ctlTip.Text = "";

            Username = ctlUsername.Text;
            Password = ctlPassword.Text;
            Session.Clear();
            DoAuthenticate();
        }

        private void DoAuthenticate()
        {
            Authentication auth = new Authentication(this);
            Business.Security.Domain.User data = auth.Authenticate();

            switch (data.LoginStatus)
            {
                case -1:
                    ctlTip.Text = "请勿输入非法字符！";
                    break;
                case 0:
                    ctlTip.Text = "用户处于无效状态！";
                    break;
                case 1:
                    Session["userAccount"] = data;
                    Session.Timeout = 30;
                    Response.Redirect("~/Admin/Main.aspx", true);
                    break;
                case 2:
                case 3:
                    ctlTip.Text = "用户名或密码错误！";
                    break;
                case 4:
                    ctlTip.Text = "该用户没有登录权限！";
                    break;
            }
        }
    }
}