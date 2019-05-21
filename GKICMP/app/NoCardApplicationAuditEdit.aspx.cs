/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年12月28日 16时34分38秒
** 描    述:      补卡基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;


using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.app
{
    public partial class NoCardApplicationAuditEdit : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public NoCardApplyDAL applyDAL = new NoCardApplyDAL();


        #region 参数集合
        public string nocardid
        {
            get
            {
                return GetQueryString<string>("id", "");

            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NoCardApplyEntity model = applyDAL.GetObjByID(nocardid);
                this.lbl_NoCardApplyDate.Text = model.NoCardApplyDate.ToString("yyyy-MM-dd HH:mm");
                this.lbl_NoCardApplyUser.Text = model.NoCardApplyUserName;
                this.ltl_NoCardApplyDesc.Text = model.NoCardApplyDesc;
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            NoCardApplyEntity model = new NoCardApplyEntity();
            string b = this.div_NoCardAuditDesc.InnerText;
            model.NoCardAuditDesc = this.hf_NoCardAuditDesc.Value;
           // model.NoCardState = Convert.ToInt32(this.hf_NoCardState.Value);
            string a = this.hf_NoCardState.Value;
            if (this.hf_NoCardState.Value == "")
            {
                ShowMessage("请选择审核结果");
                return;
            }
            else
            {
                model.NoCardState = Convert.ToInt32(this.hf_NoCardState.Value);
            }

            model.ID = nocardid;
            int result = applyDAL.Audit(model);
            if (result > 0)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核补卡信息", UserID));
                RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='NoCardApplicationAudit.aspx'</script>");
            }
            else
            {
                ShowMessage("提交失败");
                return;
            }
        }
        #endregion
    }
}