
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;

namespace GKICMP.teachermanage
{
    public partial class TeacherClassHourManage : PageBase
    {
        public Teacher_ClassHourDAL teacher_ClassHourDAL = new Teacher_ClassHourDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Semester, "-2");//学期

                //DataTable dtDep = DepartmentBLL.GetSchool();
                //CommonFunction.DDlTypeBind(this.ddl_DepName, dtDep, "DepID", "DepName", "-2");//单位

                DataTable ct = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.学科);//主教学科
                CommonFunction.DDlTypeBind(this.ddl_MainSubject, ct, "SDID", "DataName", "-2");
                ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_RealName.Text.Trim());//姓名
                DataBindList();
            }
        }
       
        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
             DataTable dt = new DataTable();
            int recordCount = -1;
            Teacher_ClassHourEntity model = new Teacher_ClassHourEntity((string)ViewState["RealName"], this.ddl_MainSubject.SelectedItem.Text == "--请选择--" ? "" : this.ddl_MainSubject.SelectedItem.Text, (int)CommonEnum.Deleted.未删除);
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.Semester = Convert.ToInt32(this.ddl_Semester.SelectedValue.ToString());
            model.SchoolYear = this.txt_SchoolYear.Text.ToString();
            dt = teacher_ClassHourDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_RealName.Text.Trim());//姓名
            DataBindList();
        }
        #endregion


        #region 导出事件
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            StringBuilder str = new StringBuilder();
            Teacher_ClassHourEntity model = new Teacher_ClassHourEntity((string)ViewState["RealName"], this.ddl_MainSubject.SelectedItem.Text == "--请选择--" ? "" : this.ddl_MainSubject.SelectedItem.Text, (int)CommonEnum.Deleted.未删除);
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.Semester = Convert.ToInt32(this.ddl_Semester.SelectedValue.ToString());
            model.SchoolYear = this.txt_SchoolYear.Text.ToString();
            DataTable dt = teacher_ClassHourDAL.GetPaged(9999999, 1, ref recordCount, model);
            if (dt == null || dt.Rows.Count == 0)
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                       <tr>
                            <th align='center' rowspan='2'>学年度/学期</th>
                            <th align='center' width='75' rowspan='2'>姓名</th>
                            <th align='center' rowspan='2'>性别</th>
                            <th align='center' rowspan='2'>年龄</th>
                            <th align='center' rowspan='2'>所授年级</th>
                            <th align='center' width='75' colspan='2'>主要任教学科及周课时</th>
                            <th align='center' colspan='2'>兼教其他学科及周课时</th>
                            <th align='center' rowspan='2'>周课时合计（纯课时）</th>
                            <th align='center' rowspan='2'>语文、数学、英语跨教情况</th>
                            <th align='center' rowspan='2'>任行政或班主任情况</th>
                            <th align='center' rowspan='2'>是否上报</th>
                        </tr>
                        <tr>
                            <th align='center' width='75'>主教学科</th>
                            <th align='center'>纯课时数</th>
                            <th align='center' width='75'>兼教学科</th>
                            <th align='center'>纯课时数</th>
                        </tr>");

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["SchoolYear"] + "学年度" + GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(row["Semester"]));
                    str.AppendFormat("<td>{0}</td>", row["RealName"]);
                    str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XB>(row["TSex"]));
                    str.AppendFormat("<td>{0}</td>", row["Age"]);
                    //str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.NJ>(row["GradeID"]));
                    str.AppendFormat("<td>{0}</td>", row["GradeName"]);
                    str.AppendFormat("<td>{0}</td>", row["MainName"]);
                    str.AppendFormat("<td>{0}</td>", row["MainHours"]);
                    str.AppendFormat("<td>{0}</td>", row["PartName"]);
                    str.AppendFormat("<td>{0}</td>", row["PartHours"]);
                    str.AppendFormat("<td>{0}</td>", row["TotelMainHours"]);
                    str.AppendFormat("<td>{0}</td>", row["SubDesc"]);
                    str.AppendFormat("<td>{0}</td>", row["Executive"]);
                    str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.IsorNot>(row["IsReport"].ToString()).ToString() == "0" ? "未上报" : "已上报");
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("教师课时", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "教师课时信息", UserID));
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

        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = teacher_ClassHourDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除教师课时信息", UserID));
                    ShowMessage("删除成功");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion

        #region 上报 ---测试完成
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string aa = "";
                List<GKICMP.localhost1.ClassHourEntity> args = new List<GKICMP.localhost1.ClassHourEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_ClassHourEntity p = teacher_ClassHourDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.ClassHourEntity model1 = new localhost1.ClassHourEntity();
                    model1.THID = p.THID;
                    model1.TID = p.TID;//
                    model1.GradeID = p.GradeID.ToString();//
                    model1.MainSubject = p.MainSubject;
                    model1.MainHours = p.MainHours;

                    model1.PartSubject = p.PartSubject;
                    model1.PartHours = p.PartHours;//
                    model1.Executive = p.Executive.ToString();
                    model1.SchoolYear = p.SchoolYear;
                    model1.Semester = p.Semester;//

                    model1.SubDesc = p.SubDesc;
                    model1.THDesc = p.THDesc;
                    model1.IDCard = p.IDCard;
                    model1.Isdel = (int)CommonEnum.Deleted.未删除;


                    args.Add(model1);
                }

               // service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.ClassHourEntity[] A = args.ToArray();
                if (service.TeacherClassHour(sguid, A, out aa))
                {
                    int rusult = teacher_ClassHourDAL.Update(id);//更新字段为 已上报
                    ShowMessage(aa);
                    DataBindList();
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }

        }
        #endregion

        #region 多条上报 ---测试未完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                string aa = "";
                string id = "";
                id = this.hf_CheckIDS.Value.ToString();
                id = id.TrimEnd(',').TrimStart(',');

                List<GKICMP.localhost1.ClassHourEntity> args = new List<GKICMP.localhost1.ClassHourEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_ClassHourEntity p = teacher_ClassHourDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.ClassHourEntity model1 = new localhost1.ClassHourEntity();
                    model1.THID = p.THID;
                    model1.TID = p.TID;//
                    model1.GradeID = p.GradeID.ToString();//
                    model1.MainSubject = p.MainSubject;
                    model1.MainHours = p.MainHours;

                    model1.PartSubject = p.PartSubject;
                    model1.PartHours = p.PartHours;//
                    model1.Executive = p.Executive.ToString();
                    model1.SchoolYear = p.SchoolYear;
                    model1.Semester = p.Semester;//

                    model1.SubDesc = p.SubDesc;
                    model1.THDesc = p.THDesc;
                    model1.IDCard = p.IDCard;
                    model1.Isdel = (int)CommonEnum.Deleted.未删除;


                    args.Add(model1);
                }

               // service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.ClassHourEntity[] A = args.ToArray();
                if (service.TeacherClassHour(sguid, A, out aa))
                {
                    int rusult = teacher_ClassHourDAL.Update(id);//更新字段为 已上报
                    ShowMessage(aa);
                    DataBindList();
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }

        }
        #endregion

        #region 判断复选框是否可用
        /// <summary>
        /// 判断复选框是否可用
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetState(object state)
        {
            string sstate = state.ToString();
            if (sstate == "1")
            {
                return "disabled";
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}