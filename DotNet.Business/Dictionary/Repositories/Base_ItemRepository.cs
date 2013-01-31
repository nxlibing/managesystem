using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Repositories;
using DotNet.DataAccess;
using DotNet.Business.Dictionary.Entities;
using NHibernate.Criterion;
using System.Collections;
using DotNet.Common;

namespace DotNet.Business.Dictionary.Repositories
{
    public class Base_ItemRepository : Repository
    {
        public Base_ItemRepository(ICommonDao commonDao)
            : base(commonDao)
        { }


        public IList<Base_Item> GetQueryList(int pageindex, int pagesize, out int count)
        {
            DetachedCriteria criteria = DetachedCriteria.For<Base_Item>();

            //criteria.Add(Expression.Like("Realname", "%" + filter + "%"));
            criteria.SetProjection(Projections.RowCount());
            count = this.GetUniquResult<int>(criteria);

            criteria.SetProjection(null);
            return this.GetAlDotNetyCriteria<Base_Item>(criteria, pageindex, pagesize);
        }


        /// <summary>
        /// 根据指定的分类编码获取分类数据
        /// </summary>
        /// <param name="categoryCodes">分类编码列表</param>
        /// <returns></returns>
        public IList<Base_Item> GetCategories(String[] categoryCodes)
        {
            DetachedCriteria cireterial = DetachedCriteria.For<Base_Item>();
            cireterial.Add(Restrictions.In("Code", categoryCodes));
            cireterial.AddOrder(Order.Asc("Code"));
            return CommonDao.GetAlDotNetyCriteria<Base_Item>(cireterial);
        }

        public IList<Base_Item> GetCategories(string categoryName)
        {
            string hql = string.Format("from Base_Item where Mc like '%{0}%' ORDER BY Dm", categoryName);
            IList list = CommonDao.GetByHql(hql, new object[] { });
            return list.OfType<Base_Item>().ToList<Base_Item>();
        }

        public IList<Base_Item> GetCategorieList()
        {
            DetachedCriteria cireterial = DetachedCriteria.For<Base_Item>();
            cireterial.AddOrder(Order.Asc("Code"));
            return CommonDao.GetAlDotNetyCriteria<Base_Item>(cireterial);
        }

        /// <summary>
        /// 数据保存更新
        /// </summary>
        /// <param name="data"></param>
        /// <param name="unitOfWork"></param>
        public bool SaveOrUpdate(Base_Item data, Core.IUnitOfWork unitOfWork = null)
        {
            try
            {
                CommonDao.SaveOrUpdate(data, unitOfWork);
                return true;
            }
            catch (Exception e)
            {
                Log.Error("字典类别删除时", e);
                return false;
            }
        }

        /// <summary>
        /// 数据保存更新
        /// </summary>
        /// <param name="data"></param>
        /// <param name="unitOfWork"></param>
        public bool SaveOrUpdate(Base_ItemDetails data, Core.IUnitOfWork unitOfWork = null)
        {
            try
            {
                CommonDao.SaveOrUpdate(data, unitOfWork);
                return true;
            }
            catch (Exception e)
            {
                Log.Error("字典详情类别删除时", e);
                return false;
            }
        }

        public bool Delete(Base_Item data)
        {
            try
            {
                CommonDao.Delete(data);
                return true;
            }
            catch (Exception e)
            {
                Log.Error("字典类别删除时", e);
                return false;
            }
        }

        /// <summary>
        /// 获取要添加数据的分类代码
        /// </summary>
        /// <returns></returns>
        public string GetCurrentDm()
        {
            string hql = "select max(Dm) from Jc_xxfDotNet";
            string r = "01";
            IList list = CommonDao.GetByHql(hql, new object[] { });
            if (list != null && list.Count > 0)
            {
                r = list[0].ToString();
                r = (int.Parse(r) + 1).ToString();
                if (r.Length == 1)
                {
                    r = "0" + r;
                }
            }
            return r;
        }
    }
}
