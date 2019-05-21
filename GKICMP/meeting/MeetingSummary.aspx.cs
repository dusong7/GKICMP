/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月15日 14时25分01秒
** 描    述:      会议纪要编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.meeting
{
    public partial class MeetingSummary : PageBase
    {
        public MeetingDAL mDAL = new MeetingDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_RepairDAL repairDAL = new Asset_RepairDAL();
        public SysUser_TypeDAL sTypeDAL = new SysUser_TypeDAL();

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
            if (!IsPostBack)
            {
                DataTable dt = sTypeDAL.GetList((int)CommonEnum.HumanType.会议主持人);
                CommonFunction.DDlTypeBind(this.ddl_MeetingHost, dt, "UID", "RealName", "-2");

                DataTable dtUser = mDAL.GetMeetUser(MID);
                this.chbl_AbsendUser.DataSource = dtUser;
                this.chbl_AbsendUser.DataTextField = "MeetUserName";
                this.chbl_AbsendUser.DataValueField = "MUID";
                this.chbl_AbsendUser.DataBind();

                this.chbl_LateUser.DataSource = dtUser;
                this.chbl_LateUser.DataTextField = "MeetUserName";
                this.chbl_LateUser.DataValueField = "MUID";
                this.chbl_LateUser.DataBind();
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
                MeetingEntity model = new MeetingEntity();
                model.MID = MID;
                model.MeetingHost = this.ddl_MeetingHost.SelectedValue;
                model.Minutes = this.txt_Minutes.Text.ToString().Trim();
                string Absendstr = "";
                foreach (ListItem item in chbl_AbsendUser.Items)
                {
                    if (item.Selected == true)
                    {
                        Absendstr += item.Value + ",";
                    }
                }

                string Latestr = "";
                foreach (ListItem item in chbl_LateUser.Items)
                {
                    if (item.Selected == true)
                    {
                        Latestr += item.Value + ",";
                    }
                }

                int result = mDAL.UpdateSummary(model, Absendstr.TrimEnd(',').TrimStart(','), Latestr.TrimEnd(',').TrimStart(','));
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "更新会议纪要信息", UserID));
                }
                else
                {
                    ShowMessage("保存失败");
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