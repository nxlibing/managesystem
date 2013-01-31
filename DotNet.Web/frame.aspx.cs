using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Web.UI
{
    public partial class frame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{

            // Page.GetPostBackEventReference(Button1);

            //}1 
            if (Request.Headers["Accept"] == "*/*")
            {

                //当前
            }
        }

        protected void DotNetCustomCalDotNetack_CustomCalDotNetack(object sender, Controls.CustomCalDotNetack.DotNetCustomCalDotNetack.CustomCalDotNetackEventArgs e)
        {
           // Label1.Text = e.Parameters;
        }

        //protected void DotNetCustomCalDotNetack_CustomCalDotNetack(object sender, EventArgs e)
        //{
        //   // Label1.Text=e.
        //}
    }
}