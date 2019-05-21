using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.test
{
    public partial class OnlineEdit : System.Web.UI.Page
    {
        //[DllImport("../ActiveX/DSOframer/dsoframer.ocx", EntryPoint = "DllRegisterServer")]
        //public static extern int DllRegisterServer1();//注册时用
        //[DllImport("../ActiveX/WebFileHelper2.dll", EntryPoint = "DllRegisterServer")]
        //public static extern int DllRegisterServer2();//注册时用

        protected string Path 
        {
            get { return Request.QueryString["ID"] != null ? Request.QueryString["ID"].Replace('\\', '/') : ""; }
        }
        protected string DocUrl
        {
            get { return "http://" + Request.Url.Authority + Url().Replace('\\','/'); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //int a=  DllRegisterServer1();
            //int b=DllRegisterServer2();
            //if (!IsPostBack) return;
            string url = ""; string path = "";
            //if (!IsPostBack)
            //{
            //    url = Request.Url.ToString();
            //    path = Request.QueryString["ID"] != null ? Request.QueryString["ID"] : "";
            //}
            if (Request.InputStream.Length <= 0) return;
            using (var stream = Request.InputStream)
            {
                url = Request.Url.ToString();
                path = Request.QueryString["ID"] != null ? Request.QueryString["ID"] : "";
               if (path == "") { return; }
               using (var fs = new FileStream(Server.MapPath("~" + path), FileMode.Create))
                {
                    int readCount;
                    var buffer = new byte[1024];
                    while ((readCount = stream.Read(buffer, 0, 1024)) > 0)
                        fs.Write(buffer, 0, readCount);
                    fs.Flush();
                }
            }

        }
        
        //[DllImport("../ActiveX/DSOframer/dsoframer.ocx")]
        //public static extern int DllRegisterServer();//注册时用
        public string Url() 
        {
            return Server.UrlDecode(Path);
        }
    }
}