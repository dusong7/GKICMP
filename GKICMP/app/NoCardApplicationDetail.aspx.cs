/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年11月11日 9时55分47秒
** 描    述:      通知公告详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;
using System.Text;

namespace GKICMP.app
{
    public partial class NoCardApplicationDetail : PageBaseApp
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
                    this.lbl_NoCardApplyUser.Text = model.NoCardApplyUserName.ToString();
                    this.lbl_NoCardApplyDate.Text = model.NoCardApplyDate.ToString("yyyy-MM-dd HH:mm");
                    this.lbl_NoCardApplyDesc.Text = model.NoCardApplyDesc;

                    //this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd HH:mm");
                    this.lbl_CreateDate.Text = model.CreateDate.ToString() == "0001/1/1 0:00:00" ? "" : model.CreateDate.ToString("yyyy-MM-dd HH:mm");

                    this.lbl_NoCardAuditUser.Text = model.NoCardAuditUserName.ToString();

                    //this.ltl_NoCardAuditDate.Text = model.NoCardAuditDate.ToString("yyyy-MM-dd HH:mm:");
                    this.lbl_NoCardAuditDate.Text = model.NoCardAuditDate.ToString() == "0001/1/1 0:00:00" ? "" : model.NoCardAuditDate.ToString("yyyy-MM-dd HH:mm");


                    this.lbl_NoCardAuditDesc.Text = model.NoCardAuditDesc;
                    this.lbl_NoCardState.Text = CommonFunction.CheckEnum<CommonEnum.PraState>(model.NoCardState);


                }
            }
        }
        #endregion


    }
}