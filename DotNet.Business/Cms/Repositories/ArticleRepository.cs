using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Repositories;
using DotNet.DataAccess;
using DotNet.Business.Cms.Entities;
using DotNet.Common;
using NHibernate.Criterion;
using System.Collections;

namespace DotNet.Business.Cms.Repositories
{
    public class ArticleRepository : Repository
    {
        public ArticleRepository(ICommonDao commonDao)
            : base(commonDao)
        { }

        #region Article相关操作

        public bool SaveOrUpdate(Cms_Article data)
        {
            try
            {
                CommonDao.SaveOrUpdate(data);
                return true;
            }
            catch (Exception e)
            {
                Log.Error("用户数据编辑", e);
                return false;
            }
        }



        public IList<Cms_Article> GetQueryList(string filter, int pageindex, int pagesize, out int count)
        {
            DetachedCriteria criteria = DetachedCriteria.For<Cms_Article>();

            //criteria.Add(Expression.Like("Realname", "%" + filter + "%"));
            criteria.SetProjection(Projections.RowCount());
            count = this.GetUniquResult<int>(criteria);

            criteria.SetProjection(null);
            return this.GetAlDotNetyCriteria<Cms_Article>(criteria, pageindex, pagesize);
        }


        public int Delete(string[] fguids)
        {
            try
            {
                return CommonDao.Delete<Cms_Article>(fguids);
            }
            catch (Exception e)
            {
                Log.Error("用户数据删除时", e);
                return -1;
            }
        }
        #endregion


        #region Category相关操作
        public bool SaveOrUpdate(Cms_Category data)
        {
            try
            {
                if (string.IsNullOrEmpty(data.Categoryid))
                {
                    data.Categoryid = GenerateCategoryNo(data.Pguid);
                }
                CommonDao.SaveOrUpdate(data);
                return true;
            }
            catch (Exception e)
            {
                Log.Error("用户数据编辑", e);
                return false;
            }
        }

        public IList<Cms_Category> GetCategoryList()
        {
            return GetAll<Cms_Category>(Core.Query.OrderType.Asc, new string[] { "Categoryid" });
        }
        public IList<Cms_Category> GetCategoryQueryList(string filter, int pageindex, int pagesize, out int count)
        {
            DetachedCriteria criteria = DetachedCriteria.For<Cms_Category>();

            //criteria.Add(Expression.Like("Realname", "%" + filter + "%"));
            criteria.SetProjection(Projections.RowCount());
            count = this.GetUniquResult<int>(criteria);

            criteria.SetProjection(null);
            return this.GetAlDotNetyCriteria<Cms_Category>(criteria, pageindex, pagesize);
        }

        public string GenerateCategoryNo(string pguid)
        {
            string result = "";
            string maxno = GetMaxCategoryNo(pguid);
            if (string.IsNullOrEmpty(maxno))
            {
                Cms_Category data = GetObjectById<Cms_Category>(pguid);
                result = data.Categoryid + "01";
            }
            else
            {
                int newno = int.Parse(maxno) + 1;
                string newnostr = newno.ToString();
                if (newnostr.Length % 2 != 0)
                {
                    result = "0" + newnostr;
                }
                else
                {
                    result = newnostr;
                }
            }
            return result;
        }


        public int DeleteCategory(string[] fguids)
        {
            try
            {
                return CommonDao.Delete<Cms_Category>(fguids);
            }
            catch (Exception e)
            {
                Log.Error("内容栏目数据删除时", e);
                return -1;
            }
        }
        public string GetMaxCategoryNo(string pguid)
        {
            string hql = string.Format("SELECT max(Categoryid) as m FROM Cms_Category where Pguid='{0}'", pguid);
            IList list = CommonDao.GetByHql(hql, new object[] { });
            return list[0].ToString2();
        }
        #endregion
    }
}
