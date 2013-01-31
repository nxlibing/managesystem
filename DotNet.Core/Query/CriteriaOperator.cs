using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Core.Query
{
    /// <summary>
    /// 数据比较操作符
    /// </summary>
    public enum CriteriaOperator
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
