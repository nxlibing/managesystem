using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Repositories;
using DotNet.Common;

namespace DotNet.Presenter.Admin
{
    public class RoleEditPresenter
    {
        private RoleRepository _repository;
        private RoleEditIView _view;
        public RoleEditPresenter(RoleEditIView view)
        {
            _view = view;
            _repository = Ioc.Resolve<RoleRepository>();
        }

        public bool SaveOrUpdate()
        {
            return _repository.SaveOrUpdate(_view.Data);
        }

        public void DataView()
        {
            _view.Data = _repository.GetObjectById<DotNet.Business.Security.Entities.Base_Role>(_view.Fguid);
        }
    }
}
