/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月8日 18时04分
** 描 述:       我的课表管理(学生)
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

namespace GKICMP.appstu
{
    public partial class MyCourseList : PageBaseApp
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public static string EYear;
        public static int term;


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
                GetTerm(out EYear, out term);
                LoadClassSchedule();
            }
        }
        #endregion


        #region 班级排课信息加载
        /// <summary>
        /// 班级排课信息加载
        /// </summary>
        public void LoadClassSchedule()
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
            string[] arryStr = new string[] { "周一", "周二", "周三", "周四", "周五", "周六", "周日" };
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table table-bordered'><thead><tr>");
            for (int b = 0; b < WeekDays + 1; b++)
            {
                if (b == 0)
                {
                    str.Append("<th style='width:2%;text-align:center;'></th>");
                }
                else
                {
                    str.AppendFormat("<th style='width:" + (98 / WeekDays) / 100 + ";text-align:center;'>{0}</th>", arryStr[b - 1]);
                }
            }
            str.Append("</tr></thead>");
            str.Append("<tbody>");
            string sql = " and ClaID=(select DepID from Tb_SysUser where UID='" + UserID + "') and Term=" + term + " and EYear='" + EYear + "' and Isdel=0";
            DataTable dt = scourseDAL.GetAllScheduleCourseByWhere(sql);
            for (int a = 1; a <= (SWnum + XWnum + WSnum); a++)
            {
                str.Append("<tr>");
                for (int c = 0; c <= WeekDays; c++)
                {
                    string aa = "";
                    if (c == 0)
                    {
                        str.AppendFormat("<th style='text-align:center;'>{0}</th>", a.ToString());
                    }
                    else
                    {
                        strGet(dt, c * 100 + a, out aa);
                        str.AppendFormat("<td style='text-align:center;font-size:12px;'>{0}</td>", aa);
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</tbody>");
            str.Append("</table>");
            this.lbl.Text = str.ToString();
        }
        #endregion


        #region 判断是否存在
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public void strGet(DataTable dt, int position, out string aa)
        {
            aa = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] dr = dt.Select(" position=" + position + "");
                if (dr.Length > 0)
                {
                    aa = dr[0]["CourseRepeat"].ToString() + "<br>" + dr[0]["DepOtherName"].ToString().Replace("（", "(").Replace("）", ")");
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