using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace GKICMP.test
{
    public partial class Test : System.Web.UI.Page
    {
        public string Code 
        {
            get { return (Request.QueryString["code"]== null ? string.Empty : Request.QueryString["code"].ToString()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {

                string url = "http://www.hzrjdms.com:8080/?sqm=dfklwep&type=tran_value_json&key=dm&dm=362330197203172073&xsorgm=05&outlen=1";
                string s = WeixinQYAPI.RequestUrl(url);
                //VideoThumbnail.ConvertImage("~/webupload/NetworkTeac/2017112010423972670.mp4", "~/webupload/ThumbImage","123.png","80*80");
                //string a = CommonFunction.Decrypt("F344687AD3E2130E");
                //int a = ("doc,docx,xls,xlsx,ppt").IndexOf("xls00");
                //string a = CommonFunction.Decrypt("5791C95907BF9DCC");
                //System.Diagnostics.Process.Start(@"IExplore.exe", "http://localhost:4294/test/OnlineEdit.aspx");  
                #region 水印测试
                // WaterMark.InsertExcelWatermarkPic("~/1.xls", "~/Mark/m4.xls", "~/images/zy_2.png");
                //WaterMark.InsertWordWatermarkPic("~/1.doc", "~/Mark/m1.doc", "~/images/zy_2.png");
                //WaterMark.InsertWordWatermarkText("~/1.doc", "~/Mark/m2.doc", "ceshi");
                //WaterMark.AddImageSignPic("~/wximage/1.jpg", "~/Mark/m1.jpg", "~/images/zy_2.png", 9, 50, 3);
                //WaterMark.AddImageSignText("~/wximage/1.jpg", "~/Mark/m2.jpg", "高科电子", 9, 50, "宋体", 100); 
                #endregion
                #region 测
                //string a = CommonFunction.Decrypt("EDCE72F4BE46830D2FE3E44606837215A0E10CCF649B6645");
                //SendMsg("", "13365539539");
                //string a= Face.CreateFaceSet("演示", "演示");
                //string a = "1990.07";

                //DateTime dt = Convert.ToDateTime(a);

                //Split("http://www.huiemall.com/mall/wuhu/info.aspx?Type=Zhao&RowGuid=47cb7119-6fe1-48c1-9c5d-626e3a740566http://www.huiemall.com/mall/wuhu/info.aspx?Type=Zhao&RowGuid=00736145-e0da-4ee6-86e7-e7700410b776http://www.huiemall.com/mall/wuhu/info.aspx?Type=Zhao&RowGuid=b997ac43-c6b7-4f7c-9112-2af66795e83chttp://www.huiemall.com/mall/wuhu/info.aspx?Type=Zhao&RowGuid=a59d1ec7-63ea-44a1-a7c3-ff9eef5317achttp://www.huiemall.com/mall/wuhu/info.aspx?Type=Zhao&RowGuid=5b1aec69-325c-4204-82de-de7909bbdb14http://www.huiemall.com/mall/wuhu/info.aspx?Type=Zhao&RowGuid=7f70bd1d-bd9f-4834-a3c2-869d945cb4bahttp://www.huiemall.com/mall/wuhu/info.aspx?Type=Zhao&RowGuid=71afba3f-354a-45a4-b276-96992dc12ccfhttp://www.huiemall.com/mall/wuhu/info.aspx?Type=Zhao&RowGuid=6235503b-2324-4a17-9789-70748959d40a");

                //Thread newThr = new Thread(new ThreadStart(handleProcess_Thread));
                //newThr.IsBackground = true;
                //newThr.Start();
                //int q= Convert.ToInt32(Enum.Parse(typeof(CommonEnum.AttendType), "11n"));
                //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('"+q+"');", true);
                //string url = XMLHelper.GetNodes("~/QYWX.xml", "WX/Url[@name=\"Main\"]");
                //string access_token = WeixinQYAPI.GetToken(2, "Repair");
                //string a = XMLHelper.GetXmlNodesValue("~/QYWX.xml", "/WX/Agent/CorpID");
                // string b = XMLHelper.GetXmlNodesAttributes("~/BaseInfoSet.xml", "DX", "IsOpen");
                // string text = System.IO.File.ReadAllText(@"d:\11.txt");
                //// Console.WriteLine(text);

                // //按行读取为字符串数组
                // string[] lines = System.IO.File.ReadAllLines(@"d:\11.txt");
                // foreach (string line in lines)
                // {
                //     //Console.WriteLine(line);
                // }

                // //从头到尾以流的方式读出文本文件
                // //该方法会一行一行读出文本
                // using (System.IO.StreamReader sr = new System.IO.StreamReader(@"d:\11.txt"))
                // {
                //     string str;
                //     while ((str = sr.ReadLine()) != null)
                //     {
                //         //Console.WriteLine(str);
                //     }
                // }
                // Console.Read();

                //if (!string.IsNullOrEmpty(Code))
                //{
                //    string url = "http://localhost:6511/ashx/Login.ashx?code=" + Code;
                //    string userinfo = WeixinQYAPI.RequestUrl(url);
                //}
                //else { GetCode(); } 
                #endregion
            }
            //string result = GetUser();
            //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('"+result+"');", true);
            //Response.Write(result);
            //string cellphone = WeixinQYAPI.GetUser("YWmZBkkWoC420NHUOUDAjM9GpWH7Gu1t1ZH4ntsSZs0zU7LFpHPoh3yfbCxG9b39Q5gnJE6EFhC4CtGmN7elBlQu8sIm-3oFU3NcEhj1Xj70QwkBt2mCxbah9rmCPeCSsZ03UnDaSwWsyankmyR-PKE-L6JTykl2uhcT2eLpoAxTNF4IviP8WbCCsniIUyJY2be7nvlOECHoE536WZopJS05LVq5K4RFx8GkLmlf6D6o96PwVTXgVXFRf0SjSWYGxWYckNbsZgAuRUXCuCdXfffSOtK4lfdddRW9ZBlH-Ns", "123999999");
            //try
            //{
            //    //int week = CommonFunction.Weeks(DateTime.Now, "~/BaseInfoSet.xml", "TFristDate");
            //    //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('"+week+"');", true);
            //    string token = WeixinQYAPI.GetToken(1);
            //    string a = WeixinQYAPI.SendMessage(token, "@all", "1000004", "测试消息");
            //    //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('" + a + "');", true);
            //    //if (XMLHelper.CreateXmlDocument(Server.MapPath("/xml/config.xml"), "Config", "1.0", "utf-8", "no"))
            //    //{
            //    //    XMLHelper.CreateOrUpdateXmlNodeByXPath(Server.MapPath("/xml/config.xml"), "//Config//ALiDaYu", "URL", "123456");
            //    //}

            //    //XMLHelper.GetXmlNodeListByXpath("", "");
            //    //SysUserEntity model = new SysUserDAL().GetObjByID("18226530705", "123999999");
            //    //if (model != null)
            //    //{
            //    //    Response.Cookies["UserID"].Value = model.UID.ToString();
            //    //    Response.Cookies["SysUserName"].Value = model.UserName;
            //    //    Response.Cookies["UserRealName"].Value = HttpUtility.UrlEncode(model.RealName, Encoding.GetEncoding("UTF-8"));
            //    //    Response.Cookies["SysUserPwd"].Value = model.UserPwd;
            //    //    //Response.Cookies["CssFlag"].Value = model.Skin.ToString();
            //    //    //Response.Cookies["DepType"].Value = model.DepType.ToString();
            //    //    //Response.Cookies["DepID"].Value = model.DepIDs;
            //    //    //Response.Cookies["DepIDName"].Value = HttpUtility.UrlEncode(model.DepName, Encoding.GetEncoding("UTF-8"));
            //    //    Response.Redirect("APPMain.aspx");
            //    //}
            //    //else
            //    //{
            //    //    Response.Redirect("Test.html");
            //    //    //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('暂无帐号信息，请联系管理员');", true);
            //    //}
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
        public  string SendMsg(string content, string touser)
        {
            MessageConfigEntity msmodel = new MessageConfigDAL().GetObjByID("政务通知");
            return ALiDaYu.SendMessage(msmodel, content, touser);
        }
        public void Split(string kk)
        {
            List<string> list = new List<string>();
            while (kk.Length >1)
            {
                string a = kk.Substring(kk.LastIndexOf("http"), kk.Length - kk.LastIndexOf("http"));
                if (a == "")
                {
                    list.Add(kk);
                    kk = kk.Remove(0,kk.Length-1);
                }
                else
                {
                    list.Add(a);
                    kk = kk.Remove(kk.LastIndexOf("http"), kk.Length - kk.LastIndexOf("http"));
                }

            }
        }
        private void handleProcess_Thread() //多线程调用
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();


            synth.Speak(this.TextBox1.Text == "" ? "Hello, world! 你好么？" : this.TextBox1.Text);

            synth.Dispose();

            //Type type = Type.GetTypeFromProgID("SAPI.SpVoice");

            //dynamic spVoice = Activator.CreateInstance(type);

            //spVoice.Speak("你好,欢迎使用 English 播报系统。这里是测试内容。");

        }
        public void GetCode() 
        {
            string url = "http://localhost:6511/LOGIN/Login.aspx?Token=12&redirect_uri= "+ Server.UrlEncode("http://localhost:4294/test/test.aspx");
            Response.Redirect(url,true);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Thread newThr = new Thread(new ThreadStart(handleProcess_Thread));
            newThr.IsBackground = true;
            newThr.Start();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CommonFunction.upfileTest(0, 1, this.hf_UpFile,"TEST");
        }
        //public string GetUser()
        //{
            
        //}

        /// <summary>
        /// Convert Byte[] to Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static System.Drawing.Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        /// <summary>
        /// Convert Byte[] to a picture and Store it in file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string CreateImageFromBytes(string fileName, byte[] buffer)
        {
            string file = fileName;
            System.Drawing.Image image = BytesToImage(buffer);
            ImageFormat format = image.RawFormat;
            if (format.Equals(ImageFormat.Jpeg))
            {
                file += ".jpeg";
            }
            else if (format.Equals(ImageFormat.Png))
            {
                file += ".png";
            }
            else if (format.Equals(ImageFormat.Bmp))
            {
                file += ".bmp";
            }
            else if (format.Equals(ImageFormat.Gif))
            {
                file += ".gif";
            }
            else if (format.Equals(ImageFormat.Icon))
            {
                file += ".icon";
            }
            System.IO.FileInfo info = new System.IO.FileInfo(file);
            System.IO.Directory.CreateDirectory(info.Directory.FullName);
            File.WriteAllBytes(file, buffer);
            return file;
        }
        /// <summary>
        /// 壓縮圖片 /// </summary>
        /// <param name="fileStream">圖片流</param>
        /// <param name="quality">壓縮質量0-100之間 數值越大質量越高</param>
        /// <returns></returns>
        private byte[] CompressionImage(Stream fileStream, long quality)
        {
            using (System.Drawing.Image img = System.Drawing.Image.FromStream(fileStream))
            {
                using (Bitmap bitmap = new Bitmap(img))
                {
                    ImageCodecInfo CodecInfo = GetEncoder(img.RawFormat);
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, CodecInfo, myEncoderParameters);
                        myEncoderParameters.Dispose();
                        myEncoderParameter.Dispose();
                        return ms.ToArray();
                    }
                }
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                { return codec; }
            }
            return null;
        }
    }
}