using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DotNet.Entitity;


namespace DotNet.Business.Security.Entities
{
	/// <summary>
	/// 用户表
	/// </summary>
	[Serializable]
	[DataContract]
	public partial class Base_User: BusinesBase, IEquatable<Base_User>
	{

		#region Private Members

		private string _fguid; 
		private string _username; 
		private string _realname; 
		private string _password; 
		private string _status; 
		private string _description; 
		private string _createid; 
		private DateTime? _createdate; 		
		#endregion

		#region Constructor

		public Base_User()
		{
			_fguid = String.Empty; 
			_username = String.Empty; 
			_realname = String.Empty; 
			_password = String.Empty; 
			_status = String.Empty; 
			_description = String.Empty; 
			_createid = String.Empty; 
			_createdate = new DateTime?(); 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public Base_User(
			string fguid)
			: this()
		{
			_fguid = fguid;
			_username = String.Empty;
			_realname = String.Empty;
			_password = String.Empty;
			_status = String.Empty;
			_description = String.Empty;
			_createid = String.Empty;
			_createdate = null;
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
		/// 登录名
		/// </summary>
		[DataMember]
		public virtual string Username
		{
			get
			{ 
				return _username;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Username", value, value.ToString());
				
				_username = value;
			}
		}
			
		/// <summary>
		/// 姓名
		/// </summary>
		[DataMember]
		public virtual string Realname
		{
			get
			{ 
				return _realname;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Realname", value, value.ToString());
				
				_realname = value;
			}
		}
			
		/// <summary>
		/// 密码
		/// </summary>
		[DataMember]
		public virtual string Password
		{
			get
			{ 
				return _password;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Password", value, value.ToString());
				
				_password = value;
			}
		}
			
		/// <summary>
		/// 状态
		/// </summary>
		[DataMember]
		public virtual string Status
		{
			get
			{ 
				return _status;
			}

			set	
			{	
				if(  value != null &&  value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Status", value, value.ToString());
				
				_status = value;
			}
		}
			
		/// <summary>
		/// 备注
		/// </summary>
		[DataMember]
		public virtual string Description
		{
			get
			{ 
				return _description;
			}

			set	
			{	
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				
				_description = value;
			}
		}
			
		/// <summary>
		/// 创建人
		/// </summary>
		[DataMember]
		public virtual string Createid
		{
			get
			{ 
				return _createid;
			}

			set	
			{	
				if(  value != null &&  value.Length > 36)
					throw new ArgumentOutOfRangeException("Invalid value for Createid", value, value.ToString());
				
				_createid = value;
			}
		}
			
		/// <summary>
		/// 创建日期
		/// </summary>
		[DataMember]
		public virtual DateTime? Createdate
		{
			get
			{ 
				return _createdate;
			}
			set
			{
				_createdate = value;
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
			Base_User castObj = (Base_User)obj; 
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

		public virtual bool Equals(Base_User other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._fguid == other.Fguid );
				   
		}

		#endregion
		
	}
}
