using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace DotNet.Common.IOC
{
    public interface IUnityContainerAccessor
    {
        IUnityContainer Contanier
        { get; }
    }
}
