/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      liufuzhou 
** 创建日期:      2018年01月02日 16时48分17秒
** 描    述:      采购信息添加
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

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.purchase
{
    public partial class PurchaseDetail : PageBase
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                    this.ltl_PType.Text = model.PTypeName;
                }
                GetPurchaseBill();
                GetAuditUser();
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
            decimal allprice = 0.0M;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                allprice += Convert.ToDecimal(dt.Rows[i]["BPrice"].ToString()) * Convert.ToInt32(dt.Rows[i]["BCount"].ToString());
            }
            this.ltl_AllPrice.Text = allprice.ToString();
        }
        #endregion

        #region 删除采购明细
        /// <summary>
        /// 删除采购明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_BDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string esid = lbtn.CommandArgument.ToString();
                int result = purchase_BillDAL.DeleteBat(esid);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除采购明细", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                GetPurchaseBill();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion

        #region 绑定审核人信息
        /// <summary>
        /// 绑定审核人信息
        /// </summary>
        private void GetAuditUser()
        {
            DataTable dt = purchase_AuditDAL.GetList(this.hf_PID.Value.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                count = dt.Rows.Count;
                this.trnull.Visible = false;
            }
            else
            {
                this.trnull.Visible = true;
            }

            this.rp_AList.DataSource = dt;
            rp_AList.DataBind();
        }
        #endregion

        //#region 删除采购审核人
        ///// <summary>
        ///// 删除请假审核人
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lbtn_Delete_Click(object sender, EventArgs e)
        //{
        //    LinkButton ibtn = (LinkButton)sender;
        //    int istrue = purchase_AuditDAL.DeleteBat(ibtn.CommandArgument.ToString());
        //    if (istrue > 0)
        //    {
        //        ShowMessage("删除成功");
        //        GetAuditUser();
        //    }
        //    else
        //    {
        //        ShowMessage("删除失败");
        //        return;
        //    }
        //}
        //#endregion

        #region 刷新页面
        /// <summary>
        /// 刷新页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GetPurchaseBill();
            GetAuditUser();
        }
        #endregion

        //#region 提交
        ///// <summary>
        ///// 提交
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btn_Submit_Click(object sender, System.EventArgs e)
        //{
        //    try
        //    {
        //        PurchaseEntity model = new PurchaseEntity();
        //        model.PID = this.hf_PID.Value;
        //        model.PTitle = this.txt_PTitle.Text.Trim();
        //        model.PEstimate = decimal.Parse(this.txt_PEstimate.Text);
        //        model.CreateDate = DateTime.Now;
        //        model.CreateUser = UserID;
        //        model.Isdel = (int)CommonEnum.IsorNot.否;
        //        model.PState = (int)CommonEnum.AduitState.未审核;
        //        model.IsReport = (int)CommonEnum.IsorNot.否;
        //        model.PDesc = this.txt_PDesc.Text;
        //        int result = purchaseDAL.Edit(model);
        //        if (result > 0)
        //        {
        //            sysLogDAL.Edit(new SysLogEntity(PID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改, (PID == "" ? "添加" : "修改") + "采购信息为【" + this.txt_PTitle.Text + "】的信息", UserID));
        //            ShowMessage();
        //        }
        //        else
        //        {
        //            ShowMessage("提交失败");
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
        //        ShowMessage(ex.Message.Replace("\"", "").Replace("'", ""));
        //        return;
        //    }
        //}
        //#endregion

        #region 计算小计
        public string GetPrice(object sender1, object sender2)
        {
            if (sender1.ToString() != "" && sender2.ToString() != "")
            {
                return (Convert.ToDecimal(sender1.ToString()) * Convert.ToInt32(sender2.ToString())).ToString();
            }
            else
            {
                return "0";
            }
        }
        #endregion
    }
}