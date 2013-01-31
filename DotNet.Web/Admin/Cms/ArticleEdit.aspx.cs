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
    public partial class ArticleEdit : PageBase, ArticleEditIView
    {
        #region IViewl
        public IList<Cms_Category> CategoryList
        {
            set
            {
                ctlCategory.DataSource = RecursionList.GetCategory(value);
                ctlCategory.DataTextField = "Title";
                ctlCategory.DataValueField = "Fguid";
                ctlCategory.DataBind();
            }
        }
        public Cms_Article Data
        {
            get
            {
                Cms_Article data = new Cms_Article()
                {
                    Author = ctlAuthor.Text,
                    Categoryid = ctlCategory.SelectedValue,
                    Contents = Request.Params["editorcontent"].ToString(),
                    Editid = User.Userid,
                    Editsj = DateTime.Now,
                    Introduction = ctlIntroduction.Text,
                    Keywords = ctlKeywords.Text,
                    Title = ctlTitle.Text,
                    Source = ctlSource.Text,
                    Pubsj = DateTime.Parse(ctlPubsj.Text),
                    LinkUrl = ctlLinkurl.Text,
                    //  Jlsj
                    //Jlr
                    //Status

                };
                data.Fguid = txtFguid.Text;
                if (string.IsNullOrEmpty(data.Fguid))
                {
                    data.Jlr = User.Userid;
                    data.Jlsj = DateTime.Now;
                }
                int ishot = 0; int istop = 0; int isrecomen = 0; int iscolor = 0;
                GetRecomendType(out  ishot, out  istop, out  isrecomen, out  iscolor);
                data.Iscolor = iscolor;
                data.Ishot = ishot;
                data.Istop = istop;
                data.IsRecomend = isrecomen;
                return data;
            }
            set
            {
                if (null == value)
                {
                    return;
                }
                ctlContent.Text = value.Contents;
                txtFguid.Text = value.Fguid;
                ctlAuthor.Text = value.Author;
                ctlCategory.SelectedValue = value.Categoryid;
                ctlIntroduction.Text = value.Introduction;
                ctlKeywords.Text = value.Keywords;
                ctlLinkurl.Text = value.LinkUrl;
                ctlPubsj.Text = value.Pubsj.ToString2();
                ctlSource.Text = value.Source;
                ctlTitle.Text = value.Title;

                SetRecomendType(value);
            }
        }
        #endregion

        private ArticleEditPresenter _presenter;
        private ArticleEditPresenter presenter
        {
            get
            {
                if (null == _presenter)
                {
                    _presenter = new ArticleEditPresenter(this);
                }
                return _presenter;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                presenter.Init();

                string fguid = Request["fguid"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            presenter.SaveOrUpdate();
        }

        private void GetRecomendType(out int ishot, out int istop, out int isrecomen, out int iscolor)
        {
            ishot = 0; istop = 0; isrecomen = 0; iscolor = 0;
            int count = ctlRecomendType.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (ctlRecomendType.Items[i].Selected == true)
                {
                    string value = ctlRecomendType.Items[i].Value;
                    switch (value)
                    {
                        case "hot":
                            ishot = 1;
                            break;
                        case "recomen":
                            isrecomen = 1;
                            break;
                        case "color":
                            iscolor = 1;
                            break;
                        case "top":
                            istop = 1;
                            break;
                    }
                }
            }
        }

        private void SetRecomendType(Cms_Article data)
        {
            int count = ctlRecomendType.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (ctlRecomendType.Items[i].Selected == true)
                {
                    string value = ctlRecomendType.Items[i].Value;
                    switch (value)
                    {
                        case "hot":
                            ctlRecomendType.Items[i].Selected = data.Ishot == 1 ? true : false;
                            break;
                        case "recomen":
                            ctlRecomendType.Items[i].Selected = data.IsRecomend == 1 ? true : false;
                            break;
                        case "color":
                            ctlRecomendType.Items[i].Selected = data.Iscolor == 1 ? true : false;
                            break;
                        case "top":
                            ctlRecomendType.Items[i].Selected = data.Istop == 1 ? true : false;
                            break;
                    }
                }
            }
        }
    }
}