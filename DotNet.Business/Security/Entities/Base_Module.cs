using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DotNet.Entitity;


namespace DotNet.Business.Security.Entities
{
	/// <summary>
	/// 模块（菜单）表
	/// </summary>
	[Serializable]
	[DataContract]
	public partial class Base_Module: BusinesBase, IEquatable<Base_Module>
	{

		#region Private Members

		private string _fguid; 
		private string _sysno; 
		private string _title; 
		private string _description; 
		private string _navigateurl; 
		private string _icon; 
		private string _dispindex; 
		private string _pguid; 
		private string _status; 
		private string _createid; 
		private DateTime? _createdate; 		
		#endregion

		#region Constructor

		public Base_Module()
		{
			_fguid = String.Empty; 
			_sysno = String.Empty; 
			_title = String.Empty; 
			_description = String.Empty; 
			_navigateurl = String.Empty; 
			_icon = String.Empty; 
			_dispindex = String.Empty; 
			_pguid = String.Empty; 
			_status = String.Empty; 
			_createid = String.Empty; 
			_createdate = new DateTime?(); 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public Base_Module(
			string fguid)
			: this()
		{
			_fguid = fguid;
			_sysno = String.Empty;
			_title = String.Empty;
			_description = String.Empty;
			_navigateurl = String.Empty;
			_icon = String.Empty;
			_dispindex = String.Empty;
			_pguid = String.Empty;
			_status = String.Empty;
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
		/// 
		/// </summary>
		[DataMember]
		public virtual string Moduleno
		{
			get
			{ 
				return _sysno;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Sysno", value, value.ToString());
				
				_sysno = value;
			}
		}
			
		/// <summary>
		/// 标题
		/// </summary>
		[DataMember]
		public virtual string Title
		{
			get
			{ 
				return _title;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Title", value, value.ToString());
				
				_title = value;
			}
		}
			
		/// <summary>
		/// 描述
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
		/// 连接
		/// </summary>
		[DataMember]
		public virtual string Navigateurl
		{
			get
			{ 
				return _navigateurl;
			}

			set	
			{	
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Navigateurl", value, value.ToString());
				
				_navigateurl = value;
			}
		}
			
		/// <summary>
		/// 图标
		/// </summary>
		[DataMember]
		public virtual string Icon
		{
			get
			{ 
				return _icon;
			}

			set	
			{	
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Icon", value, value.ToString());
				
				_icon = value;
			}
		}
			
		/// <summary>
		/// 排序码
		/// </summary>
		[DataMember]
		public virtual string Dispindex
		{
			get
			{ 
				return _dispindex;
			}

			set	
			{	
				if(  value != null &&  value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Dispindex", value, value.ToString());
				
				_dispindex = value;
			}
		}
			
		/// <summary>
		/// 父级编码
		/// </summary>
		[DataMember]
		public virtual string Pguid
		{
			get
			{ 
				return _pguid;
			}

			set	
			{	
				if(  value != null &&  value.Length > 36)
					throw new ArgumentOutOfRangeException("Invalid value for Pguid", value, value.ToString());
				
				_pguid = value;
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
		/// 创建时间
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
			Base_Module castObj = (Base_Module)obj; 
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

		public virtual bool Equals(Base_Module other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._fguid == other.Fguid );
				   
		}

		#endregion
		
	}
}
