/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年11月13日 9时14分
** 描 述:       资产折旧管理页面
** 修改人:      
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

namespace GKICMP.assetmanage
{
    public partial class AssetDepreRate : PageBase
    {
        public AssetDAL assetDAL = new AssetDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public string assetname = "";

        #region 参数集合
        /// <summary>
        /// 资产ID
        /// </summary>
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
                AssetEntity model = assetDAL.GetObjByID(AID);
                if (model != null)
                {
                    this.txt_AssRate.Text = model.AssRate.ToString();
                    assetname = model.AssetName.ToString();
                }
            }
        }
        #endregion


        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int result = assetDAL.UpdateRate(AID, Convert.ToDecimal(this.txt_AssRate.Text.ToString().ToString()));
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "更新资产名称为：【" + assetname + "】的折旧率信息", UserID));
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
        #endregion
    }
}