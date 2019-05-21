/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2016年11月09日
** 描 述:       供应商编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace ICMP.assetmanage
{
    public partial class SupplierEdit : PageBase
    {
        public SupplierDAL supplierDAL = new SupplierDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


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
                    InfoBind();
                }
            }
        }
        #endregion


        #region 提交
        /// <summary>
        ///   提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                SupplierEntity model = new SupplierEntity();
                model.SDID = SDID == "" ? "" : SDID;
                model.SupplierName = this.txt_SupplierName.Text.Trim();
                model.Enterprise = this.txt_Enterprise.Text.Trim();
                model.LinkUser = this.txt_LinkUser.Text.Trim();
                model.LinkPost = this.txt_LinkPost.Text.Trim();
                model.LinkPhone = this.txt_LinkPhone.Text.Trim();
                model.MainAssest = this.txt_MainAssest.Text.Trim();
                model.BankName = this.txt_BankName.Text.Trim();
                model.BankNum = this.txt_BankNum.Text.Trim();
                model.Qualifications = this.txt_Qualifications.Text.Trim();
                model.Legal = this.txt_Legal.Text.Trim();
                model.CreateUser = UserID;
                int result = supplierDAL.Edit(model);
                if (result == -1)
                {
                    ShowMessage("保存失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("系统中已存在供应商名称，请重新录入");
                    return;
                }
                else
                {
                    int log = SDID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, SDID == "" ? "添加" : "修改" + "供应商名称为【"+this .txt_SupplierName.Text +"】的信息", UserID));
                    ShowMessage();
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            SupplierEntity model = supplierDAL.GetObjByID(SDID);
            if (model != null)
            {
                this.txt_SupplierName.Text = model.SupplierName;
                this.txt_Enterprise.Text = model.Enterprise;
                this.txt_LinkUser.Text = model.LinkUser;
                this.txt_LinkPost.Text = model.LinkPost;
                this.txt_LinkPhone.Text = model.LinkPhone;
                this.txt_MainAssest.Text = model.MainAssest;
                this.txt_BankName.Text = model.BankName;
                this.txt_BankNum.Text = model.BankNum;
                this.txt_Qualifications.Text = model.Qualifications;
                this.txt_Legal.Text = model.Legal;
            }
        }
        #endregion
    }
}