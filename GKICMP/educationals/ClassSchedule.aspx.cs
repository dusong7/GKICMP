/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月8日 18时04分
** 描 述:       班级课表管理
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;
using System.Text;

namespace GKICMP.educationals
{
    public partial class ClassSchedule : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public static string EYear;
        public static int term;


        #region 班级ID
        /// <summary>
        /// 班级ID
        /// </summary>
        public int ClaID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        public int DepID
        {
            get
            {
                return GetQueryString<int>("deep", -1);
            }
        }
        #endregion


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ClaID != -1 && DepID != 0)
                {
                    GetTerm(out EYear, out term);
                    DepartmentEntity model = departmentDAL.GetObj(ClaID);
                    if (model != null)
                    {
                        this.ltl_NowClass.Text = model.OtherName;
                        this.lblclass.Text = model.OtherName + "班";
                    }
                    this.lbl.Text = DataBindList();
                }
                else
                {
                    this.ltl_NowClass.Text = this.lblclass.Text = "暂无数据";
                }
            }
        }
        #endregion


        #region 数据绑定
        public string DataBindList()
        {
            StringBuilder str = new StringBuilder();
            int WeekDays = 0;
            int SWnum = 0;
            int XWnum = 0;
            int WSnum = 0;
            ScheduleSetEntity smodel = setDAL.GetObjByID();//获取基础设置信息
            if (smodel != null)
            {
                WeekDays = smodel.CourseDay;
                SWnum = smodel.MorningPitch;
                XWnum = smodel.AfterPitch;
                WSnum = smodel.EveningPitch;
            }
            string sql1 = " and ClaID=" + ClaID + " and Isdel=0 and EYear='" + EYear + "' and Term=" + term + " order by Position";
            DataTable dt1 = scourseDAL.GetAllScheduleCourseByWhere(sql1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                string[] arryStr = new string[] { "", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
                str.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' class='content' height='" + ((SWnum + XWnum + WSnum) * 80 + 40) + "' >");
                str.Append("<tr>");
                for (int i = 0; i <= WeekDays; i++)
                {
                    if (i == 0)
                    {
                        str.AppendFormat("<th style='width:5%;height:10%;'>{0}</th>", arryStr[i].ToString());
                    }
                    else
                    {
                        str.AppendFormat("<th style='width:" + (95 / WeekDays).ToString() + "%;height:10%;'>{0}</th>", arryStr[i].ToString());
                    }
                }
                str.Append("</tr>");
                for (int a = 1; a <= WSnum + SWnum + XWnum; a++)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td class='contd1' style='height:" + (90 / (SWnum + XWnum + WSnum)).ToString() + "%'>{0}</td>", "第" + a.ToString() + "节课");
                    for (int c = 1; c <= WeekDays; c++)
                    {
                        string tid = "";
                        string position = c + "0" + a;
                        string aa = "";
                        strGet(c + "0" + a, dt1, out tid, 1, out aa);
                        if (aa == "无课")
                        {
                            str.AppendFormat("<td id=\"{1}\"  class='contd3'>{0}</td>", aa, position);
                        }
                        if (aa == "")
                        {
                            str.AppendFormat("<td id=\"{3}\" onContextMenu='showadd({1},{2});'>{0}</td>", aa, ClaID, position, position);
                        }
                        if (aa != "" && aa != "无课")
                        {
                            str.AppendFormat("<td id=\"{1}\"  onclick=\"CellText(this.innerHTML)\">{0}</td>", aa, position);
                        }
                    }
                    str.Append("</tr>");
                }
                str.Append("</table>");

                string sql2 = " and ClaID=" + ClaID + " and Isdel=1 and EYear='" + EYear + "' and Term=" + term + " order by Position";
                DataTable dt2 = scourseDAL.GetAllScheduleCourseByWhere(sql2);
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    this.padbot.Visible = true;
                }
                else
                {
                    this.padbot.Visible = false;
                }
                rp_List.DataSource = dt2;
                rp_List.DataBind();
                return str.ToString();
            }
            else
            {
                this.btn_OutPut.Visible = false;
                this.btn_Print.Visible = false;
                return " <div class=\"datanone\">抱歉！当前班级暂无课表信息</div>"; ;
            }
        }
        #endregion


        #region 导出
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                string sql = " and ClaID=" + ClaID + " and Isdel=0 and EYear='" + EYear + "' and Term=" + term + " order by Position";
                DataTable dt = scourseDAL.GetAllScheduleCourseByWhere(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int WeekDays = 0;
                    int SWnum = 0;
                    int XWnum = 0;
                    int WSnum = 0;
                    ScheduleSetEntity smodel = setDAL.GetObjByID();//获取基础设置信息
                    if (smodel != null)
                    {
                        WeekDays = smodel.CourseDay;
                        SWnum = smodel.MorningPitch;
                        XWnum = smodel.AfterPitch;
                        WSnum = smodel.EveningPitch;
                    }
                    string[] arryStr = new string[] { "", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
                    str.Append("<table border='1' cellpadding='0' cellspacing='0'>");
                    for (int a = 0; a <= SWnum + XWnum + WSnum; a++)
                    {
                        if (a == 0)
                        {
                            str.Append("<tr>");
                            for (int i = 0; i <= WeekDays; i++)
                            {
                                str.AppendFormat("<th>{0}</th>", arryStr[i].ToString());
                            }

                            str.Append("</tr>");
                        }
                        else
                        {
                            str.Append("<tr>");
                            str.AppendFormat("<td style='text-align:center;'>第{0}节课</td>", a);
                            for (int c = 1; c <= WeekDays; c++)
                            {
                                string tid = "";
                                string position = c + "0" + a;
                                string aa = "";
                                strGet(c + "0" + a, dt, out tid, 2, out aa);
                                str.AppendFormat("<td style='text-align:center;'>{0}</td>", aa);
                            }
                            str.Append("</tr>");
                        }
                    }
                    str.Append("</table>");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出" + this.ltl_NowClass.Text + "课表", UserID));
                    CommonFunction.ExportExcel("班级\"" + this.ltl_NowClass.Text + "\"课表", str.ToString());
                }
                else
                {
                    ShowMessage("暂无数据导出");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 判断该位置是否有课
        /// <summary>
        /// 判断该位置是否有课
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public void strGet(string position, DataTable dt, out string tid, int flag, out string aa)
        {
            aa = "";
            tid = "";
            ScheduleSetEntity model = setDAL.GetObjByID();
            if (model != null && model.NoTimetable != "")
            {
                int id = Array.IndexOf(model.NoTimetable.ToString().Split('|'), position);
                if (id == -1)    //不存在
                {
                    DataRow[] dr = dt.Select("Position ='" + position + "'");
                    if (dr.Length > 0)
                    {
                        tid = dr[0]["TID"].ToString();
                        if (flag == 1)
                        {
                            aa = dr[0]["CourseRepeat"].ToString() + "<br>" + "<span style='color:red;margin-right: 0px;'>" + dr[0]["TeacherRepeat"].ToString() + "</span>" + (dr[0]["CRIDName"].ToString() == "" ? "" : "<br>" + dr[0]["CRIDName"].ToString()) + "<label style='display:none;'>:a:c" + dr[0]["SCID"].ToString() + ":b:c</label>";
                        }
                        else
                        {
                            aa = dr[0]["CourseRepeat"].ToString() + "<br>(" + dr[0]["TeacherRepeat"].ToString() + ")" + (dr[0]["CRIDName"].ToString() == "" ? "" : "<br>" + dr[0]["CRIDName"].ToString());
                        }
                    }
                    else
                    {
                        aa = "";
                    }
                }
                else
                {
                    aa = "无课";
                }
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow[] dr = dt.Select("Position ='" + position + "'");
                    if (dr.Length > 0)
                    {
                        tid = dr[0]["TID"].ToString();
                        if (flag == 1)
                        {
                            aa = dr[0]["CourseRepeat"].ToString() + "<br>" + "<span style='color:red;margin-right: 0px;'>" + dr[0]["TeacherRepeat"].ToString() + "</span>" + (dr[0]["CRIDName"].ToString() == "" ? "" : "<br>" + dr[0]["CRIDName"].ToString()) + "<label style='display:none;'>:a:c" + dr[0]["SCID"].ToString() + ":b:c</label>";
                        }
                        else
                        {
                            aa = dr[0]["CourseRepeat"].ToString() + "<br>(" + dr[0]["TeacherRepeat"].ToString() + ")" + (dr[0]["CRIDName"].ToString() == "" ? "" : "<br>" + dr[0]["CRIDName"].ToString());
                        }
                    }
                    else
                    {
                        aa = "";
                    }
                }
            }
        }
        #endregion


        #region 获取当前学期
        private static void GetTerm(out string EYear, out int term)
        {
            EYear = "";
            term = 0;
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            if (month < 8 && month >= 2)
            {
                EYear = (year - 1) + "-" + year;
                term = (int)CommonEnum.XQ.下学期;
            }
            else
            {
                if (month <= 12 && month >= 8)
                {
                    EYear = year + "-" + (year + 1);
                }
                else
                {
                    EYear = (year - 1) + "-" + year;
                }
                term = (int)CommonEnum.XQ.上学期;
            }
        }
        #endregion
    }
}