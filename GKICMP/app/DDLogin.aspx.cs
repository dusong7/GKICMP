using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace GKICMP.app
{
    public partial class DDLogin : System.Web.UI.Page
    {
        public SysUserDAL sysUsergDAL = new SysUserDAL();
       
        ////正式使用
        public string agentId = ConfigurationManager.AppSettings["ArgentID"];
        public string appkey = ConfigurationManager.AppSettings["appkey"];
        public string CorpId = ConfigurationManager.AppSettings["CorpId"];
        public string CorpSecret = ConfigurationManager.AppSettings["appsecret"];
        public string nonceStr = ConfigurationManager.AppSettings["nonceStr"];
        public string timestamp = string.Empty;

        ////测试使用
        //public string agentId = "205607914";
        //public string corpId = "ding622179de41ce4b65";
        //public string CorpSecret = "bhwGmBemlj0mXv5UCKGAQ6WGoAXxPtf2mFkOzmRThUXFGfM96KCQb-PD32hdalp-";
        //public string nonceStr = "sgffd674efdgs";
        //public string timestamp = string.Empty;

        public string signature = string.Empty;
        public string accessToken = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btn_CodeInfo();
                GetConfig();
               // this.btn_Code.Click;
            }
        }
       
        #region jsapi签名验证处理
        /// <summary>
        /// jsapi签名验证处理
        /// </summary>
        private void GetConfig()
        {
            //string access_Token = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/gettoken?corpid={0}&corpsecret={1}", corpId, CorpSecret));
            
            //2018-12-17 钉钉接口发布新版本 获取accessToken发生变化
            string access_Token = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/gettoken?appkey={0}&appsecret={1}", appkey, CorpSecret));
            accessToken = CommonFunction.Json(access_Token, "access_token");
            
            string Ticket = CommonFunction.RequestUrl(string.Format(" https://oapi.dingtalk.com/get_jsapi_ticket?access_token={0}", accessToken.Trim()));
            timestamp = timeStamp();
            string jsApiTicket = CommonFunction.Json(Ticket, "ticket");
            if (jsApiTicket !=null)
            {
                //测试使用
                // string url = "http://dd.whsedu.cn/DDDefault.aspx";
                //string url = "http://whgkdz.whsedu.cn/sismpapp/DDDefault.aspx";
                // string url = ConfigurationManager.AppSettings["URL"];
                string url = Request.Url.AbsoluteUri;
                string signature1 = "jsapi_ticket=" + jsApiTicket.Trim() + "&noncestr=" + nonceStr.Trim() + "&timestamp=" + timestamp.Trim() + "&url=" + url.Trim();
                signature = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signature1, "SHA1").ToLower();
            }
        }
        #endregion

        #region 成功返回code成功点击事件
        /// <summary>
        /// 成功返回code成功点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Code_Click(object sender, EventArgs e)
        {
            string code = this.hf_Code.Value;
            //string code = "614e05f18def30fe97ff8496446ac260";
            //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('" + "COID:" + code + "');", true);

            //string at = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/gettoken?corpid={0}&corpsecret={1}", corpId, CorpSecret));

            //2018-12-17 钉钉接口发布新版本 获取accessToken发生变化
            string at = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/gettoken?appkey={0}&appsecret={1}", appkey, CorpSecret));
            accessToken = CommonFunction.Json(at, "access_token");
            
            string useridJson = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/user/getuserinfo?access_token={0}&code={1}", accessToken, code));
            string userid = CommonFunction.Json(useridJson, "userid");

    // Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('code=" + code + "  accessToken=" + accessToken + "  useridJson:" + useridJson + "');", true);
  
            if (userid == null || userid == "")
            {
                string mess = CommonFunction.Json(useridJson, "errmsg");
                Response.Write(mess + "【请联系管理员】");
            }
            else
            {
                string userInfoJson = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/user/get?access_token={0}&userid={1}", accessToken, userid));
     // Page.ClientScript.RegisterStartupScript(GetType(), "", "alert(code=" + code + "  accessToken=" + accessToken + "  userid" + userid + "  useridJson:" + userInfoJson + "');", true);
     
                if (CommonFunction.Json(userInfoJson, "errcode") == "0")
                {
                    string mobile = CommonFunction.Json(userInfoJson, "mobile");
                    string name = CommonFunction.Json(userInfoJson, "name");

                    //JObject jo = (JObject)JsonConvert.DeserializeObject(userInfoJson);
                    ////Response.Write(userInfoJson);
                    ////return;
                    //string mobile = jo["mobile"].ToString();
                    //string name = jo["name"].ToString();
                    if (mobile == null || name == "")
                    {
                        string mess = CommonFunction.Json(userInfoJson, "errmsg");
                        Response.Write(mess + "【请联系管理员】");
                    }
                    else
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(mobile))
                            {
                                SysUserEntity sysuser = sysUsergDAL.DDLogin(name, mobile, userid);
                                //SysUserEntity sysuser = sysUsergDAL.GetLogin(name);
                                if (sysuser != null)
                                {
                                    Response.Cookies["UserID"].Value = CommonFunction.Encrypt(sysuser.UID.ToString());
                                    Response.Cookies["SysUserName"].Value = sysuser.UserName;
                                    Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(sysuser.RealName, Encoding.GetEncoding("UTF-8"));
                                    Response.Cookies["UserType"].Value = sysuser.UserType.ToString();
                                    Response.Cookies["SysUserPwd"].Value = sysuser.UserPwd.ToString();
                                    string url = Request.Cookies["rurl"] == null ? "" : Request.Cookies["rurl"].Value;
                                    if (string.IsNullOrEmpty(url))
                                    {
                                        Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'AppMain.aspx';", true);
                                    }
                                    else
                                    {
                                        Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = '" + System.Web.HttpUtility.UrlDecode(url) + "';", true);
                                    }
                                }
                                else
                                {
                                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('请登录pc端，完善个人信息！');", true);
                                    Response.Redirect("Login.html", false);
                                }
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('用户名或密码错误！');", true);
                                Response.Redirect("Login.html", false);
                            }
                        }
                        catch (Exception error)
                        {
                            Response.Write(error.Message + "【请联系管理员】");
                        }
                    }
                }
                else {
                    Response.Write( "【没有找到联系人，请联系管理员】");
                }
            }
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