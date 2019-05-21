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

namespace GKICMP.educational
{
    public partial class SubstituteAdd : PageBase
    {
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
                //if (ClaID != -1 && DepID != 0)
                //{
                //    DepartmentEntity model = departmentDAL.GetObj(ClaID);
                //    this.ltl_NowClass.Text = model.DepName;
                //}
                //else
                //{
                //    this.ltl_NowClass.Text = "暂无班级";
                //}
                ViewState["Time"] = this.txt_TKDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            string tt = ViewState["Time"].ToString();
            DateTime startweek = Convert.ToDateTime(tt).AddDays(1 - Convert.ToInt32(Convert.ToDateTime(tt).DayOfWeek.ToString("d")));  //本周周一
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
                            myCell.Text = arryStr[b - 1] + "<br/>" + startweek.AddDays(b - 1).ToString("MM月dd日");
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
                            //myCell.Attributes.Add("onmouseover", "this.style.background='#C4C6C8'");
                            //myCell.Attributes.Add("onmouseout", "this.style.background=''");
                            myCell.Attributes.Add("onclick", "CellText(this.innerHTML);");
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
            string str = "";
            string sql = " and TID=" + "'" + UserID + "' and Isdel=0 and EYear='" + EYear + "' and Term='" + term + "'";
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
                        DateTime jctime = Convert.ToDateTime(ViewState["Time"]).AddDays(1 - Convert.ToInt32(Convert.ToDateTime(ViewState["Time"]).DayOfWeek.ToString("d"))).AddDays(b - 1);
                        if (DateTime.Now < jctime)
                        {
                            str = dt.Rows[i]["CourseRepeat"].ToString() + "(" + dt.Rows[i]["ClaIDName"].ToString() + ")" + "<br />" + "<label style='display:none;'>:a:c" + dt.Rows[i]["Position"].ToString() + ":b:c" +
                                Convert.ToDateTime(ViewState["Time"]).AddDays(1 - Convert.ToInt32(Convert.ToDateTime(ViewState["Time"]).DayOfWeek.ToString("d"))).AddDays(b - 1).ToString("yyyy-MM-dd") + "xy" + dt.Rows[i]["SCID"].ToString() + "</label>";

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

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            ViewState["Time"] = this.txt_TKDate.Text == "" ? DateTime.Now.ToString("yyyy-MM-dd") : this.txt_TKDate.Text;
            LoadClassSchedule();
        }

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