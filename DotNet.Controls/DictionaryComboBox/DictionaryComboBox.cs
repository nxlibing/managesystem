using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Presenter.Controls;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace DotNet.Controls.DictionaryComboBox
{
    [ToolboxData("<{0}:DictionaryComboBox  ID=DictionaryComboBox runat=server></{0}:DictionaryComboBox>")]
    public class DictionaryComboBox : System.Web.UI.WebControls.DropDownList, IDictionaryView, ISelectdItem
    {
        private DictionaryPresenter _presenter;

        private bool _enableAll;
        private bool _enableEmpty;

        /// <summary>
        /// 在组合中增加所有选项
        /// </summary>
        public bool EnableAll
        {
            get { return _enableAll; }
            set { _enableAll = value; }
        }

        /// <summary>
        /// 在组合中增加空选项
        /// </summary>
        public bool EnableEmpty
        {
            get { return _enableEmpty; }
            set { _enableEmpty = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this._presenter = new DictionaryPresenter(this);

            this.DataValueField = "Fguid";
            this.DataTextField = "Name";
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="category">字典种类</param>
        public void Init(String category)
        {
            this._presenter.InitView(new String[] { category });

            if (this.EnableAll)
            {
                this.Items.Insert(0, new ListItem("所有", "all"));
            }

            if (this.EnableEmpty)
            {
                this.Items.Insert(0, new ListItem("", ""));
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        ///<param name="categories">种类大类编码</param>
        public void Init(String[] categories)
        {
            this._presenter.InitView(categories);

            if (this.EnableAll)
            {
                this.Items.Insert(0, new ListItem("所有", "all"));
            }

            if (this.EnableEmpty)
            {
                this.Items.Insert(0, new ListItem("", ""));
            }
        }

        #region IDictionaryView 成员
        /// <summary>
        /// 选择的项
        /// </summary>
        public String SelectedItemValue
        {
            get
            {
                return null == this.SelectedValue ? "" : this.SelectedValue;
            }
            set
            {
                var item = this.Items.FindByValue(value);
                if (null != item)
                {
                    this.SelectedItem.Value = item.Value;
                }
                else
                {
                    this.SelectedIndex = -1;
                }
            }
        }

        public IList<Business.Dictionary.Entities.Base_ItemDetails> DataItems
        {
            get
            {
                return this.DataSource as IList<Business.Dictionary.Entities.Base_ItemDetails>;
            }
            set
            {
                this.DataSource = value;
                this.DataBind();

                if (this.Items.Count > 0)
                {
                    this.SelectedIndex = 0;
                }
            }
        }

        #endregion
    }
}
