using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Presenter.Controls
{
    public interface IDictionaryView
    {
        /// <summary>
        /// 选择项
        /// </summary>
        String SelectedItemValue { get; set; }

        /// <summary>
        /// 数据项
        /// </summary>
        IList<Business.Dictionary.Entities.Base_ItemDetails> DataItems { get; set; }
    }
}
