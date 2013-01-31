using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Business.Dictionary.Entities
{
    public partial class Base_ItemDetails
    {
        public virtual string ShowDelete
        {
            get
            {
                if (Status == "1")
                {
                    return "hidden";
                }
                return "";
            }
        }

        public virtual string StatusName
        {
            get
            {
                if (Status == "1")
                {
                    return "<font color='green'>启用</font>";
                }
                return "<font color='red'>未启用</font>";
            }
        }
    }
}
