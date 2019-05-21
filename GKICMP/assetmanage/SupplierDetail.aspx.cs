/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      201611月10日 10时55分47秒
** 描    述:     供应商详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;

namespace ICMP.assetmanage
{
    public partial class SupplierDetail : PageBase
    {
        public SupplierDAL supplierDAL = new SupplierDAL();


        #region 参数集合
        public string SDID
        {
            get
            {
                return GetQueryString<string>("id", "");
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
                if (SDID != "")
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 数据绑定
        public void BindInfo()
        {
            SupplierEntity model = supplierDAL.GetObjByID(SDID);
            if (model != null)
            {
                this.lbl_SupplierName.Text = model.SupplierName;
                this.lbl_Enterprise.Text = model.Enterprise;
                this.lbl_LinkUser.Text = model.LinkUser;
                this.lbl_LinkPost.Text = model.LinkPost;
                this.lbl_LinkPhone.Text = model.LinkPhone;
                this.lbl_MainAssest.Text = model.MainAssest;
                this.lbl_BankNum.Text = model.BankNum;
                this.lbl_BankName.Text = model.BankName;
                this.lbl_Qualifications.Text = model.Qualifications;
                this.lbl_Legal.Text = model.Legal;
            }
        }
        #endregion
    }
}