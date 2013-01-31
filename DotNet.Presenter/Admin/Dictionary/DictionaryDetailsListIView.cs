using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Presenter.Admin.Dictionary
{
    public interface DictionaryDetailsListIView
    {
        IList<Business.Dictionary.Entities.Base_Item> CategoryList { set; get; }
        IList<Business.Dictionary.Entities.Base_ItemDetails> DetailsList { set; }
        Business.Dictionary.Entities.Base_ItemDetails Data { get; }
    }
}
