/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年8月15日 13时49分01秒
** 描    述:      会议审核页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.meeting
{
    public partial class MeetingAuditEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public MeetingDAL mDAL = new MeetingDAL();

        #region 参数集合
        /// <summary>
        /// 会议ID
        /// </summary>
        public string MID
        {
            get
            {
                return GetQueryString<string>("id", "");
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
                MeetingEntity model = new MeetingEntity();
                if (this.rdo_AuditState.SelectedValue.ToString() == "1")
                {
                    model.AuditState = (int)CommonEnum.PraState.通过;
                }
                else
                {
                    model.AuditState = (int)CommonEnum.PraState.驳回;
                }
                model.MID = MID.ToString().TrimEnd(',').TrimStart(',');
                model.AuditUser = UserID.ToString();
                int result = mDAL.AuditMeet(model);
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核会议申请记录", UserID));
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
            }
        }
        #endregion
    }
}