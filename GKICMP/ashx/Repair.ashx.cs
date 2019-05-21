using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;
using System.Data;
using System.IO;

namespace GKICMP.ashx
{
    /// <summary>
    /// Repair 的摘要说明
    /// </summary>
    public class Repair : IHttpHandler
    {
        public Asset_RepairDAL asset_RepairDAL = new Asset_RepairDAL();
        public void ProcessRequest(HttpContext context)
        {
            string path=context.Request.Params["path"];
                string filekind = Path.GetExtension(path);
                string name = "444" + filekind;
                //提供下载的文件并且编码
                string fileName = HttpContext.Current.Server.UrlEncode(name);
                fileName = fileName.Replace("+", "%20");
                string filePath =CommonFunction.GetMapPath(path);
                context.Response.Buffer = true;
                context.Response.Clear();
                context.Response.ContentType = "application/download";
               // string downFile = System.IO.Path.GetFileName(filename);//这里也可以随便取名
                string EncodeFileName = HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);//防止中文出现乱码
                context.Response.AddHeader("Content-Disposition", "attachment;filename=" + EncodeFileName + ";");
                context.Response.WriteFile(filePath);//返回文件数据给客户端下载
                context.Response.Flush();
                context.Response.End();
            //string method = context.Request.Params["method"];
            //switch (method)
            //{
            //    case "detail":
            //        Detail(context);
            //        break;
               
            //}
        }
        public void Detail(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string createuser = context.Request.Params["tid"];
            string arstate = context.Request.Params["state"];
            string begin = context.Request.Params["begin"];
            string end = context.Request.Params["end"];
            //DataTable dt = asset_RepairDAL.GetList();

            context.Response.Clear();
            context.Response.Write(sb.ToString());
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