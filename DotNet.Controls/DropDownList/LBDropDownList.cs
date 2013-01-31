using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using DotNet.Common;

namespace DotNet.Controls.DropDownList
{/// <summary>
    /// 继承自GridView
    /// </summary>
    [ToolboxData("<{0}:DotNetDropDownList  ID=DropDownList1 runat=server></{0}:DotNetDropDownList")]
    public class DotNetDropDownList : System.Web.UI.WebControls.DropDownList
    {
        protected override void OnPreRender(EventArgs e)
        {
            LiteralControl include = new LiteralControl(getHeaderInfo());
            List<string> list = new List<string>();
            foreach (var item in Page.Header.Controls)
            {
                LiteralControl ctr = item as LiteralControl;
                if (ctr != null)
                {
                    list.Add(ctr.Text);
                }
            }
            if (!list.Contains(include.Text))
            {
                Page.Header.Controls.AddAt(0, include);
            }
            base.OnPreRender(e);
        }

        private string getHeaderInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\" src=\"" + AppInfo.Domain + "Style/Js/select.js\"></script>\n");
            sb.Append("<link href=\"" + AppInfo.Domain + "Style/Css/select.css\" rel=\"stylesheet\" type=\"text/css\" />\n");
            return sb.ToString();
        }
    }
}
