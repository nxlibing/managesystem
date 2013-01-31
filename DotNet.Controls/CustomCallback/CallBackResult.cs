using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Web.UI
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public class CalDotNetackResultClass
    {
        private string _calDotNetackValue;
        /// <summary>
        /// 执行结果
        /// </summary>
        public string Result
        {
            get
            {
                if (_calDotNetackValue != null)
                {

                    return _calDotNetackValue.ToLower();
                }
                return _calDotNetackValue;
            }
            set
            {
                _calDotNetackValue = value;
            }
        }

        private bool _isRefresh = false;
        /// <summary>
        /// 是否已执行刷新
        /// </summary>
        public bool IsRefresh
        {
            get { return _isRefresh; }
            set { _isRefresh = value; }
        }
    }
}
