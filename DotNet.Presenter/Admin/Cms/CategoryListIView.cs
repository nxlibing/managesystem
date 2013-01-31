using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Cms.Entities;

namespace DotNet.Presenter.Admin.Cms
{
    public interface CategoryListIView
    {
        Cms_Category Data { get; set; }
        IList<Cms_Category> List { set; }
        string Filter { get; set; }
        string[] Fguids { get; set; }
        int MaxRows { get; set; }
        int StartIndex { get; set; }
        int Count { get; set; }
    }
}
