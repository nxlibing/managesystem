using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Core.Query
{
    /// <summary>
    /// 查询对象
    /// </summary>
    public class Query
    {
        private IList<Criteria> _criterias = new List<Criteria>();

        /// <summary>
        /// 过滤条件
        /// </summary>
        public IList<Criteria> Criterias
        {
            get { return this._criterias; }
        }
    }
}
