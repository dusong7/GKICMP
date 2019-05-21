using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using GK.GKICMP.DAL;
using System.IO;
using System.Text;
using GK.GKICMP.Common;
using System.Xml;
using System.Net;

namespace GKICMP.ashx
{
    /// <summary>
    /// WXQYService 的摘要说明
    /// </summary>
    public class WXQYService : IHttpHandler
    {
        public string token = ConfigurationManager.AppSettings["CorpToken"];//从配置文件获取Token
        public string encodingAESKey = ConfigurationManager.AppSettings["EncodingAESKey"];//从配置文件获取EncodingAESKey
       // public string corpId = ConfigurationManager.AppSettings["CorpId"];//从配置文件获取corpId  
        public string corpId = XMLHelper.GetValues("~/QYWX.xml", "WX");//从配置文件获取corpId  
        public string echoString = HttpContext.Current.Request.QueryString["echoStr"];
        public string signature = HttpContext.Current.Request.QueryString["msg_signature"];//企业号的 msg_signature
        public string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
        public string nonce = HttpContext.Current.Request.QueryString["nonce"];
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public void ProcessRequest(HttpContext context)
        {
           // Subscribe(1, "123999999");
            string postString = string.Empty;
            if (HttpContext.Current.Request.HttpMethod.ToUpper() == "GET")
            {
                Auth();
            }
            //if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
            else
            {
                using (Stream stream = HttpContext.Current.Request.InputStream)
                {
                    Byte[] postBytes = new Byte[stream.Length];
                    stream.Read(postBytes, 0, (Int32)stream.Length);
                    postString = Encoding.UTF8.GetString(postBytes);

                }

                if (!string.IsNullOrEmpty(postString))
                {
                    //    HttpContext.Current.Response.Write(postString); 
                    //   //  .CreateFileWithContent();
                    //    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", postString, false);
                    //    context.Response.End();
                    //  //new  WXBizMsgCrypt().EncryptMsg  Execute(postString, accountInfo);
                    string sReqMsgSig = HttpContext.Current.Request.QueryString["msg_signature"];
                    //string sReqMsgSig = "477715d11cdb4164915debcba66cb864d751f3e6";
                    string sReqTimeStamp = HttpContext.Current.Request.QueryString["timestamp"];
                    //string sReqTimeStamp = "1409659813";
                    string sReqNonce = HttpContext.Current.Request.QueryString["nonce"];
                    //string sReqNonce = "1372623149";
                    // Post请求的密文数据
                    string sReqData = postString;
                    //string sReqData = "<xml><ToUserName><![CDATA[wx5823bf96d3bd56c7]]></ToUserName><Encrypt><![CDATA[RypEvHKD8QQKFhvQ6QleEB4J58tiPdvo+rtK1I9qca6aM/wvqnLSV5zEPeusUiX5L5X/0lWfrf0QADHHhGd3QczcdCUpj911L3vg3W/sYYvuJTs3TUUkSUXxaccAS0qhxchrRYt66wiSpGLYL42aM6A8dTT+6k4aSknmPj48kzJs8qLjvd4Xgpue06DOdnLxAUHzM6+kDZ+HMZfJYuR+LtwGc2hgf5gsijff0ekUNXZiqATP7PF5mZxZ3Izoun1s4zG4LUMnvw2r+KqCKIw+3IQH03v+BCA9nMELNqbSf6tiWSrXJB3LAVGUcallcrw8V2t9EL4EhzJWrQUax5wLVMNS0+rUPA3k22Ncx4XXZS9o0MBH27Bo6BpNelZpS+/uh9KsNlY6bHCmJU9p8g7m3fVKn28H3KDYA5Pl/T8Z1ptDAVe0lXdQ2YoyyH2uyPIGHBZZIs2pDBS8R07+qN+E7Q==]]></Encrypt><AgentID><![CDATA[218]]></AgentID></xml>";
                    string sMsg = "";  // 解析之后的明文
                    string xml = "";//解析之后节点内容
                    int ret = new WXBizMsgCrypt(token, encodingAESKey, corpId).DecryptMsg(sReqMsgSig, sReqTimeStamp, sReqNonce, sReqData, ref sMsg);
                    if (ret != 0)
                    {
                        System.Console.WriteLine("ERR: Decrypt Fail, ret: " + ret);
                        return;
                    }
                    // ret==0表示解密成功，sMsg表示解密之后的明文xml串
                    // TODO: 对明文的处理
                    // For example:
                    //事件处理
                    if (XmlContent(sMsg, "MsgType") == "event")
                    {
                        string userid = XmlContent(sMsg, "FromUserName");
                        switch (XmlContent(sMsg, "Event"))
                        {
                            case "subscribe":
                                FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", "关注成功" + userid, false);
                                Subscribe(1, userid);
                                break;
                            case "unsubscribe":
                                FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", "取消关注", false);
                                Subscribe(0, userid);
                                break;
                            case "LOCATION":
                                FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", "上报地理位置(纬度：" + XmlContent(sMsg, "Latitude") + ",经度：" + XmlContent(sMsg, "Longitude") + ",精度：" + XmlContent(sMsg, "Precision") + ")", false);
                                //Auth();
                                break;
                            case "click":
                               // HttpContext.Current.Response.Redirect("http://gk.whsedu.cn/yghd/Test.html");
                                string data = "";
                                //FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", "点击菜单（AgentID:" + XmlContent(sMsg, "AgentID") + "）", false);
                               // xml = SendMsg(XmlContent(sMsg, "FromUserName"), DateTimeToUnixInt(DateTime.Now), "这里是点击事件被动响应消息。详情请看：http://gk.whxedu.cn");//验证通过（可以发送）
                                //xml = SendMsg(XmlContent(sMsg, "FromUserName"), DateTimeToUnixInt(DateTime.Now), 1, "未来已来，你来不来。", "不管你信不信，反正我信了", "http://gk.whsedu.cn/wximage/1.jpg", "http://gk.whsedu.cn/Test.html");//验证通过（可以发送）
                                xml = SendMsg(XmlContent(sMsg, "FromUserName"), DateTimeToUnixInt(DateTime.Now), ref data);//发送图片（未通过）
                                if (!string.IsNullOrEmpty(xml))
                                {
                                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", data, false);
                                    HttpContext.Current.Response.Write(xml);
                                    HttpContext.Current.Response.End();

                                }
                                break;
                            case "view":
                                HttpContext.Current.Response.Redirect("http://gk.whsedu.cn/yghd/Test.html");
                                xml = SendMsg(XmlContent(sMsg, "FromUserName"), DateTimeToUnixInt(DateTime.Now), "点击菜单跳转链接的事件推送(设置的跳转URL:" + XmlContent(sMsg, "EventKey") + ",AgentID:" + XmlContent(sMsg, "AgentID") + ")");
                                if (!string.IsNullOrEmpty(xml))
                                {
                                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", xml, false);
                                    HttpContext.Current.Response.Write(xml);
                                    HttpContext.Current.Response.End();

                                }
                                //FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", "点击菜单跳转链接的事件推送(设置的跳转URL:" + XmlContent(sMsg, "EventKey") + ",AgentID:" + XmlContent(sMsg, "AgentID") + ")", false);
                                break;
                            case "scancode_push":
                                xml = SendMsg(XmlContent(sMsg, "FromUserName"), DateTimeToUnixInt(DateTime.Now), "扫码推事件且弹出“消息接收中”提示框的事件推送" + XmlContent(sMsg, "ScanCodeInfo"));
                                if (!string.IsNullOrEmpty(xml))
                                {
                                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", xml, false);
                                    HttpContext.Current.Response.Write(xml);
                                    HttpContext.Current.Response.End();

                                }
                                FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", "扫码推事件的事件推送,扫描信息：" + XmlContent(sMsg, "ScanCodeInfo"), false);
                                break;
                            case "scancode_waitmsg":
                                xml = SendMsg(XmlContent(sMsg, "FromUserName"), DateTimeToUnixInt(DateTime.Now), "扫码推事件且弹出“消息接收中”提示框的事件推送" + XmlContent(sMsg, "ScanCodeInfo"));
                                if (!string.IsNullOrEmpty(xml))
                                {
                                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", xml, false);
                                    HttpContext.Current.Response.Write(xml);
                                    HttpContext.Current.Response.End();

                                }
                                FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", "扫码推事件且弹出“消息接收中”提示框的事件推送" + XmlContent(sMsg, "ScanCodeInfo"), false);
                                break;

                        }
                    }
                    else
                    {
                        string data="";
                        //FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", "发送消息" + DateTime.Now, false);
                        //xml = SendMsg(XmlContent(sMsg, "FromUserName"), DateTimeToUnixInt(DateTime.Now), "这里是系统自动回复。详情请看：http://gk.whxedu.cn");
                        //xml = SendMsg(XmlContent(sMsg, "FromUserName"), DateTimeToUnixInt(DateTime.Now) ,ref data);
                        xml = SendMsg(XmlContent(sMsg, "FromUserName"), DateTimeToUnixInt(DateTime.Now), "自动回复");
                        if (!string.IsNullOrEmpty(xml))
                        {
                            FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", sMsg, false);
                            HttpContext.Current.Response.Write(xml);
                            HttpContext.Current.Response.End();
                           
                        }
                    }
                    //System.Console.WriteLine(XmlContent(sMsg, "content"));
                }
            }
        }
        public static int DateTimeToUnixInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        /// <summary>
        /// 读取xml节点内容
        /// </summary>
        /// <param name="xml">xml内容</param>
        /// <param name="key">节点名称</param>
        /// <returns>节点内容</returns>
        public string XmlContent(string xml, string key)
        {
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode root = doc.FirstChild;
            return root[key].InnerText;
        }
        /// <summary>
        /// 回调验证
        /// </summary>
        private void Auth()
        {
            string decryptEchoString = "";
            if (CheckSignature(token, signature, timestamp, nonce, corpId, encodingAESKey, echoString, ref decryptEchoString))
            {
                if (!string.IsNullOrEmpty(decryptEchoString))
                {
                    HttpContext.Current.Response.Write(decryptEchoString);
                    HttpContext.Current.Response.End();
                }
            }
        }
        /// <summary> /// 验证企业号签名 
        /// </summary> 
        /// <param name="token">企业号配置的Token</param>
        /// /// <param name="signature">签名内容</param> ///
        /// <param name="timestamp">时间戳</param> ///
        /// <param name="nonce">nonce参数</param> ///
        /// <param name="corpId">企业号ID标识</param> ///
        /// <param name="encodingAESKey">加密键</param> ///
        /// <param name="echostr">内容字符串</param> /// 
        /// <param name="retEchostr">返回的字符串</param> ///
        /// <returns></returns>  /// 
        public bool CheckSignature(string token, string signature, string timestamp, string nonce, string corpId, string encodingAESKey, string echostr, ref string retEchostr)
        {
            WXBizMsgCrypt wxcpt = new WXBizMsgCrypt(token, encodingAESKey, corpId);
            int result = wxcpt.VerifyURL(signature, timestamp, nonce, echostr, ref retEchostr);
            if (result != 0)
            { //LogTextHelper.Error("ERR: VerifyURL fail, ret: " + result); 
                return false;
            }
            return true;  //ret==0表示验证成功，retEchostr参数表示明文，用户需要将retEchostr作为get请求的返回参数，返回给企业号。 //  HttpUtils.SetResponse(retEchostr); } 
        }
        #region  发送以图文消息（待改进）
        /// <summary>
        /// 发送以图文消息（待改进）
        /// </summary>
        /// <param name="ToUserName"></param>
        /// <param name="CreateTime"></param>
        /// <param name="ArticleCount"></param>
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        /// <param name="PicUrl"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public string SendMsg(string ToUserName, int CreateTime, int ArticleCount, string Title, string Description, string PicUrl, string Url)
        {
            string sEncryptMsg = "";
            string sRespData = "<xml>" +
                                  "<ToUserName><![CDATA[" + ToUserName + "]]></ToUserName><FromUserName><![CDATA[" + corpId + "]]></FromUserName> <CreateTime>" + CreateTime + "</CreateTime> <MsgType><![CDATA[news]]></MsgType> <ArticleCount>1</ArticleCount>" +
                                  "<Articles>" +
                                     "<item>" +
                                            " <Title><![CDATA[" + Title + "]]></Title> " +
                                             "<Description><![CDATA[" + Description + "]]></Description>" +
                                             "<PicUrl><![CDATA[" + PicUrl + "]]></PicUrl>" +
                                             " <Url><![CDATA[" + Url + "]]></Url>" +
                                     "</item>" +
                                 "</Articles>" +
                              "</xml>";
            int ret = new WXBizMsgCrypt(token, encodingAESKey, corpId).EncryptMsg(sRespData, timestamp, nonce, ref sEncryptMsg);
            if (ret == 0)
            {
                return sEncryptMsg;
            }
            return "";
        } 
        #endregion

        #region 发送以图片消息（待改进）
        /// <summary>
        /// 发送以图片消息（待改进）
        /// </summary>
        /// <param name="ToUserName"></param>
        /// <param name="CreateTime"></param>
        /// <param name="ArticleCount"></param>
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        /// <param name="PicUrl"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public string SendMsg(string ToUserName, int CreateTime, ref string  data)
        {
            string result = "1bZcTUQBFAnXO3cISbLKejJctpZHH2QGFZvJ8VAsJ2je2tMY9PPkklUYHl9a6wVa5";
            try
            {
                string token1 = WeixinQYAPI.GetAccess_Token(corpId, "hO3Z0iAo9B_S9vh17sL6_QmThmvrvsArrJbW6pn3Ujs");
                string wxurl = " https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token=" + token1 + "&type=image";
                string filepath = System.Web.HttpContext.Current.Server.MapPath("wximage/3.jpg"); //(本地服务器的地址)
                FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", filepath, false);
                // WriteLog("上传路径:" + filepath);
                WebClient myWebClient = new WebClient();
                myWebClient.Credentials = CredentialCache.DefaultCredentials;

                try
                {
                    byte[] responseArray = myWebClient.UploadFile(wxurl, "POST", filepath);
                    result = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);
                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", result, false);
                    result = Json(result, "media_id");

                    // WriteLog("上传result:" + result);
                    //UploadMM _mode = JsonHelper.ParseFromJson<UploadMM>(result);
                    //result = _mode.media_id;
                }
                catch (Exception ex)
                {
                    result = "Error:" + ex.Message;
                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", result, false);
                }
            }
            catch (Exception err)
            {

                FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", err.Message, false);
            }
            string sEncryptMsg = "";
            string sRespData = "<xml>" +
                                  "<ToUserName><![CDATA[" + ToUserName + "]]></ToUserName><FromUserName><![CDATA[" + corpId + "]]></FromUserName> <CreateTime>" + CreateTime + "</CreateTime> <MsgType><![CDATA[image]]></MsgType>" +
                                  "<image>" +
                                            " <MediaId><![CDATA[" + result + "]]></MediaId> " +
                                 "</image>" +
                              "</xml>";
            //string sRespData = "<xml><ToUserName><![CDATA[" + ToUserName + "]]></ToUserName><FromUserName><![CDATA[" + corpId + "]]></FromUserName><CreateTime>" + CreateTime + "</CreateTime><MsgType><![CDATA[image]]></MsgType><Image><MediaId><![CDATA[1bZcTUQBFAnXO3cISbLKejJctpZHH2QGFZvJ8VAsJ2je2tMY9PPkklUYHl9a6wVa5]]></MediaId></Image></xml>";
            int ret = new WXBizMsgCrypt(token, encodingAESKey, corpId).EncryptMsg(sRespData, timestamp, nonce, ref sEncryptMsg);
            data = sRespData;
            if (ret == 0)
            {
                return sEncryptMsg;
            }
            return sEncryptMsg;
        } 
        #endregion
        /// <summary>  
        /// 上传多媒体文件,返回 MediaId  
        /// </summary>  
        /// <param name="ACCESS_TOKEN"></param>  
        /// <param name="Type"></param>  
        /// <returns></returns>  
        public string UploadMultimedia(string ACCESS_TOKEN, string Type)
        {
            string result = "";
            string wxurl = "https://qyapi.weixin.qq.com/cgi-bin/material/add_material?access_token=" + ACCESS_TOKEN + "&type=" + Type;
            string filepath = System.Web.HttpContext.Current.Server.MapPath("wximage/1.jpg") ; //(本地服务器的地址)
            // WriteLog("上传路径:" + filepath);
            WebClient myWebClient = new WebClient();
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                byte[] responseArray = myWebClient.UploadFile(wxurl, "POST", filepath);
                result = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);
               // WriteLog("上传result:" + result);
                //UploadMM _mode = JsonHelper.ParseFromJson<UploadMM>(result);
                //result = _mode.media_id;
            }
            catch (Exception ex)
            {
                result = "Error:" + ex.Message;
            }
            //WriteLog("上传MediaId:" + result);
            return result;
        }
        #region 被动相应消息
        /// <summary>
        /// 被动相应消息
        /// </summary>
        /// <param name="ToUserName">接受人</param>
        /// <param name="CreateTime"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public string SendMsg(string ToUserName, int CreateTime, string Content)
        {
            string sEncryptMsg = "";
            string sRespData = "<xml> <ToUserName><![CDATA[" + ToUserName + "]]></ToUserName><FromUserName><![CDATA[" + corpId + "]]></FromUserName><CreateTime>" + CreateTime + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + Content + "]]></Content></xml>";
            int ret = new WXBizMsgCrypt(token, encodingAESKey, corpId).EncryptMsg(sRespData, timestamp, nonce, ref sEncryptMsg);
            if (ret == 0)
            {
                return sEncryptMsg;
            }
            return "";
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
        public void Subscribe(int flag,string userid)
        {
            try
            {
                string Token = WeixinQYAPI.GetToken(1);
                string url = "https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token=" + Token + "&userid=" + userid;
                string result = WeixinQYAPI.RequestUrl(url);
                string json = WeixinQYAPI.Json(result, "mobile");
                int results = sysUserDAL.Subscribe(flag, json);
            }
            catch (Exception ex)
            {
               FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", ex.Message, false);
            }

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