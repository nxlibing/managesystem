using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Presenter.Admin.Security;
using DotNet.Business.Security.Entities;

namespace DotNet.Web.Admin.Security
{
    public partial class Password : PageBase, PasswordIView
    {
        #region IView
        public IList<Base_User> List
        {
            get;
            //{
            //   // return new Base_User { Fguid = User.Userid, Password = ctlNewPassword.Text };
            //}
            set;
        }
        #endregion

        private PasswordPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presenter = new PasswordPresenter(this);
                //_presenter.Init();
                //ctlPguid.SelectedValue = Request.QueryString["pguid"].ToString2();

                //_fguid = Request["fguid"];
                //if (!string.IsNullOrEmpty(_fguid))
                //{
                //    _presenter.DataView();
                //}
                PageInit();
            }
        }

        private void PageInit()
        {
            string fguid = Request["fguid"];
            if (!string.IsNullOrEmpty(fguid))
            {
                old.Visible = false;
                name.Visible = false;
            }
            else
            {
                ctlFguid.Text = User.Userid;
                ctlUsername.Text = User.Username + "(" + User.Realname + ")";
                ctlOldPassword2.Text = User.Password;
            }
        }

        protected void DotNetCustomCalDotNetack_CustomCalDotNetack(object sender, Controls.CustomCalDotNetack.DotNetCustomCalDotNetack.CustomCalDotNetackEventArgs e)
        {
            string args = Request["fguid"];
            List = new List<Base_User>();
            if (string.IsNullOrEmpty(args))
            {
                List.Add(new Base_User { Fguid = User.Userid, Password = ctlNewPassword.Text });
            }
            else
            {
                string[] fguids = args.Split(',');
                Base_User data;
                foreach (var item in fguids)
                {
                    data = new Base_User();
                    data.Fguid = item;
                    data.Password = ctlNewPassword.Text;
                    List.Add(data);
                }
            }
            _presenter = new PasswordPresenter(this);
            bool result = _presenter.ChangePassword();
            DotNetCustomCalDotNetack.CalDotNetackResult.Result = result.ToString();
        }

    }
}