/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月8日 18时04分
** 描 述:       调课显示管理
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

namespace GKICMP.educationals
{
    public partial class SelectCourse : PageBase
    {
        public GradeDAL gradeDAL = new GradeDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public static string EYear;
        public static int term;

        #region 参数集合
        public string SCID
        {
            get
            {
                return GetQueryString<string>("scid", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTerm(out EYear, out term);
                this.hf_scid.Value = SCID.ToString();
                this.hf_UserID.Value = UserID.ToString();
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
            string[] arryStr = new string[] { "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };

            this.tab.Height = ((4 + 4 + 2) * 35 + 40);
            this.tab.Width = (6 * 100 + 20);

            for (int a = 0; a <= (SWnum + XWnum + WSnum); a++)
            {
                TableRow myRow = new TableRow();
                if (a == 0)
                {
                    for (int b = 0; b < WeekDays + 1; b++)
                    {
                        TableCell myCell = new TableCell();
                        if (b == 0)
                        {
                            myCell.Text = "";
                        }
                        else
                        {
                            myCell.Text = arryStr[b - 1];
                        }
                        myRow.Cells.Add(myCell);
                    }
                }
                else
                {
                    for (int c = 0; c < WeekDays + 1; c++)
                    {
                        TableCell myCell = new TableCell();
                        if (c == 0)
                        {
                            myCell.Text = "第" + a + "节课";
                        }
                        else
                        {
                            //根据课程表ID从课程表中获取选取的课程信息
                            string sql0 = " and SCID='" + SCID + "'";
                            DataTable dt0 = scourseDAL.GetAllScheduleCourseByWhere(sql0);
                            //如果是被选中的课程，标记为红色
                            string kb = LoadClassScheduleData(a, c);
                            if (kb.Contains(dt0.Rows[0][8].ToString() + " ") || kb.Contains("已有课"))
                            {
                                if (kb.Contains("已有课"))
                                {
                                    myCell.Text = "<label style='color:gray; '>" + kb.Replace("连续", "") + "</label>";
                                }
                                else
                                {
                                    myCell.Text = "<label style='color:red; '>" + kb.Replace("连续", "") + "</label>";
                                }
                            }
                            else
                            {
                                if (kb != "无课")
                                {
                                    myCell.Text = "<label style='color:green; '>" + kb.Replace("连续", "") + "</label>";
                                    myCell.Attributes.Add("onmouseover", "this.style.background='#C4C6C8'");
                                    myCell.Attributes.Add("onmouseout", "this.style.background=''");
                                    myCell.Attributes.Add("onclick", "CellText1(this.innerHTML);");
                                }
                                else
                                {
                                    myCell.Attributes.CssStyle.Add("background", "#ef5d5d");
                                    myCell.Attributes.CssStyle.Add("color", "#fff");
                                    myCell.Text = "<label >" + kb.Replace("连续", "") + "</label>";
                                }
                            }

                        }
                        myRow.Cells.Add(myCell);
                    }
                }
                tab.Rows.Add(myRow);
            }
        }
        #endregion


        #region 班级排课数据加载
        /// <summary>
        /// 班级排课数据加载
        /// </summary>
        /// <param name="a">节</param>
        /// <param name="b">星期</param>
        /// <returns></returns>
        public string LoadClassScheduleData(int a, int b)
        {
            string str = "";
            //根据课程表ID从课程表中获取选取的课程信息
            string sql0 = " and SCID='" + SCID + "'";
            DataTable dt0 = scourseDAL.GetAllScheduleCourseByWhere(sql0);
            if (dt0 != null)
            {
                this.ltl_NowClass.Text = dt0.Rows[0][10].ToString();
            }
            //该位置本班是否有课
            string pos = b.ToString() + "0" + a.ToString();
            if (Istrue(pos))
            {
                str = "无课";
            }
            else
            {
                string sql1 = " and ClaID='" + dt0.Rows[0][1].ToString() + "' and Position=" + pos + " and EYear='" + EYear + "'" + " and Term=" + term + " and isdel=0";
                DataTable dt1 = scourseDAL.GetAllScheduleCourseByWhere(sql1);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    //调课和被调课一样的课程
                    if (dt1.Rows[0][8].ToString() == dt0.Rows[0][8].ToString())
                    {
                        str = dt1.Rows[0]["CourseRepeat"].ToString() + " " + "<br />" + "<label style='display:none;'>:a:c" + dt1.Rows[0]["SCID"].ToString() + ":b:c</label>";
                    }
                    else
                    {
                        //在调课位置调被调课的位置判断被调课的位置在本位制是否有课
                        string sql3 = " and TID='" + dt0.Rows[0][3].ToString() + "' and Position=" + pos + " and ClaID !='" + dt0.Rows[0][1].ToString() + "'" + " and EYear='" + EYear + "'" + " and Term=" + term + "  and isdel=0";
                        DataTable dt3 = scourseDAL.GetAllScheduleCourseByWhere(sql3);

                        //在被调课位置调调课的位置判断本位制在被调课的位置是否有课
                        string sql4 = " and TID='" + dt1.Rows[0][3].ToString() + "' and Position=" + dt0.Rows[0][5].ToString() + " and ClaID !='" + dt1.Rows[0][1].ToString() + "'" + " and EYear='" + EYear + "'" + " and Term=" + term + "  and isdel=0";
                        DataTable dt4 = scourseDAL.GetAllScheduleCourseByWhere(sql4);

                        if (dt3 != null && dt3.Rows.Count > 0 && dt4 != null && dt4.Rows.Count > 0)
                        {
                            str = dt3.Rows[0][9].ToString() + "在" + dt3.Rows[0][10].ToString() + "已有课" + "<br>" + dt4.Rows[0][9].ToString() + "在" + dt4.Rows[0][10].ToString() + "已有课";
                        }
                        if ((dt3 != null && dt3.Rows.Count > 0) && (dt4 == null || dt4.Rows.Count == 0))
                        {
                            str = dt3.Rows[0][9].ToString() + "在" + dt3.Rows[0][10].ToString() + "已有课";
                        }
                        if ((dt3 == null || dt3.Rows.Count == 0) && (dt4 != null && dt4.Rows.Count > 0))
                        {
                            str = dt4.Rows[0][9].ToString() + "在" + dt4.Rows[0][10].ToString() + "已有课";
                        }
                        if ((dt3 == null || dt3.Rows.Count == 0) && (dt4 == null || dt4.Rows.Count == 0))
                        {
                            str = dt1.Rows[0]["CourseRepeat"].ToString() + "<br />" + "<label style='display:none;'>:a:c" + dt1.Rows[0]["SCID"].ToString() + ":b:c</label>";
                        }
                        //该位置本班教室在其他班是否存在
                        string sql5 = " and CRID=" + dt0.Rows[0][4].ToString() + " and CRID!=-2 and Position=" + pos + "and ClaID !='" + dt0.Rows[0][1].ToString() + "'" + " and EYear='" + EYear + "'" + " and Term=" + term + "  and isdel=0";
                        DataTable dt5 = scourseDAL.GetAllScheduleCourseByWhere(sql5);
                        //被调课位置班级教室在本班是否存在
                        string sql6 = " and CRID=" + dt1.Rows[0][4].ToString() + " and CRID!=-2 and Position=" + dt0.Rows[0][5].ToString() + "and ClaID !='" + dt1.Rows[0][1].ToString() + "'" + " and EYear='" + EYear + "'" + " and Term=" + term + "  and isdel=0";
                        DataTable dt6 = scourseDAL.GetAllScheduleCourseByWhere(sql6);
                        if (dt5 != null && dt5.Rows.Count > 0 && dt6 != null && dt6.Rows.Count > 0)
                        {
                            str = str + "<br>" + dt5.Rows[0][12].ToString() + "在" + dt5.Rows[0][10].ToString() + "已有课" + "<br>" + dt6.Rows[0][12].ToString() + "在" + dt6.Rows[0][10].ToString() + "已有课";
                        }
                        if ((dt5 != null && dt5.Rows.Count > 0) && (dt6 == null || dt6.Rows.Count == 0))
                        {
                            str = str + "<br>" + dt5.Rows[0][12].ToString() + "在" + dt5.Rows[0][10].ToString() + "已有课";
                        }
                        if ((dt5 == null || dt5.Rows.Count == 0) && (dt6 != null && dt6.Rows.Count > 0))
                        {
                            str = str + "<br>" + dt6.Rows[0][12].ToString() + "在" + dt6.Rows[0][10].ToString() + "已有课";
                        }
                    }
                }
                else
                {
                    string sql2 = " and TID='" + dt0.Rows[0][3].ToString() + "' and Position=" + pos + " and ClaID !='" + dt0.Rows[0][1].ToString() + "'" + " and EYear='" + EYear + "'" + " and Term=" + term + "  and isdel=0";
                    DataTable dt2 = scourseDAL.GetAllScheduleCourseByWhere(sql2);

                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        str = dt2.Rows[0][9].ToString() + "在" + "<br>" + dt2.Rows[0][10].ToString() + "已有课";
                    }
                    string sql7 = " and CRID=" + dt0.Rows[0][4].ToString() + " and CRID!=-2 and Position=" + pos + "and ClaID !='" + dt0.Rows[0][1].ToString() + "'" + " and EYear='" + EYear + "'" + " and Term=" + term + "  and isdel=0";
                    DataTable dt7 = scourseDAL.GetAllScheduleCourseByWhere(sql7);
                    if (dt7 != null && dt7.Rows.Count > 0)
                    {
                        str = str + "<br>" + dt7.Rows[0][12].ToString() + "在" + dt7.Rows[0][10].ToString() + "已有课";
                    }
                    else
                    {
                        str = "可安排" + "<label  style='display:none;'>:a:c" + pos + ":b:c</label>";
                    }
                }
            }
            return str;

        }
        #endregion


        #region 判断是否存在
        public bool Istrue(string position)
        {
            bool b1 = true;
            bool b2 = true;
            ScheduleSetEntity model = setDAL.GetObjByID();
            if (model != null)
            {
                if (model.NoTimetable != null)
                {
                    string[] arr = model.NoTimetable.Split('|');
                    for (int k = 0; k < arr.Length; k++)
                    {
                        if (arr[k].Contains(position))
                        {
                            b1 = false;
                            b2 = false;
                        }
                        else
                        {
                            b1 = true;
                        }
                    }
                }
                else
                {
                    b2 = true;
                }
            }
            if (b2 == false)
            {
                b1 = true;
            }
            else
            {
                b1 = false;
            }
            return b1;
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