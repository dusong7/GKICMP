/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月7日 18时04分
** 描 述:       代课安排
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;

namespace GKICMP.educationals
{
    public partial class AbsentEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveDAL leaveDAL = new LeaveDAL();
        public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public AbsentDAL absentDAL = new AbsentDAL();
        public static string EYear;
        public static int term;



        #region 参数集合
        public string LID
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
                if (LID != "")
                {
                    GetTerm(out EYear, out term);
                    GetSchedule();
                }
            }
        }
        #endregion



        #region 获取请假信息
        public string GetLeaveInfo(int i)
        {
            string data = "";
            string week = i == 0 ? "" : i == 1 ? "Monday" : i == 2 ? "Tuesday" : i == 3 ? "Wednesday" : i == 4 ? "Thursday" : i == 5 ? "Friday" : i == 6 ? "Saturday" : "Sunday";
            LeaveEntity model = leaveDAL.GetObjByID(LID);
            if (model != null)
            {
                DateTime begin = Convert.ToDateTime(model.BeginDate.ToString("yyyy-MM-dd"));
                DateTime end = Convert.ToDateTime(model.EndDate.ToString("yyyy-MM-dd"));
                TimeSpan ts = end - begin;

                for (int j = 0; j <= ts.Days; j++)
                {
                    string weekstr = begin.DayOfWeek.ToString();
                    if (begin.DayOfWeek.ToString() == week)
                    {
                        data += begin.ToString("MM" + "月" + "dd" + "日") + " ";
                    }
                    begin = begin.AddDays(1);
                }
            }
            return data;
        }
        #endregion



        #region 获取请假人的课表
        public void GetSchedule()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                DataTable dt = absentDAL.GetByLeave(LID, term, (int)CommonEnum.IsorNot.否, EYear);
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
                        //WeekDays = 7;
                        SWnum = smodel.MorningPitch;
                        XWnum = smodel.AfterPitch;
                        WSnum = smodel.EveningPitch;
                    }

                    string[] arryStr = new string[] { "", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
                    str.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' class='tb'>");
                    str.Append("<tr>");
                    for (int i = 0; i <= WeekDays; i++)
                    {
                        str.AppendFormat("<th>{0}</th>", arryStr[i].ToString() + "<br>" + GetLeaveInfo(i));
                    }
                    str.Append("</tr>");


                    for (int j = 1; j <= (WSnum + SWnum + XWnum); j++)
                    {
                        str.Append("<tr>");
                        for (int k = 0; k <= WeekDays; k++)
                        {
                            string aa = "";
                            string tid = "";
                            string data = "";
                            int cid = 0;
                            int did = 0;
                            int states = 0;
                            string pos = k + "0" + j;
                            strGet(pos, dt, out aa, out tid, out data, out cid, out did, out states);
                            if (k == 0)
                            {
                                str.AppendFormat("<th>第{0}节课</th>", j.ToString());
                            }
                            else
                            {
                                if (aa == "")
                                {
                                    str.AppendFormat("<td>{0}</td>", aa);
                                }
                                else
                                {
                                    if (states == 2)
                                    {
                                        str.AppendFormat("<td class='states2' onContextMenu=\"TX(2)\">{0}</td>", aa);
                                    }
                                    if (states == 3)
                                    {
                                        str.AppendFormat("<td class='states1' onContextMenu=\"TX(3)\">{0}</td>", aa);
                                    }
                                    if (states == 1)
                                    {
                                        str.AppendFormat("<td tid=\"{0}\" data=\"{1}\" pos=\"{2}\" cid=\"{3}\" did=\"{4}\" lid=\"{5}\" uid=\"{6}\" onContextMenu=\"showteacher(this)\">{7}</td>", tid, data, pos, cid, did, LID, UserID, aa);
                                    }
                                }
                            }
                        }
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    this.dv1.Visible = true;
                    this.lbl_Name.Text = dt.Rows[0]["TeacherRepeat"].ToString() + "共" + dt.Rows.Count + "节课";
                    this.lbl_SC.Text = str.ToString();
                }
                else
                {
                    this.lbl_SC.Text = " <div class=\"datanone\">抱歉！当前老师暂无课表信息</div>";
                }
            }
            catch (Exception ex)
            {
                string aa = ex.Message;
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
        public void strGet(string position, DataTable dt, out string aa, out string tid, out string data, out int cid, out int did, out int states)
        {
            aa = "";
            tid = "";
            data = "";
            cid = 0;
            did = 0;
            states = 0;
            string statesname = "";
            ScheduleSetEntity model = setDAL.GetObjByID();
            if (model != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Position"].ToString().Contains(position))
                    {
                        tid = dt.Rows[i]["TID"].ToString();
                        data = dt.Rows[i]["data"].ToString();
                        cid = Convert.ToInt32(dt.Rows[i]["CID"].ToString());
                        did = Convert.ToInt32(dt.Rows[i]["ClaID"].ToString());
                        states = Convert.ToInt32(dt.Rows[i]["States"].ToString());
                        //if (states == 1)
                        //{
                        //    statesname = "<br>代课人：" + dt.Rows[i]["subuserName"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;代课状态：驳回";
                        //}
                        if (states == 2)
                        {
                            statesname = "<br>代课人：" + dt.Rows[i]["subuserName"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;代课状态：申请中";
                        }
                        if (states == 3)
                        {
                            statesname = "<br>代课人：" + dt.Rows[i]["subuserName"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;代课状态：已完成";
                        }
                        aa = dt.Rows[i]["CourseRepeat"].ToString() + "<br>" + dt.Rows[i]["DepOtherName"].ToString() + statesname;
                        break;
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


        #region 刷新
        protected void btn_Freash_Click(object sender, EventArgs e)
        {
            GetTerm(out EYear, out term);
            GetSchedule();
        }
        #endregion


        #region 返回
        protected void btn_Back_Click(object sender, EventArgs e)
        {
            string aa = string.Format("<script language=javascript>window.open('AbsentManage.aspx', '_self')</script>");
            Response.Write(aa);
        }
        #endregion
    }
}