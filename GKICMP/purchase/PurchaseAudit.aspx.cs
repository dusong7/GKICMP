
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
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.purchase
{
    public partial class PurchaseAudit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Purchase_BillDAL purchase_BillDAL = new Purchase_BillDAL();
        public PurchaseDAL purchaseDAL = new PurchaseDAL();
        public Purchase_AuditDAL purchase_AuditDAL = new Purchase_AuditDAL();
        protected int count = 0;
        #region 参数集合
        /// <summary>
        /// 考试ID
        /// </summary>
        public string PID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public string PAID
        {
            get
            {
                return GetQueryString<string>("paid", "0");
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.AduitState>(this.ddl_AuditResult, "-99");
                this.ddl_AuditResult.Items.Remove(new ListItem("未审核", "1"));
                this.ddl_AuditResult.Items.Remove(new ListItem("审核中", "4"));
                if (PID == "")
                {
                    this.hf_PID.Value = Guid.NewGuid().ToString();
                }
                else
                {
                    this.hf_PID.Value = PID;
                    InfoBind();
                }
            }
        }

        public void InfoBind()
        {
            try
            {
                PurchaseEntity model = purchaseDAL.GetObjByID(PID);
                if (model != null)
                {
                    this.ltl_PTitle.Text = model.PTitle;
                    this.ltl_PEstimate.Text = model.PEstimate.ToString();
                    this.ltl_PDesc.Text = model.PDesc;
                }
                GetPurchaseBill();
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message.Replace("\"", "").Replace("'", ""));
                return;
            }
        }

        #region 获取采购明细
        /// <summary>
        /// 获取采购明细
        /// </summary>
        private void GetPurchaseBill()
        {
            DataTable dt = purchase_BillDAL.GetByPID(this.hf_PID.Value);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_BList.DataSource = dt;
            this.rp_BList.DataBind();
        }
        #endregion

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Purchase_AuditEntity model = new Purchase_AuditEntity();
                model.PAID =int.Parse(PAID);
                if (Convert.ToInt32(this.ddl_AuditResult.SelectedValue) == (int)CommonEnum.AduitState.通过 && this.txt_AuditMark.Text == "")
                    this.txt_AuditMark.Text = "通过";
                model.AuditMark = this.txt_AuditMark.Text;
                model.AuditResult = Convert.ToInt32(this.ddl_AuditResult.SelectedValue);
                model.PID = PID;
                model.AuditDate = DateTime.Now;
                int result = purchase_AuditDAL.Update(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核采购信息", UserID));
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
    }
}