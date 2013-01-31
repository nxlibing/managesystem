using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Presenter.Admin.Security
{
    public interface AuthenticationIView
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
