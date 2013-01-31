using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Business.Dao
{
    /// <summary>
    /// 字符类型在数据查找时的匹配方式
    /// </summary>
    public enum StringMatchType
    {
        /// <summary>
        /// 全匹配，like '%值%'
        /// </summary>
        Full = 0,
        /// <summary>
        /// 开始于,like '值%'
        /// </summary>
        StratWith = 1,
        /// <summary>
        /// 接受于,like'%值'
        /// </summary>
        EndWith = 2,
        /// <summary>
        /// 相等
        /// </summary>
        Equal = 3
    }
}
