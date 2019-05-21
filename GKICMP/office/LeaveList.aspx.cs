using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.oamanage
{
    public partial class LeaveList : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveDAL leaveDAL = new LeaveDAL();
        public LeaveAuditDAL leaveAuditDAL = new LeaveAuditDAL();

        #region 参数集合
        /// <summary>
        /// Flag 1：学生 2：全部教师请假-1 我的请假（教师）
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

                if (Flag == 2)
                {
                    this.btn_Add.Visible = false;
                    this.btn_Delete.Visible = false;
                    CommonFunction.DDlDataBaseBind(this.ddl_LType, (int)CommonEnum.BaseDataType.请假类型, "-999");
                }
                else if (Flag == 1)
                {
                    this.btn_OutPut.Visible = false;
                    this.btn_AllOut.Visible = false;
                    this.divpos.Visible = false;
                    this.div1.Visible = true;
                    this.txt_LeaveUser.Text = UserRealName;
                    this.txt_LeaveUser.Enabled = false;
                    CommonFunction.BindEnum<CommonEnum.StuLeaveType>(this.ddl_LType, "-2");
                }
                else
                {
                    this.btn_OutPut.Visible = false;
                    this.btn_AllOut.Visible = false;
                    this.txt_LeaveUser.Text = UserRealName;
                    this.txt_LeaveUser.Enabled = false;
                    CommonFunction.DDlDataBaseBind(this.ddl_LType, (int)CommonEnum.BaseDataType.请假类型,"-999");
                    //CommonFunction.BindEnum<CommonEnum.LType>(this.ddl_LType, "-2");
                }
                CommonFunction.BindEnum<CommonEnum.AduitState>(this.ddl_LeaveState, "-2");
                GetConditon();
                DataBindList();
                this.hf_Flag.Value = Flag.ToString();
            }
        }
        #endregion


        public bool GetIsshow()
        {
            if (Flag == 2)
                return false;
            else
                return true;
        }


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        public void GetConditon()
        {
            ViewState["LeaveUser"] = CommonFunction.GetCommoneString(this.txt_LeaveUser.Text);
            ViewState["BeginDate"] = this.txt_SDate.Text == "" ? "1900-01-01" :Convert .ToDateTime( this.txt_SDate.Text).ToString("yyyy-MM-dd 0:00:00");
            ViewState["EndDate"] = this.txt_EDate.Text == "" ? "9999-12-31" : Convert.ToDateTime(this.txt_EDate.Text).ToString("yyyy-MM-dd 23:59:59");
            ViewState["LeaveState"] = this.ddl_LeaveState.SelectedValue;
            ViewState["LType"] = this.ddl_LType.SelectedValue;
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        public void DataBindList()
        {
            int recordCount = 0;
            LeaveEntity model = new LeaveEntity();
            model.LeaveUserName = ViewState["LeaveUser"].ToString();
            model.BeginDate = Convert.ToDateTime(ViewState["BeginDate"].ToString());
            model.EndDate = Convert.ToDateTime(ViewState["EndDate"].ToString());
            model.LeaveState = Convert.ToInt32(ViewState["LeaveState"].ToString());
            model.LType = Convert.ToInt32(ViewState["LType"].ToString());
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            model.LFlag = Convert.ToInt32(CommonEnum.LFlag.请假);
            //model.LeaveUser =UserRealName;
            //if (Flag == 2)
            //{
                model.LeaveUser = ViewState["LeaveUser"].ToString();
            //}
            DataTable dt = leaveDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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


        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetConditon();
            DataBindList();
        }
        #endregion


        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = leaveDAL.DeleteBat(ids, Convert.ToInt32(CommonEnum.Deleted.删除));
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除请假信息", UserID));
                    ShowMessage();
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 分页
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 复选框是否可用
        /// <summary>
        /// 复选框是否可用
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public string Istrue(object sender)
        {
            if (Flag == 1)
            {
                if (sender.ToString() == Convert.ToInt32(CommonEnum.AduitState.未审核).ToString())
                {
                    return "";
                }
                else
                {
                    return "disabled";
                }
            }
            else 
            {
                return "";
            }
        }
        #endregion

        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                string name = "";
                DataSet dtall = new DataSet();
                DataTable dt = new DataTable();
                DataTable dtaudit = new DataTable();


                DataTable dtneew = new DataTable("Item");
                dtneew.Columns.Add("LID", typeof(string));
                dtneew.Columns.Add("RealName", typeof(string));
                dtneew.Columns.Add("AuditName", typeof(string));
                dtneew.Columns.Add("AuditDate", typeof(string));
                dtneew.Columns.Add("AuditResult", typeof(string));
                dtneew.Columns.Add("AuditMark", typeof(string));
                dtneew.Columns.Add("AuditOrder", typeof(string));
                if (this.hf_CheckIDS.Value == "")
                {
                    int recordCount = 0;
                    LeaveEntity model = new LeaveEntity();
                    model.LeaveUserName = ViewState["LeaveUser"].ToString();
                    model.BeginDate = Convert.ToDateTime(ViewState["BeginDate"].ToString());
                    model.EndDate = Convert.ToDateTime(ViewState["EndDate"].ToString());
                    model.LeaveState = Convert.ToInt32(ViewState["LeaveState"].ToString());
                    model.LType = Convert.ToInt32(ViewState["LType"].ToString());
                    model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
                    model.LFlag = Convert.ToInt32(CommonEnum.LFlag.请假);
                    model.LeaveUser = ViewState["LeaveUser"].ToString();
                    dt = leaveDAL.GetPaged(2000, 1, ref recordCount, model);
                    dtaudit = leaveAuditDAL.GetList(model);
                }
                else
                {
                    dt = leaveDAL.GetList(this.hf_CheckIDS.Value.Trim(','));
                    dtaudit = leaveAuditDAL.GetList(this.hf_CheckIDS.Value.Trim(','));
                }
                string schoolname = ConfigurationManager.AppSettings["SchoolName"];
                if (dt.Rows.Count > 0)
                {
                    DataTable leave = new DataTable("All");
                    //source.Columns.Add("")
                    leave.Columns.Add("LID", typeof(string));
                    leave.Columns.Add("SchoolName", typeof(string));
                    leave.Columns.Add("Title", typeof(string));
                    leave.Columns.Add("UserName", typeof(string));
                    leave.Columns.Add("PostName", typeof(string));
                    leave.Columns.Add("AppDate", typeof(string));
                    leave.Columns.Add("LType", typeof(string));
                    leave.Columns.Add("Desc", typeof(string));

                    leave.Columns.Add("Begin", typeof(string));
                    leave.Columns.Add("End", typeof(string));
                    leave.Columns.Add("Days", typeof(string));
                    //leave.Columns.Add("AuditName", typeof(string));
                    //leave.Columns.Add("AuditDate", typeof(string));
                    foreach (DataRow dr in dt.Rows)
                    {
                        List<string> list = new List<string>();
                        list.Add(dr["LID"].ToString());
                        list.Add(schoolname);
                        list.Add(dr["TypeName"].ToString() + dr["LeaveDays"].ToString()+"天");
                        list.Add(dr["UserName"].ToString());
                        list.Add(dr["PostName"].ToString());
                        list.Add(Convert.ToDateTime(dr["LeaveDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                        list.Add(dr["TypeName"].ToString());
                        list.Add(dr["LeaveMark"].ToString());

                        list.Add(Convert.ToDateTime( dr["BeginDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                        list.Add(Convert.ToDateTime(dr["EndDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                        list.Add(dr["LeaveDays"].ToString());
                        DataRow[] drlist=dtaudit.Select("LID='" + dr["LID"] + "'"); 
                       
                        if (drlist.Length > 0)
                        {
                           
                            foreach (DataRow dra in drlist)
                            {


                                List<string> list1 = new List<string>();
                                DataRow[] drselect = dtaudit.Select("LID='" + dra["LID"] + "' AND AuditOrder=" + dra["AuditOrder"] + " and AuditResult<>1");
                                if (drselect.Length > 0)
                                {
                                    if (dtneew.Select("LID='" + dra["LID"] + "' AND AuditOrder=" + dra["AuditOrder"]).Length <= 0)
                                    {
                                        list1.Add(drselect[0]["LID"].ToString());
                                        list1.Add(drselect[0]["RealName"].ToString());
                                        list1.Add(drselect[0]["AuditResult"].ToString() == "1" ? "" : drselect[0]["RealName"].ToString().Split(',').Length > 1 ? (drselect[0]["AuditName"].ToString() + ":") : "");
                                        list1.Add(drselect[0]["AuditDate"].ToString() == "" ? "" : Convert.ToDateTime(drselect[0]["AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm"));
                                        list1.Add(CommonFunction.CheckEnum<CommonEnum.AduitState>( drselect[0]["AuditResult"].ToString()));
                                        list1.Add(drselect[0]["AuditMark"].ToString());
                                        list1.Add(drselect[0]["AuditOrder"].ToString());
                                        dtneew.Rows.Add(list1.ToArray());
                                    }
                                }

                                else
                                {
                                    if (dtneew.Select("LID='" + dra["LID"] + "' AND AuditOrder=" + dra["AuditOrder"]).Length <= 0)
                                    {
                                        list1.Add(dra["LID"].ToString());
                                        list1.Add(dra["RealName"].ToString());
                                        list1.Add(dra["AuditResult"].ToString() == "1" ? "" : dra["RealName"].ToString().Split(',').Length > 1 ? dra["AuditName"].ToString() : "");
                                        list1.Add(dra["AuditDate"].ToString() == "" ? "" : Convert.ToDateTime(dra["AuditDate"].ToString()).ToString("yyyy-MM-dd HH:mm"));
                                        list1.Add(CommonFunction.CheckEnum<CommonEnum.AduitState>(dra["AuditResult"].ToString()));
                                        list1.Add(dra["AuditMark"].ToString());
                                        list1.Add(dra["AuditOrder"].ToString());
                                        dtneew.Rows.Add(list1.ToArray());
                                    }
                                }
                                
                            }
                            //foreach (DataRow drnew in dtneew.Rows) 
                            //{
                            //    name += drnew["RealName"].ToString() + ",      " + (drnew["RealName"].ToString().Split(',').Length > 1 ? drnew["AuditName"].ToString() : drnew["RealName"].ToString())+"      " +
                            //        CommonFunction.CheckEnum<CommonEnum.AduitState>(drnew["AuditResult"]) + ";    " + drnew["AuditMark"].ToString() + drnew["AuditDate"].ToString();
                            //}
                        }
                        //list.Add(name);
                       // list.Add(dr["AuditDate"].ToString());
                       

                        leave.Rows.Add(list.ToArray());
                       

                    }
                    //dtall.Tables.Add(leave.Copy());
                    //dtall.Tables.Add(dtneew.Copy());
                    ExportWord.ImportWord(leave,dtneew ,"../Template/Leave.docx", "教师请假列表" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc", new SysSetConfigEntity());
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "导出教师请假信息", UserID));
                }
                else
                {
                    ShowMessage("暂无数据导出，请选择时间段");
                    return;
                }
            }
            catch (Exception ex)
            {
               ShowMessage("导出失败"+ex.Message);
               sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
               return;
            }
        }


        #region 导出Excel事件
        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_AllOut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            StringBuilder str = new StringBuilder();
            LeaveEntity model = new LeaveEntity();
            model.LeaveUserName = ViewState["LeaveUser"].ToString();
            model.BeginDate = Convert.ToDateTime(ViewState["BeginDate"].ToString());
            model.EndDate = Convert.ToDateTime(ViewState["EndDate"].ToString());
            model.LeaveState = Convert.ToInt32(ViewState["LeaveState"].ToString());
            model.LType = Convert.ToInt32(ViewState["LType"].ToString());
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            model.LFlag = Convert.ToInt32(CommonEnum.LFlag.请假);
            model.LeaveUser = ViewState["LeaveUser"].ToString();
           
            DataTable dt = leaveDAL.GetPaged(2000, 1, ref recordCount, model);


            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>请假人</strong></th>
                                        <th><strong>类型</strong></th>
                                        <th><strong>开始日期</strong></th>
                                        <th><strong>结束日期</strong></th>
                                        <th><strong>天数</strong></th>
                                        <th><strong>状态</strong></th>
                                     </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["LeaveUserName"]);
                    str.AppendFormat("<td>{0}</td>", row["LTypeName"]);
                    str.AppendFormat("<td>{0}</td>", row["BeginDate"].ToString() == "" ? "" : Convert.ToDateTime(row["BeginDate"]).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", row["EndDate"].ToString() == "" ? "" : Convert.ToDateTime(row["EndDate"]).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", row["LeaveDays"]);
                    str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.AduitState>(row["LeaveState"].ToString()));
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("教师请假导出", str.ToString());


        }
        #endregion
    }
}