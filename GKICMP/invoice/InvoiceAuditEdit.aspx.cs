/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月30日 9时27分01秒
** 描    述:      报销审核编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.invoice
{
    public partial class InvoiceAuditEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveAuditDAL leaveAuditDAL = new LeaveAuditDAL();
        public InvoiceDAL invoiceDAL = new InvoiceDAL();


        #region 参数集合
        /// <summary>
        /// IID 报销ID
        /// </summary>
        public string IID
        {
            get
            {
                return GetQueryString<string>("iid", "");
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
                model.AuditMark = this.txt_AuditMark.Text;
                model.AuditResult = Convert.ToInt32(this.ddl_AuditResult.SelectedValue);
                model.LID = IID.ToString();
                model.AuditUser = UserID;
                int result = invoiceDAL.AuditEdit(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核报销信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("提交失败");
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