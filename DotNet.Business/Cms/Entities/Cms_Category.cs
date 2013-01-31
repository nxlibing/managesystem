using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DotNet.Entitity;


namespace DotNet.Business.Cms.Entities
{
	/// <summary>
	/// 内容管理——内容类别
	/// </summary>
	[Serializable]
	[DataContract]
	public partial class Cms_Category: BusinesBase, IEquatable<Cms_Category>
	{

		#region Private Members

		private string _fguid; 
		private string _categoryid; 
		private string _title; 
		private string _pguid; 
		private string _url; 
		private string _description; 
		private bool? _isadd; 		
		#endregion

		#region Constructor

		public Cms_Category()
		{
			_fguid = String.Empty; 
			_categoryid = String.Empty; 
			_title = String.Empty; 
			_pguid = String.Empty; 
			_url = String.Empty; 
			_description = String.Empty; 
			_isadd = new bool?(); 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public Cms_Category(
			string fguid)
			: this()
		{
			_fguid = fguid;
			_categoryid = String.Empty;
			_title = String.Empty;
			_pguid = String.Empty;
			_url = String.Empty;
			_description = String.Empty;
			_isadd = null;
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
		/// 栏目编号
		/// </summary>
		[DataMember]
		public virtual string Categoryid
		{
			get
			{ 
				return _categoryid;
			}

			set	
			{	
				if(  value != null &&  value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Categoryid", value, value.ToString());
				
				_categoryid = value;
			}
		}
			
		/// <summary>
		/// 名称
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
		/// 父级编号
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
		/// 外部链接
		/// </summary>
		[DataMember]
		public virtual string Url
		{
			get
			{ 
				return _url;
			}

			set	
			{	
				if(  value != null &&  value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Url", value, value.ToString());
				
				_url = value;
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
				if(  value != null &&  value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				
				_description = value;
			}
		}
			
		/// <summary>
		/// 是否可添加新闻
		/// </summary>
		[DataMember]
		public virtual bool? Isadd
		{
			get
			{ 
				return _isadd;
			}
			set
			{
				_isadd = value;
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
			Cms_Category castObj = (Cms_Category)obj; 
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

		public virtual bool Equals(Cms_Category other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._fguid == other.Fguid );
				   
		}

		#endregion
		
	}
}
