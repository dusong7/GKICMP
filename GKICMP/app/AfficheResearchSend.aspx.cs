/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年06月03日
** 描 述:       通知公告页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.app
{
    public partial class AfficheResearchSend : PageBaseApp
    {
        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.通知公告);
                //GetCondition();
                //DataBindList();
            }
        }
        #endregion
    }
}