using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Cms.Entities;

namespace DotNet.Presenter.Admin.Cms
{
    public interface ArticleEditIView
    {
        IList<Cms_Category> CategoryList { set; }
        Cms_Article Data { get; set; }
    }
}
