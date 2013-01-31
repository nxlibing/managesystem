using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Cms.Repositories;

namespace DotNet.Presenter.Admin.Cms
{
    public class ArticleListPresenter
    {
        private ArticleRepository _repository;
        private ArticleListIView _view;
        public ArticleListPresenter(ArticleListIView view)
        {
            _view = view;
            _repository = DotNet.Common.Ioc.Resolve<ArticleRepository>();
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
