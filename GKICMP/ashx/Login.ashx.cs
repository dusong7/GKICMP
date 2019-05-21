using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Net;
using System.Web.SessionState;
using System.Configuration;
using System.Data;

namespace GKICMP.ashx
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler,  IReadOnlySessionState
    {
        public SysUserDAL sysUsergDAL = new SysUserDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public myDirectory mDirectory = new myDirectory();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "APP":
                    Load(context);
                    break;
                default :
                    getUser( context);
                    break;
            }
            
        }
        public void Load(HttpContext context) 
        {
            string username = context.Request.Params["name"];
            string psw = context.Request.Params["psw"];
            string pwd = CommonFunction.Encrypt(psw.Trim());
            string oresult = "success";
            string result = "";
            //string username = this.txt_UserName.Text.Trim();
            if (ConfigurationManager.AppSettings["LDAP"] == "1")
            {
                DataTable dt = sysUsergDAL.GetLDAP();
                if (dt != null && dt.Rows.Count > 0)
                {
                    LDapEntity model = new LDapEntity();
                    model.Path = dt.Rows[0]["Path"].ToString();
                    model.DN = dt.Rows[0]["DN"].ToString();
                    model.OU = dt.Rows[0]["OU"].ToString();
                    model.UserName = "uid=" + username;
                    model.Psw = pwd;
                    string Lresult = mDirectory.GetDirectoryEntry(model);
                    if (Lresult == "")
                    {
                        SysUserEntity sysuser = sysUsergDAL.GetLogin(username);
                        if (sysuser != null)
                        {
                            context.Response.Cookies["UserType"].Value = sysuser.UserType.ToString();
                            context.Response.Cookies["UserID"].Value = CommonFunction.Encrypt(sysuser.UID.ToString());
                            context.Response.Cookies["SysUserName"].Value = sysuser.UserName;
                            context.Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(sysuser.RealName, Encoding.GetEncoding("UTF-8"));
                            context.Response.Cookies["SysUserPwd"].Value = pwd;
                            //SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + sysuser.UserName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统",sysuser.UID);
                            SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + sysuser.RealName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统【手机端登录】", sysuser.UID);
                            sysLogDAL.Edit(log);
                            // Context.Cache.Insert("uid", sysuser.UID, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.Normal, null);
                            // Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'WebMain.aspx'", true);
                            if (sysuser.UserType == (int)CommonEnum.UserType.老师)
                            {
                                result = "WebMain.aspx";
                            }
                            else
                            {
                                result="Stu_WebMain.aspx";
                            }
                        }
                    }
                    else
                    {
                        Lresult = Lresult.Replace("'", "");
                        Lresult = Lresult.Replace("\"", "");
                        Lresult = Lresult.Replace("\r\n", "");
                        oresult= Lresult ;
                        //return;
                    }
                }
                else
                {
                    oresult="请配置LDAP地址！";
                    //return;
                }
            }
            else
            {
               result = Loging(pwd, username, out oresult);
            }
            StringBuilder sb = new StringBuilder("");
            sb.Append("{\"result\":\"" + oresult + "\",\"url\":\"" + result + "\"}");
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        private string  Loging(string pwd, string username,out string rr)
        {
            int result = 0;
            rr = "success";
            //SysUserEntity sysuser = sysUsergDAL.UserLogin(username, pwd);
            SysUserEntity sysuser = sysUsergDAL.UserLoad(username, pwd, ref result);
            if (result == -1)
            {
                rr = "用户不存在！";
                return "";
            }
            else if (result == -2)
            {
                rr="密码错误！";
                return "";
            }
            else if (sysuser.UState == -1)
            {
                rr = "您的账户已被禁用，请联系系统管理员！";
                return "";
            }
            else
            {
               HttpContext.Current.Response.Cookies["UserType"].Value = sysuser.UserType.ToString();
               HttpContext.Current.Response.Cookies["UserID"].Value = CommonFunction.Encrypt(sysuser.UID.ToString());
               HttpContext.Current.Response.Cookies["SysUserName"].Value = sysuser.UserName;
               HttpContext.Current.Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(sysuser.RealName, Encoding.GetEncoding("UTF-8"));
               HttpContext.Current.Response.Cookies["SysUserPwd"].Value = pwd;
                //SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + sysuser.UserName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统",sysuser.UID);
                SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + sysuser.RealName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统", sysuser.UID);
                sysLogDAL.Edit(log);
                // Context.Cache.Insert("uid", sysuser.UID, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.Normal, null);
                // Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'WebMain.aspx'", true);
                if (sysuser.UserType == (int)CommonEnum.UserType.老师)
                {
                    return "AppMain.aspx";
                }
                else
                {
                    return "../appstu/Stu_AppMain.aspx";
                }
            }
        }
        public void getUser(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            try
            {
               
                if (XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "Login") == "1")
                {

                    string uid = context.Request.Params["code"];
                 //   string uid = context.Cache.Get("uid").ToString();
                    SysUserEntity sysuser = sysUsergDAL.GetObjByID(CommonFunction.Decrypt(uid));
                    if (sysuser != null)
                    {
                        sb.Append("{\"result\":\"true\",");
                        sb.Append("\"name\":\"" + sysuser.RealName + "\",");
                        sb.Append("\"gender\":\"" + sysuser.UserSex + "\",");
                        sb.Append("\"mobile\":\"" + sysuser.CellPhone + "\",");
                        sb.Append("\"email\":\"" + sysuser.MailNum + "\",");
                        sb.Append("}");
                    }

                }
                else { sb.Append("{\"result\":\"false\"}"); }
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}