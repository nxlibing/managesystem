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
    public partial class ModuleEdit : PageBase, ModuleEditIView
    {
        #region IView
        public IList<Base_Module> List
        {
            set
            {
                IList<Base_Module> list = RecursionList.GetModule(value);

                list.Insert(0, new Base_Module { Fguid = "", Title = "根目录" });
                ctlPguid.DataSource = list;
                ctlPguid.DataValueField = "Fguid";
                ctlPguid.DataTextField = "Title";
                ctlPguid.DataBind();
            }
        }
        public Base_Module Data
        {
            get
            {
                Base_Module data = new Base_Module();
                data.Createdate = DateTime.Now;
                data.Createid = "";
                data.Description = ctlDescription.Text;
                data.Dispindex = ctlDispindex.Text;
                if (!string.IsNullOrEmpty(ctlFguid.Text))
                {
                    data.Fguid = ctlFguid.Text;
                }
                data.Moduleno = ctlSysno.Text;
                data.Navigateurl = ctlNavigateurl.Text;
                data.Pguid = ctlPguid.SelectedValue;
                data.Status = ctlStatus.SelectedValue;
                data.Title = ctlTitle.Text;
                return data;
            }
            set
            {
                if (value != null)
                {
                    ctlDescription.Text = value.Description;
                    ctlDispindex.Text = value.Dispindex;
                    ctlFguid.Text = value.Fguid;
                    ctlNavigateurl.Text = value.Navigateurl;
                    ctlPguid.SelectedValue = value.Pguid;
                    ctlStatus.SelectedValue = value.Status;
                    ctlSysno.Text = value.Moduleno;
                    ctlTitle.Text = value.Title.Trim().Replace("∟", "");
                }
            }
        }
        private string _fguid;
        public string Fguid
        {
            get { return _fguid; }
        }
        #endregion

        private ModuleEditPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presenter = new ModuleEditPresenter(this);
                _presenter.Init();
                ctlPguid.SelectedValue = Request.QueryString["pguid"].ToString2();

                _fguid = Request["fguid"];
                if (!string.IsNullOrEmpty(_fguid))
                {
                    _presenter.DataView();
                }
            }
        }

        protected void DotNetCustomCalDotNetack_CustomCalDotNetack(object sender, Controls.CustomCalDotNetack.DotNetCustomCalDotNetack.CustomCalDotNetackEventArgs e)
        {
            _presenter = new ModuleEditPresenter(this);
            bool result = _presenter.SaveOrUpdate();
            DotNetCustomCalDotNetack.CalDotNetackResult.Result = result.ToString();
        }

    }
}