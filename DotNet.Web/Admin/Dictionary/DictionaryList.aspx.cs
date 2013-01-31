using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Presenter.Admin.Dictionary;
using DotNet.Business.Dictionary.Entities;

namespace DotNet.Web.Admin.Dictionary
{
    public partial class DictionaryList : PageBase, DictionaryListIView
    {
        #region IView
        private Business.Dictionary.Entities.Base_Item _data;
        public Business.Dictionary.Entities.Base_Item Data
        {
            get
            {
                return _data;
            }
        }

        public IList<Business.Dictionary.Entities.Base_Item> CategoryList
        {
            set
            {
                GridView1.DataSource = value;
                GridView1.DataBind();
            }
        }
        #endregion

        private DictionaryListPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (null == _data)
            {
                _data = new Base_Item();
            }
            _data.Fguid = GridView1.DataKeys[e.RowIndex].Value.ToString();

            _presenter = new DictionaryListPresenter(this);
            _presenter.Delete();
            GridView1.EditIndex = -1;
            GridBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string fguid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string code = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text;
            string name = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text;

            CreateData( code, name,fguid);

            _presenter = new DictionaryListPresenter(this);
            _presenter.SaveOrUpdate();
            GridView1.EditIndex = -1;
            GridBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridBind();
        }
        private void GridBind()
        {
            _presenter = new DictionaryListPresenter(this);
            _presenter.GetCategoryList();
        }


        protected void DotNetCustomCalDotNetack_CustomCalDotNetack(object sender, Controls.CustomCalDotNetack.DotNetCustomCalDotNetack.CustomCalDotNetackEventArgs e)
        {
            string name = ctlName.Text;
            string code = ctlCode.Text;
            CreateData(code, name);
            _presenter = new DictionaryListPresenter(this);
            _presenter.SaveOrUpdate();
            _presenter.GetCategoryList();
            ctlCode.Text = "";
            ctlName.Text = "";
        }

        private Business.Dictionary.Entities.Base_Item CreateData(string code, string name, string fguid = null)
        {
            if (null == _data)
            {
                _data = new Base_Item();
            }
            if (!string.IsNullOrEmpty(fguid))
            {
                _data.Fguid = fguid;
            }
            _data.Code = code;
            _data.Name = name;
            return _data;
        }
    }
}