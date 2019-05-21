/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年02月04日 14时39分01秒
** 描    述:      宿舍管理员设置页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.assetmanage
{
    public partial class TBuildingAdmin : PageBase
    {
        public Asset_RepairDAL repairDAL = new Asset_RepairDAL();
        public BuildingDAL buildingDAL = new BuildingDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        /// <summary>
        /// 宿舍楼ID
        /// </summary>
        public int BID
        {
            get
            {
                return GetQueryString<int>("id", -1);
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
                DataTable dt = repairDAL.GetSysUserType(Convert.ToInt32(CommonEnum.HumanType.宿舍楼管理员));
                CommonFunction.DDlTypeBind(this.ddl_BAdmin, dt, "UID", "RealName", "-2");
            }
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int result = buildingDAL.AdminSet(BID, this.ddl_BAdmin.SelectedValue.ToString());
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "设置宿舍楼管理员", UserID));
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