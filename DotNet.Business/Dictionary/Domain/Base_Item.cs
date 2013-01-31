using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Business.Dictionary.Entities
{
    public partial class Base_Item
    {
        /// <summary>
        /// 是否显示删除按钮
        /// </summary>
        public virtual bool? ShowDelete
        {
            get
            {
                if (this.ItemDetailsList.Count > 0)
                {
                    return false;
                }
                return true;

            }
        }
    }
}
