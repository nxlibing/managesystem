using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Criterion;
using NHibernate;
using DotNet.Entitity;
using DotNet.Core.Query;
using DotNet.Core;
using DotNet.Facilities.NHibernateIntegration;

namespace DotNet.DataAccess
{
    /// <summary>
    /// 通用数据访问接口
    /// </summary>
    public interface ICommonDao
    {
        /// <summary>
        /// NH Session管理器
        /// </summary>
        ISessionManager SessionManager { get; }

        /// <summary>
        /// 根据指定的类型和主键从数据库获取一个实例
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="id">主键</param>
        /// <returns>请求的对象，或者为null</returns>
        object GetObjectById(Type type, String id);

        /// <summary>
        /// 根据指定的类型和主键从数据库获取一个实例. 
        /// 可以指定当没找数据数据时候，是否可以返回null
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="id">主键</param>
        /// <param name="allowNull">受否可以返回null</param>
        /// <returns>请求的对象</returns>
        object GetObjectById(Type type, String id, bool allowNull);

        /// <summary>
        /// 根据指定的类型和主键从数据库获取一个实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>请求的对象，或者为null</returns>
        T GetObjectById<T>(String id);

        /// <summary>
        /// 根据指定的queryData里的属性以与的方式组合，从数据库查找数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>        
        /// <param name="queryData">数据条件</param>
        /// <param name="mathType">字符类型匹配方式，默认为全匹配</param>
        /// <returns>以与的方式组合查询的结果</returns>
        IList<T> CompositeList<T>(BusinesBase queryData, CriteriaOperator criteriaOperator = CriteriaOperator.Full) where T : BusinesBase;

        /// <summary>
        /// 根据指定的属性值获取从数据库获取指定类型的单个数据对象
        /// </summary>
        /// <param name="type">数据类型</param>
        /// <param name="propertyName">属性字段名称</param>
        /// <param name="description">属性值</param>
        /// <returns>请求的对象</returns>
        object GetObjectByProperty(Type type, string propertyName, object value);

        /// <summary>
        /// 根据指定的属性值获取从数据库获取指定类型的单个数据对象
        /// </summary>
        /// <typeparam name="T">数据类型</param>
        /// <param name="propertyName">属性字段名称</param>
        /// <param name="description">属性值</param>
        /// <returns>请求的对象</returns>
        T GetObjectByProperty<T>(string propertyName, object value);

        /// <summary>
        /// 获取指定类型的所有对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <returns>指定类型的所有数据库数据对象</returns>
        IList GetAll(Type type);

        /// <summary>
        /// 获取指定类型的所有对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>指定类型的所有数据库数据对象</returns>
        IList<T> GetAll<T>();

        /// <summary>
        /// 获取指定类型的所有数据，并根据指定的属性排序.
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="sortProperties">排序属性（字段）</param>
        /// <returns>根据指定属性排序后的所有数据</returns>
        IList GetAll(Type type, OrderType orderType = OrderType.Asc, params string[] sortProperties);

        /// <summary>
        /// 获取指定类型的所有数据，并根据指定的属性排序(ascending).
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sortProperties">排序属性（字段）</param>
        /// <returns></returns>
        IList<T> GetAll<T>(OrderType orderType = OrderType.Asc, params string[] sortProperties);

        /// <summary>
        /// 获取和所有criteria匹配的对象.
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="criteria">NHibernate DetachedCriteria 对象.</param>
        /// <returns>所有criteria匹配的对象</returns>
        /// <remarks>
        /// 不要在UI层使用，这样会导致UI层和Nhibernate关联绑定
        /// </remarks>
        IList<T> GetAlDotNetyCriteria<T>(DetachedCriteria criteria);

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
        IList<T> GetAlDotNetyCriteria<T>(DetachedCriteria criteria, int start, int pageSize);

        /// <summary>
        /// 获取指定fguid的所有对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="ids">fguid数组</param>
        /// <returns></returns>
        IList<T> GetByIds<T>(String[] ids);

        /// <summary>
        /// 通过带参的hql查询数据
        /// </summary>
        /// <param name="hql">hql查询语句</param>
        /// <param name="values">值</param>
        /// <returns>符合查询条件的查询结果</returns>
        /// <remarks>valuses值的顺序必须和hql里的参数一一对应</remarks>
        IList GetByHql(String hql, object[] values);

        /// <summary>
        /// 通过带参的hql查询数据
        /// </summary>
        /// <param name="hql">hql查询语句</param>
        /// <param name="values">值</param>
        /// <param name="start">起始位置</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns>符合查询条件的查询结果</returns>
        /// <remarks>valuses值的顺序必须和hql里的参数一一对应</remarks>
        IList GetByHql(String hql, object[] values, int start, int pageSize);

        /// <summary>
        /// 通过带参的hql查询数据(查询唯一值)
        /// </summary>
        /// <param name="hql">hql查询语句</param>
        /// <param name="values">值</param>
        /// <returns>符合查询条件的查询结果</returns>
        /// <remarks>valuses值的顺序必须和hql里的参数一一对应</remarks>
        T GetUniqueResult<T>(String hql, object[] values);

        /// <summary>
        /// 通过Criteria查询数据(查询唯一值)
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="criteria">查询条件</param>
        /// <returns></returns>
        T GetUniqueResult<T>(DetachedCriteria criteria);

        /// <summary>
        /// 保存或者更新数据库对象
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <param name="unitOfWork">工作单元</param>
        void SaveOrUpdate(object obj, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// 显示更新
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <param name="unitOfWork">工作单元</param>
        void Update(object obj, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// 显式保存
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="unitOfWork">工作单元</param>
        void Save(object obj, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// 从数据删除指定的对象
        /// </summary>
        /// <param name="obj">删除对象</param>
        /// <param name="unitOfWork">工作单元</param>
        void Delete(object obj, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// 通过id删除数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="id">主键</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <returns>删除的记录条数</returns>        
        int Delete<T>(String id, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// 根据指定的查询删除指定的数据(适合于游离对象)
        /// </summary>        
        /// <param name="query">查询字符串</param>
        /// <param name="values">值</param>
        /// <param name="types">值的Nhibernate类型</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <returns>返回删除的数目</returns>
        int Delete(String query, object[] values, NHibernate.Type.IType[] types, IUnitOfWork unitOfWork = null);

        /// <summary>
        /// 删除指定的数据(根据数据的主键)
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="deleteDatas">需要删除的数据</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <returns>删除的数据条数</returns>        
        int Delete<T>(IList<T> deleteDatas, IUnitOfWork unitOfWork = null) where T : BusinesBase;
        
        /// <summary>
        /// 删除指定的数据集(根据数据的主键集合)
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="fguids">需要删除的数据主键集合</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <returns>删除的数据条数</returns>
        int Delete<T>(string[] fguids, IUnitOfWork unitOfWork = null) where T : BusinesBase;

        /// <summary>
        /// 从二级缓存中移除指定的集合
        /// </summary>
        /// <param name="roleName"></param>
        void RemoveCollectionFromCache(string roleName);

        /// <summary>
        /// 从二级缓存中移除指定的集合
        /// </summary>
        /// <param name="roleName">集合的全称 (e.g. DotNet.Bussiness.Domain.Node.ChildNodes).</param>
        /// <param name="id">集合对象所有者的主键</param>
        void RemoveCollectionFromCache(string roleName, String id);

        /// <summary>
        /// 从缓存中移除一个查询
        /// </summary>
        /// <param name="cacheRegion">移除的查询名称</param>
        void RemoveQueryFromCache(string cacheRegion);

        /// <summary>
        /// 把当前所有的数据更新写到数据库
        /// </summary>
        void Flush();

        /// <summary>
        /// 清空Session
        /// </summary>
        void Clear();

        /// <summary>
        /// 从数据刷新指定的对象
        /// </summary>
        void Refresh(object obj);

        /// <summary>
        /// 从nh session缓存中移除指定对象
        /// </summary>
        /// <param name="obj">nh session中移除的对象</param>
        void Evict(object obj);
    }
}
