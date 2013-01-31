using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Core;
using DotNet.Facilities.NHibernateIntegration;
using NHibernate;

namespace DotNet.DataAccess
{
    public class NhibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISessionManager _sessionManager;

        private ISession _session;
        private ISession Session
        {
            get
            {
                if (null == _session)
                {
                    return this._sessionManager.OpenSession(); ;
                }
                return _session;
            }
        }

        [Microsoft.Practices.Unity.InjectionConstructor]
        public NhibernateUnitOfWork(ISessionManager sessionManager)
        {
            this._sessionManager = sessionManager;
        }

        public NhibernateUnitOfWork(ISession session)
        {
            this._session = session;
        }

        #region IUnitOfWork 成员

        public object Save(object entity)
        {
            object ret = this.Session.Save(entity);
            
            return ret;
        }

        /// <summary>
        /// 保存或者更新对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        public void SaveOrUpdate(object entity)
        {
            this.Session.SaveOrUpdate(entity);
        }

        public void Update(object entity)
        {
            this.Session.Update(entity);
        }

        public void Delete(object entity)
        {            
            this.Session.Delete(entity);
        }

        public int Delete<T>(string id)
        {            
            String hql = String.Format("FROM {0} WHERE Fguid = ?", typeof(T).Name);
            int r = this.Session.Delete(hql, id, NHibernateUtil.String);

            return r;
        }

        /// <summary>
        /// 根据指定的查询删除指定的数据(适合于游离对象)
        /// </summary>        
        /// <param name="query">查询字符串</param>
        /// <param name="values">值</param>
        /// <param name="types">值的Nhibernate类型</param>        
        /// <returns>返回删除的数目</returns>
        public int Delete(String query, object[] values, NHibernate.Type.IType[] types)
        {
            int r = this.Session.Delete(query, values, types);

            return r;
        }

        public void Commit()
        {
            ISession session = this._sessionManager.OpenSession();
            using (ITransaction trans = this.Session.BeginTransaction())
            {
                try
                {
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        #endregion
    }
}
