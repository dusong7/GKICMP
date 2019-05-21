/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年12月28日 16时34分38秒
** 描    述:      教室基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.app
{
    public partial class AppointmentEdit : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AppointmentDAL appointmentDAL = new AppointmentDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                AppointmentEntity model = new AppointmentEntity();
                model.AID = -1;
                model.AppUser = UserID;//预约人
                model.MRID = Convert.ToInt32(this.hf_AID.Value);
                model.AppointmentDesc = this.txt_AppointmentDesc.Text.ToString().Trim();
                // model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.BeginDate = Convert.ToDateTime(this.hf_begin.Value);//
                model.EndDate = Convert.ToDateTime(this.hf_end.Value);//
                if (model.BeginDate >= model.EndDate)
                {
                    ShowMessage("开始时间不能大于等于结束时间");
                    return;
                }
                int result = appointmentDAL.Edit(model);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加预约信息", UserID));
                    RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='AppointmentManage.aspx'</script>");
                }
                else if (result == -2)
                {
                    ShowMessage("所选时间冲突，请重新选择。");
                    return;
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
    }
}