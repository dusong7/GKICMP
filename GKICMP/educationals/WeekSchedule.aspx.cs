/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年3月13日 10时28分
** 描 述:       周课表页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Text;

namespace GKICMP.educationals
{
    public partial class WeekSchedule : PageBase
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public static int ClaID = 0;
        public static string EYear;
        public static int term;


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTerm(out EYear, out term);
                this.lbl.Text = DataBindList();
            }
        }
        #endregion


        #region 数据绑定
        public string DataBindList()
        {
            DataTable dt = scourseDAL.GetClaID(EYear, term);
            StringBuilder str = new StringBuilder();
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
                str.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' class='content' >");
                str.Append("<tr>");
                for (int i = 0; i <= WeekDays; i++)
                {
                    if (i == 0)
                    {
                        str.AppendFormat("<th class='conth1'>{0}</th>", arryStr[i].ToString());
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            str.AppendFormat("<th colspan=" + (WSnum + SWnum + XWnum) + " class='conth2'>{0}</th>", arryStr[i].ToString());
                        }
                        else
                        {
                            str.AppendFormat("<th colspan=" + (WSnum + SWnum + XWnum) + " class='conth3'>{0}</th>", arryStr[i].ToString());
                        }
                    }
                }
                str.Append("</tr>");
                str.Append("<tr>");
                for (int l = 0; l <= WeekDays; l++)
                {
                    for (int j = 1; j < (WSnum + SWnum + XWnum) + 1; j++)
                    {
                        if (l == 0)
                        {
                            str.AppendFormat("<td class='contd1'>{0}</td>", "班级");
                            j = WSnum + SWnum + XWnum;
                        }
                        else
                        {
                            if (j == 1)
                            {
                                str.AppendFormat("<td class='contd2'>{0}</td>", j.ToString());
                            }
                            else
                            {
                                str.AppendFormat("<td>{0}</td>", j.ToString());
                            }
                        }
                    }
                }
                str.Append("</tr>");
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    str.Append("<tr>");
                    ClaID = Convert.ToInt32(dt.Rows[k]["ClaID"].ToString());
                    string sql1 = " and ClaID=" + ClaID + " and Isdel=0 and EYear='" + EYear + "' and Term=" + term + " and ClaID not in (select DID from Tb_Department a,Tb_Grade b where a.GID=b.GID and a.DepType=-1 and b.IsGraduate=1) order by Position";
                    DataTable dt1 = scourseDAL.GetAllScheduleCourseByWhere(sql1);
                    str.AppendFormat("<td  class='contd1'>{0}</td>", dt.Rows[k]["ClaIDName"]);
                    for (int c = 1; c <= WeekDays; c++)
                    {
                        for (int a = 1; a <= WSnum + SWnum + XWnum; a++)
                        {
                            string aa = "";
                            string title = "";
                            strGet(c + "0" + a, dt1, out title, out aa);
                            if (a == 1)
                            {
                                if (aa == "无课")
                                {
                                    str.AppendFormat("<td  class='contd3'>{0}</td>", aa);
                                }
                                if (aa == "")
                                {
                                    str.AppendFormat("<td  class='contd2'>{0}</td>", aa);
                                }
                                if (aa != "" && aa != "无课")
                                {
                                    str.AppendFormat("<td title='" + title + "'class='contd2' >{0}</td>", aa);
                                }
                            }
                            else
                            {
                                if (aa == "无课")
                                {
                                    str.AppendFormat("<td class='contd3'>{0}</td>", aa);
                                }
                                if (aa == "")
                                {
                                    str.AppendFormat("<td >{0}</td>", aa);
                                }
                                if (aa != "" && aa != "无课")
                                {
                                    str.AppendFormat("<td  title='" + title + "'>{0}</td>", aa);
                                }
                            }
                        }
                    }
                    str.Append("</tr>");
                }
                str.Append("</table>");
                return str.ToString();
            }
            else
            {
                return " <div class=\"datanone\">抱歉！暂无课表信息</div>";

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
        public void strGet(string position, DataTable dt, out string title, out string aa)
        {
            aa = "";
            title = "";
            ScheduleSetEntity model = setDAL.GetObjByID();
            if (model != null && model.NoTimetable != "")
            {
                int id = Array.IndexOf(model.NoTimetable.ToString().Split('|'), position);
                if (id == -1)    //不存在
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Position"].ToString().Contains(position))
                        {
                            title = dt.Rows[i]["CourseRepeat"].ToString() + "  (" + dt.Rows[i]["TeacherRepeat"].ToString() + ")" + (dt.Rows[i]["CRIDName"].ToString() == "" ? "" : "  (" + dt.Rows[i]["CRIDName"].ToString() + ")");
                            aa = Split(dt.Rows[i]["CourseRepeat"].ToString());
                            break;
                        }
                        else
                        {
                            title = "";
                            aa = "";
                        }

                    }
                }
                else
                {
                    title = "无课";
                    aa = "无课";
                }
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Position"].ToString().Contains(position))
                    {
                        title = dt.Rows[i]["CourseRepeat"].ToString() + "  (" + dt.Rows[i]["TeacherRepeat"].ToString() + ")" + (dt.Rows[i]["CRIDName"].ToString() == "" ? "" : "  (" + dt.Rows[i]["CRIDName"].ToString() + ")");
                        aa = Split(dt.Rows[i]["CourseRepeat"].ToString());
                        break;
                    }
                    else
                    {
                        title = "";
                        aa = "";
                    }

                }
            }
        }
        #endregion


        #region 换行输出
        public string Split(string name)
        {
            string cname = "";
            if (name != "" && name != "无课")
            {
                for (int i = 0; i < name.Length; i += 2)
                {
                    if (name.Length <= i + 2)
                    {
                        cname += name.Substring(i, name.Length - i).ToString();
                    }
                    else
                    {
                        cname += name.Substring(i, 2).ToString() + "<br>";
                    }
                }
            }
            return cname;
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