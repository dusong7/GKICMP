
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
using System.Web;
using System.Data;
using System.Text;
using System.Linq;
using System.Web.UI;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class ScoreAnalysis : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Exam_StudentDAL exam_StudentDAL = new Exam_StudentDAL();
        public Exam_SubjectDAL exam_SubjectDAL = new Exam_SubjectDAL();
        public StringBuilder strAll = new StringBuilder();
        public StringBuilder strPart = new StringBuilder();
        public StringBuilder strAllOut = new StringBuilder();

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


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EID))
            {
                DataBand();
            }
        }
        #endregion


        public void DataBand()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //耗时巨大的代码
            DataTable cid = exam_SubjectDAL.GetByEID(EID);

            #region 全年级班级总览
            DataTable dtscore = exam_StudentDAL.GetZH(int.Parse(EID));
            StringBuilder th = new StringBuilder();
            th.Append("<th colspan='" + (cid.Rows.Count * 2 + 4) + "' align='left'>全年级班级总览 </th>");
            /*********************导出全年级班级总览数据*********************/
            strAll.Append(@"<table width='100%' border='1' cellspacing='0' cellpadding='0' >");
            strAll.Append("<th style='color:#48bd81;height:48px;border-bottom:1px solid #3fa96b;' colspan='" + (cid.Rows.Count * 2 + 4) + "' align='left'>全年级班级总览 </th>");
            /****************************************************************/
            this.ltl_th.Text = th.ToString();

            var query = from g in dtscore.AsEnumerable()
                        group g by g["did"] into g
                        select new { did = g.Key, DName = g.Select(m => m["dname"]).First(), zg = g.Select(m => m["zg"]).First(), zd = g.Select(m => m["zd"]).First(), pj = g.Select(m => m["pj"]).First() };
            query.ToList();
            var d = query.ToList();
            if (dtscore != null && dtscore.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<tr style='color:#48bd81;height:46px;border-bottom:1px solid #3fa96b;'>");
                sb.Append("<th rowspan='2' class='gd'>");
                sb.Append("班级");
                sb.Append("</th>");
                sb.Append("<th rowspan='2'>");
                sb.Append("最高分");
                sb.Append("</th>");
                sb.Append("<th rowspan='2'>");
                sb.Append("最低分");
                sb.Append("</th>");
                sb.Append("<th rowspan='2'>");
                sb.Append("平均分");
                sb.Append("</th>");
                sb.Append("<th colspan=" + cid.Rows.Count + ">");
                sb.Append("优秀率");
                sb.Append("</th>");
                sb.Append("<th colspan=" + cid.Rows.Count + ">");
                sb.Append("合格率");
                sb.Append("</th>");
                sb.Append("</tr>");
                sb.Append("<tr style='color:#48bd81;height:46px;border-bottom:1px solid #3fa96b;'>");
                foreach (DataRow dr in cid.Rows)
                {
                    sb.Append("<th align='center' class='gd'  >");
                    sb.Append(dr["CourseName"]);
                    sb.Append("</th>");
                }
                foreach (DataRow dr in cid.Rows)
                {
                    sb.Append("<th align='center'>");
                    sb.Append(dr["CourseName"]);
                    sb.Append("</th>");
                }
                sb.Append("</tr>");
                foreach (var a in d)
                {
                    sb.Append("<tr style='height:39px;line-height:39px;border-top:#e4e4e4 1px solid;border-left:#e4e4e4 1px solid;padding-left:10px;padding-right:10px;'>");
                    sb.Append("<td  align='center'>");
                    sb.Append(a.DName);
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append(a.zg);
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append(a.zd);
                    sb.Append("</td>");
                    sb.Append("<td align='center'>");
                    sb.Append(a.pj);
                    sb.Append("</td>");
                    DataRow[] yxl = dtscore.Select("did=" + a.did);
                    foreach (DataRow dr in yxl)
                    {
                        sb.Append("<td align='center'>");
                        sb.Append(dr["优秀"]);
                        sb.Append("</td>");
                    }
                    foreach (DataRow dr in yxl)
                    {
                        sb.Append("<td align='center'>");
                        sb.Append(dr["合格"]);
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");
                }
                strAll.Append(sb.ToString());
                strAllOut.Append(strAll.ToString());
                sb.Append("<tr>");
                sb.Append("<td align='center' colspan='" + (cid.Rows.Count * 2 + 4) + "'>");
                sb.Append("<input type='button' onclick='return allgrade(1)' value='导出' class='submit' />");
                sb.Append("</td>");
                sb.Append("</tr>");
                this.ltl_zh.Text = sb.ToString();
                sw.Stop();
                TimeSpan ts2 = sw.Elapsed;
            #endregion

                #region 各班各分数段均分情况
                if (cid != null && cid.Rows.Count > 0)
                {
                    StringBuilder HtmlHeader = new StringBuilder();
                    HtmlHeader.Append("<th style='color:#48bd81;height:48px;border-bottom:1px solid #3fa96b;'>");
                    HtmlHeader.Append("班级");
                    HtmlHeader.Append("</th>");
                    foreach (DataRow dr in cid.Rows)
                    {
                        HtmlHeader.Append("<th colspan='3' style='color:#48bd81;height:48px;border-bottom:1px solid #3fa96b;'>");
                        HtmlHeader.Append(dr["CourseName"]);
                        HtmlHeader.Append("</th>");
                    }
                    strPart.Append(@"<table width='100%' border='1' cellspacing='0' cellpadding='0' >");
                    strPart.Append("<tr><th style='color:#48bd81;height:48px;border-bottom:1px solid #3fa96b;' colspan='" + (cid.Rows.Count * 3 + 1) + "' align='left'>各班各分数段均分情况</th></tr>");
                    strPart.Append("<tr>");
                    strPart.Append(HtmlHeader.ToString());
                    strPart.Append("</tr>");
                    this.ltl_Header.Text = HtmlHeader.ToString();
                }
                DataTable stu = exam_StudentDAL.GetScore(int.Parse(EID));
                StringBuilder fsd = new StringBuilder();
                fsd.Append("<th colspan='" + (cid.Rows.Count * 3 + 1) + "' align='left'>各班各分数段均分情况</th>");

                this.ltl_fsd.Text = fsd.ToString();

                if (stu != null && stu.Rows.Count > 0)
                {
                    StringBuilder HtmlHeader = new StringBuilder();
                    foreach (DataRow dr in stu.Rows)
                    {
                        HtmlHeader.Append("<tr style='height:39px;line-height:39px;border-top:#e4e4e4 1px solid;border-left:#e4e4e4 1px solid;padding-left:10px;padding-right:10px;'>");
                        HtmlHeader.Append("<td rowspan='2'>");
                        HtmlHeader.Append(dr["BJName"].ToString());
                        HtmlHeader.Append("</td>");
                        for (int i = 0; i < cid.Rows.Count; i++)
                        {
                            HtmlHeader.Append("<td >");
                            //TextBox tb = new TextBox();
                            //this.td.Controls.Add(tb); 
                            HtmlHeader.Append("前十名");
                            HtmlHeader.Append("</td>");
                            HtmlHeader.Append("<td>");
                            //TextBox tb = new TextBox();
                            //this.td.Controls.Add(tb); 
                            HtmlHeader.Append("前三十名");
                            HtmlHeader.Append("</td>");
                            HtmlHeader.Append("<td>");
                            //TextBox tb = new TextBox();
                            //this.td.Controls.Add(tb); 
                            HtmlHeader.Append("平均分");
                            HtmlHeader.Append("</td>");
                        }
                        HtmlHeader.Append("</tr>");
                        HtmlHeader.Append("<tr style='vnd.ms-excel.numberformat:0.00;height:39px;line-height:39px;border-top:#e4e4e4 1px solid;border-left:#e4e4e4 1px solid;padding-left:10px;padding-right:10px;'>");
                        for (int i = 0; i < cid.Rows.Count; i++)
                        {
                            HtmlHeader.Append("<td align='left'>");
                            HtmlHeader.Append(Math.Round(decimal.Parse(dr["s" + cid.Rows[i]["SubCode"] + "10"].ToString()), 2).ToString());
                            HtmlHeader.Append("</td>");
                            HtmlHeader.Append("<td align='left'>");
                            HtmlHeader.Append(Math.Round(decimal.Parse(dr["s" + cid.Rows[i]["SubCode"] + "30"].ToString()), 2).ToString());
                            HtmlHeader.Append("</td>");
                            HtmlHeader.Append("<td align='left'>");
                            HtmlHeader.Append(Math.Round(decimal.Parse(dr["s" + cid.Rows[i]["SubCode"]].ToString()), 2).ToString());
                            HtmlHeader.Append("</td>");
                        }
                        HtmlHeader.Append("</tr>");
                    }
                    strPart.Append(HtmlHeader.ToString());
                    strAllOut.Append(strPart.ToString());
                    HtmlHeader.Append("<tr>");
                    HtmlHeader.Append("<td align='center' colspan='" + (cid.Rows.Count * 3 + 1) + "'>");
                    HtmlHeader.Append("<input type='button' onclick='return allgrade(2)' value='导出' class='submit' />");
                    HtmlHeader.Append("</td>");
                    HtmlHeader.Append("</tr>");

                    this.ltl_Rows.Text = HtmlHeader.ToString();
                }
                #endregion

                #region 全年级排名各班人数情况
                DataTable dtlist = exam_StudentDAL.GetList(int.Parse(EID));
                if (dtlist != null && dtlist.Rows.Count > 0)
                {
                    this.rp_List.DataSource = dtlist;
                    this.rp_List.DataBind();
                }
                #endregion
            }
        }

        #region 全年级班级成绩总览
        protected void btn_AllGrade_Click(object sender, EventArgs e)
        {
            CommonFunction.ExportExcel("全年级班级成绩总览", strAll.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出全年级班级成绩总览信息", UserID));
        }
        #endregion


        #region 各班各分数段均分情况
        protected void btn_PartGrade_Click(object sender, EventArgs e)
        {
            CommonFunction.ExportExcel("各班各分数段均分情况", strPart.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出各班各分数段均分情况信息", UserID));
        }
        #endregion


        #region 全年级排名各班人数情况
        protected void lbtn_OutPut_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            DataTable dtlist = exam_StudentDAL.GetList(int.Parse(EID));
            if (dtlist == null && dtlist.Rows.Count == 0)
            {
                ShowMessage("暂无数据导出！");
                return;
            }

            str.Append(@"<table width='100%' border='1' cellspacing='0' cellpadding='0' class='listinfo' >
                    <tr><th colspan='10' align='left' style='height:46px;color:#48bd81;border-bottom:1px solid #3fa96b;line-height:46px;border-top:#e4e4e4 1px solid;border-left:#e4e4e4 1px solid;'>全年级排名各班人数情况</th></tr>
                        <tr style='text-align: center;height:46px;color:#48bd81;border-bottom:1px solid #3fa96b;line-height:46px;border-top:#e4e4e4 1px solid;border-left:#e4e4e4 1px solid;'>
                            <th align='center'>班级</th>
                            <th align='center'>1-10名</th>
                            <th align='center'>11-20名</th>
                            <th align='center'>21-30名</th>
                            <th align='center'>31-50名</th>
                            <th align='center'>51-100名</th>
                            <th align='center'>101-200名</th>
                            <th align='center'>201-300名</th>
                            <th align='center'>>301名</th>
                            <th align='center'>总人数</th>    
                        </tr>");
            if (dtlist != null && dtlist.Rows.Count > 0)
            {
                foreach (DataRow row in dtlist.Rows)
                {
                    str.Append("<tr style='line-height:39px;height:39px;border-top:#e4e4e4 1px solid;border-left:#e4e4e4 1px solid;padding-left:10px;padding-right:10px;'>");
                    str.AppendFormat("<td align='center'>{0}</td>", row["BJName"]);
                    str.AppendFormat("<td align='center'>{0}</td>", row["S10"]);
                    str.AppendFormat("<td align='center'>{0}</td>", row["S20"]);
                    str.AppendFormat("<td align='center'>{0}</td>", row["S30"]);
                    str.AppendFormat("<td align='center'>{0}</td>", row["S50"]);
                    str.AppendFormat("<td align='center'>{0}</td>", row["S100"]);
                    str.AppendFormat("<td align='center'>{0}</td>", row["S200"]);
                    str.AppendFormat("<td align='center'>{0}</td>", row["S300"]);
                    str.AppendFormat("<td align='center'>{0}</td>", row["QT"]);
                    str.AppendFormat("<td align='center'>{0}</td>", row["ZRS"]);
                    str.Append("</tr>");
                }
            }

            CommonFunction.ExportExcel("全年级排名各班人数情况", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出全年级排名各班人数情况信息", UserID));
        }
        #endregion


        #region 全部导出功能
        protected void btn_AllOut_Click(object sender, EventArgs e)
        {
            DataTable dtlist = exam_StudentDAL.GetList(int.Parse(EID));
            if (dtlist == null && dtlist.Rows.Count == 0)
            {
                ShowMessage("暂无数据导出！");
                return;
            }

            strAllOut.Append(@"<table width='100%' border='1' cellspacing='0' cellpadding='0' class='listinfo' >
                    <tr><th colspan='10' align='left' style='height:46px;color:#48bd81;border-bottom:1px solid #3fa96b;line-height:46px;border-top:#e4e4e4 1px solid;border-left:#e4e4e4 1px solid;'>全年级排名各班人数情况</th></tr>
                        <tr style='text-align: center;height:46px;color:#48bd81;border-bottom:1px solid #3fa96b;line-height:46px;border-top:#e4e4e4 1px solid;border-left:#e4e4e4 1px solid;'>
                            <th align='center'>班级</th>
                            <th align='center'>1-10名</th>
                            <th align='center'>11-20名</th>
                            <th align='center'>21-30名</th>
                            <th align='center'>31-50名</th>
                            <th align='center'>51-100名</th>
                            <th align='center'>101-200名</th>
                            <th align='center'>201-300名</th>
                            <th align='center'>>301名</th>
                            <th align='center'>总人数</th>    
                        </tr>");
            if (dtlist != null && dtlist.Rows.Count > 0)
            {
                foreach (DataRow row in dtlist.Rows)
                {
                    strAllOut.Append("<tr style='line-height:39px;height:39px;border-top:#e4e4e4 1px solid;border-left:#e4e4e4 1px solid;padding-left:10px;padding-right:10px;'>");
                    strAllOut.AppendFormat("<td align='center'>{0}</td>", row["BJName"]);
                    strAllOut.AppendFormat("<td align='center'>{0}</td>", row["S10"]);
                    strAllOut.AppendFormat("<td align='center'>{0}</td>", row["S20"]);
                    strAllOut.AppendFormat("<td align='center'>{0}</td>", row["S30"]);
                    strAllOut.AppendFormat("<td align='center'>{0}</td>", row["S50"]);
                    strAllOut.AppendFormat("<td align='center'>{0}</td>", row["S100"]);
                    strAllOut.AppendFormat("<td align='center'>{0}</td>", row["S200"]);
                    strAllOut.AppendFormat("<td align='center'>{0}</td>", row["S300"]);
                    strAllOut.AppendFormat("<td align='center'>{0}</td>", row["QT"]);
                    strAllOut.AppendFormat("<td align='center'>{0}</td>", row["ZRS"]);
                    strAllOut.Append("</tr>");
                }
            }

            CommonFunction.ExportExcel("成绩分析总数据", strAllOut.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出成绩分析总数据信息", UserID));
        }
        #endregion
    }
}