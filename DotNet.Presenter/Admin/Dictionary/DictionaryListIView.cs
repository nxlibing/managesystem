using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Presenter.Admin.Dictionary
{
    public interface DictionaryListIView
    {
        Business.Dictionary.Entities.Base_Item Data { get; }
        IList<Business.Dictionary.Entities.Base_Item> CategoryList { set; }
    }
}
