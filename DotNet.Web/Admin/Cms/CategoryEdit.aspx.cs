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
    public partial class CategoryEdit : PageBase, CategoryEditIView
    {
        #region IView
        public IList<Cms_Category> CategoryList
        {
            set
            {
                IList<Cms_Category> list = RecursionList.GetCategory(value);
                list.Insert(0, new Cms_Category { Title = "根目录" });
                ctlPguid.DataSource = list;
                ctlPguid.DataTextField = "Title";
                ctlPguid.DataValueField = "Fguid";
                ctlPguid.DataBind();
            }
        }
        public Cms_Category Data
        {
            get
            {
                Cms_Category data = new Cms_Category();
                data.Pguid = ctlPguid.SelectedValue;
                data.Title = ctlTitle.Text;
                if (!string.IsNullOrEmpty(ctlFguid.Text))
                {
                    data.Fguid = ctlFguid.Text;
                }
                data.Description = ctlDescription.Text;
                data.Isadd = bool.Parse(ctlIsadd.SelectedValue);
                data.Url = ctlUrl.Text;
                data.Categoryid = ctlCategoryid.Text;
                return data;
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                ctlFguid.Text = value.Fguid;
                ctlCategoryid.Text = value.Categoryid;
                ctlDescription.Text = value.Description;
                ctlIsadd.SelectedValue = value.Isadd.ToString();
                ctlPguid.SelectedValue = value.Pguid;
                ctlTitle.Text = value.Title.Trim().Replace("∟", "");
                ctlUrl.Text = value.Url;
            }
        }
        private string _fguid;
        public string Fguid
        {
            get { return _fguid; }
        }
        #endregion

        private CategoryEditPresentry _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presenter = new CategoryEditPresentry(this);
                _presenter.Init();
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
            _presenter = new CategoryEditPresentry(this);
            bool result = SaveOrUpdate();
            DotNetCustomCalDotNetack.CalDotNetackResult.Result = result.ToString();
        }


    }
}