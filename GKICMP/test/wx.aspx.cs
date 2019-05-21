using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;

namespace GKICMP.test
{
    public partial class wx : System.Web.UI.Page
    {
        public string signature = string.Empty;
        public string accessToken = string.Empty;
        public string timestamp = string.Empty;
        public string nonceStr = "whgk";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetConfig();
            }
        }
        #region jsapi签名验证处理
        /// <summary>
        /// jsapi签名验证处理
        /// </summary>
        private void GetConfig()
        {
            accessToken = WeixinQYAPI.GetToken(1,"Main");
            //accessToken = API_DingTalk.Json(access_Token, "access_token");
            string Ticket = WeixinQYAPI.RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={0}", accessToken.Trim()));
            string jsApiTicket = WeixinQYAPI.Json(Ticket, "ticket");

            string ticket = WeixinQYAPI.Json(WeixinQYAPI.RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/ticket/get?access_token={0}&type=contact", accessToken.Trim())), "ticket"); ;
            timestamp = WeixinQYAPI.timeStamp();
            // string url = "http://dd.whsedu.cn/DDPosition.aspx";
            string url = Request.Url.AbsoluteUri;
            //string url = ConfigurationManager.AppSettings["URL"];
            string signature1 = "jsapi_ticket=" + jsApiTicket.Trim() + "&noncestr=" + nonceStr.Trim() + "&timestamp=" + timestamp.Trim() + "&url=" + url.Trim();
            signature = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signature1, "SHA1").ToLower();
        }
        #endregion
    }
}