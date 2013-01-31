using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DotNet.Entitity;


namespace DotNet.Business.Security.Entities
{
	/// <summary>
	/// 角色权限表
	/// </summary>
	[Serializable]
	[DataContract]
	public partial class Base_RoleModule: BusinesBase, IEquatable<Base_RoleModule>
	{

		#region Private Members

		private string _fguid; 
		private string _roleid; 
		private string _moduleid; 		
		#endregion

		#region Constructor

		public Base_RoleModule()
		{
			_fguid = String.Empty; 
			_roleid = String.Empty; 
			_moduleid = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public Base_RoleModule(
			string fguid)
			: this()
		{
			_fguid = fguid;
			_roleid = String.Empty;
			_moduleid = String.Empty;
		}
		#endregion // End Constructor

		#region Public Properties
			
		/// <summary>
		/// 主键
		/// </summary>
		[DataMember]
		public virtual string Fguid
		{
			get
			{ 
				return _fguid;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for Fguid", value, "null");
				
				if(  value.Length > 36)
					throw new ArgumentOutOfRangeException("Invalid value for Fguid", value, value.ToString());
				
				_fguid = value;
			}
		}
			
		/// <summary>
		/// 角色编码
		/// </summary>
		[DataMember]
		public virtual string Roleid
		{
			get
			{ 
				return _roleid;
			}

			set	
			{	
				if(  value != null &&  value.Length > 36)
					throw new ArgumentOutOfRangeException("Invalid value for Roleid", value, value.ToString());
				
				_roleid = value;
			}
		}
			
		/// <summary>
		/// 权限编码
		/// </summary>
		[DataMember]
		public virtual string Moduleid
		{
			get
			{ 
				return _moduleid;
			}

			set	
			{	
				if(  value != null &&  value.Length > 36)
					throw new ArgumentOutOfRangeException("Invalid value for Moduleid", value, value.ToString());
				
				_moduleid = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		#endregion //Public Functions

		#region Equals And HashCode Overrides
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			Base_RoleModule castObj = (Base_RoleModule)obj; 
			return ( castObj != null ) &&
				( this._fguid == castObj.Fguid );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 ^ hash ^ _fguid.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region IEquatable members

		public virtual bool Equals(Base_RoleModule other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._fguid == other.Fguid );
				   
		}

		#endregion
		
	}
}
