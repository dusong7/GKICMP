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
    public partial class NoCardApplicationEdit : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public NoCardApplyDAL applyDAL = new NoCardApplyDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.hf_LID.Value = Guid.NewGuid().ToString();
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                NoCardApplyEntity model = new NoCardApplyEntity();
                model.ID = this.hf_LID.Value.ToString();
                model.NoCardApplyDate = Convert.ToDateTime(this.hf_NoCardApplyDate.Value);
                model.NoCardApplyDesc = this.hf_NoCardApplyDesc.Value;
                model.NoCardState = (int)CommonEnum.PraState.申请中;
                model.NoCardApplyUser = UserID;
                //string aa = this.hf_NoCardApplyUser.Value;
                if (this.hf_NoCardApplyUser.Value != "")
                {
                    model.NoCardAuditUser = this.hf_NoCardApplyUser.Value;
                }
                else 
                {
                    ShowMessage("请选择审核人");
                    return;
                }


                int result = applyDAL.Edit(model);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                 {
                     ShowMessage("该补卡点已存在，请勿重复提交");
                     return;
                 }
                else
                 {
                     sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加补卡信息", UserID));
                     RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='NoCardApplicationManage.aspx'</script>");
                 }
                
                
                //if (result == 0)
                //{
                //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加补卡信息", UserID));
                //    RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='NoCardApplicationManage.aspx'</script>");
                //}
                //else
                //{
                //    ShowMessage("提交失败");
                //    return;
                //}
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
    }
}