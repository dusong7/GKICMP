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

namespace GKICMP.office
{
    public partial class LeaveListRecord : PageBase
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
                if (Flag == 1)//我的
                {
                    this.txt_LeaveUser.Text = UserRealName;
                    this.txt_LeaveUser.Enabled = false;

                }
                else //所有的
                {
                    this.btn_Delete.Visible = false;
                    this.btn_Add.Visible = false;
                }
                this.hf_Flag.Value = Flag.ToString();
                GetConditon();
                DataBindList();
            }
        }
        #endregion
        public bool GetIsshow()
        {
            if (Flag == 1)
                return true;
            else
                return false;
        }


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        public void GetConditon()
        {
            ViewState["LeaveUser"] = CommonFunction.GetCommoneString(this.txt_LeaveUser.Text);
            ViewState["BeginDate"] = this.txt_SDate.Text == "" ? "1900-01-01" : Convert.ToDateTime(this.txt_SDate.Text).ToString("yyyy-MM-dd 0:00:00");
            ViewState["EndDate"] = this.txt_EDate.Text == "" ? "9999-12-31" : Convert.ToDateTime(this.txt_EDate.Text).ToString("yyyy-MM-dd 23:59:59");
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
            model.LeaveState =-2;
            model.LType = -2;
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            model.LFlag = Convert.ToInt32(CommonEnum.LFlag.外出备案);
            model.LeaveUser = ViewState["LeaveUser"].ToString();
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
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除外出备案信息", UserID));
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
        public string Istrue()
        {
            if (Flag == 1)
                return "";
            else
                return "disabled";
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


                //DataTable dtneew = new DataTable("Item");
                ////dtneew.Columns.Add("LID", typeof(string));
                //dtneew.Columns.Add("RealName", typeof(string));
                //dtneew.Columns.Add("AuditName", typeof(string));
                //dtneew.Columns.Add("AuditDate", typeof(string));
                //dtneew.Columns.Add("AuditResult", typeof(string));
                //dtneew.Columns.Add("AuditMark", typeof(string));
                //dtneew.Columns.Add("AuditOrder", typeof(string));
                if (this.hf_CheckIDS.Value == "")
                {
                    int recordCount = 0;
                    LeaveEntity model = new LeaveEntity();
                    model.LeaveUserName = ViewState["LeaveUser"].ToString();
                    model.BeginDate = Convert.ToDateTime(ViewState["BeginDate"].ToString());
                    model.EndDate = Convert.ToDateTime(ViewState["EndDate"].ToString());
                    model.LeaveState = -2;
                    model.LType =-2;
                    model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
                    model.LFlag = Convert.ToInt32(CommonEnum.LFlag.外出备案);
                    model.LeaveUser = ViewState["LeaveUser"].ToString();
                    dt = leaveDAL.GetPaged(2000, 1, ref recordCount, model);
                    //dtaudit = leaveAuditDAL.GetList(model);
                }
                else
                {
                    dt = leaveDAL.GetList(this.hf_CheckIDS.Value.Trim(','));
                    //dtaudit = leaveAuditDAL.GetList(this.hf_CheckIDS.Value.Trim(','));
                }
                string schoolname = ConfigurationManager.AppSettings["SchoolName"];
                if (dt.Rows.Count > 0)
                {
                    DataTable leave = new DataTable("All");
                    leave.Columns.Add("姓名", typeof(string));
                    leave.Columns.Add("开始时间", typeof(string));
                    leave.Columns.Add("结束时间", typeof(string));
                    leave.Columns.Add("天数", typeof(string));
                    leave.Columns.Add("备注", typeof(string));
                    foreach (DataRow dr in dt.Rows)
                    {
                        List<string> list = new List<string>();
                        list.Add(dr["UserName"].ToString());
                        list.Add(Convert.ToDateTime(dr["BeginDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                        list.Add(Convert.ToDateTime(dr["EndDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));                       
                        list.Add(dr["LeaveDays"].ToString());
                        list.Add(dr["LeaveMark"].ToString());
                        leave.Rows.Add(list.ToArray());
                    }
                    CommonFunction.ExportByWeb(leave, "", "教师外出备案" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
                   // ExportWord.ImportWord(leave, dtneew, "../Template/Leave.docx", "教师外出备案" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc", new SysSetConfigEntity());
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "导出教师外出备案信息", UserID));
                }
                else
                {
                    ShowMessage("暂无数据导出，请选择时间段");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage("导出失败" + ex.Message);
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