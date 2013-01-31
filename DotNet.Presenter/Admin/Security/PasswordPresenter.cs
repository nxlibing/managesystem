using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Repositories;

namespace DotNet.Presenter.Admin.Security
{
    public class PasswordPresenter
    {
        private PasswordIView _view;
        private Business.Security.Repositories.UserManage _repository;
        public PasswordPresenter(PasswordIView view)
        {
            _view = view;
            _repository = Common.Ioc.Resolve<UserManage>();
        }

        public bool ChangePassword()
        {
            try
            {
                Core.IUnitOfWork unitorwork = Common.Ioc.Resolve<Core.IUnitOfWork>();
                IList<Business.Security.Entities.Base_User> list = _view.List;
                foreach (var item in list)
                {
                    Business.Security.Entities.Base_User data = _repository.GetObjectById<Business.Security.Entities.Base_User>(item.Fguid);
                    data.Password = Common.Encryption.EncryptMD5(item.Password);
                    _repository.Update<Business.Security.Entities.Base_User>(data, unitorwork);
                }
                unitorwork.Commit();
                return true;
            }
            catch (Exception e)
            {
                Common.Log.Error("修改密码时", e);
                return false;
            }
        }
    }
}
