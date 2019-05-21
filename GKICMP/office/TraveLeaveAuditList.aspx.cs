
using System;
using System.Data;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.office
{
    public partial class TraveLeaveAuditList : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveDAL leaveDAL = new LeaveDAL();
        public LeaveAuditDAL auditDAL = new LeaveAuditDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CommonFunction.BindEnum<CommonEnum.AduitState>(this.ddl_LeaveState, "-2");
                GetConditon();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetConditon()
        {
            ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_LeaveUser.Text.Trim());
            ViewState["BeginDate"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;
            ViewState["EndDate"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;
            //ViewState["LeaveState"] = this.ddl_LeaveState.SelectedValue;
            ViewState["LType"] = "-2";
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            LeaveEntity model = new LeaveEntity();
            model.LeaveUserName = ViewState["RealName"].ToString();
            model.BeginDate = Convert.ToDateTime(ViewState["BeginDate"].ToString());
            model.EndDate = Convert.ToDateTime(ViewState["EndDate"].ToString());
            //model.LeaveState = Convert.ToInt32(ViewState["LeaveState"].ToString());
            model.LeaveState = 1;
            model.LType = Convert.ToInt32(ViewState["LType"].ToString());
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            model.LFlag = 2;
            int isdisplay = (int)CommonEnum.IsorNot.是;
            DataTable dt = auditDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, UserID, isdisplay);
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
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetConditon();
            DataBindList();
        }
        #endregion


        #region 分页
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 复选框是否可用
        public string Istrue(object sender)
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
        #endregion
    }
}