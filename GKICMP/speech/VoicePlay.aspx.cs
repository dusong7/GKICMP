using Baidu.Aip.Speech;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.speech
{

    public partial class VoicePlay : PageBase
    {
        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // Speech();
                //Thread newThr = new Thread(new ThreadStart(handleProcess_Thread));
                //newThr.IsBackground = true;
                //newThr.Start();
            }
        }
        private void handleProcess_Thread() //多线程调用
        {

            // SpeechVoiceSpeakFlags flag = SpeechVoiceSpeakFlags.SVSFlagsAsync;
            //SpVoice voice = new SpVoice();
            //voice.Speak(this.txt_Content.Text == "" ? "Hello, world!" : this.txt_Content.Text);
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            ////synth.Volume = 100;
            //synth.Rate = 0;
            ////synth.SelectVoice("VW Lily");
            //synth.Speak(this.txt_Content.Text == "" ? "Hello, world!" : this.txt_Content.Text);

            //synth.Dispose();

            //Type type = Type.GetTypeFromProgID("SAPI.SpVoice");

            //dynamic spVoice = Activator.CreateInstance(type);

            //spVoice.Speak("你好,欢迎使用 English 播报系统。这里是测试内容。");

        }
        public void Speech(string path) 
        {
            //Tts _ttsClient = new Tts("zBoqwIjlyXPT1cKeWxEYwnfg", "j99fGL2teCGk9QTaXfjY6McstdF51dvY");
            //var option = new Dictionary<string, object>()
            //{
            //    {"spd", 5}, // 语速
            //    {"vol", 7}, // 音量
            //  //  {"per", 4}  // 发音人，4：情感度丫丫童声
            //};
            //var result = _ttsClient.Synthesis(this.txt_Content.Text==""?"Hello World":this.txt_Content.Text, option);

            //if (result.ErrorCode == 0)  // 或 result.Success
            //{
            //    string pah = Server.MapPath("~/1.mp3");
            //    File.WriteAllBytes(pah, result.Data);
               
            //}
            new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, Server.MapPath(path), UserID));
            //new MCI().Play(AppDomain.CurrentDomain.BaseDirectory + "\voice\voice.mp3", 1); 
            new MCI().Play(Server.MapPath(path), 1);
        }
        
        protected void txt_Content_TextChanged(object sender, EventArgs e)
        {
           // Speech("~/voice/voice.mp3");

            //Thread newThr = new Thread(new ThreadStart(handleProcess_Thread));
            //newThr.IsBackground = true;
            //newThr.Start();
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Tts _ttsClient = new Tts("zBoqwIjlyXPT1cKeWxEYwnfg", "j99fGL2teCGk9QTaXfjY6McstdF51dvY");
                var option = new Dictionary<string, object>()
                {
                   {"spd", 5}, // 语速
                    {"vol", 7}, // 音量
                {"per", int.Parse(this.ddl_Select.SelectedValue)}  // 发音人，4：情感度丫丫童声
                 };
                var result = _ttsClient.Synthesis(this.txt_Content.Text == "" ? "Hello World" : this.txt_Content.Text, option);

                if (result.ErrorCode == 0)  // 或 result.Success
                {
                    string pah = Server.MapPath("~/voice/voice.mp3");
                    File.WriteAllBytes(pah, result.Data);
                }
                Speech("~/voice/voice.mp3");
            }
            catch (Exception ex)
            {
                ShowMessage("请等待播放完毕");
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }

        protected void btn_Try_Click(object sender, EventArgs e)
        {
            try
            {
                Tts _ttsClient = new Tts("zBoqwIjlyXPT1cKeWxEYwnfg", "j99fGL2teCGk9QTaXfjY6McstdF51dvY");
                var option = new Dictionary<string, object>()
                {
                   {"spd", 5}, // 语速
                    {"vol", 7}, // 音量
                {"per", int.Parse(this.ddl_Select.SelectedValue)}  // 发音人，4：情感度丫丫童声
                 };
                var result = _ttsClient.Synthesis(this.txt_Content.Text == "" ? "Hello World" : this.txt_Content.Text, option);

                if (result.ErrorCode == 0)  // 或 result.Success
                {
                    string pah = Server.MapPath("~/voice/voice.mp3");
                    File.WriteAllBytes(pah, result.Data);
                }
                Speech("~/voice/voice.mp3");
            }
            catch (Exception ex)
            {
                ShowMessage("请等待播放完毕");
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
    }
}