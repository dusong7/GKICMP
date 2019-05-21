using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GK.GKICMP.Common;
using System.Text;
using GK.GKICMP.Entities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Configuration;
using GK.GKICMP.DAL;

namespace GKICMP.ashx
{
    /// <summary>
    /// NewsSend 的摘要说明
    /// </summary>
    public class NewsSend : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "send":
                    AddPost(context);
                    break;
            }
        }
        private void AddPost(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
           
            var newslist = context.Request.Params["newslist"];
            string result = "";
          
            JArray list = (JArray)JsonConvert.DeserializeObject(newslist);
            if (list.Count > 0)
            {
                string content = "";
                string a = "";
                string imgurl = "";
                string url = context.Request.UrlReferrer.Authority;
                foreach (JObject job in list)
                {
                    imgurl = "http://" + job["url"].ToString();
                    content += "{\"title\": \"" + "【" + ConfigurationManager.AppSettings["SchoolName"] + "】"  + job["title"] + "\", \"description\": \"" + job["desc"] + "\",\"url\": \"" + url + "/phone/Article?id=" + job["id"] + "\", \"picurl\":\"" + imgurl + "\"},";

                    //content += "{\"title\": \"" + ConfigurationManager.AppSettings["SchoolName"] + "--" + job["title"] + "\", \"description\": \"" + job["desc"] + "\",\"url\": \"" + url + "/phone/Article?id=" + job["id"] + "\", \"picurl\":\"" +  job["url"] + "\"},";
                    //a = job["url"].ToString();
                }
                sb.Append(content.TrimEnd(','));
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, imgurl, ""));
                string newssend = SendMsg(sb.ToString());
                if (newssend == "true")
                    result = "{\"result\":true}";
                else
                    result = "{\"result\":\"" + newssend + "\"}";
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, result, ""));
            }
            context.Response.Clear();
            context.Response.Write(result);
            context.Response.End();
        }
        public string SendMsg(string content)
        {
            string result = "";
            try
            {
              
                StringBuilder sb = new StringBuilder();
                WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "News", 1);
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, model1.IsOpen.ToString(), ""));
                if (model1.IsOpen == 1)
                {
                    string token = WeixinQYAPI.GetToken(1, "News");
                    //string json = "{\"touser\":\"@all\",\"msgtype\":\"mpnews\",\"agentid\":\"" + model1.Agent + "\",\"text\":{\"content\":\"" + content + "\"},\"safe\":0}";
                    sb.Append("{\"touser\": \"@all\",");
                    sb.Append("   \"msgtype\": \"news\",");
                    sb.Append("   \"agentid\": " + model1.Agent + ",");
                    sb.Append("   \"news\": {");
                    sb.Append("       \"articles\":[");
                    sb.Append(content);
                    sb.Append("       ]");
                    sb.Append("   },");
                    sb.Append("   \"safe\":0}");
                    string msg = WeixinQYAPI.Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", token), sb.ToString());
                    new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, msg, ""));
                    if (WeixinQYAPI.Json(msg, "errmsg") == "ok")
                    {
                        result = "success";
                    }
                    else
                    {
                        result = "error";
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                
                result=ex.Message;
            }
            return result;
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