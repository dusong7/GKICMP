
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

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using System.Text;
using System.Web.Caching;

namespace GKICMP.educational
{
    public partial class ScoreDetail : PageBase
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
           // this.hf_EID.Value = EID;
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(EID))
                {
                    DataBand();
                }
            }
        }
        public void DataBand()
        {
           
            DataTable cid = exam_SubjectDAL.GetByEID(EID);
            if (cid != null && cid.Rows.Count > 0)
            {
                this.ltl_ExamName.Text = "【" + cid.Rows[0]["GName"].ToString() + "】【" + cid.Rows[0]["GLName"].ToString() + cid.Rows[0]["ExamName"].ToString() + "】考试成绩一览表";
                StringBuilder HtmlHeader = new StringBuilder();
                HtmlHeader.Append("<th align='center'>");
                HtmlHeader.Append("班级");
                HtmlHeader.Append("</th>");
             
                HtmlHeader.Append("<th align='center'>");
                HtmlHeader.Append("姓名");
                HtmlHeader.Append("</th>");
              
                // string txt = "";

                foreach (DataRow dr in cid.Rows)
                {
                    HtmlHeader.Append("<th align='center'>");
                    HtmlHeader.Append(dr["CourseName"]);
                    HtmlHeader.Append("</th>");
                  

                }
                HtmlHeader.Append("<th align='center'>");
                HtmlHeader.Append("总分");
                HtmlHeader.Append("</th>");
              
                HtmlHeader.Append("<th align='center'>");
                HtmlHeader.Append("平均分");
                HtmlHeader.Append("</th>");
            
                HtmlHeader.Append("<th align='center'>");
                HtmlHeader.Append("班级排名");
                HtmlHeader.Append("</th>");
              
                HtmlHeader.Append("<th align='center'>");
                HtmlHeader.Append("年级排名");
                HtmlHeader.Append("</th>");
               
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
                    HtmlHeader.Append("<tr >");
                    HtmlHeader.Append("<td align='center'>");
                    HtmlHeader.Append(dr["DepName"].ToString());
                   

                    HtmlHeader.Append("</td>");
                    HtmlHeader.Append("<td align='center'>");
                    HtmlHeader.Append(dr["Uname"].ToString());
                    HtmlHeader.Append("</td>");
                    decimal avg = 0;
                    for (int i = 0; i < cid.Rows.Count; i++)
                    {
                        HtmlHeader.Append("<td align='center'>");
                        //TextBox tb = new TextBox();
                        //this.td.Controls.Add(tb); 
                        HtmlHeader.Append(dr["Score"+cid.Rows[i]["SubCode"]].ToString());
                        HtmlHeader.Append("</td>");
                        //
                    
                    }
                    if(cid.Rows.Count!=0)
                        avg = Math.Round((decimal.Parse(dr["zf"].ToString()) / cid.Rows.Count), 2);
                    HtmlHeader.Append("<td align='center'>");
                    HtmlHeader.Append(dr["zf"] );
                    HtmlHeader.Append("</td>");
                    HtmlHeader.Append("<td align='center'>");
                    HtmlHeader.Append(avg);
                    HtmlHeader.Append("</td>");
                    HtmlHeader.Append("<td align='center'>");
                    HtmlHeader.Append(dr["bjpm"]);
                    HtmlHeader.Append("</td>");
                    HtmlHeader.Append("<td align='center'>");
                    HtmlHeader.Append(dr["pm"]);
                    HtmlHeader.Append("</td>");
                   
                    HtmlHeader.Append("</tr>");
                  
                }
                DataTable dt = (DataTable)Cache.Get("Score" + EID);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    CacheInsert(cid, stu);
                }
               // Cache.Insert("Score", dt, null, DateTime.Now.AddMinutes(20), System.Web.Caching.Cache.NoSlidingExpiration);
               
                this.ltl_Rows.Text = HtmlHeader.ToString();

            }

        }
        /// <summary>
        /// 将考试成绩存入缓存
        /// </summary>
        /// <param name="dttitle">table列名</param>
        /// <param name="dtdata">table行数据</param>
        public void CacheInsert(DataTable dttitle ,DataTable dtdata)
        {
            DataTable dt = new DataTable();
            if (dttitle != null && dttitle.Rows.Count > 0)
            {
                dt.Columns.Add("班级", typeof(string));
                dt.Columns.Add("姓名", typeof(string));
                foreach (DataRow dr in dttitle.Rows)
                {
                    dt.Columns.Add(dr["CourseName"].ToString(), typeof(string));
                }
                dt.Columns.Add("总分", typeof(string));
                dt.Columns.Add("平均分", typeof(string));
                dt.Columns.Add("班级排名", typeof(string));
                dt.Columns.Add("年级排名", typeof(string));
            }
            if (dtdata != null && dtdata.Rows.Count > 0)
            {
               
                foreach (DataRow dr in dtdata.Rows)
                {
                    List<string> list = new List<string>();
                    list.Add(dr["DepName"].ToString());
                    list.Add(dr["Uname"].ToString());
                    for (int i = 0; i < dttitle.Rows.Count; i++)
                    {
                        list.Add(dr["Score" + dttitle.Rows[i]["SubCode"]].ToString());
                    }
                    list.Add(dr["zf"].ToString());
                    if (dttitle.Rows.Count != 0)
                        list.Add((Math.Round((decimal.Parse(dr["zf"].ToString()) / dttitle.Rows.Count), 2).ToString()));                    
                    list.Add(dr["bjpm"].ToString());
                    list.Add(dr["pm"].ToString());
                    dt.Rows.Add(list.ToArray());
                }
                Cache.Insert("Score" + EID, dt, null, DateTime.Now.AddMinutes(1), System.Web.Caching.Cache.NoSlidingExpiration);
            }
        }

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Cache.Get("Score" + EID);
            if (dt != null && dt.Rows.Count > 0)
            {
                CommonFunction.ExportByWeb(dt, this.ltl_ExamName.Text, this.ltl_ExamName.Text + ".xls");
            }
            else 
            {
                DataTable subject = exam_SubjectDAL.GetByEID(EID);
                DataTable stu = exam_StudentDAL.GetStuByEid(int.Parse(EID));
                if (subject == null || subject.Rows.Count <= 0 || stu == null || stu.Rows.Count <= 0)
                {
                    ShowMessage("暂无信息导出，请先添加成绩");
                    return;
                }
                CacheInsert(exam_SubjectDAL.GetByEID(EID), exam_StudentDAL.GetStuByEid(int.Parse(EID)));
                dt = (DataTable)Cache.Get("Score" + EID);
                CommonFunction.ExportByWeb(dt, this.ltl_ExamName.Text, this.ltl_ExamName.Text + ".xls");
            }
        }
    }
}