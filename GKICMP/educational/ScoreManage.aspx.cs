
/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    20177214日
** 描 述:       工作计划管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;

namespace GKICMP.educational
{
    public partial class ScoreManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Exam_StudentDAL exam_StudentDAL = new Exam_StudentDAL();
        public Exam_SubjectDAL exam_SubjectDAL = new Exam_SubjectDAL();
        #region 参数集合
        /// <summary>
        /// 考试ID
        /// </summary>
        public string EID
        {
            get
            {
                return GetQueryString<string>("eid", "");
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            this.hf_EID.Value = EID;
            DataBand();
        }
        public void DataBand()
        {
            DataTable cid = exam_SubjectDAL.GetByEID(EID);
            if (cid != null && cid.Rows.Count > 0)
            {
                StringBuilder HtmlHeader = new StringBuilder();

                HtmlHeader.Append("<td>");
                HtmlHeader.Append("班级");
                HtmlHeader.Append("</td>");

                HtmlHeader.Append("<td>");
                HtmlHeader.Append("姓名");
                HtmlHeader.Append("</td>");

               // string txt = "";
               
                foreach (DataRow dr in cid.Rows)
                {
                    HtmlHeader.Append("<td>");
                    HtmlHeader.Append(dr["CourseName"]);
                    HtmlHeader.Append("</td>");

                }
                this.ltl_Header.Text = HtmlHeader.ToString();
                //this.Literal1.Text = HtmlHeader.ToString();
            }
            DataTable stu = exam_StudentDAL.GetStuByEid(int.Parse(EID));

            //Repeater1.DataSource = stu;
            //Repeater1.DataBind();
            if (stu != null && stu.Rows.Count > 0)
            {
                StringBuilder HtmlHeader = new StringBuilder();
                foreach (DataRow dr in stu.Rows)
                {
                    HtmlHeader.Append("<tr>");
                    HtmlHeader.Append("<td align='center'>");
                    HtmlHeader.Append(dr["DepName"].ToString());
                    HtmlHeader.Append("</td>");

                    HtmlHeader.Append("<td align='center'>");
                    HtmlHeader.Append(dr["Uname"].ToString());
                    HtmlHeader.Append("</td>");
                    for (int i = 0; i < cid.Rows.Count; i++) 
                    {
                        HtmlHeader.Append("<td align='center'>");
                        //TextBox tb = new TextBox();
                        //this.td.Controls.Add(tb); 
                        HtmlHeader.Append("<input type='text' name='username' runat='server' id='txt_" + dr["STID"] + "_" + cid.Rows[i]["SubCode"] + "' Width='130px' value='" + dr["score" + cid.Rows[i]["SubCode"]].ToString()+ "' />");
                        HtmlHeader.Append("</td>");
                    }
                        HtmlHeader.Append("</tr>");
                }
                this.ltl_Rows.Text = HtmlHeader.ToString();

            }

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            List<Exam_CJ> estu = new List<Exam_CJ>();
            //TextBox hit = this.FindControl("txt_03A65789-6B1B-4935-8BBD-224ED15ABB3F_2") as TextBox;
            string username = Request["username"].ToString();
            string[] aa = username.Split(',');
            string b = this.hf_Value.Value.Replace("txt_","");
            string[] c = b.TrimEnd(',').Split(',');
            for (int i = 0; i < c.Length; i++) 
            {
                Exam_CJ model = new Exam_CJ();
                model.EID =int.Parse(EID);
                //Exam_StudentEntity model = new Exam_StudentEntity();
                string[] d = c[i].Split(':');
                string[] f = d[0].Split('_');
                model.Score = decimal.Parse(d[1] == "" ? "0" : d[1]);
                model.Code = "Score" + f[1];
                model.StID = f[0];
                estu.Add(model);
            }
            int result = exam_StudentDAL.UpdateByScore(estu);
            if (result == 0) 
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加,"添加考生成绩",UserID));
                ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('提交成功');window.location.href='ExamManage.aspx'</script>"); 
            }
            //for (int i = 0; i < c.Length; i++) 
            //{
            //    string[] d = c[i].Split(':');
            //    string[] f = d[0].Split('_');

            //}
           // string a = hit.Text;
            //Table tb = this.FindControl("tb_Right") as Table;
            //foreach (TableRow tr in tb.Rows) 
            //{
            
            //}
            //for (int i = 0; i < tb.Rows.Count; i++)
            //{

            //}
            //foreach (Control ct in this.Controls)
            //{
            //    if (ct is HtmlInputText)
            //    {
            //        ShowMessage("33");
            //    }
            //}
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExamManage.aspx",true);
        }
    }
}