/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月11日 10:00
** 描 述:       资产详细编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.assetmanage
{
    public partial class AssetAccountInfoEdit : PageBase
    {
        public SysDataDAL sysDataDAL = new SysDataDAL();


        #region 参数集合
        public string  AAID
        {
            get
            {
                return GetQueryString<string>("aaid","");
            }
        }
        public int AiType
        {
            get
            {
                return GetQueryString<int>("aitype", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.计量单位);
                CommonFunction.DDlTypeBind(this.ddl_AccUnit, dt, "SDID", "DataName", "-2");
                this.hf_AAID.Value = AAID.ToString();
                this.hf_AiType.Value = AiType.ToString();
            }
        }
        #endregion
    }
}