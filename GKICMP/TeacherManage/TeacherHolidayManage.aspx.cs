/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月17日 09点30分
** 描   述:      招标详情
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
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
    public partial class TeacherHolidayManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_HolidayDAL teacher_HolidayDAL = new Teacher_HolidayDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["TeacherName"] = CommonFunction.GetCommoneString(this.txt_TeacName.Text.ToString().Trim());
                DDLBind();
                DataBindList();
            }
        }
        #region 下拉框绑定
        /// <summary>
        /// 下拉框绑定
        /// </summary>
        private void DDLBind()
        {
            //DataTable dtDep = DepartmentBLL.GetSchool();
            //CommonFunction.DDlTypeBind(this.ddl_Depart, dtDep, "DepID", "DepName", "-2");//单位

            DataTable dtHType = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.长假类型);
            CommonFunction.DDlTypeBind(this.ddl_HType, dtHType, "SDID", "DataName", "-2");

            DataTable dtCourse = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.学科);
            CommonFunction.DDlTypeBind(this.ddl_TCourse, dtCourse, "SDID", "DataName", "-2");
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {

            int recordCount = -1;
            Teacher_HolidayEntity model = new Teacher_HolidayEntity();
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            //model.DepID = int.Parse(this.ddl_Depart.SelectedValue);
            model.HType = int.Parse(this.ddl_HType.SelectedValue);
            DataTable dt = teacher_HolidayDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, (string)ViewState["TeacherName"], int.Parse(this.ddl_TCourse.SelectedValue));
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
            ViewState["TeacherName"] = CommonFunction.GetCommoneString(this.txt_TeacName.Text.ToString().Trim());
            DataBindList();
        }
        #endregion

        //#region 跳转详情页面
        ///// <summary>
        ///// 跳转详情页面
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lbtn_Info_Click(object sender, EventArgs e)
        //{
        //    LinkButton lbtn = (LinkButton)sender;
        //    string id = lbtn.CommandArgument.ToString();
        //    string aa = string.Format("<script language=javascript>window.open('TeacherHolidayDetail.aspx?THID={0}', '_self')</script>", id);
        //    Response.Write(aa);
        //}
        //#endregion

        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string ids = this.hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = teacher_HolidayDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除教师长假信息信息", UserID));
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
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            StringBuilder str = new StringBuilder();
            Teacher_HolidayEntity model = new Teacher_HolidayEntity();
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            // model.DepID = int.Parse(this.ddl_Depart.SelectedValue);
            DataTable dt = teacher_HolidayDAL.GetPaged(9999999, 1, ref recordCount, model, (string)ViewState["TeacherName"], int.Parse(this.ddl_TCourse.SelectedValue));
            if (dt == null)
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>姓名</strong></th>
                                        <th><strong>原单位</strong></th>
                                        <th><strong>所授科目</strong></th>
                                        <th><strong>开始日期</strong></th>
                                        <th><strong>结束日期</strong></th>
                                        <th><strong>休假备注</strong></th>
                                        <th><strong>是否上报</strong></th>
                                        </tr>");

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["TeacherName"]);
                    str.AppendFormat("<td>{0}</td>", row["DepName"]);
                    str.AppendFormat("<td>{0}</td>", row["CourseName"]);
                    str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["HStartDate"].ToString()).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["HEndDate"].ToString()).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", row["HolidayDesc"]);
                    str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.IsorNot>(row["IsReport"].ToString()).ToString() == "0" ? "未上报" : "已上报");
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("教师长假信息表", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出教师长假信息表", UserID));
        }
        #endregion

        #region 单条上报 --测试完成
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {

            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                string aa = "";
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();

                #region 附件上传
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_HolidayEntity dr = teacher_HolidayDAL.GetObjByID(id.Split(',')[i]);
                    for (int t = 0; t < dr.HFile.Split(',').Length; t++)
                    {
                        Byte[] b = CommonFunction.File2Bytes(dr.HFile.Split(',')[t]);
                        service.SaveFile(b, dr.HFile.Split(',')[t]);
                    }
                }
                #endregion

                List<GKICMP.localhost1.Teacher_HolidayEntity> args = new List<GKICMP.localhost1.Teacher_HolidayEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_HolidayEntity p = teacher_HolidayDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Teacher_HolidayEntity model1 = new localhost1.Teacher_HolidayEntity();

                    model1.THID = p.THID;
                    model1.TID = p.TID;
                    //model1.HType = p.HType;--类型无法转换
                    model1.HType = Convert.ToString(p.HType);
                    model1.DepID = p.DepID;
                    model1.HStartDate = p.HStartDate;
                    model1.HEndDate = p.HEndDate;
                    model1.HolidayDesc = p.HolidayDesc;
                    model1.CreateDate = DateTime.Now; ;
                    model1.HFile = p.HFile;
                    model1.Isdel = (int)CommonEnum.Deleted.未删除;
                    model1.HDays = p.HDays;
                    args.Add(model1);
                }

                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.Teacher_HolidayEntity[] A = args.ToArray();
                if (service.TeacherHoliday(sguid, A, out aa))
                {
                    int rusult = teacher_HolidayDAL.Update(id);//更新字段为 已上报
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

        #region 上报 --多条上报
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

                #region 附件上传
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_HolidayEntity dr = teacher_HolidayDAL.GetObjByID(id.Split(',')[i]);
                    for (int t = 0; t < dr.HFile.Split(',').Length; t++)
                    {
                        Byte[] b = CommonFunction.File2Bytes(dr.HFile.Split(',')[t]);
                        service.SaveFile(b, dr.HFile.Split(',')[t]);
                    }
                }
                #endregion

                List<GKICMP.localhost1.Teacher_HolidayEntity> args = new List<GKICMP.localhost1.Teacher_HolidayEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_HolidayEntity p = teacher_HolidayDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Teacher_HolidayEntity model1 = new localhost1.Teacher_HolidayEntity();

                    model1.THID = p.THID;
                    model1.TID = p.TID;
                    //model1.HType = p.HType;--类型无法转换
                    model1.HType = Convert.ToString(p.HType);
                    model1.DepID = p.DepID;
                    model1.HStartDate = p.HStartDate;
                    model1.HEndDate = p.HEndDate;
                    model1.HolidayDesc = p.HolidayDesc;
                    model1.CreateDate = DateTime.Now; ;
                    model1.HFile = p.HFile;
                    model1.Isdel = (int)CommonEnum.Deleted.未删除;
                    model1.HDays = p.HDays;
                    args.Add(model1);
                }

                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.Teacher_HolidayEntity[] A = args.ToArray();
                if (service.TeacherHoliday(sguid, A, out aa))
                {
                    int rusult = teacher_HolidayDAL.Update(id);//更新字段为 已上报
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


        #region 导出
        protected void btn_OutPut_Click1(object sender, EventArgs e)
        {
            try
            {
                int recordCount = -1;
                Teacher_HolidayEntity model = new Teacher_HolidayEntity();
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.HType = int.Parse(this.ddl_HType.SelectedValue);
                DataTable dt = teacher_HolidayDAL.GetPaged(int.MaxValue, 1, ref recordCount, model, (string)ViewState["TeacherName"], int.Parse(this.ddl_TCourse.SelectedValue));
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append("<table border='1' cellspaccing='0' cellpadding='0'><tr><th>姓名</th><th>所授学科</th><th>长假类型</th><th>开始日期</th><th>结束日期</th><th>休假备注</th><th>是否上报</th></tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["TeacherName"]);
                        str.AppendFormat("<td>{0}</td>", row["CourseName"]);
                        str.AppendFormat("<td>{0}</td>", row["HTypeName"]);
                        str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["HStartDate"]).ToString("yyyy-MM-dd"));
                        str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["HEndDate"]).ToString("yyyy-MM-dd"));
                        str.AppendFormat("<td>{0}</td>", row["HolidayDesc"].ToString());
                        str.AppendFormat("<td>{0}</td>", row["IsReport"].ToString() == "0" ? "<span style='color:red'>未上报</span>" : "已上报");
                        str.Append("</tr>");
                    }
                    str.Append("</tr>");
                    str.Append("</table>");
                    CommonFunction.ExportExcel("请假管理信息", str.ToString());
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