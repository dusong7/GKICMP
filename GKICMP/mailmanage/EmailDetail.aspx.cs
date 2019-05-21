/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年08月21日 16：59
** 描 述:       邮件消息详细页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using GK.GKICMP.Common;


namespace GKICMP.mailmanage
{
    public partial class EmailDetail : PageBase
    {
        public EmailDAL emailDAL = new EmailDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        public string EID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// 1:发件箱 2：收件箱
        /// </summary>
        public int flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }

        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = emailDAL.GetObj(EID, flag);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (flag == 2)
                    {
                        this.ltl_User.Text = "发送人：";
                        this.ltl_Users.Text = dt.Rows[0]["SenduserName"].ToString();
                    }
                    if (flag == 1)
                    {
                        this.ltl_Date.Text = "发送时间";
                        this.ltl_SendDate.Text = Convert.ToDateTime(dt.Rows[0]["SendDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        this.ltl_User.Text = "接收人：";
                        this.ltl_Users.Text = "已读人员：" + dt.Rows[0]["Yd"].ToString() + "</br>" + "未读人员：" + dt.Rows[0]["Wd"].ToString();
                    }
                    this.ltl_EmailContent.Text = dt.Rows[0]["EmailContent"].ToString();
                    this.ltl_EmailTitle.Text = dt.Rows[0]["EmailTitle"].ToString();
                    this.ltl_EType.Text = CommonFunction.CheckEnum<CommonEnum.RecType>(dt.Rows[0]["EType"].ToString());
                    if (flag == 2)
                    {
                        try
                        {
                            this.aa.Visible = true;
                            this.ltl_IsRead.Text = CommonEnum.IsorNot.是.ToString();
                            this.ltl_AcceptDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            int result = emailDAL.Update(EID, Convert.ToInt32(CommonEnum.IsorNot.是), Convert.ToDateTime(this.ltl_AcceptDate.Text));
                            if (result > 0)
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "收件箱更新已读状态", UserID));
                            }
                            //else
                            //{
                            //    ShowMessage("更新失败");
                            //    return;
                            //}
                        }
                        catch (Exception ex)
                        {
                            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                            ShowMessage(ex.Message);
                        }
                    }
                }
            }
        }
        #endregion
    }
}