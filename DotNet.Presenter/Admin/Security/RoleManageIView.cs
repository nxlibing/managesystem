using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Entities;

namespace DotNet.Presenter.Admin
{
    public interface RoleManageIView
    {
        IList<Base_Role> List { set; }
        string Filter { get; set; }
        string[] Fguids { get; set; }
        int MaxRows { get; set; }
        int StartIndex { get; set; }
        int Count { get; set; }
    }
}
