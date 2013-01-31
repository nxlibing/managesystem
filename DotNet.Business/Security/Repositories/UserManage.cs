using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Repositories;
using DotNet.DataAccess;
using DotNet.Business.Security.Entities;
using System.Collections;
using NHibernate;
using DotNet.Business.Security.Domain;

namespace DotNet.Business.Security.Repositories
{
    public class UserManage : Repository
    {
        public UserManage(ICommonDao commonDao)
            : base(commonDao)
        { }

        /// <summary>
        /// 获取启用状态的角色列表
        /// </summary>
        /// <returns></returns>
        public IList<Base_Role> GetEnableRoleList()
        {
            string hql = "from Base_Role where Status=1";
            IList list = GetByHql(hql, new object[] { });
            return list.OfType<Base_Role>().ToList<Base_Role>();
        }

        public IList<Base_UserRole> GetUserRoleListByUserid(string userid)
        {
            string hql = string.Format("from Base_UserRole where Userid='{0}'", userid);
            IList list = GetByHql(hql, new object[] { });
            return list.OfType<Base_UserRole>().ToList<Base_UserRole>();
        }

        public int DeleteUserRoles(string userid, Core.IUnitOfWork unitofWork = null)
        {
            string hql = string.Format("from  Base_UserRole where Userid='{0}'", userid);
            return Delete(hql, new object[] { }, new NHibernate.Type.IType[] { }, unitofWork);
        }

        public int DeleteRoleModules(string roleid, Core.IUnitOfWork unitofWork = null)
        {
            string hql = string.Format("from  Base_RoleModule where Roleid='{0}'", roleid);
            return Delete(hql, new object[] { }, new NHibernate.Type.IType[] { }, unitofWork);
        }

        public List<String> GetRoleModules(string roleid)
        {
            string hql = "select Moduleid from Base_RoleModule where   Roleid=?";
            IList list = GetByHql(hql, new object[] { roleid });
            return list.OfType<string>().ToList();
        }

        /// <summary>
        /// 获取启用状态的模块列表
        /// </summary>
        /// <returns></returns>
        public IList<Base_Module> GetEnableModuleList(string moduleid = "")
        {
            string hql = string.Format("from Base_Module where Moduleno like '{0}%' and Status=1 order by Moduleno asc", moduleid);
            IList list = GetByHql(hql, new object[] { });
            return list.OfType<Base_Module>().ToList<Base_Module>();
        }

        public IList<Base_Module> GetEnableRootModuleList()
        {
            string hql = "from Base_Module where Status=1 and (Pguid is null or len(Pguid)=0) order by Moduleno asc";
            IList list = GetByHql(hql, new object[] { });
            return list.OfType<Base_Module>().ToList<Base_Module>();
        }

        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string username, string password)
        {
            User data = new User();
            if (!Common.Encryption.SqlFilter(username))
            {
                data.LoginStatus = -1;//输入非法字符
                return data;
            }
            string hql = "from Base_User where Username=? ";
            IList list = GetByHql(hql, new object[] { username });

            if (null == list || list.Count == 0)
            {
                data.LoginStatus = 2;//用户不存在
                return data;
            }
            Base_User user = list.OfType<Base_User>().ToList()[0];
            password = Common.Encryption.EncryptMD5(password);
            if (user.Password != password)
            {
                data.LoginStatus = 3;//用户密码错误
                return data;
            }
            if (user.Status != "1")
            {
                data.LoginStatus = 0;//用户处于无效状态
                return data;
            }
            data.ModuleList = GetModuleListByUserid(user.Fguid);
            if (data.ModuleList == null || data.ModuleList.Count == 0)
            {
                data.LoginStatus = 4;//没有登录系统的权限
                return data;
            }
            data.Realname = user.Realname;
            data.LoginStatus = 1; //0未启用 1正常
            data.Userid = user.Fguid;
            data.Username = user.Username;
            data.Password = user.Password;
            return data;
        }

        /// <summary>
        /// 根据用户id获取权限列表 
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        private List<string> GetModuleListByUserid(string userid)
        {
            string hql = @"select c.Moduleid from Base_User a,Base_UserRole b,Base_RoleModule c where a.Fguid=b.Userid and b.Roleid=c.Roleid and a.Fguid=?";
            IList list = CommonDao.GetByHql(hql, new object[] { userid });
            return list.OfType<string>().ToList();
        }

        public IList<Base_User> GerUserListByRoleid(string roleid)
        {
            string hql = "  select b from Base_UserRole a ,Base_User b where a.Userid=b.Fguid and a.Roleid=?";
            IList list = CommonDao.GetByHql(hql, new object[] { roleid });
            return list.OfType<Base_User>().ToList();
        }
    }
}
