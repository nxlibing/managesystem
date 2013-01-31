using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Entities;

namespace DotNet.Presenter.Admin
{
    public interface RoleEditIView
    {
        Base_Role Data { get; set; }

        string Fguid { get; }
    }

}
