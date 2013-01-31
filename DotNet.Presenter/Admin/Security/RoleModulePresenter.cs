using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Repositories;
using DotNet.Common;
using DotNet.Business.Security.Entities;

namespace DotNet.Presenter.Admin.Security
{
    public class RoleModulePresenter
    {
        private UserManage _repository;
        private RoleModuleIView _view;
        public RoleModulePresenter(RoleModuleIView view)
        {
            _view = view;
            _repository = Ioc.Resolve<UserManage>();
        }

        public void Init()
        {
            //_view.RootModuleList = _repository.GetEnableRootModuleList();
            _view.ModuleList = _repository.GetEnableModuleList();
            _view.RoleList = _repository.GetEnableRoleList();
        }

        public void SetRoleModules()
        {
            _view.List = _repository.GetRoleModules(_view.Roleid);
        }

        public void SetModules()
        {
            _view.ModuleList = _repository.GetEnableModuleList();
        }

        public bool Save()
        {
            try
            {
                Core.IUnitOfWork unitOfWork = Ioc.Resolve<Core.IUnitOfWork>();
                IList<Base_RoleModule> list = new List<Base_RoleModule>();

                List<string> moduleList = _view.List;
                string roleid = _view.Roleid;
                Base_RoleModule data;
                foreach (var item in moduleList)
                {
                    data = new Base_RoleModule();
                    data.Moduleid = item;
                    data.Roleid = roleid;
                    list.Add(data);
                }
                _repository.DeleteRoleModules(roleid, unitOfWork);
                _repository.Save<Base_RoleModule>(list, unitOfWork);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                Log.Error("角色权限指派时：", e);
                return false;
            }
        }

        public void GetUserList()
        {
            IList<Base_User> list=_repository.GerUserListByRoleid(_view.Roleid);
            
            _view.UserList =list;
            _view.Count = list.Count;
        }
    }
}
