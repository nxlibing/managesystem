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
    public partial class UserRole : PageBase, UserRoleIView
    {
        #region IView
        public IList<DotNet.Business.Security.Entities.Base_Role> RoleList
        {
            set
            {
                ctlRoleList.DataSource = value;
                ctlRoleList.DataTextField = "Rolename";
                ctlRoleList.DataValueField = "Fguid";
                ctlRoleList.DataBind();
                foreach (ListItem li in ctlRoleList.Items)
                {
                    li.Attributes.Add("alt", li.Value);
                }

            }
        }
        private string _userid;
        public string Userid
        {
            get
            {
                return _userid;
            }
        }
        public IList<Base_UserRole> _userRoleList;
        public IList<Base_UserRole> UserRoleList
        {
            get
            {
                return _userRoleList;
            }
            set
            {
                foreach (var item in value)
                {
                    ListItem lt = ctlRoleList.Items.FindByValue(item.Roleid);
                    lt.Selected = true;
                }
            }
        }
        #endregion

        private UserRolePresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presenter = new UserRolePresenter(this);
                _userid = Request["fguid"];
                string user = Request["value"];
                if (!string.IsNullOrEmpty(user))
                {
                    userinfo.InnerText = user;
                }
                _presenter.Init();
            }
        }
        private bool Save(string roleguids)
        {
            string[] roleids = roleguids.Split(',');

            if (null == _userRoleList)
            {
                _userRoleList = new List<Base_UserRole>();
            }
            Base_UserRole data;
            _userid = Request["fguid"];
            for (int i = 0; i < roleids.Length - 1; i++)
            {
                data = new Base_UserRole();
                data.Userid = _userid;
                data.Roleid = roleids[i];
                _userRoleList.Add(data);
            }
            return _presenter.Save();
        }


        protected void DotNetCustomCalDotNetack_CustomCalDotNetack(object sender, Controls.CustomCalDotNetack.DotNetCustomCalDotNetack.CustomCalDotNetackEventArgs e)
        {
            string values = e.Parameters;
            _presenter = new UserRolePresenter(this);
            bool result = Save(values);
            DotNetCustomCalDotNetack.CalDotNetackResult.Result = result.ToString();
            DotNetCustomCalDotNetack.CalDotNetackResult.IsRefresh = true;
        }
    }
}