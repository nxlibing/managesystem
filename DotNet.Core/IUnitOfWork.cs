using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Core
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        object Save(object entity);

        /// <summary>
        /// 保存或者更新对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        void SaveOrUpdate(object entity);

        /// <summary>
        /// 更新数据                
        /// </summary>
        /// <param name="entity">实体对象</param>
        void Update(object entity);

        /// <summary>
        /// 从数据删除指定的对象
        /// </summary>
        /// <param name="obj">删除对象</param>
        void Delete(object entity);

        /// <summary>
        /// 通过id删除数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="id">主键</param>
        /// <returns>删除的记录条数</returns>
        int Delete<T>(String id);

        /// <summary>
        /// 根据指定的查询删除指定的数据(适合于游离对象)
        /// </summary>        
        /// <param name="query">查询字符串</param>
        /// <param name="values">值</param>
        /// <param name="types">值的Nhibernate类型</param>        
        /// <returns>返回删除的数目</returns>
        int Delete(String query, object[] values, NHibernate.Type.IType[] types);

        /// <summary>
        /// 提交工作单元（事务）
        /// </summary>
        void Commit();
    }
}
