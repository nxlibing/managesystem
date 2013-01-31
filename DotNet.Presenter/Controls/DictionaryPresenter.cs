using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Dictionary.Repositories;
using DotNet.Business.Dictionary.Entities;

namespace DotNet.Presenter.Controls
{
    public class DictionaryPresenter
    {
        private IDictionaryView _view;
        private Base_ItemRepository _repository;
        public DictionaryPresenter(IDictionaryView view)
        {
            _view = view;
            _repository = DotNet.Common.Ioc.Resolve<Base_ItemRepository>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="categoryCodes">字典种类</param>
        public void InitView(String[] categoryCodes)
        {
            IList<Base_Item> list = _repository.GetCategories(categoryCodes);
            List<Base_ItemDetails> datas = new List<Base_ItemDetails>();
            foreach (Base_Item data in list)
            {
                foreach (Base_ItemDetails item in data.ItemDetailsList)
                {
                    datas.Add(item);
                }
            }
            IList<Base_ItemDetails> orderdeDatas = datas.OrderBy(d => d.Code).ToList();
            this._view.DataItems = orderdeDatas;
        }
    }
}
