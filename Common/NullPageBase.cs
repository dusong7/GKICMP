/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月03日 17时55分16秒
** 描    述:      PageBase
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;

namespace GK.GKICMP.Common
{
    public class NullPageBase : System.Web.UI.Page
    {

        #region 页面加载
        protected override void OnLoad(EventArgs e)
        {
         
            base.OnLoad(e);
        }
        #endregion


        /// <summary>
        /// 用户ID
        /// </summary>
        protected internal string UserID
        {
            get
            {
                string result = CommonFunction.Decrypt((GetCookie<string>("UserID")));
                if (result == null || result == "")
                {
                  //  CookieInvalidTo();
                }
                return result;
            }
        }

        protected string SysUserName
        {
            get
            {
                string result = Server.UrlDecode(GetCookie<string>("SysUserName"));

                if (result == null || result == "")
                {

               
                }
                return result;
            }
        }







        /// <summary>
        /// 姓名
        /// </summary>
        protected string UserRealName
        {
            get
            {
                string result = Server.UrlDecode(GetCookie<string>("RealName"));

                if (result == null || result == "")
                {

                
                }
                return result;
            }
        }

        #region 获取QueryString值
        /// <summary>
        /// 获取QueryString值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="queryName">Key</param>
        /// <returns></returns>
        protected T GetQueryString<T>(string queryName)
        {
            if ((typeof(T).FullName == "System.String"))
            {
                return GetQueryString(queryName, (T)Convert.ChangeType(string.Empty, typeof(T)));
            }

            return GetQueryString(queryName, default(T));
        }

        /// <summary>
        /// 获取QueryString值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="queryName">Key</param>
        /// <param name="defultValue">默认值</param>
        /// <returns></returns>
        protected T GetQueryString<T>(string queryName, T defultValue)
        {
            T stateValue = defultValue;

            try
            {
                if (Request.QueryString[queryName] != null)
                    stateValue = (T)Convert.ChangeType(Request.QueryString[queryName], typeof(T));
            }
            catch
            {
                stateValue = defultValue;
            }
            return stateValue;
        }
        #endregion


   


        #region 获取和设置Cookie值
        /// <summary>
        /// 设置Cookie值
        /// </summary>
        /// <param name="cookieName">名称</param>
        /// <param name="cookieValue">值</param>
        protected void SetCookie(string cookieName, string cookieValue)
        {
            SetCookie(cookieName, cookieValue, string.Empty, string.Empty, null);
        }

        /// <summary>
        /// 设置Cookie值
        /// </summary>
        /// <param name="cookieName">名称</param>
        /// <param name="cookieValue">值</param>
        /// <param name="cookiePath">虚拟路径（默认：empty）</param>
        /// <param name="cookieDomain">关联的域（默认：empty）</param>
        /// <param name="cookieExpires">过期时间（默认：null）</param>
        protected void SetCookie(string cookieName, string cookieValue, string cookiePath, string cookieDomain, DateTime? cookieExpires)
        {
            HttpCookie cookie = new HttpCookie(cookieName, cookieValue);

            if (!string.IsNullOrEmpty(cookiePath))
            {
                cookie.Path = cookiePath;
            }

            if (!string.IsNullOrEmpty(cookieDomain))
            {
                cookie.Domain = cookieDomain;
            }

            if (cookieExpires != null)
            {
                cookie.Expires = (DateTime)cookieExpires;
            }

            Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 获取Cookie值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="cookieName">Key</param>
        /// <returns></returns>
        protected T GetCookie<T>(string cookieName)
        {
            if ((typeof(T).FullName == "System.String"))
            {
                return GetCookie(cookieName, (T)Convert.ChangeType(string.Empty, typeof(T)));
            }

            return GetCookie(cookieName, default(T));
        }

        /// <summary>
        /// 获取Cookie值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="cookieName">Key</param>
        /// <param name="defultValue">默认值</param>
        /// <returns></returns>
        protected T GetCookie<T>(string cookieName, T defultValue)
        {
            T cookieValue = defultValue;

            try
            {
                cookieValue = (T)Convert.ChangeType(Request.Cookies[cookieName].Value, typeof(T));
            }
            catch
            { }

            return cookieValue;
        }
        #endregion


        #region 消息提醒
        /// <summary>
        /// 消息提醒
        /// </summary>
        /// <param name="sMessage"></param>
        public void ShowMessage(string sMessage)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：" + sMessage + "！');</script>");
            //Response.Write("<Script Language='JavaScript'>window.alert('系统提示：" + sMessage.ToString() + "')'</script>"); 

            return;
        }


        /// <summary>
        /// 消息提醒,并跳转
        /// </summary>
        /// <param name="sMessage"></param>
        public void ShowMessage(string sMessage, string script)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('" + sMessage + "！');" + script, true);
            return;
        }
        #endregion


        #region 消息提醒成功
        /// <summary>
        /// 消息提醒成功
        /// </summary>
        /// <param name="sMessage"></param>
        public void ShowMessage()
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');winclose();", true);

        }


        /// <summary>
        /// 运行纯脚本
        /// </summary>
        /// <param name="sMessage"></param>
        public void ShowScript(string script)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", script, true);
        }
        #endregion


        #region 截取字符
        /// <summary>
        /// 截取字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string GetCutStr(object str, int length)
        {
            if (str.ToString().Length > length)
            {
                return str.ToString().Substring(0, length).TrimEnd(',') + "...";
            }
            else
            {
                return str.ToString().TrimEnd(',');
            }
        }
        #endregion


  
    }
}
