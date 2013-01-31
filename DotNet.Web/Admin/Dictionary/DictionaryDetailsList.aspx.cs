using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Presenter.Admin.Dictionary;

namespace DotNet.Web.Admin.Dictionary
{
    public partial class DictionaryDetailsList : PageBase, DictionaryDetailsListIView
    {
        #region IView
        public IList<Business.Dictionary.Entities.Base_Item> _categoryList;
        public IList<Business.Dictionary.Entities.Base_Item> CategoryList
        {
            set
            {
                Session["DictionaryDetailsList_CategoryList"] = value;
                _categoryList = value;
            }
            get
            {
                IList<Business.Dictionary.Entities.Base_Item> list = new List<Business.Dictionary.Entities.Base_Item>();
                list.Add(new Business.Dictionary.Entities.Base_Item { Fguid = ctlCategorys.SelectedValue });
                return list;
            }
        }
        public IList<Business.Dictionary.Entities.Base_ItemDetails> DetailsList
        {
            set
            {
                GridView1.DataSource = value;
                GridView1.DataBind();
            }
        }

        private Business.Dictionary.Entities.Base_ItemDetails _data;
        public Business.Dictionary.Entities.Base_ItemDetails Data
        {
            get
            {
                return _data;
            }
        }
        #endregion

        private DictionaryDetailsListPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _presenter = new DictionaryDetailsListPresenter(this);
                _presenter.Init();


                ctlCategorys.DataSource = _categoryList;
                ctlCategorys.DataTextField = "Name";
                ctlCategorys.DataValueField = "Fguid";
                ctlCategorys.DataBind();
                ctlCategorys.SelectedIndex = 0;

                SetItemDetailsList();
            }
        }
        protected void CalDotNetack_CustomCalDotNetack(object sender, Controls.CustomCalDotNetack.DotNetCustomCalDotNetack.CustomCalDotNetackEventArgs e)
        {
            if (null == _data)
            {
                _data = new Business.Dictionary.Entities.Base_ItemDetails();
            }
            _data.Name = ctlName.Text;
            _data.Code = ctlCode.Text;
            _data.Pguid = ctlCategorys.SelectedValue;

            _presenter = new DictionaryDetailsListPresenter(this);
            _presenter.SaveOrUpdate();
            _presenter.Init();
            SetItemDetailsList();
            ctlCode.Text = "";
            ctlName.Text = "";
        }

        protected void ctlCategorys_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetItemDetailsList();
        }

        private void SetItemDetailsList()
        {
            IList<Business.Dictionary.Entities.Base_Item> list = Session["DictionaryDetailsList_CategoryList"] as IList<Business.Dictionary.Entities.Base_Item>;
            if (list != null)
            {
                foreach (var item in list)
                {
                    if (item.Fguid == ctlCategorys.SelectedValue)
                    {
                        DetailsList = item.ItemDetailsList;
                    }
                }
            }
        }

        #region GridView事件
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Enable")
            {
                if (null == _data)
                {
                    _data = new Business.Dictionary.Entities.Base_ItemDetails();
                }
                _data.Fguid = e.CommandArgument.ToString();
                _presenter = new DictionaryDetailsListPresenter(this);
                _presenter.ItemDetailEnable();

                _presenter.Init();
                SetItemDetailsList();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            SetItemDetailsList();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (null == _data)
            {
                _data = new Business.Dictionary.Entities.Base_ItemDetails();
            }
            _data.Fguid = GridView1.DataKeys[e.RowIndex].Value.ToString();

            _presenter = new DictionaryDetailsListPresenter(this);
            _presenter.Delete();
            GridView1.EditIndex = -1;
            _presenter.Init();
            SetItemDetailsList();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (null == _data)
            {
                _data = new Business.Dictionary.Entities.Base_ItemDetails();
            }

            _data.Fguid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            _data.Code = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text;
            _data.Name = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text;

            _presenter = new DictionaryDetailsListPresenter(this);
            _presenter.SaveOrUpdate();
            GridView1.EditIndex = -1;
            _presenter.Init();
            SetItemDetailsList();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            SetItemDetailsList();
        }
        #endregion
    }
}