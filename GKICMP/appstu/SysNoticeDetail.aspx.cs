/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年1月4日 17时15分47秒
** 描    述:      通知公告详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;


namespace GKICMP.appstu
{
    public partial class SysNoticeDetail : PageBaseApp
    {
        public SysNoticeDAL sysNoticeDAL = new SysNoticeDAL();

        #region 参数集合
        public string SNID
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
            SysNoticeEntity model = sysNoticeDAL.GetObj(SNID);
            if (model != null)
            {                
                this.lbl_SendDate.Text = model.SendDate.ToString("yyyy-MM-dd HH:mm");
                this.lbl_SendUserName.Text = model.SendUserName;
                //this.ltl_AcceptUser.Text = model.AcceptUserName;

                sysNoticeDAL.Update(SNID, (int)CommonEnum.IsorNot.是);
                this.lbl_IsRead.Text = CommonEnum.IsorNot.是.ToString();
                this.lbl_AContent.Text = model.NContent;
            }
        } 
        #endregion
    }
}