using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Presenter.Admin;
using DotNet.Business.Security.Entities;
using DotNet.Common;

namespace DotNet.Web.Admin.Security
{
    public partial class UserEdit : PageBase, UserEditIView
    {
        public Base_User Data
        {
            get
            {
                Base_User data = new Base_User();
                data.Description = txtDescription.Text;
                data.Realname = txtRealname.Text;
                data.Username = txtUsername.Text;
                data.Password = txtPassword.Text;
                data.Status = txtStatus.SelectedValue;
                data.Createid = User.Userid;
                data.Createdate = DateTime.Now;
                if (!string.IsNullOrEmpty(txtFguid.Text))
                {
                    data.Fguid = txtFguid.Text;
                }
                if (!string.IsNullOrEmpty(txtFguid.Text) && string.IsNullOrEmpty(txtPassword.Text))
                {
                    data.Password = txtPw.Text;
                }
                return data;
            }
            set
            {
                if (value != null)
                {
                    txtPw.Text = value.Password;
                    txtRealname.Text = value.Realname;
                    txtStatus.Text = value.Status;
                    txtUsername.Text = value.Username;
                    txtFguid.Text = value.Fguid;
                    txtDescription.Text = value.Description;
                }
            }
        }

        private string _fguid;
        public string Fguid
        {
            get { return _fguid; }
        }

        private UserEditPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presenter = new UserEditPresenter(this);
                _fguid = Request["fguid"];
                if (!string.IsNullOrEmpty(_fguid))
                {
                    View();
                }
                else
                {
                    pwtip.Visible = false;
                }
            }
        }

        public bool SaveOrUpdate()
        {
            return _presenter.SaveOrUpdate();
        }
        public void View()
        {
            _presenter.DataView();
        }
        protected void DotNetCustomCalDotNetack_CustomCalDotNetack(object sender, Controls.CustomCalDotNetack.DotNetCustomCalDotNetack.CustomCalDotNetackEventArgs e)
        {
            string action = e.Parameters;
            _presenter = new UserEditPresenter(this);
            bool result = SaveOrUpdate();
            DotNetCustomCalDotNetack.CalDotNetackResult.Result = result.ToString();
        }
    }
}