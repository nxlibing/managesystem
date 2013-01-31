using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DotNet.Entitity;


namespace DotNet.Business.Cms.Entities
{
	/// <summary>
	/// 内容管理——新闻表
	/// </summary>
	[Serializable]
	[DataContract]
	public partial class Cms_Article: BusinesBase, IEquatable<Cms_Article>
	{

		#region Private Members

		private string _fguid;
        private string _categoryid;
        private Cms_Category _category;
		private string _title; 
		private string _author; 
		private string _source; 
		private string _linkurl; 
		private string _contents; 
		private string _introduction; 
		private string _keywords; 
		private int _ishot; 
		private int _isrecomend; 
		private int _istop; 
		private int _iscolor; 
		private string _status; 
		private int _click; 
		private DateTime _pubsj; 
		private string _editid; 
		private DateTime _editsj; 
		private string _jlr; 
		private DateTime _jlsj; 		
		#endregion

		#region Constructor

		public Cms_Article()
		{
			_fguid = String.Empty; 
			_categoryid = String.Empty; 
			_title = String.Empty; 
			_author = String.Empty; 
			_source = String.Empty; 
			_linkurl = String.Empty; 
			_contents = String.Empty; 
			_introduction = String.Empty; 
			_keywords = String.Empty; 
			_ishot = 0; 
			_isrecomend = 0; 
			_istop = 0; 
			_iscolor = 0; 
			_status = String.Empty; 
			_click = 0; 
			_pubsj = DateTime.MinValue; 
			_editid = String.Empty; 
			_editsj = DateTime.MinValue; 
			_jlr = String.Empty; 
			_jlsj = DateTime.MinValue; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Required Fields Only Constructor
		/// <summary>
		/// required (not null) fields only constructor
		/// </summary>
		public Cms_Article(
			string fguid)
			: this()
		{
			_fguid = fguid;
			_categoryid = String.Empty;
			_title = String.Empty;
			_author = String.Empty;
			_source = String.Empty;
			_linkurl = String.Empty;
			_contents = String.Empty;
			_introduction = String.Empty;
			_keywords = String.Empty;
			_ishot = 0;
			_isrecomend = 0;
			_istop = 0;
			_iscolor = 0;
			_status = String.Empty;
			_click = 0;
			_pubsj = DateTime.MinValue;
			_editid = String.Empty;
			_editsj = DateTime.MinValue;
			_jlr = String.Empty;
			_jlsj = DateTime.MinValue;
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
		/// 所属类别
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
				if(  value != null &&  value.Length > 36)
					throw new ArgumentOutOfRangeException("Invalid value for Categoryid", value, value.ToString());
				
				_categoryid = value;
			}
		}


        /// <summary>
        /// 所属类别
        /// </summary>
        [DataMember]
        public virtual Cms_Category Category
        {
            get
            {
                return _category;
            }

            set
            {
                _category = value;
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
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Title", value, value.ToString());
				
				_title = value;
			}
		}
			
		/// <summary>
		/// 作者
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
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Author", value, value.ToString());
				
				_author = value;
			}
		}
			
		/// <summary>
		/// 来源
		/// </summary>
		[DataMember]
		public virtual string Source
		{
			get
			{ 
				return _source;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Source", value, value.ToString());
				
				_source = value;
			}
		}
			
		/// <summary>
		/// 外部链接
		/// </summary>
		[DataMember]
		public virtual string LinkUrl
		{
			get
			{ 
				return _linkurl;
			}

			set	
			{	
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for LinkUrl", value, value.ToString());
				
				_linkurl = value;
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
		/// 内容简介
		/// </summary>
		[DataMember]
		public virtual string Introduction
		{
			get
			{ 
				return _introduction;
			}

			set	
			{	
				if(  value != null &&  value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Introduction", value, value.ToString());
				
				_introduction = value;
			}
		}
			
		/// <summary>
		/// 关键词
		/// </summary>
		[DataMember]
		public virtual string Keywords
		{
			get
			{ 
				return _keywords;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Keywords", value, value.ToString());
				
				_keywords = value;
			}
		}
			
		/// <summary>
		/// 是否热点
		/// </summary>
		[DataMember]
		public virtual int Ishot
		{
			get
			{ 
				return _ishot;
			}
			set
			{
				_ishot = value;
			}

		}
			
		/// <summary>
		/// 是否推荐
		/// </summary>
		[DataMember]
		public virtual int IsRecomend
		{
			get
			{ 
				return _isrecomend;
			}
			set
			{
				_isrecomend = value;
			}

		}
			
		/// <summary>
		/// 是否置顶
		/// </summary>
		[DataMember]
		public virtual int Istop
		{
			get
			{ 
				return _istop;
			}
			set
			{
				_istop = value;
			}

		}
			
		/// <summary>
		/// 是否醒目
		/// </summary>
		[DataMember]
		public virtual int Iscolor
		{
			get
			{ 
				return _iscolor;
			}
			set
			{
				_iscolor = value;
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
		/// 点击数
		/// </summary>
		[DataMember]
		public virtual int Click
		{
			get
			{ 
				return _click;
			}
			set
			{
				_click = value;
			}

		}
			
		/// <summary>
		/// 发布时间
		/// </summary>
		[DataMember]
		public virtual DateTime Pubsj
		{
			get
			{ 
				return _pubsj;
			}
			set
			{
				_pubsj = value;
			}

		}
			
		/// <summary>
		/// 修改人
		/// </summary>
		[DataMember]
		public virtual string Editid
		{
			get
			{ 
				return _editid;
			}

			set	
			{	
				if(  value != null &&  value.Length > 36)
					throw new ArgumentOutOfRangeException("Invalid value for Editid", value, value.ToString());
				
				_editid = value;
			}
		}
			
		/// <summary>
		/// 修改时间
		/// </summary>
		[DataMember]
		public virtual DateTime Editsj
		{
			get
			{ 
				return _editsj;
			}
			set
			{
				_editsj = value;
			}

		}
			
		/// <summary>
		/// 记录人
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
		/// 记录时间
		/// </summary>
		[DataMember]
		public virtual DateTime Jlsj
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
			Cms_Article castObj = (Cms_Article)obj; 
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

		public virtual bool Equals(Cms_Article other)
		{
			if (other == this)
				return true;
		
			return ( other != null ) &&
				( this._fguid == other.Fguid );
				   
		}

		#endregion
		
	}
}
