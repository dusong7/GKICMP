/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2016年12月26日
** 描 述:       受理报修管理编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;

namespace ICMP.assetmanage
{
    public partial class RepairPeopleEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_RepairDAL repairDAL = new Asset_RepairDAL();

        #region 参数集合
        public string ARID
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

            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int result = repairDAL.Update(ARID, this.txt_CompDesc.Text.Trim(), Convert.ToInt32(CommonEnum.ARState.完成));
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "完成受理的报修信息", UserID));
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
        #endregion
    }
}