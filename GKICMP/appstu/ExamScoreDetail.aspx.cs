/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2018年1月4日 8时46分
** 描 述:       学生手机端考试分数页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.appstu
{
    public partial class ExamScoreDetail : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Exam_StudentDAL exam_StudentDAL = new Exam_StudentDAL();
        public Exam_SubjectDAL exam_SubjectDAL = new Exam_SubjectDAL();
        public StringBuilder sb = new StringBuilder();


        #region 参数集合
        /// <summary>
        /// 考试ID
        /// </summary>
        public string EID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(EID))
                {
                    DataBand();
                }
            }
        } 
        #endregion


        #region 数据绑定
        public void DataBand()
        {
            sb.Append("<table class='table table-bordered'><tr style='text-align: center' onmouseout='backg'>");
            DataTable cid = exam_SubjectDAL.GetByEID(EID);
            if (cid != null && cid.Rows.Count > 0)
            {
                this.ltl_ExamName.Text = "【" + cid.Rows[0]["GName"].ToString() + "】【" + cid.Rows[0]["GLName"].ToString() + cid.Rows[0]["ExamName"].ToString() + "】考试成绩一览表";
                StringBuilder HtmlHeader = new StringBuilder();
                HtmlHeader.Append("<th style='text-align: center'>");
                HtmlHeader.Append("班级");
                HtmlHeader.Append("</th>");
                HtmlHeader.Append("<th style='text-align: center'>");
                HtmlHeader.Append("姓名");
                HtmlHeader.Append("</th>");
                foreach (DataRow dr in cid.Rows)
                {
                    HtmlHeader.Append("<th style='text-align: center'>");
                    HtmlHeader.Append(dr["CourseName"]);
                    HtmlHeader.Append("</th>");
                }
                HtmlHeader.Append("<th style='text-align: center'>");
                HtmlHeader.Append("总分");
                HtmlHeader.Append("</th>");
                HtmlHeader.Append("<th style='text-align: center'>");
                HtmlHeader.Append("平均分");
                HtmlHeader.Append("</th>");
                sb.Append(HtmlHeader.ToString());
                sb.Append("</tr>");
                //this.ltl_Header.Text = HtmlHeader.ToString();
            }

            DataTable stu = exam_StudentDAL.GetMyStuByEid(int.Parse(EID), UserID);
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
                    for (int i = 0; i < cid.Rows.Count; i++)
                    {
                        HtmlHeader.Append("<td align='center'>");
                        HtmlHeader.Append(dr["Score" + cid.Rows[i]["SubCode"]].ToString());
                        HtmlHeader.Append("</td>");
                    }
                    HtmlHeader.Append("<td align='center'>");
                    HtmlHeader.Append(dr["zf"]);
                    HtmlHeader.Append("</td>");
                    HtmlHeader.Append("<td align='center'>");
                    HtmlHeader.Append(Math.Round((decimal.Parse(dr["zf"].ToString()) / cid.Rows.Count), 2));

                    HtmlHeader.Append("</tr>");
                }
                DataTable dt = (DataTable)Cache.Get("Score" + EID);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    CacheInsert(cid, stu);
                }
                //this.ltl_Rows.Text = HtmlHeader.ToString();
                sb.Append(HtmlHeader.ToString());
            }
            sb.Append("</table>");
            this.ltl_Header.Text = sb.ToString();
        } 
        #endregion


        /// <summary>
        /// 将考试成绩存入缓存
        /// </summary>
        /// <param name="dttitle">table列名</param>
        /// <param name="dtdata">table行数据</param>
        public void CacheInsert(DataTable dttitle, DataTable dtdata)
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
                    list.Add((Math.Round((decimal.Parse(dr["zf"].ToString()) / dttitle.Rows.Count), 2).ToString()));
                    //list.Add(dr["bjpm"].ToString());
                    //list.Add(dr["pm"].ToString());
                    dt.Rows.Add(list.ToArray());
                }
                Cache.Insert("Score" + EID, dt, null, DateTime.Now.AddMinutes(1), System.Web.Caching.Cache.NoSlidingExpiration);
            }
        }
    }
}