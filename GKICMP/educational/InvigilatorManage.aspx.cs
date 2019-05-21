/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月08日 09点30分
** 描   述:       学生监考表管理
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;
using System.Text;

namespace GKICMP.educational
{
    public partial class InvigilatorManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Exam_SubjectDAL subjectDAL = new Exam_SubjectDAL();
        public Exam_TeacherDAL teacherDAL = new Exam_TeacherDAL();


        #region 参数集合
        public int EID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lbl.Text = DataBindList();
            }
        }
        #endregion


        #region 绑定数据
        public string DataBindList()
        {
            DataTable dtsubject = subjectDAL.GetByEID(EID.ToString());
            StringBuilder str = new StringBuilder();
            if (dtsubject != null && dtsubject.Rows.Count > 0)
            {
                this.lbl_Title.Text = dtsubject.Rows[0]["GName"].ToString() + dtsubject.Rows[0]["EYear"].ToString() + "年度" + CommonFunction.CheckEnum<CommonEnum.XQ>(Convert.ToInt32(dtsubject.Rows[0]["Term"].ToString())) + dtsubject.Rows[0]["ExamName"] + "监考表";
                str.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' class='content' >");
                str.Append("<tr>");
                str.AppendFormat("<th class='conth1'>{0}</th>", "考场/考试");
                foreach (DataRow row in dtsubject.Rows)
                {
                    str.AppendFormat("<th class='conth1'>{0}</th>", row["CourseName"].ToString() + "【" + Convert.ToDateTime(row["BeginDate"]).ToString("yyyy-MM-dd HH:mm") + "-" + Convert.ToDateTime(row["EndDate"]).ToString("HH:mm") + "】");
                }
                str.Append("</tr>");
                DataTable dtteacher = teacherDAL.GetByEID(EID.ToString());
                if (dtteacher != null && dtteacher.Rows.Count > 0)
                {
                    int x = 0;
                    for (int i = 1; i <= dtteacher.Rows.Count; i++)
                    {
                        if (dtsubject.Rows.Count > 1)
                        {
                            if (i % dtsubject.Rows.Count == 1 && x == 0)
                            {
                                str.Append("<tr>");
                                str.AppendFormat("<td class='contd1'>{0}</td>", dtteacher.Rows[i - 1]["RoomName"]);
                            }
                            else
                            {
                                x = 1;
                            }
                            str.AppendFormat("<td class='contd1'>{0}</td>", dtteacher.Rows[i - 1]["TIDName"]);
                            if (i % dtsubject.Rows.Count == 0 && x == 1)
                            {
                                str.Append("</tr>");
                                x = 0;
                            }
                        }
                        else
                        {
                            str.Append("<tr>");
                            str.AppendFormat("<td class='contd1'>{0}</td>", dtteacher.Rows[i - 1]["RoomName"]);
                            str.AppendFormat("<td class='contd1'>{0}</td>", dtteacher.Rows[i - 1]["TIDName"]);
                            str.Append("</tr>");
                        }
                    }
                }
                str.Append("</table>");
                return str.ToString();
            }
            else
            {
                this.div_top.Visible = false;
                this.btn_OutPut.Visible = false;
                this.btn_OutPutWord.Visible = false;
                return "<span style='color:red;font-size: 22px;margin-top:10px;'>暂无监考教师信息</span>";
            }
        }
        #endregion


        #region 导出
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtsubject = subjectDAL.GetByEID(EID.ToString());
                StringBuilder str = new StringBuilder();
                if (dtsubject != null && dtsubject.Rows.Count > 0)
                {
                    str.Append("<table border='1' cellpadding='0' cellspacing='0'>");
                    str.AppendFormat("<tr><th colspan='" + (dtsubject.Rows.Count + 1) + "'>{0}</th></tr>", dtsubject.Rows[0]["GName"].ToString() + dtsubject.Rows[0]["EYear"].ToString() + "年度" + CommonFunction.CheckEnum<CommonEnum.XQ>(Convert.ToInt32(dtsubject.Rows[0]["Term"].ToString())) + dtsubject.Rows[0]["ExamName"] + "监考表");
                    str.Append("<tr>");
                    str.AppendFormat("<th>{0}</th>", "考场/考试");
                    foreach (DataRow row in dtsubject.Rows)
                    {
                        str.AppendFormat("<th>{0}</th>", row["CourseName"].ToString() + "【" + Convert.ToDateTime(row["BeginDate"]).ToString("yyyy-MM-dd HH:mm") + "-" + Convert.ToDateTime(row["EndDate"]).ToString("HH:mm") + "】");
                    }
                    str.Append("</tr>");
                    DataTable dtteacher = teacherDAL.GetByEID(EID.ToString());
                    if (dtteacher != null && dtteacher.Rows.Count > 0)
                    {
                        int x = 0;
                        for (int i = 1; i <= dtteacher.Rows.Count; i++)
                        {
                            if (dtsubject.Rows.Count > 1)
                            {
                                if (i % dtsubject.Rows.Count == 1 && x == 0)
                                {
                                    str.Append("<tr>");
                                    str.AppendFormat("<td>{0}</td>", dtteacher.Rows[i - 1]["RoomName"]);
                                }
                                else
                                {
                                    x = 1;
                                }
                                str.AppendFormat("<td>{0}</td>", dtteacher.Rows[i - 1]["TIDName"]);
                                if (i % dtsubject.Rows.Count == 0 && x == 1)
                                {
                                    str.Append("</tr>");
                                    x = 0;
                                }
                            }
                            else
                            {
                                str.Append("<tr>");
                                str.AppendFormat("<td>{0}</td>", dtteacher.Rows[i - 1]["RoomName"]);
                                str.AppendFormat("<td>{0}</td>", dtteacher.Rows[i - 1]["TIDName"]);
                                str.Append("</tr>");
                            }
                        }
                    }
                    str.Append("</table>");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出Excel监考表数据", UserID));
                    CommonFunction.ExportExcel("导出监考表", str.ToString());
                }
                else
                {
                    ShowMessage("暂无数据");
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


        #region 导出Word
        protected void btn_OutPutWord_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtsubject = subjectDAL.GetByEID(EID.ToString());
                if (dtsubject != null && dtsubject.Rows.Count > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出Word监考表数据", UserID));
                    CommonFunction.ImportWordJKB("../Template/JKB.doc", "监考表" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc", EID);
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
    }
}