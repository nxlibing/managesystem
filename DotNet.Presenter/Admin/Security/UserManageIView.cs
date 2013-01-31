using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Entities;

namespace DotNet.Presenter.Admin
{
    public interface UserManageIView
    {
        Base_User Data { get; set; }
        IList<Base_User> List { set; }
        string Filter { get; set; }
        string[] Fguids { get; set; }
        int MaxRows { get; set; }
        int StartIndex { get; set; }
        int Count { get; set; }
    }
}
