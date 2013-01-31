using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Repositories;
using DotNet.Common;

namespace DotNet.Presenter.Admin
{
    public class RoleManagePresenter
    {
        private RoleRepository _repository;
        private RoleManageIView _view;
        public RoleManagePresenter(RoleManageIView view)
        {
            _view = view;
            _repository = Ioc.Resolve<RoleRepository>();
        }

        public void GetAllList()
        {
            int i = 0;
            _view.List = _repository.GetQueryList(_view.Filter, _view.StartIndex, _view.MaxRows, out i);
            _view.Count = i;
        }

        public int Delete()
        {
            return _repository.Delete(_view.Fguids);
        }


    }
}
