
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
using System.Text;

namespace GKICMP.app
{
    public partial class WXOAuth : System.Web.UI.Page
    {
        //public string CorpID = ConfigurationManager.AppSettings["CorpID"];
        //public string CorpSecret = ConfigurationManager.AppSettings["CorpSecret"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Code"] == null)
                {
                    //string CorpID = "";
                    //string CorpSecret = "";
                    WeiXinInfoEntity model = new WeiXinInfoEntity();
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        model = XMLHelper.Get("~/QYWX.xml", Request.QueryString["id"], 1);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('地址配置错误。');window.location.href='Login.html'", true);
                        return;
                    }
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
                    //string access_token = WeixinQYAPI.GetAccess_Token(CorpID, CorpSecret);
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



                                #region 单一帐号（注释）
                                SysUserEntity model = new SysUserDAL().GetObjByID(cellphone, UserId, fllow);
                                if (model != null)
                                {
                                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", "登录名:" + model.RealName + "\t\n", false);
                                    Response.Cookies["UserType"].Value = model.UserType.ToString();
                                    Response.Cookies["UserID"].Value = CommonFunction.Encrypt(model.UID.ToString());
                                    Response.Cookies["SysUserName"].Value = HttpUtility.UrlEncode(model.UserName);
                                    Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(model.RealName, Encoding.GetEncoding("UTF-8"));
                                    Response.Cookies["SysUserPwd"].Value = model.UserPwd;
                                    SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + model.RealName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统【微信客户端登录】", model.UID);
                                    new SysLogDAL().Edit(log);
                                    string url = "";
                                    if (Request.QueryString["rurl"] != null && Request.QueryString["rurl"] != "")
                                    {
                                        url = Request.QueryString["rurl"];
                                    }
                                    else
                                    {
                                        if (model.UserType == (int)CommonEnum.UserType.老师)
                                            url = XMLHelper.GetNodes("~/QYWX.xml", "WX/Url[@name=\"" + id + "\"]");
                                        else if (model.UserType == (int)CommonEnum.UserType.学生)
                                            url = XMLHelper.GetNodes("~/QYWX.xml", "WX/StuUrl[@name=\"" + id + "\"]");
                                        else
                                            url = "RepairTransfer.aspx";
                                    }
                                    Response.Redirect(url, false);
                                    //if (!string.IsNullOrEmpty(id))
                                    //    Response.Redirect("AppRepair.aspx?id=1", false);
                                    //else
                                    //    Response.Redirect("APPMain.aspx", false);
                                }
                                else
                                {
                                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", "登录名:" + cellphone + "--" + UserId + "\t\n", false);
                                    Response.Redirect("Test.html", false);
                                }
                                #endregion



                            }
                            catch (Exception ex)
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('获取身份信息失败，请联系管理员');", true);
                                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                            }
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('微信认证失败');", true);
                        return;
                    }
                }




                ////string cellphone = "18226530705";
                //string code = Request.QueryString["Code"];
                //// string code = "IZuwI2Q2rq4ux3lQ35kjRzME2PE9Om_4RR7xWgDcS4c";
                //string access_token = WeixinQYAPI.GetAccess_Token(CorpID, CorpSecret);
                //FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", access_token + "\t\n", false);
                ////Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('" + access_token + "');", true); 
                //string UserId = WeixinQYAPI.GetUserInfo(access_token, code);
                //FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", "用户id:" + UserId + "\t\n", false);
                ////string UserId = WeixinAPI.GetUserInfo(WeixinAPI.GetAccess_Token(CorpID,CorpSecret),code);
                ////Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('" + access_token+"========"+UserId + "');", true); ;
                //if (!string.IsNullOrEmpty(UserId))
                //{
                //    string cellphone = WeixinQYAPI.GetUser(access_token, UserId);
                //    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", "手机号:" + cellphone + "\t\n", false);
                //    try
                //    {
                //        SysUserEntity model = new SysUserDAL().GetObjByID(cellphone, UserId);
                //        if (model != null)
                //        {
                //            FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/weixinlog/"), "wx.txt", "登录名:" + model.RealName + "\t\n", false);
                //            Response.Cookies["UserType"].Value = model.UserType.ToString();
                //            Response.Cookies["UserID"].Value = CommonFunction.Encrypt(model.UID.ToString());
                //            Response.Cookies["SysUserName"].Value = model.UserName;
                //            Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(model.RealName, Encoding.GetEncoding("UTF-8"));
                //            Response.Cookies["SysUserPwd"].Value = model.UserPwd;
                //            SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + model.UserName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统", model.UID);
                //            new SysLogDAL().Edit(log);
                //            Response.Redirect("APPMain.aspx", false);
                //        }
                //        else
                //        {
                //            Response.Redirect("Test.html");
                //            //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('暂无帐号信息，请联系管理员');", true);
                //        }

                //    }
                //    catch (Exception ex)
                //    {

                //        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('获取身份信息失败，请联系管理员');", true);
                //        new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, ex.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                //    }

                //}

            }
        }
    }
}