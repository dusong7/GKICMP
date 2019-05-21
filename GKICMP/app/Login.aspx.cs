/*钉钉免登共如下步骤:
 * 1.加入免登群 申请获得appid与appserect。（access_token）
 * 2.创建钉钉微应用。设置微应用地址为：https://oapi.dingtalk.com/connect/oauth2/sns_authorize?appid=APPID&response_type=code&scope=snsapi_login&state=STATE&redirect_uri=REDIRECT_URI
 * （其中appid与redirect_uri（需要urlencode编码）必填）
 * 3.回调网址会追加code参数，登录页面需获取此code（临时身份验证码）（tmp_auth_code）。
 * 4.根据临时验证码获取持久授权码。（sns_token）
 * 5.根据永久验证码获取用户unionid。
 * 6.根据unionid获取用户userid。
 * 7.根据userid获取详细信息（手机，姓名。）
 */


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.app
{
    public partial class Login : System.Web.UI.Page
    {
        public SysUserDAL sysUsergDAL = new SysUserDAL();
        
        //public string corpId = "ding622179de41ce4b65";
        //public string CorpSecret = "bhwGmBemlj0mXv5UCKGAQ6WGoAXxPtf2mFkOzmRThUXFGfM96KCQb-PD32hdalp-";
        //public string agentId = "37232286";
        //public string nonceStr = "sgffd674efdgs";

        //正式使用
        //public string corpId = ConfigurationManager.AppSettings["appkey"];
        //public string CorpSecret = ConfigurationManager.AppSettings["appsecret"];
        //public string agentId = ConfigurationManager.AppSettings["ArgentID"];
        //public string nonceStr = ConfigurationManager.AppSettings["nonceStr"];
        //public string timestamp = string.Empty;
        
        //测试使用
        //public string agentId = "38189067";
        public string agentId = "205607914";
        public string corpId = "dingbc5b86cca0a36b29";
        public string CorpSecret = "Ua6F9ABeRKQFFT1JiuV-f7GrLYHXqeTfNuIH9ClqFW1Dz8vDpNcq4c2DzTDln9Yp";
        public string timestamp = string.Empty;
        public string nonceStr = "sgffd674efdgs";
        
        public string signature = string.Empty;
        public string accessToken = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btn_CodeInfo();
                GetConfig();
            }
        }

        #region 测试方法
        /// <summary>
        /// 测试方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_CodeInfo()
        {
            //string code = this.hf_Code.Value;
            string code = "0b3e1cb45d033f239dd20827bd6f4f79";
            string at = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/gettoken?corpid={0}&corpsecret={1}", corpId, CorpSecret));
            accessToken = CommonFunction.Json(at, "access_token");
            string useridJson = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/user/getuserinfo?access_token={0}&code={1}", accessToken, code));
            string userid = CommonFunction.Json(useridJson, "userid");
            
            if (userid == null || userid == "")
            {
                string mess = CommonFunction.Json(useridJson, "errmsg");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('错误信息：" + mess + "');</script>");
                Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'Default.aspx';", true);
            }
            else
            {
                string userInfoJson = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/user/get?access_token={0}&userid={1}", accessToken, userid));
                string mobile = CommonFunction.Json(userInfoJson, "mobile");
                string name = CommonFunction.Json(userInfoJson, "name");
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
                            //SysUserEntity sysuser = SysUserBLL.DDLogin(name, mobile, userid);
                            //Response.Cookies["UserID"].Value = sysuser.SysID.ToString();
                            //Response.Cookies["SysUserName"].Value = sysuser.SysUserName;
                            //Response.Cookies["UserFace"].Value = sysuser.PreStr;
                            //Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(sysuser.RealName, Encoding.GetEncoding("UTF-8"));

                            SysUserEntity sysuser = sysUsergDAL.DDLogin(name, mobile, userid);
                            if (sysuser != null)
                            {
                                Response.Cookies["UserType"].Value = sysuser.UserType.ToString();
                                Response.Cookies["UserID"].Value = CommonFunction.Encrypt(sysuser.UID.ToString());
                                Response.Cookies["SysUserName"].Value = sysuser.UserName;
                                Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(sysuser.RealName, Encoding.GetEncoding("UTF-8"));
                               
                            }
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'AppMain.aspx';", true);
                        }
                        else
                        {
                            Response.Write("身份验证出错，请联系管理员");
                            
                        }
                    }
                    catch (Exception error)
                    {
                        Response.Write(error.Message + "【请联系管理员】");
                    }
                }
            }
        }
        #endregion

        #region jsapi签名验证处理
        /// <summary>
        /// jsapi签名验证处理
        /// </summary>
        private void GetConfig()
        {
            string access_Token = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/gettoken?corpid={0}&corpsecret={1}", corpId, CorpSecret));
            accessToken = CommonFunction.Json(access_Token, "access_token");
            string Ticket = CommonFunction.RequestUrl(string.Format(" https://oapi.dingtalk.com/get_jsapi_ticket?access_token={0}", accessToken.Trim()));
            string jsApiTicket = CommonFunction.Json(Ticket, "ticket");
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

        #region 成功返回code成功点击事件
        /// <summary>
        /// 成功返回code成功点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Code_Click(object sender, EventArgs e)
        {
            string code = this.hf_Code.Value;
            string at = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/gettoken?corpid={0}&corpsecret={1}", corpId, CorpSecret));
            accessToken = CommonFunction.Json(at, "access_token");
            string useridJson = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/user/getuserinfo?access_token={0}&code={1}", accessToken, code));
            string userid = CommonFunction.Json(useridJson, "userid");

            if (userid == null || userid == "")
            {

                string mess = CommonFunction.Json(useridJson, "errmsg");
                Response.Write(mess + "【请联系管理员】");
            }
            else
            {
                string userInfoJson = CommonFunction.RequestUrl(string.Format("https://oapi.dingtalk.com/user/get?access_token={0}&userid={1}", accessToken, userid));
                string mobile = CommonFunction.Json(userInfoJson, "mobile");
                string name = CommonFunction.Json(userInfoJson, "name");
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
                                //Response.Cookies["UserID"].Value = sysuser.SysID.ToString();
                                //Response.Cookies["SysUserName"].Value = sysuser.SysUserName;
                                //Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(sysuser.RealName, Encoding.GetEncoding("UTF-8"));
                                //Response.Cookies["UserFace"].Value = sysuser.PreStr;
                                //Response.Cookies["SysUserPwd"].Value = sysuser.SysPwd;
                                //Response.Cookies["DepIds"].Value = sysuser.DepIDs;
                                //Response.Cookies["UserType"].Value = sysuser.UserType;
                                //Response.Cookies["RankName"].Value = sysuser.Rank.ToString();
                                //Response.Cookies["RankScore"].Value = (sysuser.Rank == 1 ? "2" : sysuser.Rank == 2 ? "5" : sysuser.Rank == 3 ? "5" : sysuser.Rank == 4 ? "10" : sysuser.Rank == 5 ? "30" : sysuser.Rank == 6 ? "50" : "100");

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
                                Response.Redirect("Login.aspx");
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('用户名或密码错误！');", true);
                            Response.Redirect("Login.aspx");
                        }
                    }
                    catch (Exception error)
                    {
                        Response.Write(error.Message + "【请联系管理员】");
                    }
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