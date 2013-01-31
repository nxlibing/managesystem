using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DotNet.Entitity;


namespace DotNet.Business.Cms.Entities
{
	/// <summary>
	/// 内容管理——短消息表
	/// </summary>
	[Serializable]
	[DataContract]
	public partial class Cms_News: BusinesBase, IEquatable<Cms_News>
	{

		#region Private Members

		private string _fguid; 
		private string _title; 
		private string _contents; 
		private string _accept; 
		private string _author; 
		private DateTime? _stime; 
		private DateTime? _etime; 
		private int? _isnowsend; 
		private int? _sendinterval; 
		private string _jlr; 
		private DateTime? _jlsj; 		
		#endregion

		#region Constructor

		public Cms_News()
		{
			_fguid = String.Empty; 
			_title = String.Empty; 
			_contents = String.Empty; 
			_accept = String.Empty; 
			_author = String.Empty; 
			_stime = new DateTime?(); 
			_etime = new DateTime?(); 
			_isnowsend = new int?(); 
			_sendinterval = new int?(); 
			_jlr = String.Empty; 
			_jlsj = new DateTime?(); 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public Cms_News(
			string fguid)
			: this()
		{
			_fguid = fguid;
			_title = String.Empty;
			_contents = String.Empty;
			_accept = String.Empty;
			_author = String.Empty;
			_stime = null;
			_etime = null;
			_isnowsend = null;
			_sendinterval = null;
			_jlr = String.Empty;
			_jlsj = null;
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
		/// 内容
		/// </summary>
		[DataMember]
		public virtual string Contents
		{
			get
			{ 
				return _contents;
			}

			set	
			{	
				if(  value != null &&  value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for Contents", value, value.ToString());
				
				_contents = value;
			}
		}
			
		/// <summary>
		/// 接收人
		/// </summary>
		[DataMember]
		public virtual string Accept
		{
			get
			{ 
				return _accept;
			}

			set	
			{	
				if(  value != null &&  value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Accept", value, value.ToString());
				
				_accept = value;
			}
		}
			
		/// <summary>
		/// 发送人
		/// </summary>
		[DataMember]
		public virtual string Author
		{
			get
			{ 
				return _author;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Author", value, value.ToString());
				
				_author = value;
			}
		}
			
		/// <summary>
		/// 发送开始时间
		/// </summary>
		[DataMember]
		public virtual DateTime? Stime
		{
			get
			{ 
				return _stime;
			}
			set
			{
				_stime = value;
			}

		}
			
		/// <summary>
		/// 发送截止时间
		/// </summary>
		[DataMember]
		public virtual DateTime? Etime
		{
			get
			{ 
				return _etime;
			}
			set
			{
				_etime = value;
			}

		}
			
		/// <summary>
		/// 是否立即发送
		/// </summary>
		[DataMember]
		public virtual int? Isnowsend
		{
			get
			{ 
				return _isnowsend;
			}
			set
			{
				_isnowsend = value;
			}

		}
			
		/// <summary>
		/// 发送间隔
		/// </summary>
		[DataMember]
		public virtual int? Sendinterval
		{
			get
			{ 
				return _sendinterval;
			}
			set
			{
				_sendinterval = value;
			}

		}
			
		/// <summary>
		/// 创建人
		/// </summary>
		[DataMember]
		public virtual string Jlr
		{
			get
			{ 
				return _jlr;
			}

			set	
			{	
				if(  value != null &&  value.Length > 36)
					throw new ArgumentOutOfRangeException("Invalid value for Jlr", value, value.ToString());
				
				_jlr = value;
			}
		}
			
		/// <summary>
		/// 创建时间
		/// </summary>
		[DataMember]
		public virtual DateTime? Jlsj
		{
			get
			{ 
				return _jlsj;
			}
			set
			{
				_jlsj = value;
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
			Cms_News castObj = (Cms_News)obj; 
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

		public virtual bool Equals(Cms_News other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._fguid == other.Fguid );
				   
		}

		#endregion
		
	}
}
