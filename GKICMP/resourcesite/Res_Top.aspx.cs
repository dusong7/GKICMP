using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.resourcesite
{
    public partial class Res_Top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_FirstPage_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "window.parent.location.href= 'Res_NewMain.aspx'", true);
            //string aa = string.Format("<script language=javascript>window.open('Res_NewMain.aspx', '_self')</script>");
            //Response.Write(aa);
        }
    }
}