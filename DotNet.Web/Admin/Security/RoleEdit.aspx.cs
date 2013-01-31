using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Presenter.Admin;
using DotNet.Business.Security.Entities;

namespace DotNet.Web.Admin.Security
{
    public partial class RoleEdit : PageBase, RoleEditIView
    {
        // private Base_Role _data;
        public Base_Role Data
        {
            get
            {
                Base_Role data = new Base_Role();
                if (string.IsNullOrEmpty(txtFguid.Text))
                {
                    data.Fguid = Guid.NewGuid().ToString();
                }
                else
                {
                    data.Fguid = txtFguid.Text;
                }
                data.Description = txtDescription.Text;
                data.Rolename = txtRolename.Text;
                data.Status = txtStatus.SelectedValue;
                data.Createid = "tr";
                data.Createdate = DateTime.Now;
                return data;
            }
            set
            {
                if (value != null)
                {
                    txtRolename.Text = value.Rolename;
                    txtStatus.Text = value.Status;

                    txtDescription.Text = value.Description;
                    txtFguid.Text = value.Fguid;
                }
            }
        }

        private string _fguid;
        public string Fguid
        {
            get { return _fguid; }
        }
        private RoleEditPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presenter = new RoleEditPresenter(this);
                _fguid = Request["fguid"];
                if (!string.IsNullOrEmpty(_fguid))
                {
                    View();
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
            _presenter = new RoleEditPresenter(this);
            bool result = SaveOrUpdate();
            DotNetCustomCalDotNetack.CalDotNetackResult.Result = result.ToString();
        }
    }
}