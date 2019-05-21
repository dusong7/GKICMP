/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月08日 09点30分
** 描   述:       通知公告详情页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;

namespace GKICMP.cms
{
    public partial class SendNews : PageBase
    {
        public Web_NewsDAL newsDAL = new Web_NewsDAL();
        #region 参数集合
        public string NID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = HttpContext.Current.Request.Url.AbsolutePath;
                BindInfo();
              //  SendMsg(sb.ToString());
            }
        }
        #region 初始化用户数据
        private void BindInfo() 
        {
            //Web_NewsEntity model = newsDAL.GetObjByID(NID);
            //if (model != null)
            //{
            //    List<string> a=getimgurl(model.NContent);
            //    if (a.Count > 0)
            //    {
            //        this.Img.ImageUrl = a[0];
            //    }
            //    else
            //        this.Img.ImageUrl = "~/images/lgbg.png";
            //    this.lbl_Title.Text = model.NewsTitle;
            //    string content = CommonFunction.xxHTML(model.NContent);
            //    this.lbl_Description.Text = content.Length > 20 ? content.Substring(0, 20) : content;
            //    //this.bg.Attributes.Add("","this.style.backgroundColor='red'");
            //}
        }
        #endregion
        public List<string> getimgurl(string html)
        {
            List<string> resultStr = new List<string>();
            Regex r = new Regex(@"<IMG[^>] src=s*(?:´(?<src>[^´] )´|""(?<src>[^""] )""|(?<src>[^>s] ))s*[^>]*>", RegexOptions.IgnoreCase);//忽视大小写
            MatchCollection mc = r.Matches(html);

            foreach (Match m in mc)
            {
                resultStr.Add(m.Groups["src"].Value.ToLower());
            }
            if (resultStr.Count > 0)
            {
                return resultStr;
            }
            else
            {
                resultStr.Clear();
                return resultStr;
            }
        }
        public string News()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("           {");
            sb.Append("               \"title\": \"芜湖高科电子-测试图文消息\",");
            sb.Append("               \"description\": \"图文消息发送\",");
            sb.Append("               \"url\": \"http://whmhyghd.whsedu.cn/phone/Article/12\",");
            sb.Append("               \"picurl\": \"http://whmhyghd.whsedu.cn/yghd/images/lgbg.png\"");
            sb.Append("           },");
            sb.Append("           {");
            sb.Append("               \"title\": \"芜湖高科电子-消息\",");
            sb.Append("               \"description\": \"图文发送\",");
            sb.Append("               \"url\": \"http://whmhyghd.whsedu.cn/phone/Article/50\",");
            sb.Append("               \"picurl\": \"http://whmhyghd.whsedu.cn/yghd/images/lgbg.png\"");
            sb.Append("           },");
            sb.Append("           {");
            sb.Append("               \"title\": \"芜湖高科电子-图文消息\",");
            sb.Append("               \"description\": \"图文消息\",");
            sb.Append("               \"url\": \"http://whmhyghd.whsedu.cn/phone/Article/19\",");
            sb.Append("               \"picurl\": \"http://whmhyghd.whsedu.cn/yghd/images/lgbg.png\"");
            sb.Append("           },");
            sb.Append("           {");
            sb.Append("               \"title\": \"芜湖高科电子-图文\",");
            sb.Append("               \"description\": \"消息发送\",");
            sb.Append("               \"url\": \"http://whmhyghd.whsedu.cn/phone/Article/16\",");
            sb.Append("               \"picurl\": \"http://whmhyghd.whsedu.cn/yghd/images/lgbg.png\"");
            sb.Append("           },");
            return sb.ToString();
        }
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("           {");
            sb.Append("               \"title\": \"测试图文消息\",");
            sb.Append("               \"description\": \"id\",");
            sb.Append("               \"url\": \"芜湖高科电子有限公司\",");
            sb.Append("               \"picurl\": \"http://www.whgkdz.com\",");
            sb.Append("           },");
            string result = SendMsg(sb.ToString());
            ShowMessage(result);
        }
        public string SendMsg(string content)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Notice", 1);
            if (model1.IsOpen == 1)
            {
                string token = WeixinQYAPI.GetToken(1, "Notice");
                //string json = "{\"touser\":\"@all\",\"msgtype\":\"mpnews\",\"agentid\":\"" + model1.Agent + "\",\"text\":{\"content\":\"" + content + "\"},\"safe\":0}";
                sb.Append("{\"touser\": \"123999999\",");
                sb.Append("   \"msgtype\": \"news\",");
                sb.Append("   \"agentid\": " + model1.Agent+ ",");
                sb.Append("   \"news\": {");
                sb.Append("       \"articles\":[");
                sb.Append(content);
                sb.Append("       ]");
                sb.Append("   },");
                sb.Append("   \"safe\":0}");
                string msg = WeixinQYAPI.Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", token), sb.ToString());
                if (WeixinQYAPI.Json(msg, "errmsg") == "ok")
                {
                    result = "微信消息发送成功";
                }
                else
                {
                    result = "微信消息发送失败";
                }

            }
            return result;
        }
    }
}