using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Repositories;

namespace DotNet.Presenter.Admin.Security
{
    public class ModuleEditPresenter
    {
        private ModuleRepository _repository;
        private ModuleEditIView _view;
        public ModuleEditPresenter(ModuleEditIView view)
        {
            _view = view;
            _repository = DotNet.Common.Ioc.Resolve<ModuleRepository>();
        }

        public bool SaveOrUpdate()
        {
            return _repository.SaveOrUpdate(_view.Data);
        }

        public void DataView()
        {
            _view.Data = _repository.GetObjectById<DotNet.Business.Security.Entities.Base_Module>(_view.Fguid);
        }

        public void Init()
        {
            _view.List = _repository.GetAll<DotNet.Business.Security.Entities.Base_Module>();
        }
    }
}
