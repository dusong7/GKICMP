using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP
{
    public partial class WXLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Code"] == null)
            {
                WeiXinInfoEntity model = new WeiXinInfoEntity();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    model = XMLHelper.Get("~/QYWX.xml", Request.QueryString["id"], 1);
                }
                else { return; }
                if (model.IsOpen == 1)
                {
                    string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&agentid={2}&state=STATE#wechat_redirect";
                    //string redirecturl = "http://yjqapms.whsedu.cn/app/WXOAuth.aspx";
                    string redirecturl = Request.Url.ToString();
                    redirecturl = Server.UrlEncode(redirecturl);
                    url = String.Format(url, model.CorpID, redirecturl, model.Agent);
                    Response.Redirect(url);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('未开启企业微信，" + model.IsOpen + "');", true);
                    return;
                }
            }
            else
            {
                string code = Request.QueryString["Code"];
                string id = Request.QueryString["id"];
                string access_token = WeixinQYAPI.GetToken(1, id);
                if (access_token != "")
                {
                    //FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", access_token + "\t\n", false);
                    string UserId = WeixinQYAPI.GetUserInfo(access_token, code);
                    //FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", "用户id:" + UserId + "\t\n", false);
                    if (!string.IsNullOrEmpty(UserId))
                    {
                        try
                        {
                            string json = WeixinQYAPI.GetUser(access_token, UserId);
                            string cellphone = WeixinQYAPI.Json(json, "mobile");
                            int fllow = int.Parse(WeixinQYAPI.Json(json, "status"));
                            // string cellphone = "18226530705";
                            SysUserEntity model = new SysUserDAL().GetObjByID(cellphone, UserId, fllow);
                            if (model != null)
                            {
                                FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", "登录名:" + model.RealName + "\t\n", false);
                                Response.Cookies["UserType"].Value = model.UserType.ToString();
                                Response.Cookies["UserID"].Value = CommonFunction.Encrypt(model.UID.ToString());
                                Response.Cookies["SysUserName"].Value = model.UserName;
                                Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(model.RealName, Encoding.GetEncoding("UTF-8"));
                                Response.Cookies["SysUserPwd"].Value = model.UserPwd;
                                SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + model.RealName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统【微信扫码登录】" + id, model.UID);
                                new SysLogDAL().Edit(log);
                                if (model.UserType == (int)CommonEnum.UserType.老师)
                                    Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'WebMain.aspx';", true);
                                else
                                    Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'Stu_WebMain.aspx';", true);
                              
                            }
                            else
                            {
                                FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", "登录名:" + cellphone + "--" + UserId + "\t\n", false);
                                Response.Redirect("Default.aspx", false);
                            }
                        }
                        catch (Exception ex)
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('获取身份信息失败，请联系管理员');", true);
                            new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                            Response.Redirect("Default.aspx", false);
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('微信认证失败');", true);
                    Response.Redirect("Default.aspx", false);
                }
            }
        }
    }
}