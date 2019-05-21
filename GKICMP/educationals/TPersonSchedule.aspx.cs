/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月8日 18时04分
** 描 述:       我的课表管理
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
using System.Web.UI.WebControls;

namespace GKICMP.educationals
{
    public partial class TPersonSchedule : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public static int count = 0;
        public static string name = "";
        public static string EYear;
        public static int term;



        #region 参数集合
        public string UID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        public int deep
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
                name = "";
                count = 0;
                if (deep != 0 && deep != -1)
                {
                    this.hf_uid.Value = UserID;
                    if (Flag == 1)
                    {
                        this.hf_uid.Value = UID;
                        this.dv.Visible = false;
                    }
                    else
                    {
                        this.dv.Visible = true;
                    }
                    this.lbl.Text = LoadClassSchedule();
                }
                GetTerm(out EYear, out term);
                if (name != "" && count != 0)
                {
                    this.lbl_top.Text = name;
                    this.lbl_Teacher.Text = name + "共有" + count + "节课";
                }
            }
        }
        #endregion


        #region 班级排课信息加载
        /// <summary>
        /// 班级排课信息加载
        /// </summary>
        public string LoadClassSchedule()
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
            string sql = " and TID=" + "'" + this.hf_uid.Value + "' and EYear='" + EYear + "' and Term=" + term + " and isdel=0 and ClaID not in (select DID from Tb_Department a,Tb_Grade b where a.GID=b.GID and a.DepType=-1 and b.IsGraduate=1) ";
            DataTable dt1 = scourseDAL.GetAllScheduleCourseByWhere(sql);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                count = dt1.Rows.Count;
                name = dt1.Rows[0]["TeacherRepeat"].ToString();
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
                        string position = c + "0" + a;
                        string aa = "";
                        strGet(c + "0" + a, dt1, 1, out aa);
                        if (aa == "无课")
                        {
                            str.AppendFormat("<td class='contd3'>{0}</td>", aa);
                        }
                        if (aa == "")
                        {
                            str.AppendFormat("<td>{0}</td>", aa);
                        }
                        if (aa != "" && aa != "无课")
                        {
                            str.AppendFormat("<td>{0}</td>", aa);
                        }
                    }
                    str.Append("</tr>");
                }
                str.Append("</table>");
                return str.ToString();
            }
            else
            {
                this.lbl_Teacher.Visible = false;
                this.tran.Visible = false;
                return "<div class='datanone'>抱歉！暂无课表信息</div>";
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
        public string LoadClassScheduleData(int a, int b, int flag)
        {
            string str = "";
            if (Istrue(b + "0" + a))
            {
                str = "无课";
            }
            else
            {
                string sql = " and TID=" + "'" + this.hf_uid.Value + "' and EYear='" + EYear + "' and Term=" + term + " and isdel=0 and ClaID not in (select DID from Tb_Department a,Tb_Grade b where a.GID=b.GID and a.DepType=-1 and b.IsGraduate=1) ";
                DataTable dt = scourseDAL.GetAllScheduleCourseByWhere(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    count = dt.Rows.Count;
                    name = dt.Rows[0]["TeacherRepeat"].ToString();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int x = 0;
                        int y = 0;

                        x = Convert.ToInt32(dt.Rows[i]["Position"].ToString().Substring(0, 1));
                        y = Convert.ToInt32(dt.Rows[i]["Position"].ToString().Substring(2, dt.Rows[i]["Position"].ToString().Length - 2));

                        if ((a == y) && (b == x))
                        {
                            if (flag == 1)
                            {
                                str = "<span style='color:red'>" + dt.Rows[i]["CourseRepeat"].ToString() + "</span>" + "        " + dt.Rows[i]["DepOtherName"].ToString() + (dt.Rows[i]["CRIDName"].ToString() == "" ? "" : "</br>" + dt.Rows[i]["CRIDName"].ToString());
                            }
                            else
                            {
                                str = dt.Rows[i]["CourseRepeat"].ToString() + "<br>" + dt.Rows[i]["DepOtherName"].ToString() + "<br>" + (dt.Rows[i]["CRIDName"].ToString() == "" ? "" : dt.Rows[i]["CRIDName"].ToString());
                            }
                            break;
                        }
                    }
                }
            }
            return str;
        }
        #endregion


        #region 判断该位置是否有课
        /// <summary>
        /// 判断该位置是否有课
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public void strGet(string position, DataTable dt, int flag, out string aa)
        {
            aa = "";
            ScheduleSetEntity model = setDAL.GetObjByID();
            if (model != null && model.NoTimetable != "")
            {
                int id = Array.IndexOf(model.NoTimetable.ToString().Split('|'), position);
                if (id == -1)    //不存在
                {
                    DataRow[] dr = dt.Select("Position ='" + position + "'");
                    if (dr.Length > 0)
                    {
                        if (flag == 1)
                        {
                            aa = dr[0]["CourseRepeat"].ToString() + "<br>" + "<span style='margin-right: 0px;'>" + dr[0]["DepOtherName"].ToString() + "</span>" + (dr[0]["CRIDName"].ToString() == "" ? "" : "<br>" + dr[0]["CRIDName"].ToString());
                        }
                        else
                        {
                            aa = dr[0]["CourseRepeat"].ToString() + "<br>" + dr[0]["DepOtherName"].ToString() + (dr[0]["CRIDName"].ToString() == "" ? "" : "<br>" + dr[0]["CRIDName"].ToString());
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
                        if (flag == 1)
                        {
                            aa = dr[0]["CourseRepeat"].ToString() + "<br>" + "<span style='margin-right: 0px;'>" + dr[0]["DepOtherName"].ToString() + "</span>" + (dr[0]["CRIDName"].ToString() == "" ? "" : "<br>" + dr[0]["CRIDName"].ToString());
                        }
                        else
                        {
                            aa = dr[0]["CourseRepeat"].ToString() + "<br>" + dr[0]["DepOtherName"].ToString() + (dr[0]["CRIDName"].ToString() == "" ? "" : "<br>" + dr[0]["CRIDName"].ToString());
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


        #region 导出
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                string sql = " and TID=" + "'" + this.hf_uid.Value + "' and EYear='" + EYear + "' and Term=" + term + " and isdel=0 and ClaID not in (select DID from Tb_Department a,Tb_Grade b where a.GID=b.GID and a.DepType=-1 and b.IsGraduate=1) ";
                DataTable dt1 = scourseDAL.GetAllScheduleCourseByWhere(sql);
                if (dt1 != null && dt1.Rows.Count > 0)
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
                            //str.Append("<tr>");
                            //str.AppendFormat("<th colspan='" + (WeekDays + 1) + "' style='text-align:center;'>{0}</th>", name + "共有" + count + "节课");
                            //str.Append("</tr>");
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
                                string aa = "";
                                strGet(c + "0" + a, dt1, 2, out aa);
                                str.AppendFormat("<td style='text-align:center;'>{0}</td>", aa);
                            }
                            str.Append("</tr>");
                        }
                    }
                    str.Append("</table>");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出" + this.lbl_Teacher.Text + "课表", UserID));
                    CommonFunction.ExportExcel("教师\"" + this.lbl_Teacher.Text + "\"课表", str.ToString());
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