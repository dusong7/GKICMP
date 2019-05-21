using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Web.UI.WebControls;

namespace GKICMP.office
{
    public partial class OverTimeAuditEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveAuditDAL leaveAuditDAL = new LeaveAuditDAL();



        #region 参数集合
        /// <summary>
        /// LAID 审核ID
        /// </summary>
        public string LAID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// LID 请假ID
        /// </summary>
        public string OID
        {
            get
            {
                return GetQueryString<string>("oid", "");
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
                CommonFunction.BindEnum<CommonEnum.AduitState>(this.ddl_AuditResult, "-99");
                this.ddl_AuditResult.Items.Remove(new ListItem("未审核", "1"));
                this.ddl_AuditResult.Items.Remove(new ListItem("审核中", "4"));
            }
        }
        #endregion


        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Leave_AuditEntity model = new Leave_AuditEntity();
                model.LAID = LAID.ToString();
                model.AuditMark = this.txt_AuditMark.Text;
                model.AuditResult = Convert.ToInt32(this.ddl_AuditResult.SelectedValue);
                model.LID = OID;
                int result = leaveAuditDAL.UpdateOvetTimeState(model);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核加班信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("保存失败");
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