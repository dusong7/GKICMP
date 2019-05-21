/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年3月13日 10时28分
** 描 述:       全部课表页面
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
using Baidu.Aip.Speech;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace GKICMP.educationals
{
    public partial class WebForm1 : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
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
                DataTable dt = scourseDAL.GetEYear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        this.ddl_EYear.Items.Add(row["EYear"].ToString());
                    }
                }
                else
                {
                    this.ddl_EYear.Items.Add(new ListItem(EYear, ""));
                }
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-99");
                this.ddl_EYear.SelectedValue = EYear;
                this.ddl_Term.SelectedValue = term.ToString();
                this.lbl.Text = DataBindList();
            }
        }
        #endregion


        #region 数据绑定
        public string DataBindList()
        {
            DataTable dt = scourseDAL.GetClaID(this.ddl_EYear.SelectedValue, Convert.ToInt32(this.ddl_Term.SelectedValue));
            StringBuilder str = new StringBuilder("");
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
                str.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' id='textTable' class='content table table-bordered scrollTable' >");
                str.Append("<thead><tr>");
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
                            str.AppendFormat("<th colspan=" + (WSnum + SWnum + XWnum) + " class='conth2 contd2'>{0}</th>", arryStr[i].ToString());
                        }
                        else
                        {
                            str.AppendFormat("<th colspan=" + (WSnum + SWnum + XWnum) + " class='conth3 contd2'>{0}</th>", arryStr[i].ToString());
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
                str.Append("</tr></thead><tbody id='testTbody'>");
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    str.Append("<tr>");
                    ClaID = Convert.ToInt32(dt.Rows[k]["ClaID"].ToString());
                    string sql1 = " and ClaID=" + ClaID + " and Isdel=0 and EYear='" + this.ddl_EYear.SelectedValue + "' and Term=" + this.ddl_Term.SelectedValue + " order by Position";
                    DataTable dt1 = scourseDAL.GetAllScheduleCourseByWhere(sql1);
                    if (dt1 == null || dt1.Rows.Count == 0)
                    {
                        ShowMessage("暂无数据");
                    }
                    str.AppendFormat("<td  class='contd1'>{0}</td>", dt.Rows[k]["ClaIDName"]);
                    for (int c = 1; c <= WeekDays; c++)
                    {
                        for (int a = 1; a <= WSnum + SWnum + XWnum; a++)
                        {
                            string tid = "";
                            string name = "";
                            string aa = "";
                            string title = "";
                            string scid = "";
                            strGet(c + "0" + a, dt1, out tid, 1, out name, out title, out aa, out scid, this.ddl_EYear.SelectedValue, Convert.ToInt32(this.ddl_Term.SelectedValue));
                            if (this.ddl_EYear.SelectedValue == EYear && this.ddl_Term.SelectedValue == term.ToString())
                            {
                                if (a == 1)
                                {
                                    if (aa == "无课")
                                    {
                                        str.AppendFormat("<td id=\"" + (ClaID).ToString() + (c).ToString() + a.ToString() + "\"  class='contd3'>{0}</td>", aa);
                                    }
                                    if (aa == "")
                                    {
                                        str.AppendFormat("<td  id=\"" + (ClaID).ToString() + (c).ToString() + a.ToString() + "\" class='contd2' onContextMenu='showadd({1},{2});'>{0}</td>", aa, ClaID, c + "0" + a);
                                    }
                                    if (aa != "" && aa != "无课")
                                    {
                                        str.AppendFormat("<td scid=\"" + scid + "\"  id=\"" + (ClaID).ToString() + (c).ToString() + a.ToString() + "\" title='" + title + "' teacher=\"{0}\" teachername=\"{1}\" onclick=\"showteacher(this)\" class='contd2' onContextMenu='showmenu(this);' >{2}</td>", tid, name, aa);
                                    }
                                }
                                else
                                {
                                    if (aa == "无课")
                                    {
                                        str.AppendFormat("<td  id=\"" + (ClaID).ToString() + (c).ToString() + a.ToString() + "\" class='contd3'>{0}</td>", aa);
                                    }
                                    if (aa == "")
                                    {
                                        str.AppendFormat("<td id=\"" + (ClaID).ToString() + (c).ToString() + a.ToString() + "\" onContextMenu='showadd({1},{2});'>{0}</td>", aa, ClaID, c + "0" + a);
                                    }
                                    if (aa != "" && aa != "无课")
                                    {
                                        str.AppendFormat("<td scid=\"" + scid + "\"  id=\"" + (ClaID).ToString() + (c).ToString() + a.ToString() + "\" title='" + title + "' teacher=\"{0}\" teachername=\"{1}\" onclick=\"showteacher(this)\"  onContextMenu='showmenu(this);'>{2}</td>", tid, name, aa);
                                    }
                                }
                            }
                            else
                            {
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
                                        str.AppendFormat("<td title='" + title + "'class='contd2'>{0}</td>",aa);
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
                                        str.AppendFormat("<td'>{0}</td>", aa);
                                    }
                                    if (aa != "" && aa != "无课")
                                    {
                                        str.AppendFormat("<td title='" + title + "'>{0}</td>",aa);
                                    }
                                }
                            }
                        }
                    }
                    str.Append("</tr>");
                }
                str.Append("</tbody></table>");
                this.btn_OutPut.Visible = true;
                return str.ToString();
            }
            else
            {
                this.btn_OutPut.Visible = false;
                return "<span style='color:red;font-size: 22px;margin-top:10px;'>暂无班级课表信息</span>";

            }
        }
        #endregion


        #region 导出
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder str = new StringBuilder("");
                DataTable dt = scourseDAL.GetClaID(this.ddl_EYear.SelectedValue, Convert.ToInt32(this.ddl_Term.SelectedValue));
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
                                str.AppendFormat("<th colspan=" + (WSnum + SWnum + XWnum) + ">{0}</th>", arryStr[i].ToString());
                            }
                            else
                            {
                                str.AppendFormat("<th colspan=" + (WSnum + SWnum + XWnum) + " >{0}</th>", arryStr[i].ToString());
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
                                str.AppendFormat("<td style='text-align:center;'>{0}</td>", "班级");
                                j = WSnum + SWnum + XWnum;
                            }
                            else
                            {
                                if (j == 1)
                                {
                                    str.AppendFormat("<td style='text-align:center;'>{0}</td>", j.ToString());
                                }
                                else
                                {
                                    str.AppendFormat("<td style='text-align:center;'>{0}</td>", j.ToString());
                                }
                            }
                        }
                    }
                    str.Append("</tr>");
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        str.Append("<tr>");
                        ClaID = Convert.ToInt32(dt.Rows[k]["ClaID"].ToString());
                        string sql1 = " and ClaID=" + ClaID + " and Isdel=0 and EYear='" + this.ddl_EYear.SelectedValue + "' and Term=" + this.ddl_Term.SelectedValue + " order by Position";
                        DataTable dt1 = scourseDAL.GetAllScheduleCourseByWhere(sql1);
                        str.AppendFormat("<td style='text-align:center;'>{0}</td>", dt.Rows[k]["ClaIDName"]);
                        for (int c = 1; c <= WeekDays; c++)
                        {
                            for (int a = 1; a <= WSnum + SWnum + XWnum; a++)
                            {
                                string tid = "";
                                string name = "";
                                string aa = "";
                                string title = "";
                                string scid = "";
                                strGet(c + "0" + a, dt1, out tid, 2, out name, out title, out aa, out scid, this.ddl_EYear.SelectedValue, Convert.ToInt32(this.ddl_Term.SelectedValue));
                                str.AppendFormat("<td style='text-align:center;'>{0}</td>", aa);
                            }
                        }
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出全部课表信息", UserID));
                    CommonFunction.ExportExcel("全部课表", str.ToString());

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
        public void strGet(string position, DataTable dt, out string tid, int flag, out string name, out string title, out string aa, out string scid, string EYears, int Terms)
        {
            aa = "";
            title = "";
            tid = "";
            name = "";
            scid = "";
            if (EYears == EYear && Terms == term)
            {
                ScheduleSetEntity model = setDAL.GetObjByID();
                if (model != null && model.NoTimetable != "")
                {
                    int id = Array.IndexOf(model.NoTimetable.ToString().Split('|'), position);
                    if (id == -1)    //不存在
                    {
                        DataRow[] dr = dt.Select("Position ='" + position + "'");
                        if (dr.Length > 0)
                        {
                            scid = dr[0]["SCID"].ToString();
                            tid = dr[0]["TID"].ToString();
                            name = dr[0]["TeacherRepeat"].ToString();
                            if (flag == 1)
                            {
                                title = dr[0]["CourseRepeat"].ToString() + "  (" + dr[0]["TeacherRepeat"].ToString() + ")" + (dr[0]["CRIDName"].ToString() == "" ? "" : "  (" + dr[0]["CRIDName"].ToString() + ")");
                                aa = Split(dr[0]["CourseRepeat"].ToString()) + "<label style='display:none;'>:a:c" + dr[0]["SCID"].ToString() + ":b:c</label>";
                            }
                            else
                            {
                                aa = dr[0]["CourseRepeat"].ToString() + "<br>(" + dr[0]["TeacherRepeat"].ToString() + ")" + (dr[0]["CRIDName"].ToString() == "" ? "" : "<br>" + dr[0]["CRIDName"].ToString());
                            }
                        }
                        else
                        {
                            title = "";
                            aa = "";
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
                    DataRow[] dr = dt.Select("Position ='" + position + "'");
                    if (dr.Length > 0)
                    {
                        scid = dr[0]["SCID"].ToString();
                        tid = dr[0]["TID"].ToString();
                        name = dr[0]["TeacherRepeat"].ToString();
                        if (flag == 1)
                        {
                            title = dr[0]["CourseRepeat"].ToString() + "  (" + dr[0]["TeacherRepeat"].ToString() + ")" + (dr[0]["CRIDName"].ToString() == "" ? "" : "  (" + dr[0]["CRIDName"].ToString() + ")");
                            aa = Split(dr[0]["CourseRepeat"].ToString()) + "<label style='display:none;'>:a:c" + dr[0]["SCID"].ToString() + ":b:c</label>";
                        }
                        else
                        {
                            aa = dr[0]["CourseRepeat"].ToString() + "<br>(" + dr[0]["TeacherRepeat"].ToString() + ")" + (dr[0]["CRIDName"].ToString() == "" ? "" : "<br>" + dr[0]["CRIDName"].ToString());
                        }
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
                DataRow[] dr = dt.Select("Position ='" + position + "'");
                if (dr.Length > 0)
                {
                    if (flag == 1)
                    {
                        title = dr[0]["CourseRepeat"].ToString() + "  (" + dr[0]["TeacherRepeat"].ToString() + ")" + (dr[0]["CRIDName"].ToString() == "" ? "" : "  (" + dr[0]["CRIDName"].ToString() + ")");
                        aa = Split(dr[0]["CourseRepeat"].ToString());
                    }
                    else
                    {
                        aa = dr[0]["CourseRepeat"].ToString() + "<br>(" + dr[0]["TeacherRepeat"].ToString() + ")" + (dr[0]["CRIDName"].ToString() == "" ? "" : "<br>" + dr[0]["CRIDName"].ToString());
                    }
                }
                else
                {
                    title = "";
                    aa = "";
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
            if (month < 9 && month >= 3)
            {
                EYear = (year - 1) + "-" + year;
                term = (int)CommonEnum.XQ.下学期;
            }
            else
            {
                if (month <= 12 && month >= 9)
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
        protected void btn_Searchs_Click(object sender, EventArgs e)
        {
            this.lbl.Text = DataBindList();
        }
        #endregion



        #region 课程语言播报
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string wdzw = this.hf_wdzw.Value;
            this.lbl_name.Text = wdzw;
            try
            {
                Tts _ttsClient = new Tts("zBoqwIjlyXPT1cKeWxEYwnfg", "j99fGL2teCGk9QTaXfjY6McstdF51dvY");
                var option = new Dictionary<string, object>()
                        {
                            {"spd", 5}, // 语速
                            {"vol", 7}, // 音量
                            {"per", 0}  // 发音人，4：情感度丫丫童声
                         };

                var result = _ttsClient.Synthesis(wdzw == "" ? "" : wdzw, option);

                if (result.ErrorCode == 0)  // 或 result.Success
                {
                    string pah = Server.MapPath("~/voice/voice.mp3");
                    File.WriteAllBytes(pah, result.Data);
                }
                Speech("~/voice/voice.mp3");


            }
            catch (Exception ex)
            {
                ShowMessage("正在加载中");
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }

        }

        public void Speech(string path)
        {
            //new MCI().Play(AppDomain.CurrentDomain.BaseDirectory + "\voice\voice.mp3", 1); 
            new MCI().Play(Server.MapPath(path), 1);
        }

        #endregion

    }
}