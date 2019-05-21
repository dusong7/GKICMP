using GK.GKICMP.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP
{
    public partial class Test : System.Web.UI.Page
    {
        public string Url = HttpContext.Current.Request.Url.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            GK.GKICMP.Common.FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", "222", false);
        }
        public string GetHTML(string url, string encoding)
        {
            WebClient web = new WebClient();

            byte[] buffer = web.DownloadData(url);

            return Encoding.GetEncoding(encoding).GetString(buffer);
        }
        public void Content()
        {


            //得到指定页面的html代码，第一个参数为url(貌似都知道),第二个是目标网页的编码集

            string htmlCode = GetHTML(this.txt_URL.Text, "utf-8");

            //正则表达式

            //Regex regexarticles = new Regex("<td\\s+height=\"\\d+\"><a\\s+href=\".+DataId=(?<id>\\d+)\"\\s+target=\"_blank\">(?<title>.+)</a>.*</td>");
            Regex regexarticles = new Regex("<a(\\s+(href=\"(?<url>([^\"])*)\"|'([^'])*'|\\w+=\"(([^\"])*)\"|'([^'])*'))+>(?<text>(.*?))</a>");

            //所有匹配表达式的内容

            MatchCollection marticles = regexarticles.Matches(htmlCode);

            ///遍历匹配内容

            foreach (Match m in marticles)
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("====================================");
                sb.AppendFormat("{0}Time：{1}{0}", Environment.NewLine, DateTime.Now.ToString());
                sb.Append("===================================="); sb.Append(Environment.NewLine);
                sb.AppendFormat("标题：{0}{1}", Environment.NewLine, m.Groups["url"].Value);
                // sb.AppendFormat("id：{0}", Environment.NewLine, m.Groups["span"].Value);
                sb.Append(Environment.NewLine + Environment.NewLine);
                CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/log/"), "SysLog.txt", sb.ToString(), false);
                //Console.Write("标题:" + m.Groups["title"].Value + "\n");

                //Console.Write("id:" + m.Groups["id"].Value + "\n");

                //Console.Write("\n");

            }
        }

        /// <summary>
        /// 如果路径不存在即创建这个路径
        /// </summary>
        /// <param name="folder"></param>
        public static void MakeWhenFolderNotExist(String folder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            if (directoryInfo.Exists == false)
            {
                directoryInfo.Create();
            }
        }
        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsFileExist(String filePath)
        {
            return File.Exists(filePath);
        }
        /// <summary>
        /// 删除指定的文件
        /// </summary>
        /// <param name="filePath"></param>
        public static void DeleteFile(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
        /// <summary>
        /// 如果文件不存在即创建这个文件
        /// </summary>
        /// <param name="filePath"></param>
        public static void MakeWhenFileNotExist(String filePath)
        {
            if (!File.Exists(filePath))
            {
                FileStream f = File.Create(filePath);
                f.Close();
            }
        }
        /// <summary>
        /// 删除指定的文件
        /// </summary>
        /// <param name="root"></param>
        /// <param name="file"></param>
        public static void DeleteFile(String root, String file)
        {
            DeleteFile(root + "\\" + file);
        }
        /// <summary>
        /// 按照指定的路径信息、文件名称以及内容创建文件
        /// </summary>
        /// <param name="pathInfo">路径信息</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="content">文件内容</param>
        /// <param name="deleteExistFile">是否删除已经存在的文件</param>
        public static void CreateFileWithContent(string pathInfo, string fileName, string content, bool deleteExistFile)
        {
            MakeWhenFolderNotExist(pathInfo);

            string path = pathInfo.TrimEnd('/').TrimEnd('\\') + "/" + fileName;

            if (IsFileExist(path) && deleteExistFile)
            {
                DeleteFile(path);
            }

            MakeWhenFileNotExist(path);

            StreamWriter sw = File.AppendText(path);
            sw.Write(content);
            sw.Flush();
            sw.Close();
        }

        protected void btn_Serach_Click(object sender, EventArgs e)
        {
            Content();
        }

        protected void btn_DownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string expath = @"~\ActiveX\DSOframer\dsoframer.ocx";
                if (!CommonFunction.UpLoadFunciotn(expath, "dsoframer"))
                {
                    Response.Write("文件不存在，请联系系统管理员");
                    return;
                }
                string filePath = "D:\\TempDB.bat";
                string ocxstr = "regsvr32 " + Server.MapPath("~/ActiveX/DSOframer/dsoframer.ocx");
                string dllstr = "regsvr32 " + Server.MapPath("~/ActiveX/WebFileHelper2.dll");
                File.WriteAllText(filePath, ocxstr + Environment.NewLine + dllstr, Encoding.GetEncoding("utf-8"));
                Response.Write("下载成功，请至D盘运行文件TempDB.bat");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return;
            }
        }
    }
}