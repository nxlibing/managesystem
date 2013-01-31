using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;

using System.Runtime.Serialization;
using NHibernate.Cfg;
using NHibernate;
using DotNet.Common;
using Microsoft.Practices.Unity;

namespace DotNet.Entitity
{
    /// <summary>
    /// 业务类基类
    /// </summary>    
    [Serializable]
    public abstract partial class BusinesBase : IDisposable
    {
        private static ISessionFactory _sessionFactory;
        public static ISessionFactory SessionFactory
        {
           get { return _sessionFactory; }
          
        }

        public virtual string Fguid
        {
            get
            {
                throw new NotSupportedException(String.Format("类型{0}不支持Fguid属性", this.GetType()));
            }
            set
            {
                throw new NotSupportedException(String.Format("类型{0}不支持Fguid属性", this.GetType()));
            }
        }
     
        private static object lockHelper = new object();

        public BusinesBase()
        { 
            
        }
           
        ~BusinesBase()
        {

        }

        #region IDisposable 成员

        public virtual void Dispose()
        {
           
        }

        #endregion

        public static void Init(String nhconfig)
        {
            Configuration cfg = new Configuration().Configure(System.IO.Path.Combine(Common.AppInfo.ApplicationStartPath, "config\\hibernate.cfg.config"));

            cfg.AddAssembly("DotNet.Business");

            _sessionFactory = cfg.BuildSessionFactory();
            
#if DEBUG
            _sessionFactory.Statistics.IsStatisticsEnabled = true;
#endif

            Ioc.Container.RegisterInstance(typeof(ISessionFactory), _sessionFactory, new ContainerControlledLifetimeManager());
        }

        public static String NewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 判断在指定的实体（数据表）中是否存在给定的值
        /// </summary>
        /// <param name="entityName">实体名（数据库表名）</param>
        /// <param name="fieldName">属性名（数据表字段）</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static bool ExsitInTable(String entityName, String fieldName, object value)
        {
            DotNet.DataAccess.IOracleDataAccess dataAccess = Common.Ioc.Resolve<DotNet.DataAccess.IOracleDataAccess>();

            String sql = String.Format("SELECT COUNT(*) FROM {0} WHERE {1} = :value", entityName, fieldName);
            System.Data.DataTable dt = dataAccess.GetDataTable(sql, new String[] {":value"}, new object[] { value });

            if (null != dt && dt.Rows.Count > 0)
            {
                return true;
            }
            
            return false;            
        }
    }
}
