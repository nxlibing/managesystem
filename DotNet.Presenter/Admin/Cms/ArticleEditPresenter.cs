using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Cms.Repositories;

namespace DotNet.Presenter.Admin.Cms
{
    public class ArticleEditPresenter
    {
        private ArticleEditIView _view;
        private ArticleRepository _repository;
        public ArticleEditPresenter(ArticleEditIView view)
        {
            _view = view;
            _repository = DotNet.Common.Ioc.Resolve<ArticleRepository>();
        }

        public bool SaveOrUpdate()
        {
            return _repository.SaveOrUpdate(_view.Data);
        }

        public void Init()
        {
            _view.CategoryList = _repository.GetCategoryList();
        }

        public void View()
        {
            _view.Data = _repository.GetObjectById<Business.Cms.Entities.Cms_Article>("");
        }
    }
}
