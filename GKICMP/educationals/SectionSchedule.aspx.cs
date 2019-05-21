/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年3月13日 10时28分
** 描 述:       节次课表页面
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
using System.Web.UI.WebControls;

namespace GKICMP.educationals
{
    public partial class SectionSchedule : PageBase
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
                DdlBind();
                GetTerm(out EYear, out term);
                this.lbl.Text = DataBindList();
            }
        }
        #endregion


        #region 下拉框绑定
        public void DdlBind()
        {
            ScheduleSetEntity model = setDAL.GetObjByID();
            if (model != null)
            {
                for (int i = 1; i <= model.AfterPitch + model.MorningPitch + model.EveningPitch; i++)
                {
                    this.ddl_JC.Items.Add(new ListItem("第" + i.ToString() + "节课", i.ToString()));
                }
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
                string[] arryStr = new string[] { "班级", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
                str.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' class='content' >");
                str.Append("<tr>");
                for (int i = 0; i <= WeekDays; i++)
                {
                    if (i == 0)
                    {
                        str.AppendFormat("<td class='contd1'>{0}</td>", arryStr[i].ToString());
                    }
                    else
                    {
                        str.AppendFormat("<td class='contd1'>{0}</td>", arryStr[i].ToString());
                    }
                }
                str.Append("</tr>");
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    str.Append("<tr>");
                    ClaID = Convert.ToInt32(dt.Rows[k]["ClaID"].ToString());
                    string sql1 = " and ClaID=" + ClaID + " and Isdel=0  and Position like '%" + Convert.ToInt32(this.ddl_JC.SelectedValue) + "' and EYear='" + EYear + "' and Term=" + term + " and ClaID not in (select DID from Tb_Department a,Tb_Grade b where a.GID=b.GID and a.DepType=-1 and b.IsGraduate=1) order by Position";
                    DataTable dt1 = scourseDAL.GetAllScheduleCourseByWhere(sql1);
                    str.AppendFormat("<td  class='contd1'>{0}</td>", dt.Rows[k]["ClaIDName"]);
                    for (int c = 1; c <= WeekDays; c++)
                    {
                        string aa = "";
                        strGet(c + "0" + this.ddl_JC.SelectedValue, dt1, out aa);
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
                            str.AppendFormat("<td class='contd2' >{0}</td>", aa);
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
        public void strGet(string position, DataTable dt, out string aa)
        {
            aa = "";
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
                            aa = dt.Rows[i]["CourseRepeat"].ToString() + "  (" + dt.Rows[i]["TeacherRepeat"].ToString() + ")" + (dt.Rows[i]["CRIDName"].ToString() == "" ? "" : "  (" + dt.Rows[i]["CRIDName"].ToString() + ")");
                            break;
                        }
                        else
                        {
                            aa = "";
                        }

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
                    if (dt.Rows[i]["Position"].ToString().Contains(position))
                    {
                        aa = dt.Rows[i]["CourseRepeat"].ToString() + "  (" + dt.Rows[i]["TeacherRepeat"].ToString() + ")" + (dt.Rows[i]["CRIDName"].ToString() == "" ? "" : "  (" + dt.Rows[i]["CRIDName"].ToString() + ")");
                        break;
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


        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GetTerm(out EYear, out term);
            this.lbl.Text = DataBindList();
        }
        #endregion
    }
}