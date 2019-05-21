using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GK.GKICMP.Entities;

namespace GK.GKICMP.Common
{
    public class WeixinQYAPI
    {
        /// <summary>
        /// 返回接口凭证
        /// </summary>
        /// <param name="type">凭证类型：1，应用凭证。2，通讯录凭证</param>
        /// <returns></returns>
        public static string GetToken(int type)
        {
            string Token = "";
            string time = "";
            if (type == 1)
            {
                time = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "Agentaccess_tokenTime");

                if (!string.IsNullOrEmpty(time))
                {
                    TimeSpan span = DateTime.Now - Convert.ToDateTime(time);
                    if (span.TotalSeconds > 7000)
                    {
                        Token = GetAccess_Token(XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "corpid"), XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "corpsecret"));
                        if (!string.IsNullOrEmpty(Token))
                        {
                            XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "Agentaccess_token", Token);
                            XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "Agentaccess_tokenTime", DateTime.Now.ToString());
                        }
                        else
                        {
                            Token = "";
                            return Token;
                        }
                    }
                    else
                    {
                        Token = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "Agentaccess_token");
                        if (string.IsNullOrEmpty(Token))
                        {
                            Token = GetAccess_Token(XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "corpid"), XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "corpsecret"));
                            if (!string.IsNullOrEmpty(Token))
                            {
                                XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "Agentaccess_token", Token);
                                XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "Agentaccess_tokenTime", DateTime.Now.ToString());
                            }
                            else
                            {
                                Token = "";
                                return Token;
                            }
                        }
                    }
                }
                else
                {
                    Token = GetAccess_Token(XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "corpid"), XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "corpsecret"));
                    if (!string.IsNullOrEmpty(Token))
                    {
                        XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "Agentaccess_token", Token);
                        XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "Agentaccess_tokenTime", DateTime.Now.ToString());
                    }
                    else
                    {
                        Token = "";
                        return Token;
                    }
                }
            }
            else
            {
                time = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "TXLaccess_tokenTime");

                if (!string.IsNullOrEmpty(time))
                {
                    TimeSpan span = DateTime.Now - Convert.ToDateTime(time);
                    if (span.TotalSeconds > 7000)
                    {
                        Token = GetAccess_Token(XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "corpid"), XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "Secret"));
                        if (!string.IsNullOrEmpty(Token))
                        {
                            XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "TXLaccess_token", Token);
                            XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "TXLaccess_tokenTime", DateTime.Now.ToString());
                        }
                        else
                        {
                            Token = "";
                            return Token;
                        }
                    }
                    else
                    {
                        Token = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "TXLaccess_token");
                        if (string.IsNullOrEmpty(Token))
                        {
                            Token = GetAccess_Token(XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "corpid"), XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "Secret"));
                            if (!string.IsNullOrEmpty(Token))
                            {
                                XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "TXLaccess_token", Token);
                                XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "TXLaccess_tokenTime", DateTime.Now.ToString());
                            }
                            else
                            {
                                Token = "";
                                return Token;
                            }
                        }
                    }
                }
                else
                {
                    Token = GetAccess_Token(XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "corpid"), XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "Secret"));
                    if (!string.IsNullOrEmpty(Token))
                    {
                        XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "TXLaccess_token", Token);
                        XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "TXLaccess_tokenTime", DateTime.Now.ToString());
                    }
                    else
                    {
                        Token = "";
                        return Token;
                    }
                }
            }
            return Token;
        }

        public static string GetToken(int type, string agent)
        {
            string Token = "";
            string time = "";
            WeiXinInfoEntity model = XMLHelper.Get("~/QYWX.xml", agent, 1);
            if (model.IsOpen == 1)
            {
                #region 应用
                if (type == 1)
                {
                    Token = GetAccess_Token(model.CorpID, model.Secret);
                    #region 注释
                    //if (!string.IsNullOrEmpty(model.Token_Time))
                    //{
                    //    time = model.Token_Time;
                    //    TimeSpan span = DateTime.Now - Convert.ToDateTime(time);
                    //    if (span.TotalSeconds > 7000)
                    //    {
                    //        Token = GetAccess_Token(model.CorpID, model.Secret);
                    //        if (!string.IsNullOrEmpty(Token))
                    //        {
                    //            XMLHelper.Update("~/QYWX.xml", agent, "Access_Token", Token,1);
                    //            XMLHelper.Update("~/QYWX.xml", agent, "Token_Time", DateTime.Now.ToString(""),1);
                    //        }
                    //        else
                    //        {
                    //            Token = "";
                    //            return Token;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (!string.IsNullOrEmpty(model.Access_Token))
                    //        {
                    //            Token = model.Access_Token;
                    //        }
                    //        else
                    //        {
                    //            Token = GetAccess_Token(model.CorpID, model.Secret);
                    //            if (!string.IsNullOrEmpty(Token))
                    //            {
                    //                XMLHelper.Update("~/QYWX.xml", agent, "Access_Token", Token,1);
                    //                XMLHelper.Update("~/QYWX.xml", agent, "Token_Time", DateTime.Now.ToString(), 1);
                    //            }
                    //            else
                    //            {
                    //                Token = "";
                    //                return Token;
                    //            }

                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    Token = GetAccess_Token(model.CorpID, model.Secret);
                    //    if (!string.IsNullOrEmpty(Token))
                    //    {
                    //        XMLHelper.Update("~/QYWX.xml", agent, "Access_Token", Token, 1);
                    //        XMLHelper.Update("~/QYWX.xml", agent, "Token_Time", DateTime.Now.ToString(), 1);
                    //    }
                    //    else
                    //    {
                    //        Token = "";
                    //        return Token;
                    //    }
                    //}

                    #endregion
                }
                #endregion
                #region 通讯录
                else
                {
                    model = XMLHelper.Get("~/QYWX.xml", agent, 2);
                    Token = GetAccess_Token(model.CorpID, model.Secret);
                    //if (!string.IsNullOrEmpty(model.Token_Time))
                    //{
                    //    time = model.Token_Time;
                    //    TimeSpan span = DateTime.Now - Convert.ToDateTime(time);
                    //    if (span.TotalSeconds > 7000)
                    //    {
                    //        Token = GetAccess_Token(model.CorpID, model.Secret);
                    //        if (!string.IsNullOrEmpty(Token))
                    //        {
                    //            XMLHelper.Update("~/QYWX.xml", "", "Access_Token", Token, 2);
                    //            XMLHelper.Update("~/QYWX.xml", "", "Token_Time", DateTime.Now.ToString(), 2);
                    //        }
                    //        else
                    //        {
                    //            Token = "";
                    //            return Token;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (!string.IsNullOrEmpty(model.Access_Token))
                    //        {
                    //            Token = model.Access_Token;
                    //        }
                    //        else
                    //        {
                    //            Token = GetAccess_Token(model.CorpID, model.Secret);
                    //            if (!string.IsNullOrEmpty(Token))
                    //            {
                    //                XMLHelper.Update("~/QYWX.xml", "", "Access_Token", Token, 2);
                    //                XMLHelper.Update("~/QYWX.xml", "", "Token_Time", DateTime.Now.ToString(), 2);
                    //            }
                    //            else
                    //            {
                    //                Token = "";
                    //                return Token;
                    //            }
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    Token = GetAccess_Token(model.CorpID, model.Secret);
                    //    if (!string.IsNullOrEmpty(Token))
                    //    {
                    //        XMLHelper.Update("~/QYWX.xml","", "Access_Token", Token, 2);
                    //        XMLHelper.Update("~/QYWX.xml","", "Token_Time", DateTime.Now.ToString(), 2);
                    //    }
                    //    else
                    //    {
                    //        Token = "";
                    //        return Token;
                    //    }
                    //}
                }

                #endregion
            }
            return Token;
        }
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="CorpID"></param>
        /// <param name="CorpSecret"></param>
        /// <returns></returns>
        public static string GetAccess_Token(string CorpID, string CorpSecret)
        {
            string access_Token = RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", CorpID, CorpSecret));
            return Json(access_Token, "access_token");

        }
        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="jsonDept">结构体:{ "name": "广州研发中心","parentid": 1,"order(排序越小越前)": 1,"id": 1}</param>
        /// name,parentid,id必填。其中id>1 根部门为1.
        /// <returns>返回0则成功</returns>
        public static string CreateDepart(string access_token, string jsonDept)
        {
            //string djson = "{\"access_token\":\"" + access_token + "\",\"name\":\"新增部门测试\",\"parentid\":\"1\",\"order\":\"3\",\"createDeptGroup\":\"false\"}";
            string depart = Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token={0}", access_token), jsonDept);
            return Json(depart, "errcode");

        }
        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="jsonDept">{"id": 2,"name": "广州研发中心","parentid": 1,"order": 1}</param>
        /// id必填，不填的不更新
        /// <returns>返回0则成功</returns>
        public static string UpdateDepart(string access_token, string jsonDept)
        {
            string depart = Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/department/update?access_token={0}", access_token), jsonDept);
            return Json(depart, "errcode");
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id">部门id</param>
        /// <returns>返回0则成功</returns>
        public static string DelDepart(string access_token, string id)
        {
            string access_Token = RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/department/delete?access_token={0}&id={1}", access_token, id));
            return Json(access_Token, "errcode");
        }
        /// <summary>
        /// 创建人员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="jsonUser">{"userid": "15913215421","name": "张三","department": [1, 2],"position": "产品经理","mobile": "15913215421","gender": "1",</param>
        /// 性别：1 男  ；2 女
        /// <returns>返回0则成功</returns>
        public static string CreateUser(string access_token, string jsonUser)
        {
            string user = Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/create?access_token={0}", access_token), jsonUser);
            return Json(user, "errcode");
        }
        /// <summary>
        /// 更新成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="jsonUser"> "userid": "15913215421","name": "李四","department": [1],"position": "后台工程师",</param>
        /// <returns>返回0则成功</returns>
        public static string UpdateUser(string access_token, string jsonUser)
        {
            string user = Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token={0}", access_token), jsonUser);
            return Json(user, "errcode");
        }
        /// <summary>
        /// 获取微信用户信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid">用户id</param>
        /// <returns>手机号</returns>
        public static string GetUser(string access_token, string userid)
        {
            return RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}", access_token, userid));
            //return Json(user, "mobile");
        }
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid">用户id</param>
        /// <returns>返回0则成功</returns>
        public static string DelUser(string access_token, string userid)
        {
            string access_Token = RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/delete?access_token={0}&userid={1}", access_token, userid));
            return Json(access_Token, "errcode");
        }
        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="jsonUserList">{"useridlist": ["userid", "userid"]}</param>
        /// <returns>返回0则成功</returns>
        public static string DelUserList(string access_token, string jsonUserList)
        {
            string access_Token = Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/batchdelete?access_token={0}", access_token), jsonUserList);
            return Json(access_Token, "errcode");
        }
        /// <summary>
        /// 发送图文消息
        /// </summary>
        /// <param name="access_token">调用凭借</param>
        /// <param name="touser">接受人，@all为全员，多个以‘|’隔开</param>
        /// <param name="agentid">应用id</param>
        /// <param name="title">消息标题</param>
        /// <param name="description">消息概述</param>
        /// <param name="url">图文链接地址</param>
        /// <param name="picurl">消息显示图片地址</param>
        /// <returns>结果"ok"发送成功</returns>
        public static string SendMessage(string access_token, string touser, int agentid, string title, string description, string url, string picurl = "")
        {
            string json = "{\"touser\":\"" + touser
                        + "\",\"msgtype\":\"news\",\"agentid\":\"" + agentid
                        + "\",\"news\":{\"articles\":[{\"title\":\"" + title
                        + "\",\"description\":\"" + description
                        + "\",\"url\":\"" + url + "\",\"picurl\":\"" + picurl + "\"}]}}";
            string result = Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", access_token), json);
            return Json(result, "errmsg");
        }

        /// <summary>
        /// 发送文本卡片消息
        /// </summary>
        /// <param name="access_token">调用凭借</param>
        /// <param name="touser">接受人，@all为全员，多个以‘|’隔开</param>
        /// <param name="agentid">应用id</param>
        /// <param name="title">消息标题</param>
        /// <param name="description">消息概述</param>
        /// <param name="url">图文链接地址</param>
        /// <param name="picurl">消息显示图片地址</param>
        /// <returns>结果"ok"发送成功</returns>
        public static string SendMessageCard(string access_token, string touser, int agentid, string title, string description, string url, string senddate, string sendusername, string picurl = "")
        {
              string json = "{\"touser\" : \""+touser+"\",\"msgtype\" : \"textcard\",\"agentid\" :" + agentid
                  +",\"textcard\" : {\"title\" : \""+title
                  //+ "\",\"description\" : \"<div class=\\\"gray\\\">" + title + "</div> <div class=\\\"normal\\\">" + description + "</div><div class=\\\"highlight\\\">政同事领取</div>\",\"url\" : \""+ url+"\",\"btntxt\":\"更多\"}";
                    + "\",\"description\" : \"<div class=\\\"gray\\\"> 通知时间： " + senddate + "</div> <div class=\\\"normal\\\">通知人： " + sendusername + "</div><div class=\\\"highlight\\\">通知内容：" + description + "</div>\",\"url\" : \"" + url + "\",\"btntxt\":\"更多\"}";
            
            
            string result = Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", access_token), json);
            return Json(result, "errmsg");
        }

        /// <summary>
        /// 发送图片消息
        /// </summary>
        /// <param name="access_token">调用凭借</param>
        /// <param name="touser">接受人，@all为全员，多个以‘|’隔开</param>
        /// <param name="agentid">应用id</param>
        /// <param name="title">消息标题</param>
        /// <param name="description">消息概述</param>
        /// <param name="url">图文链接地址</param>
        /// <param name="picurl">消息显示图片地址</param>
        /// <returns>结果"ok"发送成功</returns>
        public static string SendMessagePhoto(string access_token, string touser, int agentid, string serverid)
        {
            string json = "{\"touser\":\"" + touser
                        + "\",\"msgtype\":\"image\",\"agentid\":\"" + agentid
                        + "\",\"image\":{\"media_id\":\"" + serverid + "\"}}";
            string result = Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", access_token), json);
            return Json(result, "errmsg");
        }
        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="touser">接受人，多个以“|”隔开，@all全部</param>
        /// <param name="agentid">应用id</param>
        /// <param name="content">消息内容</param>
        /// <returns>返回结果："ok"成功</returns>
        public static string SendMessage(string access_token, string touser, string agentid, string content)
        {
            string json = "{\"touser\":\"" + touser + "\",\"msgtype\":\"text\",\"agentid\":\"" + agentid + "\",\"text\":{\"content\":\"" + content + "\"}}";
            string result = Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", access_token), json);
            return Json(result, "errmsg");
        }
        /// <summary>
        /// 发送语音消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="touser">接受人，多个以“|”隔开，@all全部</param>
        /// <param name="agentid">应用id</param>
        /// <param name="content">消息内容</param>
        /// <returns>返回结果："ok"成功</returns>
        public static string SendMessageMEDIA_ID(string access_token, string touser, string agentid, string media_id)
        {
            string json = "{\"touser\":\"" + touser + "\",\"msgtype\":\"voice\",\"agentid\":\"" + agentid + "\",\"voice\":{\"media_id\":\"" + media_id + "\"}}";
            string result = Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", access_token), json);
            return Json(result, "errmsg");
        }
        /// <summary>
        /// 消息发送内容格式（）
        /// </summary>
        /// <param name="touser">接受人userid多人以‘|’隔开</param>
        /// <param name="msgtype">消息类型</param>
        /// <param name="agentid">应用id</param>
        /// <param name="content">消息内容</param>
        /// <returns>json格式的消息内容</returns>
        //public static string SendMsgContent(string touser,  int agentid, string content)
        //{
        //    return "{\"touser\":\"" + touser + "\",\"msgtype\":\"text \",\"agentid\":\"" + agentid + "\",\"text\":{\"content\":\"" + content + "\"}}";
        //}

        /// <summary>
        /// 获取用户userid
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="code">临时码</param>
        /// <returns></returns>
        public static string GetUserInfo(string access_token, string code)
        {
            string result = RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}", access_token, code));
            if (Json(result, "UserId") != "")
                return Json(result, "UserId");
            else
                return Json(result, "errcode");
        }

        #region 后台post事件
        /// <summary>
        /// 后台post事件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string Post(string url, string param)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            string paraUrlCoded = param;
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }
        #endregion



        #region 截取Json字符串
        /// <summary>
        /// 截取Json字符串
        /// </summary>
        /// <param name="json"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Json(string json, string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(json))
            {
                key = "\"" + key.Trim('"') + "\"";
                int index = json.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值
                    int end = json.IndexOf(',', index);
                    if (end == -1)
                    {
                        end = json.IndexOf('}', index);
                    }

                    result = json.Substring(index, end - index);
                    result = result.Trim(new char[] { '"', ' ', '\'' }); //过滤引号或空格
                }
            }
            return result;
        }
        #endregion

        #region get事件
        /// <summary>
        /// get事件
        /// </summary>
        /// <param name="urlString"></param>
        /// <returns></returns>
        public static string RequestUrl(string urlString)
        {
            //定义局部变量
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebRespones = null;
            Stream stream = null;
            string htmlString = string.Empty;
            //请求页面
            try
            {
                httpWebRequest = WebRequest.Create(urlString) as HttpWebRequest;
            }
            //处理异常
            catch (Exception ex)
            {
                throw new Exception("建立页面请求时发生错误！", ex);
            }
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; Maxthon 2.0)";
            //获取服务器的返回信息
            try
            {
                httpWebRespones = (HttpWebResponse)httpWebRequest.GetResponse();
                stream = httpWebRespones.GetResponseStream();
            }
            //处理异常
            catch (Exception ex)
            {
                //throw new Exception("接受服务器返回页面时发生错误！", ex);
                return htmlString = "操作超时";
            }
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
            //读取返回页面
            try
            {
                htmlString = streamReader.ReadToEnd();
            }
            //处理异常
            catch (Exception ex)
            {
                throw new Exception("读取页面数据时发生错误！", ex);
            }
            //释放资源返回结果
            streamReader.Close();
            stream.Close();
            return htmlString;
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
