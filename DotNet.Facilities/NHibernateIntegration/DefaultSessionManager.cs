#region License

//  Copyright 2004-2010 Castle Project - http://www.castleproject.org/
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
// 

#endregion

namespace DotNet.Facilities.NHibernateIntegration
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NHibernate;

    /// <summary>
    /// 
    /// </summary>
    public class DefaultSessionManager : MarshalByRefObject, ISessionManager
    {
        #region constants

        /// <summary>
        /// Format string for NHibernate interceptor components
        /// </summary>
        public const string InterceptorFormatString = "nhibernate.session.interceptor.{0}";

        /// <summary>
        /// Name for NHibernate Interceptor componentInterceptorName
        /// </summary>
        public const string InterceptorName = "nhibernate.session.interceptor";

        #endregion

        private readonly ISessionStore sessionStore;
        private ISessionFactory _sessionFactory;
        private FlushMode defaultFlushMode = FlushMode.Auto;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="sessionFactory"></param>
        [Microsoft.Practices.Unity.InjectionConstructor]
        public DefaultSessionManager(ISessionStore sessionStore, ISessionFactory sessionFactory)
        {
            this.sessionStore = sessionStore;
            this._sessionFactory = sessionFactory;            
        }

        /// <summary>
        /// The flushmode the created session gets
        /// </summary>
        /// <value></value>
        public FlushMode DefaultFlushMode
        {
            get { return defaultFlushMode; }
            set { defaultFlushMode = value; }
        }

        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }

        /// <summary>
        /// Returns a valid opened and connected ISession instance
        /// for the given connection alias.
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public ISession OpenSession()
        {
            SessionDelegate wrapped = sessionStore.FindCompatibleSession();

            ISession session;

            if (wrapped == null)
            {
                //session = CreateSession();

                wrapped = WrapSession();
                sessionStore.Store(wrapped);
            }
            else
            {
                //wrapped = WrapSession();
            }

            return wrapped;
        }

        private SessionDelegate WrapSession()
        {
            return new SessionDelegate(this._sessionFactory, sessionStore);
        }

        private ISession CreateSession()
        {
            ISessionFactory sessionFactory = this._sessionFactory;

            ISession session;

            session = sessionFactory.OpenSession();

            session.FlushMode = defaultFlushMode;

            return session;
        }
    }
}