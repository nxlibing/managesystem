using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DotNet.Business.Security.Entities;
using DotNet.Presenter.Admin;

namespace DotNet.Web.Admin
{
    public partial class Content : System.Web.UI.Page, RoleManageIView
    {

        #region View
        public Base_Role Data
        {
            get
            { return new Base_Role(); }
            set { }
        }

        public string Filter { get; set; }
        public string[] Fguids { get; set; }
        //private IList<Base_User> _list;
        public IList<Base_Role> List
        {
            set;
            //{
            //    //IList<Base_User> list = value;
            //    //GridView1.DataSource = list;
            //    //GridView1.DataBind();
            //}
            get;
        }
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
                    DataSearch();
                    CalDotNetack.CalDotNetackResult.Result = "true";
                    CalDotNetack.CalDotNetackResult.IsRefresh = true;
                    //    CalDotNetack.Style= actarr[0] + "???" + actarr[1];
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
            if (action == "search")
            {
                //  GetSearchData();

            }
            //  
        }

        private void DataSearch()
        {
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