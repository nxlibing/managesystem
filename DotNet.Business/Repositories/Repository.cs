using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using DotNet.DataAccess;
using NHibernate.Criterion;
using DotNet.Entitity;
using System.Collections;
using DotNet.Core.Query;
using DotNet.Core;

namespace DotNet.Business.Repositories
{
    /// <summary>
    /// 存储库基类
    /// </summary>
    public class Repository
    {
        private ICommonDao _commonDao;

        protected ICommonDao CommonDao
        {
            get { return this._commonDao; }
        }

        [InjectionConstructor]
        public Repository(ICommonDao commonDao)
        {
            this._commonDao = commonDao;
        }

        /// <summary>
        /// 根据指定的类型和主键从数据库获取一个实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>请求的对象，或者为null</returns>
        public T GetObjectById<T>(String id)
        {
            return this._commonDao.GetObjectById<T>(id);
        }

        /// <summary>
        /// 获取指定类型的所有对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>指定类型的所有数据库数据对象</returns>
        public IList<T> GetAll<T>()
        {
            return this._commonDao.GetAll<T>();
        }

        /// <summary>
        /// 获取指定类型的所有数据，并根据指定的属性排序(ascending).
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sortProperties">排序属性（字段）</param>
        /// <returns></returns>
        public IList<T> GetAll<T>(OrderType orderType = OrderType.Asc, params string[] sortProperties)
        {
            return this._commonDao.GetAll<T>(orderType, sortProperties);
        }

        /// <summary>
        /// 获取和所有criteria匹配的对象.
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="criteria">NHibernate DetachedCriteria 对象.</param>
        /// <returns>所有criteria匹配的对象</returns>
        /// <remarks>
        /// 不要在UI层使用，这样会导致UI层和Nhibernate关联绑定
        /// </remarks>
        public IList<T> GetAlDotNetyCriteria<T>(DetachedCriteria criteria)
        {
            return this._commonDao.GetAlDotNetyCriteria<T>(criteria);
        }

        /// <summary>
        /// 获取和所有criteria匹配的对象.
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="criteria">NHibernate DetachedCriteria 对象.</param>
        /// <param name="start">起始位置</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns>所有criteria匹配的对象</returns>
        /// <remarks>
        /// 不要在UI层使用，这样会导致UI层和Nhibernate关联绑定
        /// </remarks>
        public IList<T> GetAlDotNetyCriteria<T>(DetachedCriteria criteria, int start, int pageSize)
        {
            return this._commonDao.GetAlDotNetyCriteria<T>(criteria, start, pageSize);
        }

        /// <summary>
        /// 根据指定的queryData里的属性以与的方式组合，从数据库查找数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>        
        /// <param name="queryData">数据条件</param>
        /// <param name="mathType">字符类型匹配方式，默认为全匹配</param>
        /// <returns>以与的方式组合查询的结果</returns>
        /// <remarks>字符类型以指定的方式查找</remarks>
        public IList<T> CompositeList<T>(BusinesBase queryData, CriteriaOperator criteriaOperator = CriteriaOperator.Full) where T : BusinesBase
        {
            return this._commonDao.CompositeList<T>(queryData, criteriaOperator);
        }

        /// <summary>
        /// 通过带参的hql查询数据
        /// </summary>
        /// <param name="hql">hql查询语句</param>
        /// <param name="values">值</param>
        /// <returns>符合查询条件的查询结果</returns>
        /// <remarks>valuses值的顺序必须和hql里的参数一一对应</remarks>
        public IList GetByHql(String hql, object[] values)
        {
            return this._commonDao.GetByHql(hql, values);
        }

        /// <summary>
        /// 通过带参的hql查询数据
        /// </summary>
        /// <param name="hql">hql查询语句</param>
        /// <param name="values">值</param>
        /// <param name="start">起始位置</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns>符合查询条件的查询结果</returns>
        /// <remarks>valuses值的顺序必须和hql里的参数一一对应</remarks>
        public IList GetByHql(String hql, object[] values, int start, int pageSize)
        {
            return this._commonDao.GetByHql(hql, values, start, pageSize);
        }

        /// <summary>
        /// 通过带参的hql查询数据(查询唯一值)
        /// </summary>
        /// <param name="hql">hql查询语句</param>
        /// <param name="values">值</param>
        /// <returns>符合查询条件的查询结果</returns>
        /// <remarks>valuses值的顺序必须和hql里的参数一一对应</remarks>
        public T GetUniqueResult<T>(String hql, object[] values)
        {
            return this._commonDao.GetUniqueResult<T>(hql, values);
        }


        /// <summary>
        /// 通过Criteria查询数据(查询唯一值)
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="criteria">查询条件</param>
        /// <returns></returns>
        public T GetUniquResult<T>(DetachedCriteria criteria)
        {
            return this._commonDao.GetUniqueResult<T>(criteria);
        }

        public T GetObjectByProperty<T>(string propertyName, object value)
        {
            return this._commonDao.GetObjectByProperty<T>(propertyName, value);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="data"></param>
        public void Save<T>(T data, IUnitOfWork unitOfWork = null)
        {
            this._commonDao.Save(data, unitOfWork);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="data"></param>
        public void Save<T>(IList<T> datas, IUnitOfWork unitOfWork = null)
        {
            foreach (T data in datas)
            {
                this._commonDao.Save(data, unitOfWork);
            }
        }

        /// <summary>
        /// 保存或者更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="data"></param>
        public void SaveOrUpdate<T>(IList<T> datas, IUnitOfWork unitOfWork = null)
        {
            foreach (T data in datas)
            {
                this._commonDao.SaveOrUpdate(data, unitOfWork);
            }
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="data"></param>
        public void Update<T>(T data, IUnitOfWork unitOfWork = null)
        {
            this._commonDao.Update(data, unitOfWork);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lists"></param>
        /// <param name="unitOfWork"></param>
        public virtual void Update<T>(IList<T> lists, IUnitOfWork unitOfWork = null)
        {
            foreach (T data in lists)
            {
                this._commonDao.Update(data, unitOfWork);
            }
        }
        /// <summary>
        /// 删除指定的实体数据
        /// </summary>
        /// <param name="data">实体对象</param>
        /// <param name="unitOfWork">工作单元</param>
        public void Delete(object data, IUnitOfWork unitOfWork = null)
        {
            this._commonDao.Delete(data, unitOfWork);
        }

        /// <summary>
        /// 根据指定的id删除数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="id">主键</param>
        /// <returns>删除的记录数据</returns>
        public int DeleteById<T>(String id, IUnitOfWork unitOfWork = null)
        {
            return this._commonDao.Delete<T>(id, unitOfWork);
        }

        /// <summary>
        /// 删除指定的数据(根据数据的主键)
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="deleteDatas">需要删除的数据</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <returns>删除的数据条数</returns>  
        public int Delete(String query, object[] values, NHibernate.Type.IType[] types, IUnitOfWork unitOfWork = null)
        {
            return this._commonDao.Delete(query, values, types, unitOfWork);
        }

        /// <summary>
        /// 删除指定的数据(根据数据的主键)
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="deleteDatas">需要删除的数据</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <returns>删除的数据条数</returns>        
        public int Delete<T>(IList<T> deleteDatas, IUnitOfWork unitOfWork = null) where T : BusinesBase
        {
            return this._commonDao.Delete<T>(deleteDatas, unitOfWork);
        }

        // add by yuz 2011-03-08
        /// <summary>
        /// 从Session缓存中移除指定对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="data">对象实例</param>
        public void Evict<T>(T data)
        {
            this._commonDao.Evict(data);
        }
    }
}
