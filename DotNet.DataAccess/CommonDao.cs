using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using DotNet.Common;
using Microsoft.Practices.Unity;
using DotNet.Facilities.NHibernateIntegration;
using DotNet.Entitity;
using System.Reflection;
using DotNet.Core.Query;
using DotNet.Core;

namespace DotNet.DataAccess
{
    public class CommonDao : ICommonDao
    {
        private readonly ISessionManager _sessionManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sessionManager"></param>
        [Microsoft.Practices.Unity.InjectionConstructor]
        public CommonDao(ISessionManager sessionManager)
        {
            this._sessionManager = sessionManager;
        }

        #region ICommonDao Members

        /// <summary>
        /// NH Session管理器
        /// </summary>
        public ISessionManager SessionManager { get { return this._sessionManager; } }

        public object GetObjectById(Type type, String id)
        {
            ISession session = this._sessionManager.OpenSession();
            return session.Load(type, id);
        }

        public object GetObjectById(Type type, String id, bool allowNull)
        {
            if (!allowNull)
            {
                return GetObjectById(type, id);
            }
            else
            {
                ISession session = this._sessionManager.OpenSession();
                return session.Get(type, id);
            }
        }

        public T GetObjectById<T>(String id)
        {
            ISession session = this._sessionManager.OpenSession();
            return session.Get<T>(id);
        }

        /// <summary>
        /// 根据指定的queryData里的属性以与的方式组合，从数据库查找数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>        
        /// <param name="queryData">数据条件</param>
        /// <param name="mathType">字符类型匹配方式，默认为全匹配</param>
        /// <returns>以与的方式组合查询的结果</returns>
        /// <remarks>字符类型以Like方式查找</remarks>
        public IList<T> CompositeList<T>(BusinesBase queryData, CriteriaOperator mathType = CriteriaOperator.Full) where T : BusinesBase
        {
            ISession session = this._sessionManager.OpenSession();

            Type targetType = queryData.GetType();
            IQuery query = CreateCompositeQuery(queryData, mathType);


            //如果hql语句没有构建，则认为是取所有数据
            if (null == query)
            {
                return GetAll<T>();
            }

            return query.List<T>();
        }

        /// <summary>
        /// 创建指定类型的带参数hql语句
        /// </summary>
        /// <param name="queryData"></param>
        /// <param name="mathType">字符类型匹配方式，默认为全匹配</param>
        /// <returns></returns>
        private IQuery CreateCompositeQuery(BusinesBase queryData, CriteriaOperator mathType)
        {
            Type targetType = queryData.GetType();
            String hql = "";
            PropertyInfo[] properties = targetType.GetProperties();
            IList<object[]> queryValues = new List<object[]>();
            ISessionFactory sessionFactory = this._sessionManager.SessionFactory;
            NHibernate.Metadata.IClassMetadata classMeta = sessionFactory.GetClassMetadata(queryData.GetType());
            for (int i = 0; i < properties.Length; ++i)
            {
                PropertyInfo propInfo = properties[i];
                if (!propInfo.Name.Equals(classMeta.IdentifierPropertyName, StringComparison.InvariantCultureIgnoreCase) &&
                    !classMeta.PropertyNames.Contains(propInfo.Name))
                {
                    continue;
                }

                object v = propInfo.GetValue(queryData, null);
                if (null == v)
                {
                    continue;
                }

                if (propInfo.PropertyType.IsAssignableFrom(typeof(String)) && !String.IsNullOrEmpty(v.ToString()))
                {
                    switch (mathType)
                    {
                        case CriteriaOperator.Equal:
                            hql = hql + String.Format("{0} = ? AND ", propInfo.Name);
                            break;

                        default:
                            hql = hql + String.Format("{0} LIKE ? AND ", propInfo.Name);
                            break;
                    }

                    queryValues.Add(new object[] { propInfo, v });
                }
                else if (propInfo.PropertyType.IsAssignableFrom(typeof(double?)))
                {
                    hql = hql + String.Format("{0} = ? AND ", propInfo.Name);
                    queryValues.Add(new object[] { propInfo, v });
                }
                else if (propInfo.PropertyType.IsAssignableFrom(typeof(DateTime?)))
                {
                    hql = hql + String.Format("{0} = ? AND ", propInfo.Name);
                    queryValues.Add(new object[] { propInfo, v });
                }
                else if (propInfo.PropertyType.IsAssignableFrom(typeof(BusinesBase)))
                {
                    hql = hql + String.Format("{0} = ? AND ", propInfo.Name);
                    queryValues.Add(new object[] { propInfo, v });
                }
            }

            if (!String.IsNullOrEmpty(hql))
            {
                hql = hql.Remove(hql.Length - 4, 4);
                hql = String.Format("FROM {0} WHERE {1}", targetType.Name, hql);

                IQuery query = this._sessionManager.OpenSession().CreateQuery(hql);
                for (int i = 0; i < queryValues.Count; ++i)
                {
                    object[] value = queryValues[i];
                    if (((PropertyInfo)value[0]).PropertyType.IsAssignableFrom(typeof(String)))
                    {
                        string mathValue = "";
                        switch (mathType)
                        {
                            case CriteriaOperator.Full:
                                mathValue = String.Format("%{0}%", value[1].ToString());
                                break;

                            case CriteriaOperator.StratWith:
                                mathValue = String.Format("{0}%", value[1].ToString());
                                break;

                            case CriteriaOperator.EndWith:
                                mathValue = String.Format("%{0}", value[1].ToString());
                                break;

                            case CriteriaOperator.Equal:
                                mathValue = value[1].ToString();
                                break;

                        }
                        query.SetString(i, mathValue);
                    }
                    else if (((PropertyInfo)value[0]).PropertyType.IsAssignableFrom(typeof(double?)))
                    {
                        query.SetDouble(i, double.Parse(value[1].ToString()));
                    }
                    else if (((PropertyInfo)value[0]).PropertyType.IsAssignableFrom(typeof(DateTime?)))
                    {
                        query.SetDateTime(i, DateTime.Parse(value[1].ToString()));
                    }
                    else if (((PropertyInfo)value[0]).PropertyType.IsAssignableFrom(typeof(BusinesBase)))
                    {
                        query.SetEntity(i, value[1]);
                    }
                }

                return query;
            }

            return null;
        }

        private String GenerateCompositeHql(BusinesBase queryData)
        {

            Type targetType = queryData.GetType();

            String hql = "";
            foreach (var propInfo in targetType.GetProperties())
            {
                object v = propInfo.GetValue(queryData, null);
                if (null == v)
                {
                    continue;
                }

                if (propInfo.PropertyType.IsAssignableFrom(typeof(String)) && !String.IsNullOrEmpty(v.ToString()))
                {
                    hql = hql + String.Format("{0} LIKE '%{1}%' AND ", propInfo.Name, v.ToString());
                }
                else if (propInfo.PropertyType.IsAssignableFrom(typeof(double?)))
                {
                    hql = hql + String.Format("{0} = {1} AND ", propInfo.Name, v.ToString());
                }
            }

            if (!String.IsNullOrEmpty(hql))
            {
                hql = hql.Remove(hql.Length - 4, 4);
                hql = String.Format("FROM {0} WHERE {1}", targetType.Name, hql);
            }
            return hql;
        }

        public object GetObjectByProperty(Type type, string propertyName, object value)
        {
            ISession session = this._sessionManager.OpenSession();
            ICriteria crit = session.CreateCriteria(type);
            crit.Add(Expression.Eq(propertyName, value));
            return crit.UniqueResult();
        }

        public T GetObjectByProperty<T>(string propertyName, object value)
        {
            return (T)GetObjectByProperty(typeof(T), propertyName, value);
        }

        public IList GetAll(Type type)
        {
            return GetAll(type, OrderType.None, null);
        }

        public IList GetAll(Type type, OrderType orderType = OrderType.Asc, params string[] sortProperties)
        {
            ISession session = this._sessionManager.OpenSession();

            ICriteria crit = session.CreateCriteria(type);
            if (sortProperties != null)
            {
                foreach (string sortProperty in sortProperties)
                {
                    crit.AddOrder(Order.Asc(sortProperty));
                }
            }
            return crit.List();
        }

        /// <summary>
        /// 获取指定类型的所有对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>指定类型的所有数据库数据对象</returns>
        public IList<T> GetAll<T>()
        {
            return GetAll<T>(OrderType.None, null);
        }

        /// <summary>
        /// 获取指定类型的所有数据，并根据指定的属性排序.
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sortProperties">排序属性（字段）</param>
        /// <returns></returns>
        public IList<T> GetAll<T>(OrderType orderType = OrderType.Asc, params string[] sortProperties)
        {
            ISession session = this._sessionManager.OpenSession();

            ICriteria crit = session.CreateCriteria(typeof(T));
            if (sortProperties != null)
            {
                foreach (string sortProperty in sortProperties)
                {
                    if (orderType == OrderType.Asc)
                    {
                        crit.AddOrder(Order.Asc(sortProperty));
                    }
                    else
                    {
                        crit.AddOrder(Order.Desc(sortProperty));
                    }
                }
            }
            return crit.List<T>();
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
            ISession session = this._sessionManager.OpenSession();
            ICriteria crit = criteria.GetExecutableCriteria(session);
            return crit.List<T>();
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
            ISession session = this._sessionManager.OpenSession();
            ICriteria crit = criteria.GetExecutableCriteria(session);
            crit.SetFirstResult(start);
            crit.SetMaxResults(pageSize);
            IList<T> list = crit.List<T>();
            return list;
        }

        /// <summary>
        /// 获取指定fguid的所有对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="ids">fguid数组</param>
        /// <returns></returns>
        public IList<T> GetByIds<T>(String[] ids)
        {
            ISession session = this._sessionManager.OpenSession();
            ICriteria crit = session.CreateCriteria(typeof(T))
                .Add(Expression.In("Fguid", ids));
            return crit.List<T>();
        }

        /// <summary>
        /// 通过带参的hql查询数据
        /// </summary>
        /// <param name="hql">hql查询语句</param>
        /// <param name="values">值</param>
        /// <returns>符合查询条件的查询结果</returns>
        public IList GetByHql(String hql, object[] values)
        {
            IQuery query = CreateHqlQuery(hql, values);

            return query.List();
        }

        /// <summary>
        /// 根据hql创建IQuery
        /// </summary>
        /// <param name="hql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private IQuery CreateHqlQuery(String hql, object[] values)
        {
            ISession session = this._sessionManager.OpenSession();

            IQuery query = session.CreateQuery(hql);

            for (int i = 0; i < values.Length; ++i)
            {
                if (null == values[i])
                {
                    throw new Exception("查询参数不允许为null");
                }

                Type valueType = values[i].GetType();
                if (valueType.IsAssignableFrom(typeof(String)))
                {
                    query.SetString(i, values[i].ToString());
                }
                else if (valueType.IsAssignableFrom(typeof(double?)) ||
                    valueType.IsAssignableFrom(typeof(double)) ||
                    valueType.IsAssignableFrom(typeof(int)) ||
                    valueType.IsAssignableFrom(typeof(float)) ||
                    valueType.IsAssignableFrom(typeof(long)))
                {
                    query.SetDouble(i, double.Parse(values[i].ToString()));
                }
                else if (valueType.IsAssignableFrom(typeof(DateTime?)) ||
                    valueType.IsAssignableFrom(typeof(DateTime)))
                {
                    query.SetDateTime(i, DateTime.Parse(values[i].ToString()));
                }
            }

            return query;
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
            IQuery query = CreateHqlQuery(hql, values);

            query.SetFirstResult(start);
            query.SetMaxResults(pageSize);

            return query.List();
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
            IQuery query = CreateHqlQuery(hql, values);

            return query.UniqueResult<T>();
        }

        /// <summary>
        /// 通过Criteria查询数据(查询唯一值)
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="criteria">查询条件</param>
        /// <returns></returns>
        public T GetUniqueResult<T>(DetachedCriteria criteria)
        {
            ISession session = this._sessionManager.OpenSession();
            ICriteria crit = criteria.GetExecutableCriteria(session);

            return crit.UniqueResult<T>();
        }

        /// <summary>
        /// 保存或者更新数据库对象
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <param name="unitOfWork">工作单元</param>
        public virtual void SaveOrUpdate(object obj, IUnitOfWork unitOfWork = null)
        {
            if (null == unitOfWork)
            {
                ISession session = this._sessionManager.OpenSession();
                ITransaction trans = session.BeginTransaction();
                try
                {
                    session.SaveOrUpdate(obj);

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            else
            {
                unitOfWork.SaveOrUpdate(obj);
            }
        }

        /// <summary>
        /// 显式保存
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="unitOfWork">工作单元</param>
        public virtual void Save(object obj, IUnitOfWork unitOfWork = null)
        {
            if (null == unitOfWork)
            {
                ISession session = this._sessionManager.OpenSession();
                ITransaction trans = session.BeginTransaction();
                try
                {
                    session.Save(obj);

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            else
            {
                unitOfWork.Save(obj);
            }
        }

        /// <summary>
        /// 显示更新
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <param name="unitOfWork">工作单元</param>
        public virtual void Update(object obj, IUnitOfWork unitOfWork = null)
        {
            if (null == unitOfWork)
            {
                ISession session = this._sessionManager.OpenSession();
                ITransaction trans = session.BeginTransaction();
                try
                {
                    session.Update(obj);

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            else
            {
                unitOfWork.Update(obj);
            }
        }

       
        /// <summary>
        /// 从数据删除指定的对象
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <param name="unitOfWork">工作单元</param>
        public virtual void Delete(object obj, IUnitOfWork unitOfWork = null)
        {
            if (null == unitOfWork)
            {
                ISession session = this._sessionManager.OpenSession();
                ITransaction trans = session.BeginTransaction();
                try
                {
                    session.Delete(obj);

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            else
            {
                unitOfWork.Delete(obj);
            }
        }

        /// <summary>
        /// 通过id删除数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="id">主键</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <returns>删除的记录条数</returns>
        public virtual int Delete<T>(String id, IUnitOfWork unitOfWork = null)
        {
            if (null == unitOfWork)
            {
                ISession session = this._sessionManager.OpenSession();

                ITransaction trans = session.BeginTransaction();
                try
                {
                    String hql = String.Format("FROM {0} WHERE Fguid = ?", typeof(T).Name);
                    int r = session.Delete(hql, id, NHibernateUtil.String);
                    trans.Commit();
                    return r;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            else
            {
                int ret = unitOfWork.Delete<T>(id);
                return ret;
            }
        }

        /// <summary>
        /// 根据指定的查询删除指定的数据(适合于游离对象)
        /// </summary>        
        /// <param name="query">查询字符串</param>
        /// <param name="values">值</param>
        /// <param name="types">值的Nhibernate类型</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <returns>返回删除的数目</returns>
        public int Delete(String query, object[] values, NHibernate.Type.IType[] types, IUnitOfWork unitOfWork = null)
        {
            if (null == unitOfWork)
            {
                ISession session = this._sessionManager.OpenSession();

                ITransaction trans = session.BeginTransaction();
                try
                {
                    int r = session.Delete(query, values, types);
                    trans.Commit();
                    return r;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            else
            {
                int ret = unitOfWork.Delete(query, values, types);
                return ret;
            }
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
            if (null == unitOfWork)
            {
                ISession session = this._sessionManager.OpenSession();

                ITransaction trans = session.BeginTransaction();

                try
                {
                    int r = 0;
                    foreach (BusinesBase data in deleteDatas)
                    {
                        String hql = String.Format("FROM {0} WHERE Fguid = ?", typeof(T).Name);
                        r = r + session.Delete(hql, data.Fguid, NHibernateUtil.String);
                    }
                    trans.Commit();
                    return r;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            else
            {
                try
                {
                    int r = 0;
                    foreach (BusinesBase data in deleteDatas)
                    {
                        String hql = String.Format("FROM {0} WHERE Fguid = ?", typeof(T).Name);
                        r = r + unitOfWork.Delete(hql, new object[] { data.Fguid }, new NHibernate.Type.IType[] { NHibernateUtil.String });
                    }

                    return r;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 删除指定的数据集(根据数据的主键集合)
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="fguids">需要删除的数据主键集合</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <returns>删除的数据条数</returns>
        public int Delete<T>(string[] fguids, IUnitOfWork unitOfWork = null) where T : BusinesBase
        {
            if (null == unitOfWork)
            {
                ISession session = this._sessionManager.OpenSession();

                ITransaction trans = session.BeginTransaction();

                try
                {
                    int r = 0;
                    foreach (string fguid in fguids)
                    {
                        String hql = String.Format("FROM {0} WHERE Fguid = ?", typeof(T).Name);
                        r = r + session.Delete(hql, fguid, NHibernateUtil.String);
                    }
                    trans.Commit();
                    return r;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            else
            {
                try
                {
                    int r = 0;
                    foreach (string fguid in fguids)
                    {
                        String hql = String.Format("FROM {0} WHERE Fguid = ?", typeof(T).Name);
                        r = r + unitOfWork.Delete(hql, new object[] { fguid }, new NHibernate.Type.IType[] { NHibernateUtil.String });
                    }

                    return r;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void RemoveCollectionFromCache(string roleName)
        {
            ISession session = this._sessionManager.OpenSession();
            session.SessionFactory.EvictCollection(roleName);
        }

        public void RemoveCollectionFromCache(string roleName, String id)
        {
            ISession session = this._sessionManager.OpenSession();
            session.SessionFactory.EvictCollection(roleName, id);
        }

        public void RemoveQueryFromCache(string cacheRegion)
        {
            ISession session = this._sessionManager.OpenSession();
            session.SessionFactory.EvictQueries(cacheRegion);
        }

        public void Flush()
        {
            ISession session = this._sessionManager.OpenSession();
            session.Flush();
        }

        public void Clear()
        {
            ISession session = this._sessionManager.OpenSession();
            session.Clear();
        }

        public void Refresh(object obj)
        {
            ISession session = this._sessionManager.OpenSession();
            session.Refresh(obj);
        }

        /// <summary>
        /// 从nh session缓存中移除指定对象
        /// </summary>
        /// <param name="obj">nh session中移除的对象</param>
        public void Evict(object obj)
        {
            ISession session = this._sessionManager.OpenSession();
            session.Evict(obj);
        }

        #endregion
    }
}
