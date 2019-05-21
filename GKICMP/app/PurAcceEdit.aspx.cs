/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2019年5月17日 8时49分24秒
** 描    述:      项目验收详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Configuration;

namespace GKICMP.app
{
    public partial class PurAcceEdit : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public PurchaseDAL purchaseDAL = new PurchaseDAL();
        public Project_CheckDAL project_CheckDAL = new Project_CheckDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        #endregion

        #region 提交事件
        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                Project_CheckEntity model = new Project_CheckEntity();
                model.PCID = "";
                model.PID = this.hf_ProName.Value;//
                model.Evaluate = Convert.ToInt32(this.hf_Evaluate.Value);
                model.Opinion = this.hf_Opinion.Value;

                model.BrandChecked = Convert.ToInt32(this.cb_BrandChecked.Checked);
                model.SpecificationChecked = Convert.ToInt32(this.cb_SpecificationChecked.Checked);
                model.ConfigChecked = Convert.ToInt32(this.cb_ConfigChecked.Checked);
                model.CountChecked = Convert.ToInt32(this.cb_CountChecked.Checked);
                model.DebuggingChecked = Convert.ToInt32(this.cb_DebuggingChecked.Checked);
                model.GuaranteeChecked = Convert.ToInt32(this.cb_GuaranteeChecked.Checked);
                model.PackingChecked = Convert.ToInt32(this.cb_PackingChecked.Checked);
                model.ContractChecked = Convert.ToInt32(this.cb_ContractChecked.Checked);

                model.PCDate = Convert.ToDateTime(this.hf_begin.Value.ToString());
                model.CreateUser = UserID;
                model.IsReport = (int)CommonEnum.IsorNot.否;//是否上报

                //附件上传
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_file, "file");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_file.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    accessinfo.AccessFlag = (int)CommonEnum.AccessoryType.Tb_Contract;
                    accessinfo.AccessObjID = model.PCID;
                    accessinfo.ObjID = "";
                }
                model.PCFile = accessinfo.AccessUrl;
                int result = project_CheckDAL.Edit(model, 2);
                if (result > 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location.href='PurAcceManage.aspx';", true);
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion
    }
}