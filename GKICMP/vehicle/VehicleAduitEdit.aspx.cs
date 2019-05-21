/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       出车审核编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

namespace GKICMP.vehicle
{
    public partial class VehicleAduitEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Vehicle_AduitDAL aduitDAL = new Vehicle_AduitDAL();


        #region 参数集合
        public string AID
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
                CommonFunction.BindEnum<CommonEnum.PraState>(this.ddl_AuditResult, "-99");
                this.ddl_AuditResult.Items.Remove(new ListItem("申请中", "0"));
            }
        }
        #endregion

        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Vehicle_AduitEntity model = new Vehicle_AduitEntity();
                model.AduitMess = this.txt_AduitMess.Text.Trim();
                model.AduitUser = UserID;
                model.ApplyID = AID.TrimEnd(',');
                int result = aduitDAL.Edit(model, Convert.ToInt32(this.ddl_AuditResult.SelectedValue));
                if (result == 0)
                {

                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核车辆信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("审核失败");
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