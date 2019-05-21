/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年8月15日 15时04分01秒
** 描    述:      会议详情页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.meeting
{
    public partial class MeetingDetail : PageBase
    {
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
            if (!IsPostBack)
            {
                InfoBind();
            }
        }
        #endregion


        #region 初始化用户信息
        /// <summary>
        /// 初始化用户信息
        /// </summary>
        private void InfoBind()
        {
            MeetingEntity model = mDAL.GetObjByID(MID);
            if (model != null)
            {
                this.ltl_MTitle.Text = model.MTitle.ToString();
                this.ltl_MeetingRoom.Text = model.MRName.ToString();
                this.ltl_LinkUser.Text = model.LinkUserName.ToString();
                this.ltl_LinkNum.Text = model.LinkNum.ToString();
                this.ltl_MBegin.Text = model.MBegin.ToString("yyyy-MM-dd HH:mm");
                this.ltl_MEnd.Text = model.MEnd.ToString("yyyy-MM-dd HH:mm");
                this.ltl_MeetingHost.Text = model.MeetingHostName == null ? "" : model.MeetingHostName.ToString();
                this.ltl_UserList.Text = model.UserList.ToString();
                this.ltl_MContent.Text = model.MContent.ToString();
                this.ltl_Minutes.Text = model.Minutes == null ? "" : model.Minutes.ToString();


                DataTable dt = mDAL.GetUser(MID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.ltl_MeetUser.Text = dt.Rows[0]["MeetUser"].ToString().TrimEnd(',');
                    this.ltl_AMeetUser.Text = dt.Rows[0]["AMeetUser"].ToString().TrimEnd(',');
                    this.ltl_AbsendUser.Text = dt.Rows[0]["AbsendUser"].ToString().TrimEnd(',');
                    this.ltl_LateUser.Text = dt.Rows[0]["LateUser"].ToString().TrimEnd(',');
                }
            }
        }
        #endregion
    }
}