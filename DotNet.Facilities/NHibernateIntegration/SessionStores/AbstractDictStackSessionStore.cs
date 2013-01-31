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

namespace DotNet.Facilities.NHibernateIntegration.SessionStores
{
	using System;
	using System.Collections;
	using System.Collections.Specialized;
	using System.Runtime.CompilerServices;
	using System.Runtime.Remoting.Messaging;

	/// <summary>
	/// 
	/// </summary>
	public abstract class AbstractDictStackSessionStore : AbstractSessionStore
	{
		/// <summary>
		/// Name used for storage in <see cref="CallContext"/>
		/// </summary>
		protected String SlotKey
		{
			get
			{
				if (string.IsNullOrEmpty(slotKey))
					slotKey = string.Format("nh.facility.stacks.{0}", Guid.NewGuid());
				return slotKey;
			}
		}

		private string slotKey;

        private const String StackKey = "SessionStoreStackKey";

		/// <summary>
		/// Gets the stack of <see cref="SessionDelegate"/> objects for the specified <paramref name="alias"/>.
		/// </summary>
		/// <param name="alias">The alias.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.Synchronized)]
		protected override Stack GetStackFor()
		{

			IDictionary alias2Stack = GetDictionary();

			if (alias2Stack == null)
			{
				alias2Stack = new HybridDictionary(true);

				StoreDictionary(alias2Stack);
			}

            Stack stack = alias2Stack[StackKey] as Stack;

			if (stack == null)
			{
				stack = Stack.Synchronized(new Stack());

                alias2Stack[StackKey] = stack;
			}

			return stack;
		}

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		protected abstract IDictionary GetDictionary();

		/// <summary>
		/// Stores the dictionary.
		/// </summary>
		/// <param name="dictionary">The dictionary.</param>
		protected abstract void StoreDictionary(IDictionary dictionary);
	}
}