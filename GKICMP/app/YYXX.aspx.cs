using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Web.Security;

namespace GKICMP.app
{
    public partial class YYXX : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveAuditDAL leaveAuditDAL = new LeaveAuditDAL();
        public string agentId = "";
        public string corpId = "";
        public string CorpSecret = "";
        public string nonceStr = "GKDZ";
        public string signature = "";
        public string timestamp = "";
        public string accessToken = "";
        public string jsApiTicket = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetConfig();
            }
        }


        #region 获取jsapi签名验证处理
        private void GetConfig()
        {
            WeiXinInfoEntity model = XMLHelper.Get("~/QYWX.xml", "Notice", 1);
            corpId = model.CorpID;
            CorpSecret = model.Secret;
            agentId = model.Agent;
            accessToken = WeixinQYAPI.GetAccess_Token(corpId, CorpSecret);
            string ticket = WeixinQYAPI.RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={0}", accessToken.Trim()));
            jsApiTicket = WeixinQYAPI.Json(ticket, "ticket");
            timestamp = timeStamp();
            string url = Request.Url.AbsoluteUri;
            string signature1 = "jsapi_ticket=" + jsApiTicket.Trim() + "&noncestr=" + nonceStr + "&timestamp=" + timestamp.Trim() + "&url=" + url.Trim();
            signature = FormsAuthentication.HashPasswordForStoringInConfigFile(signature1, "SHA1").ToLower();
        }
        #endregion


        #region 时间戳的随机数
        /// <summary>
        /// 时间戳的随机数
        /// </summary>
        /// <returns></returns>
        public static string timeStamp()
        {
            DateTime dt1 = Convert.ToDateTime("1970-01-01 00:00:00");
            TimeSpan ts = DateTime.Now - dt1;
            return Math.Ceiling(ts.TotalSeconds).ToString();
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, System.EventArgs e)
        {
            //ShowMessage(this.hf_serverID.Value);
            //WeiXinInfoEntity model = XMLHelper.Get("~/QYWX.xml", "Main", 1);
            //accessToken = WeixinQYAPI.GetAccess_Token(corpId, CorpSecret);
            //if (model != null)
            //{
            //    string msg = WeixinQYAPI.SendMessageMEDIA_ID(accessToken, this.hf_AuditResult.Value.TrimEnd(','), model.Agent, this.hf_serverId.Value);
            //   // ShowMessage( msg);
            //}
            //string json = WeixinQYAPI.RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", accessToken.Trim(), this.hf_serverId.Value));
        }
        #endregion
    }
}