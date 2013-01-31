using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Controls
{
    public interface ISelectdItem
    {
        /// <summary>
        /// 选择项的值
        /// </summary>
        String SelectedItemValue { get; set; }
    }
}
