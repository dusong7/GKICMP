/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2016年11月21日 16时12分29秒
** 描    述:      政务页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.oamanage
{
    public partial class EgovernmentGD : PageBase
    {
        Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        EgovernmentDAL egovernmentDAL = new EgovernmentDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();
        SysDataDAL sysDataDAL = new SysDataDAL();
        #region 参数集合
        /// <summary>
        ///政务id
        /// </summary>
        public string FID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(FID))
                {
                   // CommonFunction.DDlDataBaseBind(this.ddl_Etype, (int)CommonEnum.DataType.公文归档);
                    DataTable dt = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.公文归档);
                    CommonFunction.DDlTypeBind(this.ddl_Etype, dt, "SDID", "DataName", "-2");
                }
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            //Egovernment_FlowEntity model_Flow = egovernment_FlowDAL.GetObjByID(FID);
            //if (model_Flow != null)
            //{
            int result = egovernmentDAL.GD(FID, this.ddl_Etype.SelectedValue,UserID);
            if (result > 0)
            {
                ShowMessage();
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "归档公文信息", UserID));
            }
            else
            {
                ShowMessage("保存失败");
                return;
            }
            //  }

        }
    }
}