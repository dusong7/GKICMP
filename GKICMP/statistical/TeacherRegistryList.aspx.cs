/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年9月15日 10时37分53秒
** 描    述:      教师简明情况统计表
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.statistical
{
    public partial class TeacherRegistryList : PageBase
    {
        public TeacherDAL teacherDAL = new TeacherDAL();
        public CampusDAL campusDAL = new CampusDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 参数集合
        /// <summary>
        /// flag 1:在编 2：区聘
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
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
                DataTable dt = campusDAL.GetList((int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_Campus, dt, "CID", "CampusName", "-2");
                CommonFunction.BindEnum<CommonEnum.XB>(this.ddl_TSex, "-2");
                CommonFunction.BindEnum<CommonEnum.MZ>(this.ddl_Nation, "-2");
                CommonFunction.BindEnum<CommonEnum.ZZMM>(this.ddl_Politics, "-2");
                CommonFunction.BindEnum<CommonEnum.XL>(this.ddl_Education, "-2");
                CommonFunction.BindEnum<CommonEnum.CurrentProfessional>(this.ddl_CurrentPro, "-2");
                DataTable dtCourse = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_Course, dtCourse, "CID", "CourseName", "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        private void GetCondition()
        {
            ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_RealName.Text.ToString().Trim());
            ViewState["Campus"] = this.ddl_Campus.SelectedValue.ToString();
            ViewState["TSex"] = this.ddl_TSex.SelectedValue.ToString();
            ViewState["Nation"] = this.ddl_Nation.SelectedValue.ToString();
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString();
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString();
            ViewState["JBegin"] = this.txt_JBegin.Text == "" ? "1900-01-01" : this.txt_JBegin.Text.ToString();
            ViewState["JEnd"] = this.txt_JEnd.Text == "" ? "9999-12-31" : this.txt_JEnd.Text.ToString();
            ViewState["PBegin"] = this.txt_PBegin.Text == "" ? "1900-01-01" : this.txt_PBegin.Text.ToString();
            ViewState["PEnd"] = this.txt_PEnd.Text == "" ? "9999-12-31" : this.txt_PEnd.Text.ToString();
            ViewState["PostRole"] = CommonFunction.GetCommoneString(this.txt_PostRole.Text.ToString().Trim());
            ViewState["Politics"] = this.ddl_Politics.SelectedValue.ToString();
            ViewState["Education"] = this.ddl_Education.SelectedValue.ToString();
            ViewState["Course"] = this.ddl_Course.SelectedValue.ToString();
            ViewState["CurrentPro"] = this.ddl_CurrentPro.SelectedValue.ToString();
            ViewState["IDCard"] = CommonFunction.GetCommoneString(this.txt_IDCard.Text.ToString().Trim());
            ViewState["LinkNum"] = CommonFunction.GetCommoneString(this.txt_LinkNum.Text.ToString().Trim());
            ViewState["Email"] = CommonFunction.GetCommoneString(this.txt_Email.Text.ToString().Trim());
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            TeacherEntity model = new TeacherEntity();
            model.RealName = (string)ViewState["RealName"];
            model.CID = Convert.ToInt32(ViewState["Campus"].ToString());
            model.TSex = Convert.ToInt32(ViewState["TSex"].ToString());
            model.TNation = Convert.ToInt32(ViewState["Nation"].ToString());
            model.PostRole = (string)ViewState["PostRole"];
            model.Politics = Convert.ToInt32(ViewState["Politics"].ToString());
            model.TCourse = Convert.ToInt32(ViewState["Course"].ToString());
            model.CurrentProfessional = Convert.ToInt32(ViewState["CurrentPro"].ToString());
            model.IDCardNum = (string)ViewState["IDCard"];
            model.CellPhone = (string)ViewState["LinkNum"];
            model.Email = (string)ViewState["Email"];
            model.IsSeries = Flag;
            model.IsDel = (int)CommonEnum.Deleted.未删除;

            DataTable dt = teacherDAL.GetTeacher(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()), Convert.ToDateTime(ViewState["JBegin"].ToString()), Convert.ToDateTime(ViewState["JEnd"].ToString()), Convert.ToDateTime(ViewState["PBegin"].ToString()), Convert.ToDateTime(ViewState["PEnd"].ToString()), Convert.ToInt32(ViewState["Education"].ToString()));
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_List.DataBind();
        }
        #endregion


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 导出事件
        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                int recordCount = -1;
                TeacherEntity model = new TeacherEntity();
                model.RealName = (string)ViewState["RealName"];
                model.CID = Convert.ToInt32(ViewState["Campus"].ToString());
                model.TSex = Convert.ToInt32(ViewState["TSex"].ToString());
                model.TNation = Convert.ToInt32(ViewState["Nation"].ToString());
                model.PostRole = (string)ViewState["PostRole"];
                model.Politics = Convert.ToInt32(ViewState["Politics"].ToString());
                model.TCourse = Convert.ToInt32(ViewState["Course"].ToString());
                model.CurrentProfessional = Convert.ToInt32(ViewState["CurrentPro"].ToString());
                model.IDCardNum = (string)ViewState["IDCard"];
                model.CellPhone = (string)ViewState["LinkNum"];
                model.Email = (string)ViewState["Email"];
                model.IsSeries = Flag;
                model.IsDel = (int)CommonEnum.Deleted.未删除;
                DataTable dt = teacherDAL.GetTeacher(2000, 1, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()), Convert.ToDateTime(ViewState["JBegin"].ToString()), Convert.ToDateTime(ViewState["JEnd"].ToString()), Convert.ToDateTime(ViewState["PBegin"].ToString()), Convert.ToDateTime(ViewState["PEnd"].ToString()), Convert.ToInt32(ViewState["Education"].ToString()));
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                               <tr>
                                    <th align='center' rowspan='2'>姓名</th>
                                    <th align='center' rowspan='2'>性别</th>
                                    <th align='center' rowspan='2'>民族</th>
                                    <th align='center' rowspan='2'>出生年月</th>
                                    <th align='center' rowspan='2'>工作时间</th>
                                    <th align='center' rowspan='2'>入党时间</th>
                                    <th align='center' rowspan='2'>行政职务</th>
                                    <th align='center' rowspan='2'>何民主党派</th>
                                    <th align='center' colspan='2'>文化程度</th>
                                    <th align='center' rowspan='2'>所授科目</th>
                                    <th align='center' rowspan='2'>专业技术职称</th>
                                    <th align='center' rowspan='2'>身份证号</th>
                                    <th align='center' rowspan='2'>联系方式</th>
                                    <th align='center' rowspan='2'>邮箱地址</th>
                                </tr>
                                <tr>
                                    <th>学历</th>
                                    <th>何时何校何专业</th>
                                </tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["RealName"].ToString());
                        str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XB>(row["TSex"].ToString()));
                        str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.MZ>(row["TNation"].ToString()));
                        str.AppendFormat("<td style='vnd.ms-excel.numberformat:yyyy-MM'>{0}</td>", row["Birthday"].ToString());
                        str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["JodDate"]).ToString("yyyy-MM-dd"));
                        str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["PartyTme"].ToString() == "" ? "1900-01-01" : row["PartyTme"]).ToString("yyyy-MM-dd") == "1900-01-01" ? "" : Convert.ToDateTime(row["PartyTme"]).ToString("yyyy-MM-dd"));
                        str.AppendFormat("<td>{0}</td>", row["PostRole"].ToString());
                        str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.ZZMM>(row["Politics"].ToString()));
                        str.AppendFormat("<td>{0}</td>", row["Education"].ToString() == "" ? "" : GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XL>(row["Education"].ToString()));
                        str.AppendFormat("<td>{0}</td>", row["Education"].ToString() == "" ? "" : (Convert.ToDateTime(row["OutDate"]).ToString("yyyy-MM-dd") + "," + row["EduSchool"] + "," + row["EMajor"]));
                        str.AppendFormat("<td>{0}</td>", row["CourseName"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["CurrentProfessional"].ToString() == "0" ? "" : GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.CurrentProfessional>(row["CurrentProfessional"]));
                        str.AppendFormat("<td style='vnd.ms-excel.numberformat:@'>{0}</td>", row["IDCardNum"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["CellPhone"].ToString()==""?"":"");
                        str.AppendFormat("<td>{0}</td>", row["Email"].ToString()==""?"":"");
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    CommonFunction.ExportExcel(DateTime.Now.Year + "年" + (Flag == 1 ? "在编" : "区聘") + "教职工简明情况统计表", str.ToString());
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "教职工简明情况统计表信息", UserID));
                }
                else
                {
                    ShowMessage("暂无数据导出");
                    return;
                }
            }
            catch (Exception ex)
            {
                //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion
    }
}