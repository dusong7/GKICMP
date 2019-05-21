using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace GKICMP.ashx
{
    /// <summary>
    /// file 的摘要说明
    /// </summary>
    public class file : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string Content = context.Request.Form["imgBase64"];
            string Name = context.Request.Form["Name"];
           // Content = Content.Replace("%2B", "+");
            string[] a = Content.Split(',');
            byte[] arr = Convert.FromBase64String(a[1]);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999) + ".jpeg";
            //string filename = Name + ".jpeg";
            string fileserverpath = "/webupload/FileBox/"; 
            string fullpath = fileserverpath + filename;
            string filePath = System.Web.HttpContext.Current.Server.MapPath(fileserverpath);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            bmp.Save(filePath + filename, ImageFormat.Jpeg);
            context.Response.Clear();
            context.Response.Write("{\"path\":\"" + fullpath + "\"}");
            context.Response.End();
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