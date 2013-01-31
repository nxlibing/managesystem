using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Presenter.Admin.Cms;
using DotNet.Business.Cms.Entities;
using DotNet.Common.Extensions;

namespace DotNet.Web.Admin.Cms
{
    public partial class CategoryList : PageBase, CategoryListIView
    {
        #region View
        public Cms_Category Data
        {
            get
            { return new Cms_Category(); }
            set { }
        }

        private IList<Cms_Category> _list;
        public IList<Cms_Category> List
        {
            set { _list = RecursionList.GetCategory(value); }
            get { return _list; }
        }
        public string Filter { get; set; }
        public string[] Fguids { get; set; }
        public int MaxRows { get; set; }
        public int StartIndex { get; set; }
        public int Count { get; set; }
        #endregion

        private CategoryListPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (true)
            {

            }
        }

        public IList<Cms_Category> GetData(int maxRows, int startIndex)
        {
            this.MaxRows = maxRows;
            this.StartIndex = startIndex;

            _presenter = new CategoryListPresenter(this);
            //  Filter = Session["UserManage_Realname"].ToString2();
            _presenter.GetAllList();
            IList<Cms_Category> list = this.List;
            return list;
        }

        public int GetCount()
        {
            return this.Count;
        }

        protected void DotNetCustomCalDotNetack_CustomCalDotNetack(object sender, Controls.CustomCalDotNetack.DotNetCustomCalDotNetack.CustomCalDotNetackEventArgs e)
        {
            string action = e.Parameters;
            string[] actarr = action.Split('_');
            switch (actarr[0])
            {
                case "del":
                    _presenter = new CategoryListPresenter(this);
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
            //  Session["UserManage_Realname"] = ctlRealname.Text;
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