using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Dictionary.Repositories;

namespace DotNet.Presenter.Admin.Dictionary
{
    public class DictionaryListPresenter
    {
        private DictionaryListIView _view;
        private Base_ItemRepository _repository;
        public DictionaryListPresenter(DictionaryListIView view)
        {
            _view = view;
            _repository = DotNet.Common.Ioc.Resolve<Base_ItemRepository>();
        }

        public void GetCategoryList()
        {
            _view.CategoryList = _repository.GetCategorieList();
        }


        public void SaveOrUpdate()
        {
            DotNet.Business.Dictionary.Entities.Base_Item data = _view.Data;
            DotNet.Business.Dictionary.Entities.Base_Item olddata = _repository.GetObjectById<DotNet.Business.Dictionary.Entities.Base_Item>(data.Fguid);
            if (olddata != null)
            {
                olddata.Name = data.Name;
                olddata.Code = data.Code;
            }
            else
            {
                olddata = data;
            }
            _repository.SaveOrUpdate(olddata);
        }

        public void Delete()
        {
            DotNet.Business.Dictionary.Entities.Base_Item data = _view.Data;
            DotNet.Business.Dictionary.Entities.Base_Item olddata = _repository.GetObjectById<DotNet.Business.Dictionary.Entities.Base_Item>(data.Fguid);
            _repository.Delete(olddata);
        }

    }
}
