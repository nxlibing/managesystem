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
    public partial class RoleModule : PageBase, RoleModuleIView
    {
        #region IView
        public List<string> List
        {
            get
            {
                return ctlModuleList.CheckedValues;
            }
            set
            {
                ctlModuleList.CheckedValues = value;
            }
        }

        public string Roleid
        {
            get
            {
                if (ctlRoleid == null)
                {
                    return Session["roleid"].ToString2();
                }
                return ctlRoleid.Text;
            }
        }

        /// <summary>
        /// 权限列表
        /// </summary>
        public IList<Business.Security.Entities.Base_Module> ModuleList
        {
            set
            {
                Session["_moduleList"] = value;
            }
            get
            {
                return Session["_moduleList"] as IList<Business.Security.Entities.Base_Module>;
            }
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        public IList<Business.Security.Entities.Base_Role> RoleList
        {
            set
            {
                ctlRoleList.DataSource = value;
                ctlRoleList.DataKeyNames = new string[] { "Fguid" };
                ctlRoleList.DataBind();
            }
        }

        public IList<Base_User> UserList { set; get; }
        public int MaxRows { get; set; }
        public int StartIndex { get; set; }
        public int Count { get; set; }
        #endregion

        private RoleModulePresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presenter = new RoleModulePresenter(this);
                _presenter.Init();
            }
            ctlModuleList.ControlInit(ModuleList);
        }
        public IList<Base_User> GetData(int maxRows, int startIndex)
        {
            this.MaxRows = maxRows;
            this.StartIndex = startIndex;

            _presenter = new RoleModulePresenter(this);
            IList<Base_User> list;
            //   if (ctlRoleid != null)
            // {
            _presenter.GetUserList();
            list = this.UserList;
            //}
            //else
            //{
            //   list = new List<Base_User>();
            //}
            return list;
        }

        public int GetCount()
        {
            return this.Count;
        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {
            _presenter = new RoleModulePresenter(this);
            if (_presenter.Save())
            {
                ctlTip.Text = "保存成功！";
            }
            else
            {
                ctlTip.Text = "保存失败！";
            }

            Session["RoleModuleList"] = null;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string roleid = btn.CommandArgument;
            string rolename = btn.Text;
            roleinfo.InnerText = rolename;
            ctlRoleid.Text = roleid;

            _presenter = new RoleModulePresenter(this);
            _presenter.SetRoleModules();
            Moduleinfo.Style.Add("display", "");

            ctlTip.Text = "";
            //  SetUserList();
        }

        private void SetUserList()
        {
            Session["roleid"] = ctlRoleid.Text;
            //GridView1.DataSourceID = DataSource.ID;
            //if (this.GridView1.PageIndex == 0)
            //{
            //    this.GridView1.DataBind();
            //}
            //else
            //{
            //    this.GridView1.PageIndex = 0;
            //}
        }
    }
}