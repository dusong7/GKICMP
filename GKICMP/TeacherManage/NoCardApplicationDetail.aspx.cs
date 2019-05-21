/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年06月14日
** 描 述:       著作详细页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Text;
using System.Data;


namespace GKICMP.teachermanage
{
    public partial class NoCardApplicationDetail : PageBase
    {
        SysLogDAL sysLogDAL = new SysLogDAL();
        public NoCardApplyDAL noCardApplyDAL = new NoCardApplyDAL();

        #region 参数集合
        public string ID
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
                NoCardApplyEntity model = noCardApplyDAL.GetObjByID(ID);
                if (model != null)
                {
                    this.ltl_NoCardApplyUser.Text = model.NoCardApplyUserName.ToString();
                    this.ltl_NoCardApplyDate.Text = model.NoCardApplyDate.ToString("yyyy-MM-dd HH:mm");
                    this.ltl_NoCardApplyDesc.Text = model.NoCardApplyDesc;

                    //this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd HH:mm");
                    this.ltl_CreateDate.Text = model.CreateDate.ToString() == "0001/1/1 0:00:00" ? "" : model.CreateDate.ToString("yyyy-MM-dd HH:mm");

                    this.ltl_NoCardAuditUser.Text = model.NoCardAuditUserName.ToString();
                   
                    //this.ltl_NoCardAuditDate.Text = model.NoCardAuditDate.ToString("yyyy-MM-dd HH:mm:");
                    this.ltl_NoCardAuditDate.Text = model.NoCardAuditDate.ToString() == "0001/1/1 0:00:00" ? "" : model.NoCardAuditDate.ToString("yyyy-MM-dd HH:mm");


                    this.ltl_NoCardAuditDesc.Text = model.NoCardAuditDesc;
                    this.ltl_NoCardState.Text = CommonFunction.CheckEnum<CommonEnum.PraState>(model.NoCardState);

                    
                }
            }
        }
        #endregion

    }
}