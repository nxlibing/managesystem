using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Core.Query
{
    /// <summary>
    /// 数据过滤条件
    /// </summary>
    public class Criteria
    {
        /// <summary>
        /// 实体属性名
        /// </summary>
        public String PropertyName { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 操作符
        /// </summary>
        public CriteriaOperator Operator { get; set; }

        /// <summary>
        /// 逻辑操作，默认为And        
        /// </summary>
        public LogicalOperation LogicalOperation { get; set; }

        public Criteria()
        {
            this.LogicalOperation = Core.Query.LogicalOperation.And;
        }

        public Criteria(String propertyName, String value, CriteriaOperator criteriaOperator, LogicalOperation logicalOperation = Core.Query.LogicalOperation.And)
        {
            this.PropertyName = propertyName;
            this.Value = value;
            this.Operator = criteriaOperator;
            this.LogicalOperation = logicalOperation;
        }
    }
}
