using GK.GKICMP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.test
{
    public partial class Location : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //long jsTimeStamp = 1512356801560;
                //System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                //DateTime dt = startTime.AddMilliseconds(jsTimeStamp);
                //Response.Write(dt.ToString());
                //Response.End();
                //System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                //long lTime = 1512316800000 * 10000;
                //TimeSpan nowTimeSpan = new TimeSpan(lTime);
                //DateTime resultDateTime = startTime.Add(nowTimeSpan);
               
            }
        }
        protected void lbtn_example_Click(object sender, EventArgs e)
        {
            //string expath = @"~\Template\EducationImportTemplate.xls";
            //if (!CommonFunction.UpLoadFunciotn(expath, "学历导入模板"))
            //{
            //    //ShowMessage("模板文件不存在，请联系系统管理员");
            //    return;
            //}
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            long jsTimeStamp = long.Parse(this.TextBox1.Text);
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddMilliseconds(jsTimeStamp);
            this.Literal1.Text = dt.ToString();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示！');</script>");
        }
    }
}