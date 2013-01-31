using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Repositories;
using DotNet.Common;
using DotNet.Business.Security.Entities;

namespace DotNet.Presenter.Admin
{
    /// <summary>
    /// 用户管理库
    /// </summary>
    public class UserManagePresenter
    {
        private UserRepository _repository;
        private UserManageIView _view;
        public UserManagePresenter(UserManageIView view)
        {
            _view = view;
            _repository = Ioc.Resolve<UserRepository>();
        }

        public void GetAllList()
        {
            int i = 0;
            _view.List = _repository.GetQueryList(_view.Filter,_view.StartIndex, _view.MaxRows, out i);
            _view.Count = i;
        }
        public bool Delete()
        {
            return _repository.Delete(_view.Fguids);
        }
    }
}
