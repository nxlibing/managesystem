using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DotNet.Entitity;


namespace DotNet.Business.Dictionary.Entities
{
    /// <summary>
    /// 系统管理——字典表（信息代码表）
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Base_Item : BusinesBase, IEquatable<Base_Item>
    {

        #region Private Members

        private string _fguid;
        private string _pguid;
        private string _name;
        private string _code;
        private string _level;
        private IList<Base_ItemDetails> _itemDetailsList;
        #endregion

        #region Constructor

        public Base_Item()
        {
            _fguid = String.Empty;
            _pguid = String.Empty;
            _name = String.Empty;
            _code = String.Empty;
            _level = String.Empty;
            _itemDetailsList = new List<Base_ItemDetails>();
        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Required Fields Only Constructor
        /// <summary>
        /// required (not null) fields only constructor
        /// </summary>
        public Base_Item(
            string fguid)
            : this()
        {
            _fguid = fguid;
            _pguid = String.Empty;
            _name = String.Empty;
            _code = String.Empty;
            _level = String.Empty;
        }
        #endregion // End Constructor

        #region Public Properties

        /// <summary>
        /// ID
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
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Fguid", value, "null");

                if (value.Length > 36)
                    throw new ArgumentOutOfRangeException("Invalid value for Fguid", value, value.ToString());

                _fguid = value;
            }
        }

        /// <summary>
        /// 父级ID
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
                if (value != null && value.Length > 36)
                    throw new ArgumentOutOfRangeException("Invalid value for Pguid", value, value.ToString());

                _pguid = value;
            }
        }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public virtual string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value != null && value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());

                _name = value;
            }
        }

        /// <summary>
        /// 编码
        /// </summary>
        [DataMember]
        public virtual string Code
        {
            get
            {
                return _code;
            }

            set
            {
                if (value != null && value.Length > 10)
                    throw new ArgumentOutOfRangeException("Invalid value for Code", value, value.ToString());

                _code = value;
            }
        }

        /// <summary>
        /// 级别
        /// </summary>
        [DataMember]
        public virtual string Level
        {
            get
            {
                return _level;
            }

            set
            {
                if (value != null && value.Length > 10)
                    throw new ArgumentOutOfRangeException("Invalid value for Level", value, value.ToString());

                _level = value;
            }
        }


        /// <summary>
        /// 信息代码
        /// </summary>
        public virtual IList<Base_ItemDetails> ItemDetailsList
        {
            get
            {
                return _itemDetailsList;
            }
            set
            {
                _itemDetailsList = value;
            }
        }

        #endregion

        #region Public Functions

        #endregion //Public Functions

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Base_Item castObj = (Base_Item)obj;
            return (castObj != null) &&
                (this._fguid == castObj.Fguid);
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

        public virtual bool Equals(Base_Item other)
        {
            if (other == this)
                return true;

            return (other != null) &&
                (this._fguid == other.Fguid);

        }

        #endregion

    }
}
