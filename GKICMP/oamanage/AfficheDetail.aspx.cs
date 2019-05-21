/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月08日 09点30分
** 描   述:       通知公告详情页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.oamanage
{
    public partial class AfficheDetail : PageBase
    {
        public AfficheDAL afficheDAL = new AfficheDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        public string AID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        public string Users
        {
            get
            {
                return GetQueryString<string>("users", "");
            }
        }
        public int Flag
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
                AfficheEntity model = afficheDAL.GetObjByID(AID, Users);
                if (model != null)
                {
                    this.ltl_AfficheTitle.Text = model.AfficheTitle;
                    this.ltl_IsDisplay.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsDisplay);
                    this.ltl_AType.Text = model.ATypeName;
                    this.ltl_SendDate.Text = model.SendDate.ToString("yyyy-MM-dd HH:mm");
                    this.ltl_SendUser.Text = model.SendUserName;
                    this.ltl_AcceptUser.Text = model.AcceptUserName;
                    if (Flag == 1)
                    {
                        this.ltl_IsRead.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsRead);
                    }
                    else  if (Flag == 2)
                    {
                        afficheDAL.Update(AID, Users, (int)CommonEnum.IsorNot.是);
                        this.ltl_IsRead.Text = CommonEnum.IsorNot.是.ToString();
                    }
                    else //班级公告
                    {
                        this.ltl_AcceptUser.Text = Users;
                    }
                   
                    this.ltl_AContent.Text = model.AContent;
                    if (Flag == 4) 
                    {
                        this.tr_audit.Visible = true;
                        this.tr_return.Visible = false;
                    }
                }
            }
        }
        #endregion

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int result = afficheDAL.Audit(UserID, 1, AID);
                if (result > 0)
                {
                   // string msg = SendMsg(this.ltl_AContent.Text);
                    //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "审核全体通知公告信息【" + msg + "】", UserID));
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "审核全体通知公告信息", UserID));
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='AfficheSchoolAudit.aspx'</script>");
                }
                else
                {
                    ShowMessage("审核失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }

        protected void btn_BH_Click(object sender, EventArgs e)
        {
            try
            {
                int result = afficheDAL.Audit(UserID, -1, AID);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "审核全体通知公告信息", UserID));
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='AfficheSchoolAudit.aspx'</script>");
                }
                else
                {
                    ShowMessage("审核失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                 sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }

        public string SendMsg( string content)
        {
            string result = "";
            WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Notice", 1);
            if (model1.IsOpen == 1)
            {
                string token = WeixinQYAPI.GetToken(1, "Notice");
                string json = "{\"touser\":\"@all\",\"msgtype\":\"text\",\"agentid\":\"" + model1.Agent + "\",\"text\":{\"content\":\"" + content + "\"},\"safe\":0}";
                string msg = WeixinQYAPI.Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", token), json);
                if (WeixinQYAPI.Json(msg, "errmsg") == "ok")
                {
                    result = "微信消息发送成功";
                }
                else
                {
                    result = "微信消息发送失败";
                }

            }
            return result;
        }

        //#region 返回
        //protected void bt_ok_Click(object sender, EventArgs e)
        //{
        //    if (Flag == 1)
        //    {
        //        Response.Redirect("AfficheManage.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("AfficheAcceptManage.aspx");
        //    }
        //}
        //#endregion
    }
}