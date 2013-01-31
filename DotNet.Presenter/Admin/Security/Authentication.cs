using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Common;

namespace DotNet.Presenter.Admin.Security
{
    /// <summary>
    /// 认证类
    /// </summary>
    public class Authentication
    {
        private Presenter.Admin.Security.AuthenticationIView _view;
        public Authentication(Presenter.Admin.Security.AuthenticationIView view)
        {
            _view = view;
        }

        /// <summary>
        /// 用户登录认证
        /// </summary>
        //  /// <returns> -1非法字符 0用户未启用 1正常 2用户不存在 3密码错误 4没有登录权限</returns>
        public Business.Security.Domain.User Authenticate()
        {
            DotNet.Business.Security.Repositories.UserManage rep = Ioc.Resolve<Business.Security.Repositories.UserManage>();
            Business.Security.Domain.User data = rep.Login(_view.Username, _view.Password);
            return data;
        }
    }
}
