using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Presenter.Admin.Security
{
    public interface RoleModuleIView
    {

        /// <summary>
        /// 权限列表
        /// </summary>
        IList<Business.Security.Entities.Base_Module> ModuleList { set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        IList<Business.Security.Entities.Base_Role> RoleList { set; }

        List<string> List { get; set; }

        string Roleid { get; }


        IList<DotNet.Business.Security.Entities.Base_User> UserList { set; get; }
        int MaxRows { get; set; }
        int StartIndex { get; set; }
        int Count { get; set; }
    }
}
