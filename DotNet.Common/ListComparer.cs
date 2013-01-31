using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Common
{
    public class ListComparer : IEqualityComparer<string>
    {
        public bool Equals(string a, string b)
        {
            if (a == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(string obj)
        {
            return 0;
        }
    }
}
