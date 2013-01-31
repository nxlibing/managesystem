using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Presenter.Admin.Security
{
    public interface UserRoleIView
    {
        IList<DotNet.Business.Security.Entities.Base_Role> RoleList { set; }

        IList<DotNet.Business.Security.Entities.Base_UserRole> UserRoleList { get; set; }

        string Userid { get; }
    }
}
