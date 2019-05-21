using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using GK.GKICMP.Entities;

namespace GK.GKICMP.Common
{
    public class ALiDaYu
    {
        /// <summary>
        /// 根据配置，读取不同短信api接口发送短信
        /// </summary>
        /// <param name="flag">短信运营商</param>
        /// <param name="type">短信类型</param>
        /// <param name="smsparam">短信类型</param>
        /// <param name="recnum">接收手机号</param>
        /// <returns>返回结果（成功与否）</returns>
        //public static string Message(int flag, int type, string smsparam, string recnum)
        //{
        //    string message = "";
        //    switch (flag)
        //    {
        //        case 1:
        //            if (type == 1) { message = SendMessage(smsparam, recnum); }
        //            else { message = SendMessageCode(smsparam, recnum); }
        //            break;
        //        case 2:
        //            if (type == 1) { message = SendMessage(smsparam, recnum); }
        //            else { message = SendMessageCode(smsparam, recnum); }
        //            break;
        //    }
        //    return message;

        //}
        /// <summary>
        /// 发送通知类短信
        /// </summary>
        /// <param name="smsparam">短信内容eg:{\"参数名\":\"短信内容\",\"参数名\":\"短信内容\"…}以json字符串的形式传递</param>
        /// <param name="recnum">接收短信号码，多个号码以‘,’隔开</param>
        /// <returns></returns>
        public static string SendMessage(string smsparam, string recnum)
        {
            string url = ConfigurationManager.AppSettings["url"];
            string appkey = ConfigurationManager.AppSettings["appkey"];
            string secret = ConfigurationManager.AppSettings["secret"];
            string SignName = ConfigurationManager.AppSettings["SignName"];
            string TempCodeT = ConfigurationManager.AppSettings["TempCodeT"];
            string TempCodeN = ConfigurationManager.AppSettings["TempCodeN"];
            //通知短信  


            ITopClient client = new DefaultTopClient(url, appkey, secret, "json");
            AlibabaAliqinFcSmsNumSendRequest req = new AlibabaAliqinFcSmsNumSendRequest();
            req.Extend = "";
            req.SmsType = "normal";
            // req.
            req.SmsFreeSignName = SignName;
            //req.SmsParam = "{\"name\":\"" + this.TextBox2.Text + "\",\"content\":\"" + this.TextBox3.Text + "\"}";
            req.SmsParam = smsparam;
            req.RecNum = recnum;
            req.SmsTemplateCode = TempCodeN;
            AlibabaAliqinFcSmsNumSendResponse rsp = client.Execute(req);
            if (!string.IsNullOrEmpty(rsp.ErrCode))
                return "发送短信错误，错误代码：" + rsp.ErrCode + "，" + rsp.SubErrCode + ",错误描述：" + rsp.SubErrMsg + "！";
            else                   
                return "已通知到相关人员！";
            //Console.WriteLine(rsp.Body);

        }
        public static string SendMessage(MessageConfigEntity model,string smsparam, string recnum)
        {
            //string url = ConfigurationManager.AppSettings["url"];
            //string appkey = ConfigurationManager.AppSettings["appkey"];
            //string secret = ConfigurationManager.AppSettings["secret"];
            //string SignName = ConfigurationManager.AppSettings["SignName"];
            //string TempCodeT = ConfigurationManager.AppSettings["TempCodeT"];
            //string TempCodeN = ConfigurationManager.AppSettings["TempCodeN"];
            //通知短信  

            ITopClient client = new DefaultTopClient(model.Url, model.AppKey, model.Secret, "json");
            AlibabaAliqinFcSmsNumSendRequest req = new AlibabaAliqinFcSmsNumSendRequest();
            req.Extend = "";
            req.SmsType = "normal";
            // req.
            req.SmsFreeSignName =model.SingName;
            //req.SmsParam = "{\"name\":\"" + this.TextBox2.Text + "\",\"content\":\"" + this.TextBox3.Text + "\"}";
            req.SmsParam = smsparam;
            req.RecNum = recnum;
            req.SmsTemplateCode =model.TempCode;
            AlibabaAliqinFcSmsNumSendResponse rsp = client.Execute(req);
            if (!string.IsNullOrEmpty(rsp.ErrCode))
                return "发送短信错误，错误代码：" + rsp.ErrCode + "，" + rsp.SubErrCode + ",错误描述：" + rsp.SubErrMsg + "！";
            else
                return "已通知到相关人员！";
            //Console.WriteLine(rsp.Body);

        }
        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="code">验证码eg:{\"参数名\":\"短信内容\",\"参数名\":\"短信内容\"…}以json字符串的形式传递</param>
        /// <param name="recnum">接收短信号码，多个号码以‘,’隔开</param>
        /// <returns></returns>
        public static string SendMessageCode(MessageConfigEntity model, string code, string recnum)
        {
            //string url = ConfigurationManager.AppSettings["url"];
            //string appkey = ConfigurationManager.AppSettings["appkey"];
            //string secret = ConfigurationManager.AppSettings["secret"];
            //string SignName = ConfigurationManager.AppSettings["SignName"];
            //string TempCodeT = ConfigurationManager.AppSettings["TempCodeT"];
            //string TempCodeN = ConfigurationManager.AppSettings["TempCodeN"];
            //通知短信

            //ITopClient client = new DefaultTopClient(model.Url, model.AppKey, model.Secret, "json");
            //AlibabaAliqinFcSmsNumSendRequest req = new AlibabaAliqinFcSmsNumSendRequest();
            //req.Extend = "";
            //req.SmsType = "normal";
            //// req.
            //req.SmsFreeSignName = SignName;
            ////req.SmsParam = "{\"name\":\"" + this.TextBox2.Text + "\",\"eg\":\"" + this.TextBox3.Text + "\"}";
            //req.SmsParam = code;
            //req.RecNum = recnum;
            //req.SmsTemplateCode = TempCodeT;
            //AlibabaAliqinFcSmsNumSendResponse rsp = client.Execute(req);
            //if (!string.IsNullOrEmpty(rsp.ErrCode))
            //    return "发送短信错误，错误代码：" + rsp.ErrCode + "，" + rsp.SubErrCode + ",错误描述：" + rsp.SubErrMsg + "！";
            //else
            //    return "短信发送成功！";
            //Console.WriteLine(rsp.Body);
            return "";
        }
    }
}
