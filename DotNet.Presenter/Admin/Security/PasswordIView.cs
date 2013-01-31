using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Presenter.Admin.Security
{
    public interface PasswordIView
    {
        IList<Business.Security.Entities.Base_User> List { get; set; }
    }
}
