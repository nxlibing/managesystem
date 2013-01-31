using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Presenter.Admin.Cms;
using DotNet.Business.Cms.Entities;

namespace DotNet.Web.Admin.Cms
{
    public partial class ArticleList : PageBase,ArticleListIView
    {
        #region View
        public Cms_Article Data
        {
            get
            { return new Cms_Article(); }
            set { }
        }

        public IList<Cms_Article> List
        {
            set;
            get;
        }
        public string Filter { get; set; }
        public string[] Fguids { get; set; }
        public int MaxRows { get; set; }
        public int StartIndex { get; set; }
        public int Count { get; set; }
        #endregion

        private ArticleListPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IList<Cms_Article> GetData(int maxRows, int startIndex)
        {
            this.MaxRows = maxRows;
            this.StartIndex = startIndex;

            _presenter = new ArticleListPresenter(this);
          //  Filter = Session["UserManage_Realname"].ToString2();
            _presenter.GetAllList();
            IList<Cms_Article> list = this.List;
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
                    _presenter = new ArticleListPresenter(this);
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