using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Repositories;
using DotNet.Common;
using DotNet.Core;

namespace DotNet.Presenter.Admin.Security
{
    public class UserRolePresenter
    {
        private UserManage _repository;
        private UserRoleIView _view;
        public UserRolePresenter(UserRoleIView view)
        {
            _view = view;
            _repository = Ioc.Resolve<UserManage>();
        }

        public void GetRoleList()
        {
            _view.RoleList = _repository.GetEnableRoleList();
        }

        public bool Save()
        {
            try
            {
                IUnitOfWork unitOfWork = Ioc.Resolve<IUnitOfWork>();
                _repository.DeleteUserRoles(_view.Userid, unitOfWork);
                // _repository.Delete(
                _repository.Save<Business.Security.Entities.Base_UserRole>(_view.UserRoleList, unitOfWork);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                DotNet.Common.Log.Error("用户角色数据保存时：", e);
                return false;
            };
        }

        public void Init()
        {
            GetRoleList();
            _view.UserRoleList = _repository.GetUserRoleListByUserid(_view.Userid);
        }
    }
}
