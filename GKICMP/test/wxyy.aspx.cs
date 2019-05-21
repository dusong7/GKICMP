using System;
using System.Web.Security;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.test
{
    public partial class wxyy : System.Web.UI.Page
    {
        public string agentId = "1000004";
        public string corpId = "wxe0b787e4eaa1102c";
        public string CorpSecret = "hO3Z0iAo9B_S9vh17sL6_QmThmvrvsArrJbW6pn3Ujs";
        public string nonceStr = "GKDZ";
        public string signature = "";
        public string timestamp = "";
        public string accessToken = "";
        public string jsApiTicket = "";


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetConfig();
            }
        }
        #endregion


        #region 获取jsapi签名验证处理
        private void GetConfig()
        {
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


        #region 下载语音
        protected void btn_Click(object sender, EventArgs e)
        {
           string json= WeixinQYAPI.RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", accessToken.Trim(), this.hf_serverId.Value));
           new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, this.hf_serverId.Value, ""));
        }
        #endregion
    }
}