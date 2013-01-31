using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Presenter.Admin;
using DotNet.Business.Security.Entities;
using DotNet.Common.Extensions;

namespace DotNet.Web.Admin.Security
{
    public partial class RoleManage : PageBase, RoleManageIView
    {
        #region View
        public Base_Role Data
        {
            get
            { return new Base_Role(); }
            set { }
        }

        public string Filter { get; set; }
        public IList<Base_Role> List
        {
            set;
            get;
        }

        public string[] Fguids { get; set; }

        public int MaxRows { get; set; }
        public int StartIndex { get; set; }
        public int Count { get; set; }
        #endregion

        private RoleManagePresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IList<Base_Role> GetData(int maxRows, int startIndex)
        {
            this.MaxRows = maxRows;
            this.StartIndex = startIndex;

            _presenter = new RoleManagePresenter(this);
            Filter = Session["RoleManage_Rolename"].ToString2();
            _presenter.GetAllList();
            IList<Base_Role> list = this.List;
            return list;
        }

        public int GetCount()
        {
            return this.Count;
        }

        protected void DotNetCustomCalDotNetack_CustomCalDotNetack(object sender, Controls.CustomCalDotNetack.DotNetCustomCalDotNetack.CustomCalDotNetackEventArgs e)
        {
            //string result = e.Parameters;
            string action = e.Parameters;
            string[] actarr = action.Split('_');
            switch (actarr[0])
            {
                case "del":
                    _presenter = new RoleManagePresenter(this);
                    bool result = Delete(actarr[1]);
                    CalDotNetack.CalDotNetackResult.Result = result.ToString();
                    CalDotNetack.CalDotNetackResult.IsRefresh = result;
                    break;
                case "edit":
                    CalDotNetack.CalDotNetackResult.Result = "true";
                    break;
                case "search":
                    DataSearch();
                    break;

                //default:
                //    CalDotNetack.CalDotNetackResult = actarr[0] + "???" + actarr[1];
                //    break;
            }
        }

        private bool Delete(string paramenters)
        {
            Fguids = paramenters.Split(',');
            int count = _presenter.Delete();
            if (count > 0)
            {
                DataSearch();
                return true;
            }
            return false;
        }

        private void DataSearch()
        {
            Session["RoleManage_Rolename"] = ctlRolename.Text;
            GridView1.DataSourceID = DataSource.ID;
            if (this.GridView1.PageIndex == 0)
            {
                this.GridView1.DataBind();
            }
            else
            {
                this.GridView1.PageIndex = 0;
            }
        }
    }
}