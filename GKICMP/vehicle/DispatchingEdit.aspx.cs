/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       出车安排页面
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
    public partial class DispatchingEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Vehicle_ApplyDAL applyDAL = new Vehicle_ApplyDAL();
        public DriverDAL driverDAL = new DriverDAL();


        #region 参数集合
        public string ApplyID
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
                DataTable dt = driverDAL.GetTable();
                CommonFunction.DDlTypeBind(this.ddl_SysUID, dt, "SysUid", "SysUidName", "-2");
                Vehicle_ApplyEntity model = applyDAL.GetObjByID(ApplyID);
                if (model.SysUid != "")
                {
                    this.ddl_SysUID.SelectedValue = model.SysUid;
                }
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int result = applyDAL.Update(ApplyID, this.ddl_SysUID.SelectedValue.ToString());
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "安排司机信息", UserID));
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