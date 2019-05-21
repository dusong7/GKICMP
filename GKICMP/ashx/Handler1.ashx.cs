using Baidu.Aip.Speech;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Web;

namespace GKICMP.ashx
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string text =HttpUtility.UrlDecode( context.Request.Params["text"]);
            string type = HttpUtility.UrlDecode(context.Request.Params["type"]);
            context.Response.ContentType = "audio/mp3";
            Tts _ttsClient = new Tts("zBoqwIjlyXPT1cKeWxEYwnfg", "j99fGL2teCGk9QTaXfjY6McstdF51dvY");
            var option = new Dictionary<string, object>()
            {
                {"spd", 5}, // 语速
                {"vol", 7}, // 音量
                {"per", int.Parse(type)}  // 发音人，4：情感度丫丫童声
            };
            var result = _ttsClient.Synthesis(text, option);
            if (result.ErrorCode == 0)  // 或 result.Success
            {
                string pah = System.Web.HttpContext.Current.Server.MapPath("~/1.mp3");
                File.WriteAllBytes(pah, result.Data);
            }
            context.Response.TransmitFile("~/1.mp3");
            //speechSyn.Volume = 100;
            //speechSyn.Rate = 0;
           //s  string b=a();
            //context.Response.AddHeader("Content-Disposition", "attachment;filename=合成的语音文件本地存储地址.mp3");
            
            //Tts _ttsClient = new Tts("zBoqwIjlyXPT1cKeWxEYwnfg", "j99fGL2teCGk9QTaXfjY6McstdF51dvY");
            //var option = new Dictionary<string, object>()
            //{
            //    {"spd", 5}, // 语速
            //    {"vol", 7}, // 音量
            //  //  {"per", 4}  // 发音人，4：情感度丫丫童声
            //};
            //var result = _ttsClient.Synthesis("众里寻他千百度", option);
            //byte[] b= result.Data;
            //MemoryStream ms = new MemoryStream(b);
            //ms.Write(b,0,ms.Length);
            //if (result.ErrorCode == 0)  // 或 result.Success
            //{
            //    string pah = Server.MapPath("~/合成的语音文件本地存储地址.mp3");
            //    File.WriteAllBytes(pah, result.Data);
            //}
            //context.Response
            //context.Response.Clear();
            //context.Response.Write("2333");
            ////context.Response.Write("<audio controls='controls' src='../voice/123.mp3' >你的浏览器不支持audio标签</audio>");
            //context.Response.End();
        }
        public string  a()
        {
            SpeechSynthesizer speechSyn = new SpeechSynthesizer();
            speechSyn.SetOutputToWaveFile("~/Record.mp3");
            speechSyn.Speak("hello world");
            speechSyn.SetOutputToDefaultAudioDevice();
            speechSyn.Dispose();
            return "~/Record.mp3";
            
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