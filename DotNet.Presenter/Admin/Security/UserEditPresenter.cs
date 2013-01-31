using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Repositories;
using DotNet.Common;

namespace DotNet.Presenter.Admin
{
    public class UserEditPresenter
    {
        private UserRepository _repository;
        private UserEditIView _view;
        public UserEditPresenter(UserEditIView view)
        {
            _view = view;
            _repository = Ioc.Resolve<UserRepository>();
        }

        public bool SaveOrUpdate()
        {
            Business.Security.Entities.Base_User data = _view.Data;
            data.Password = Encryption.EncryptMD5(data.Password);
            return _repository.SaveOrUpdate(data);
        }

        public void DataView()
        {
            _view.Data = _repository.GetObjectById<DotNet.Business.Security.Entities.Base_User>(_view.Fguid);
        }
    }
}
