using DotNet.Facilities.NHibernateIntegration.Components;
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

namespace DotNet.Facilities.NHibernateIntegration.Components.Web
{
	using System;
	using System.Web;

	using NHibernate;
    using Microsoft.Practices.Unity;
    using DotNet.Common.IOC;

	/// <summary>
	/// HttpModule to set up a session for the request lifetime.
	/// <seealso cref="ISessionManager"/>
	/// </summary>
	/// <remarks>
	/// To install the module, you must:
	/// <para>
	///    <list type="number">
	///      <item>
	///        <description>
	///        Add the module to the <c>httpModules</c> configuration section within <c>system.web</c>
	///        </description>
	///      </item>
	///      <item>
	///        <description>Extend the <see cref="HttpApplication"/> if you haven't</description>
	///      </item>
	///      <item>
	///        <description>Make your <c>HttpApplication</c> subclass implement
	///        <see cref="IContainerAccessor"/> so the module can access the container instance</description>
	///      </item>
	///    </list>
	/// </para>
	/// </remarks>
	public class SessionWebModule : IHttpModule
	{
		/// <summary>
		/// 
		/// </summary>
		protected static readonly String SessionKey = "SessionWebModule.session";

		/// <summary>
		/// Initializes a module and prepares it to handle requests.
		/// </summary>
		/// <param name="app">The app.</param>
		public void Init(HttpApplication app)
		{
			app.BeginRequest += OnBeginRequest;
			app.EndRequest += OnEndRequest;
            app.Error += new EventHandler(app_Error);
		}

        void app_Error(object sender, EventArgs e)
        {
            CloseSession();
        }

		/// <summary>
		/// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
		/// </summary>
		public void Dispose()
		{
            
		}

		private void OnBeginRequest(object sender, EventArgs e)
		{            
            IUnityContainerAccessor container = HttpContext.Current.ApplicationInstance as IUnityContainerAccessor;
            if (null == container)
            {
                return;
            }

            ISessionManager sessManager = container.Contanier.Resolve<ISessionManager>();

            HttpContext.Current.Items.Add(SessionKey, sessManager.OpenSession());
		}

		private void OnEndRequest(object sender, EventArgs e)
		{
            CloseSession();
		}

        private void CloseSession()
        {
            if (null == HttpContext.Current)
            {
                return;
            }

            ISession session = (ISession)HttpContext.Current.Items[SessionKey];

            if (session != null)
            {
                session.Dispose();
                HttpContext.Current.Items[SessionKey] = null;
            }
        }
	}
}