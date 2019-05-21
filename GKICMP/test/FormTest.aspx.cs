using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.test
{
    public partial class FormTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int)); 
                dt.Columns.Add("姓名", typeof(string));   //新建第一列
                dt.Columns.Add("语文", typeof(int));      //新建第二列
                dt.Columns.Add("数学", typeof(int));
                dt.Rows.Add(1,"张三", 70,65);               //新建第一行，并赋值
                dt.Rows.Add(2,"李四", 65,88);               //新建第二行，并赋值
                dt.Rows.Add(3,"王二", 90, 95);
                this.rpt_List.DataSource = dt;
                this.rpt_List.DataBind();
            }
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            TextBox tb1; TextBox tb2; HiddenField hftid;
            string ids=""; string tid="";
            for (int i = 0; i < rpt_List.Items.Count; i++) 
            {
                tb1 = rpt_List.Items[i].FindControl("txt_CJ1") as TextBox;
                tb2 = rpt_List.Items[i].FindControl("txt_CJ2") as TextBox;
                hftid = (HiddenField)rpt_List.Items[i].FindControl("hf_TID");
                tid += hftid.Value + ",";
                ids += tb1.Text == "" ? "0" : tb1.Text + "," + tb2.Text == "" ? "0" : tb2.Text + "|";
            }
            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('【"+tid+"】，【"+ids+"】！');", true);
        }
    }
}