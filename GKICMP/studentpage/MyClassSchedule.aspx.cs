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

namespace GKICMP.studentpage
{
    public partial class MyClassSchedule : PageBase
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public static string EYear;
        public static int term;

        public static int ClaID;

        //#region 班级ID
        ///// <summary>
        ///// 班级ID
        ///// </summary>
        //public int ClaID
        //{
        //    get
        //    {
        //        return GetQueryString<int>("id", -1);
        //    }
        //}
        //public int DepID
        //{
        //    get
        //    {
        //        return GetQueryString<int>("deep", -1);
        //    }
        //}
        //#endregion


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
                DepartmentEntity dmodel = departmentDAL.GetMyObj(UserID);
                 ClaID = dmodel.DID;
                if (ClaID != -1)
                {
                    GetTerm(out EYear, out term);
                    DepartmentEntity model = departmentDAL.GetObj(ClaID);
                    if (model != null)
                    {
                        this.ltl_NowClass.Text = model.OtherName;
                    }
                    LoadClassSchedule();
                }
                else
                {
                    this.ltl_NowClass.Text = "暂无班级";
                }
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
            this.tab.Height = ((4 + 4 + 2) * 40 + 40);
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
                            myCell.Text = LoadClassScheduleData(a, c).Replace("连续", "");
                            if (myCell.Text != "无课")
                            {
                                myCell.Attributes.Add("onmouseover", "this.style.background='#C4C6C8'");
                                myCell.Attributes.Add("onmouseout", "this.style.background=''");
                               // myCell.Attributes.Add("onclick", "CellText(this.innerHTML);");
                            }
                            else
                            {
                                myCell.Attributes.CssStyle.Add("background", "#ef5d5d");
                                myCell.Attributes.CssStyle.Add("color", "#fff");
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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string LoadClassScheduleData(int a, int b)
        {
            //string CourseID = Session["CourseID"].ToString();
            string str = "";
            //string sql0 = "SELECT [ID],[ClassName],[SubjectName],[TeacherName],[AreaName],[Position],[ShouKeZhou],[CourseID] FROM [dbo].[tbSheepofCourse] where CourseID=" + CourseID + " and ClassName = '" + ClaID + "'";
            /*注释部分 DataTable dt = scourseDAL.GetTable(ClaID);*/
            // public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL(); 
            if (Istrue(b + "0" + a))
            {
                str = "无课";
            }
            else
            {
                string sql = " and ClaID=" + ClaID + " and Isdel=0 and EYear='" + EYear + "' and Term=" + term + " order by Position";
                DataTable dt = scourseDAL.GetAllScheduleCourseByWhere(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int x = 0;
                        int y = 0;

                        x = Convert.ToInt32(dt.Rows[i]["Position"].ToString().Substring(0, 1));
                        y = Convert.ToInt32(dt.Rows[i]["Position"].ToString().Substring(2, dt.Rows[i]["Position"].ToString().Length - 2));

                        if ((a == y) && (b == x))
                        {

                            //包含教师名称
                            str = "<span style='color:red;line-height:30px;'>" + dt.Rows[i]["CourseRepeat"].ToString() + "</span>" + "(" + dt.Rows[i]["TeacherRepeat"].ToString() + ")" + "<br/>" + dt.Rows[i]["CRIDName"] + "<label style='display:none;'>:a:c" + dt.Rows[i]["SCID"].ToString() + ":b:c</label>";
                            //不包含教师名称
                            //str = dt.Rows[i]["CourseRepeat"].ToString() + "<br />" + "<label style='display:none;'>:a:c" + dt.Rows[i]["SCID"].ToString() + ":b:c</label>"; 
                            break;
                        }
                    }
                }
            }
            return str;
        }
        #endregion


        #region 刷新
        protected void btn_Freshen_Click(object sender, EventArgs e)
        {
            LoadClassSchedule();
        }
        #endregion


        #region 班级排课数据加载
        /// <summary>
        /// 班级排课数据加载
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string LSMC(int a, int b)
        {
            string str = "";
            if (Istrue(b + "0" + a))
            {
                str = "无课";
            }
            else
            {
                string sql = " and ClaID=" + ClaID + " and Isdel=0 and EYear='" + EYear + "' and Term=" + term + " order by Position";
                DataTable dt = scourseDAL.GetAllScheduleCourseByWhere(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int x = 0;
                        int y = 0;

                        string p = dt.Rows[i]["Position"].ToString();

                        x = Convert.ToInt32(dt.Rows[i]["Position"].ToString().Substring(0, 1));
                        y = Convert.ToInt32(dt.Rows[i]["Position"].ToString().Substring(1, 2));

                        if ((a == y) && (b == x))
                        {
                            str = dt.Rows[i]["CourseRepeat"].ToString() + "   <br>(" + dt.Rows[i]["TeacherRepeat"].ToString() + ")" + "<br>" + dt.Rows[i]["CRIDName"].ToString();
                            break;
                        }
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