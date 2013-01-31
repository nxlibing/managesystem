using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;

namespace DotNet.Controls.CustomCalDotNetack
{
    [ToolboxData("<{0}:DotNetCustomCalDotNetack  ID=DotNetCustomCalDotNetack runat=server UseSubmitBehavior=false></{0}:DotNetCustomCalDotNetack>")]
    public class DotNetCustomCalDotNetack : Button
    {
        string jsendcalDotNetack = "<script type=\"text/javascript\">{0}('{1}')</script>";

        #region Attribute
        private string _endCalDotNetack;
        /// <summary>
        /// 回传javascript函数
        /// </summary>
        [Description("回传javascript函数"), DefaultValue(""), Category("扩展")]
        public string EndCalDotNetack
        {
            get { return _endCalDotNetack; }
            set
            {
                if (value.Contains('('))
                {
                    string[] arr = value.Split('(');
                    _endCalDotNetack = arr[0];
                }
                else
                { _endCalDotNetack = value; }
            }
        }


        private CalDotNetackResultClass _calDotNetackResult;
        /// <summary>
        /// CalDotNetack结果
        /// </summary>
        [Description("CalDotNetack结果"), DefaultValue(""), Category("扩展")]
        public CalDotNetackResultClass CalDotNetackResult
        {
            get
            {
                if (_calDotNetackResult == null)
                {
                    _calDotNetackResult = new CalDotNetackResultClass();
                }
                return _calDotNetackResult;
            }
        }

        #endregion

        #region Event
        public event EventHandler<CustomCalDotNetackEventArgs> CustomCalDotNetack;
        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            this.Style.Add("display", "none");
            base.Render(writer);
        }

        protected override void OnClick(EventArgs e)
        {
            if (null != CustomCalDotNetack)
            {
                string arg = System.Web.HttpContext.Current.Request.Form["__EVENTARGUMENT"];
                CustomCalDotNetack(this, new CustomCalDotNetackEventArgs { Parameters = arg });
                if (null != _calDotNetackResult)
                {
                    string js = string.Format(jsendcalDotNetack, EndCalDotNetack, _calDotNetackResult.ToJson());
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "JS", js);
                }
            }
        }

        public class CustomCalDotNetackEventArgs : EventArgs
        {
            public string Parameters { get; set; }
        }

    }
}
