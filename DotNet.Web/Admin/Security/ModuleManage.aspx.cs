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
    public partial class ModuleManage : PageBase, ModuleManageIView
    {
        #region View
        public Base_Module Data
        {
            get
            { return new Base_Module(); }
            set { }
        }

        private IList<Base_Module> _list;
        public IList<Base_Module> List
        {
            set
            {
                _list = RecursionList.GetModule(value);
                GridView1.DataSource = _list;
                //  GridView1.DataKeyNames = new string[] { "Fguid" };//主键
                GridView1.DataBind();
            }
            get { return _list; }
        }
        public string Filter { get; set; }
        public string[] Fguids { get; set; }
        public int MaxRows { get; set; }
        public int StartIndex { get; set; }
        public int Count { get; set; }
        #endregion

        private ModuleManagePresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presenter = new ModuleManagePresenter(this);

                _presenter.GetAllList();
            }
        }

        protected void DotNetCustomCalDotNetack_CustomCalDotNetack(object sender, Controls.CustomCalDotNetack.DotNetCustomCalDotNetack.CustomCalDotNetackEventArgs e)
        {
            string action = e.Parameters;
            string[] actarr = action.Split('_');
            switch (actarr[0])
            {
                case "del":
                    _presenter = new ModuleManagePresenter(this);
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
            _presenter = new ModuleManagePresenter(this);
            _presenter.GetAllList();
        }
    }
}