using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Business.Security.Entities;

namespace DotNet.Presenter.Admin.Security
{
    public interface ModuleEditIView
    {
        Base_Module Data { get; set; }

        IList<Base_Module> List { set; }
        string Fguid { get; }
    }
}
