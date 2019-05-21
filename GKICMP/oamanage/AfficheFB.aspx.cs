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
using System.Configuration;

namespace GKICMP.oamanage
{
    public partial class AfficheFB : PageBase
    {
        public AfficheDAL afficheDAL = new AfficheDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
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
        public string UList
        {
            get
            {
                return GetQueryString<string>("list", "");
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

                    //this.ltl_AcceptUser.Text = model.AcceptUserName;


                    this.ltl_AcceptUser.Text = Users.Trim(',');


                    this.ltl_AContent.Text = model.AContent;

                }
            }
        }
        #endregion

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                //int result = afficheDAL.Audit(UserID, 1, AID);
                //if (result > 0)
                //{
                string msg = SendMsg(UList, this.ltl_AContent.Text);
                if (msg == "ok")
                {
                    int result = afficheDAL.Send(AID);
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "发送通知公告信息【" + msg + "】", UserID));
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');winclose();</script>");
                    //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');winclose();", true);
                    ShowMessage();
                }
                else if (msg == "-1")
                {
                    ShowMessage("发送失败,无接收人");
                    return;
                }
                else 
                {
                    ShowMessage("发送失败");
                    return;
                }
                //}
                //else
                //{
                //    ShowMessage("审核失败");
                //    return;
                //}
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }

        public string SendMsg(string touser, string content)
        {
            string result = "";
            string tousers = "";
            WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Notice", 1);
            if (model1.IsOpen == 1)
            {
                DataTable dt = sysUserDAL.GetMsgIdByDep(touser);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tousers += dr["userid"].ToString() + "|";
                    }
                    string token = WeixinQYAPI.GetToken(1, "Notice");
                    string host = ConfigurationManager.AppSettings["SendUrl"] + "/app/";
                    //string json = "{\"touser\":\"" + tousers + "\",\"msgtype\":\"text\",\"agentid\":\"" + model1.Agent + "\",\"text\":{\"content\":\"" + content + "\"}}";
                    //string msg = WeixinQYAPI.Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", token), json);
                    string msg = WeixinQYAPI.SendMessage(token, tousers, int.Parse(model1.Agent), this.ltl_AfficheTitle.Text, content, host + "AfficheDetail.aspx?id=" + AID + "&users="+Users, "");
                    return WeixinQYAPI.Json(msg, "errmsg");
                    //if (WeixinQYAPI.Json(msg, "errmsg") == "ok")
                    //{
                    //    result = "微信消息发送成功";
                    //}
                    //else
                    //{
                    //    result = "微信消息发送失败";
                    //}
                }
                else
                {
                    result = "-1";//无接收人
                }
            }
            return result;
        }
        public string SendMsg(string content)
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
    }
}