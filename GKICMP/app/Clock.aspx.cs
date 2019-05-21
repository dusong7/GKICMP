using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;

namespace GKICMP.app
{
    public partial class Clock : PageBaseApp
    {
        public string agentId = "";
        public string corpId = "";
        public string CorpSecret = "";
        public string nonceStr = "GKDZ";
        public string timestamp = string.Empty;
        public string signature = string.Empty;
        public string accessToken = string.Empty;
        public string jsApiTicket = string.Empty;
        public SysUser_TypeDAL sysusertypeDAL = new SysUser_TypeDAL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDate();
                GetConfig();
                SysUser_TypeEntity model = sysusertypeDAL.GetByUIDstype((int)CommonEnum.HumanType.请假抄送人, UserID);
                if (model == null)
                {
                    this.lv2.Visible = false;
                }
            }
        }
        public void getDate()
        {
            WeiXinInfoEntity model = XMLHelper.Get("~/QYWX.xml", "Main", 1);
            corpId = model.CorpID;
            CorpSecret = model.Secret;
            agentId = model.Agent;
        }
        #region jsapi签名验证处理
        /// <summary>
        /// jsapi签名验证处理
        /// </summary>
        private void GetConfig()
        {
            accessToken = WeixinQYAPI.GetAccess_Token(corpId, CorpSecret);
            //accessToken = WeixinQYAPI.Json(access_Token, "access_token");
            string Ticket = WeixinQYAPI.RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={0}", accessToken.Trim()));
            jsApiTicket = WeixinQYAPI.Json(Ticket, "ticket");
            timestamp = timeStamp();
            //测试使用
            // string url = "http://dd.whsedu.cn/DDDefault.aspx";
            //string url = "http://whgkdz.whsedu.cn/sismpapp/DDDefault.aspx";
            // string url = ConfigurationManager.AppSettings["URL"];
            string url = Request.Url.AbsoluteUri;
            string signature1 = "jsapi_ticket=" + jsApiTicket.Trim() + "&noncestr=" + nonceStr.Trim() + "&timestamp=" + timestamp.Trim() + "&url=" + url.Trim();
            signature = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signature1, "SHA1").ToLower();
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
    }
}