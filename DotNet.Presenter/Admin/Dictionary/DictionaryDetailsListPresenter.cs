using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Dictionary.Entities;
using DotNet.Business.Dictionary.Repositories;

namespace DotNet.Presenter.Admin.Dictionary
{
    public class DictionaryDetailsListPresenter
    {
        private DictionaryDetailsListIView _view;
        private Base_ItemRepository _repository;
        public DictionaryDetailsListPresenter(DictionaryDetailsListIView view)
        {
            _view = view;
            _repository = DotNet.Common.Ioc.Resolve<Base_ItemRepository>();
        }

        public void Init()
        {
            _view.CategoryList = _repository.GetCategorieList();
        }

        public void GetDictionaryDetailsList()
        {
            // _view.DetailsList=_repository.GET
        }

        public void ItemDetailEnable()
        {
            Base_ItemDetails data = _repository.GetObjectById<Base_ItemDetails>(_view.Data.Fguid);
            data.Status = "1";
            _repository.Update<Base_ItemDetails>(data);
        }

        public void Delete()
        {
            Base_ItemDetails data = _repository.GetObjectById<Base_ItemDetails>(_view.Data.Fguid);
            _repository.Delete(data);
        }



        public void SaveOrUpdate()
        {
            Base_ItemDetails d = _view.Data;
            Base_ItemDetails data = _repository.GetObjectById<Base_ItemDetails>(d.Fguid);
            if (data != null)
            {
                data.Name = d.Name;
                data.Code = d.Code;
            }
            else
            {
                data = d;
                data.Status = "0";
            }
            _repository.SaveOrUpdate(data);
        }
    }
}
